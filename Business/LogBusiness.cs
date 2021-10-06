using Holism.Infra;
using Holism.Business;
using Holism.DataAccess;
using Holism.Logs.DataAccess;
using Holism.Logs.Models;

namespace Holism.Logs.Business
{
    public class LogBusiness : Business<Log, Log>
    {
        protected override Repository<Log> WriteRepository => Repository.Log;

        protected override ReadRepository<Log> ReadRepository => Repository.Log;

        public static void Persist(dynamic @object, MessageType messageType)
        {
            var log = new Log();
            log.Date = System.DateTime.Now;
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

        private static Type GetType(MessageType messageType)
        {
            var type = messageType.ToString().ToEnum<Type>();
            return type;
        }
    }
}
