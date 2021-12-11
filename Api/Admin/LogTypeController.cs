namespace Holism.Logs.AdminApi;

public class LogTypeController : EnumController<Type>
{
    public override EnumBusiness<Type> EnumBusiness => new TypeBusiness();
}
