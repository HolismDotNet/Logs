using Holism.Business;
using Holism.DataAccess;
using Holism.Logs.DataAccess;
using Holism.Logs.Models;
using System;

namespace Holism.Logs.Business
{
    public class LogBusiness : Business<Log, Log>
    {
        protected override Repository<Log> WriteRepository => Repository.Log;

        protected override ReadRepository<Log> ReadRepository => Repository.Log;
    }
}
