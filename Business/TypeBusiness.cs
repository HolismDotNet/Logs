using Holism.Logs.DataAccess;
using Holism.Logs.Models;

namespace Holism.Logs.Business;

public class TypeBusiness : EnumBusiness<Models.Type>
{
    public override string ConnectionString => Repository.Log.ConnectionString;
}
