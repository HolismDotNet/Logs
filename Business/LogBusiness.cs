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

        protected override Expression<Func<LogView, object>>
        DefaultDescendingSortProperty => i => i.Id;

        public static void Persist(dynamic @object, MessageType messageType)
        {
            var log = new Log();
            log.Date = DateTime.Now;
            if (@object.GetType().Name == "String")
            {
                log.Text = (string)@object;
            }
            else 
            {
                log.Text = @object.Serialize();
            }
            log.TypeId = (int)GetType(messageType);
            new LogBusiness().Create(log);
        }

        private static Holism.Logs.Models.Type GetType(MessageType messageType)
        {
            var type = messageType.ToString().ToEnum<Holism.Logs.Models.Type>();
            return type;
        }

        public void Empty()
        {
            WriteRepository.Run("truncate table Logs");
        }
    }
}
