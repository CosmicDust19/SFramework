using System;
using System.Reflection;
using PostSharp.Aspects;
using SFramework.Core.CrossCuttingConcerns.Caching;

namespace SFramework.Core.Aspects.Postsharp.CacheAspects
{
    [Serializable]
    public class CacheRemoveAspect:OnMethodBoundaryAspect
    {
        private string _pattern;
        private Type _cacheType;
        private ICacheManager _cacheManager;

        public CacheRemoveAspect(Type cacheType, string pattern)
        {
            _cacheType = cacheType;
            _pattern = pattern;
        }

        public CacheRemoveAspect(Type cacheType)
        {
            _cacheType = cacheType;
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

        public override void OnSuccess(MethodExecutionArgs args)
        {
            _cacheManager.RemoveByPattern(string.IsNullOrEmpty(_pattern)
                ? $"{args.Method.ReflectedType?.Namespace}.{args.Method.ReflectedType?.Name}.*" : _pattern);
        }
    }
}
