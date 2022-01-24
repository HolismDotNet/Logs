namespace Logs;

public class TypeBusiness : EnumBusiness<Logs.Type>
{
    public override string ConnectionString => Repository.Log.ConnectionString;
}
