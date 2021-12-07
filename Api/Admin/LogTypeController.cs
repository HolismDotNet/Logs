using Holism.Api;
using Holism.Business;
using Holism.Logs.Business;
using Holism.Logs.Models;
using Microsoft.AspNetCore.Mvc;

namespace Holism.Logs.AdminApi
{
    public class LogTypeController : EnumController<Type>
    {
        public override EnumBusiness<Type> EnumBusiness => new TypeBusiness();
    }
}
