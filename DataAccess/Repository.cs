using Holism.Logs.Models;
using Holism.DataAccess;

namespace Holism.Logs.DataAccess
{
    public class Repository
    {
        public static Repository<Log> Log
        {
            get
            {
                return new Holism.DataAccess.Repository<Log
                >(new LogsContext());
            }
        }

        public static Repository<LogView> LogView
        {
            get
            {
                return new Holism.DataAccess.Repository<LogView
                >(new LogsContext());
            }
        }
    }
}
