using log4net;

namespace SFramework.Core.CrossCuttingConcerns.Logging.Log4Net.Loggers
{
    public class FileLogger:LoggerService
    {
        public FileLogger() : base(LogManager.GetLogger("JsonFileLogger"))
        {
        }
    }
}
