using System;
using System.Linq;
using System.Reflection;
using PostSharp.Aspects;
using SFramework.Core.CrossCuttingConcerns.Caching;

namespace SFramework.Core.Aspects.Postsharp.CacheAspects
{
    [Serializable]
    public class CacheAspect : MethodInterceptionAspect
    {

        private Type _cacheType;
        private int _cacheTimeInMinutes;
        private ICacheManager _cacheManager;

        public CacheAspect(Type cacheType, int cacheTimeInMinutes = 10)
        {
            _cacheType = cacheType;
            _cacheTimeInMinutes = cacheTimeInMinutes;
        }

        public override void RuntimeInitialize(MethodBase method)
        {
            if (typeof(ICacheManager).IsAssignableFrom(_cacheType) == false)
            {
                throw new Exception($"ICacheManager cannot be assigned from {_cacheType.Name}");
            }
            _cacheManager = (ICacheManager)Activator.CreateInstance(_cacheType);
            base.RuntimeInitialize(method);
        }

        public override void OnInvoke(MethodInterceptionArgs args)
        {
            var methodName = $"{args.Method.ReflectedType?.Namespace}.{args.Method.ReflectedType?.Name}.{args.Method.Name}";
            var arguments = args.Arguments.ToList();
            var key = $"{methodName}({string.Join(",", arguments.Select(x => x != null ? x.ToString() : "<Null>"))})";
            if (_cacheManager.IsAdded(key))
            {
                args.ReturnValue = _cacheManager.Get<object>(key);
                return;
            }
            base.OnInvoke(args);
            _cacheManager.Add(key, args.ReturnValue, _cacheTimeInMinutes);
        }
    }
}
