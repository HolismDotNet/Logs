namespace Holism.Logs.AdminApi;

public class LogTypeController : EnumController<LogType>
{
    public override EnumBusiness<LogType> EnumBusiness => new LogTypeBusiness();
}
