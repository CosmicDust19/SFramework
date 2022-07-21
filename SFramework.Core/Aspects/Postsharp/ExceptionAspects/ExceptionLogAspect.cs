using System;
using System.Reflection;
using PostSharp.Aspects;
using PostSharp.Extensibility;
using SFramework.Core.CrossCuttingConcerns.Logging.Log4Net;

namespace SFramework.Core.Aspects.Postsharp.ExceptionAspects
{
    [Serializable]
    [MulticastAttributeUsage(MulticastTargets.Method, TargetMemberAttributes = MulticastAttributes.Instance)]
    public class ExceptionLogAspect:OnExceptionAspect
    {
        
        [NonSerialized]
        private LoggerService _loggerService;

        private readonly Type _loggerType;

        public ExceptionLogAspect(Type loggerType = null)
        {
            _loggerType = loggerType;
        }

        public override void RuntimeInitialize(MethodBase method)
        {
            if (_loggerType != null) 
            {
                if (_loggerType.BaseType != typeof(LoggerService))
                {
                    throw new Exception("LoggerType is not inherited from LoggerService");
                }
                _loggerService = (LoggerService)Activator.CreateInstance(_loggerType);
            }
            base.RuntimeInitialize(method);
        }

        public override void OnException(MethodExecutionArgs args)
        {
            _loggerService?.Error(args.Exception);
        }
    }
}
