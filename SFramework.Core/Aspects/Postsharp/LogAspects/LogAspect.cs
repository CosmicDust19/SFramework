using System;
using System.Linq;
using System.Reflection;
using PostSharp.Aspects;
using PostSharp.Extensibility;
using SFramework.Core.CrossCuttingConcerns.Logging;
using SFramework.Core.CrossCuttingConcerns.Logging.Log4Net;

namespace SFramework.Core.Aspects.Postsharp.LogAspects
{
    [Serializable]
    [MulticastAttributeUsage(MulticastTargets.Method, TargetMemberAttributes = MulticastAttributes.Instance)]
    public class LogAspect:OnMethodBoundaryAspect
    {
        [NonSerialized]
        private LoggerService _loggerService;

        private Type _loggerType;

        public LogAspect(Type loggerType)
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

        public override void OnEntry(MethodExecutionArgs args)
        {
            if (!_loggerService.IsInfoEnabled)
            {
                return;
            }

            try
            {
                var logParameters = args.Method.GetParameters().Select((t, index) => new LogParameter
                {
                    Name = t.Name,
                    Type = t.ParameterType.Name,
                    Value = args.Arguments.GetArgument(index)
                }).ToList();

                var logDetail = new LogDetail
                {
                    FullName = args.Method.DeclaringType?.Name,
                    MethodName = args.Method.Name,
                    Parameters = logParameters
                };

                _loggerService.Info(logDetail);
            }
            catch (Exception)
            {
                // ignored
            }
        }

    }
}
