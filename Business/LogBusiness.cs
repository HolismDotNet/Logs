using System;
using System.Linq.Expressions;
using Holism.Business;
using Holism.DataAccess;
using Holism.Infra;
using Holism.Logs.DataAccess;
using Holism.Logs.Models;
using Humanizer;

namespace Holism.Logs.Business
{
    public class LogBusiness : Business<LogView, Log>
    {
        protected override Repository<Log> WriteRepository => Repository.Log;

        protected override ReadRepository<LogView> ReadRepository => Repository.LogView;

        protected override Func<Sort> DefaultSort => () => new Sort
        {
            Property = nameof(Log.Id),
            Direction = SortDirection.Descending
        };

        public static void Persist(dynamic @object, MessageType messageType)
        {
            var log = new Log();
            log.UtcDate = UniversalDateTime.Now;
            if (@object.GetType().Name == "String")
            {
                log.Text = (string)@object;
            }
            else 
            {
                log.Text = @object.Serialize();
            }
            log.LogTypeId = (int)GetType(messageType);
            new LogBusiness().Create(log);
        }

        private static LogType GetType(MessageType messageType)
        {
            var type = messageType.ToString().ToEnum<LogType>();
            return type;
        }

        public void Empty()
        {
            WriteRepository.Run("truncate table Logs");
        }

        public void CreateTestLogs()
        {
            Logger.LogSuccess("This is a test log for success");
            Logger.LogInfo("This is a test log for info");
            Logger.LogWarning("This is a test log for warning");
            Logger.LogError("This is a test log for error");
            throw new ServerException("This is a test exception for testing logs");
        }
    }
}
