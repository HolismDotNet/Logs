namespace Holism.Logs.AdminApi;

public class LogTypeController : EnumController<Models.Type>
{
    public override EnumBusiness<Models.Type> EnumBusiness => new Logs.Business.TypeBusiness();
}
