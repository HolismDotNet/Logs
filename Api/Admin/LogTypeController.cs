namespace Logs;

public class LogTypeController : EnumController<Logs.Type>
{
    public override EnumBusiness<Logs.Type> EnumBusiness => new Logs.TypeBusiness();
}
