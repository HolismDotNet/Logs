using Holism.Logs.DataAccess;
using Holism.Logs.Models;

namespace Holism.Logs.Business;

public class LogTypeBusiness : EnumBusiness<LogType>
{
    public override string ConnectionString => Repository.Log.ConnectionString;
}
