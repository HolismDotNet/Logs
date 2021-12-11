namespace Holism.AdminApi.Controllers;

public class LogController : Controller<LogView, Log>
{
    public override ReadBusiness<LogView> ReadBusiness => new LogBusiness();
    
    public override Business<LogView, Log> Business => new LogBusiness();

    [HttpPost]
    public IActionResult Empty()
    {
        new LogBusiness().Empty();
        return OkJson();
    }

    [HttpPost]
    public IActionResult CreateTestLogs()
    {
        new LogBusiness().CreateTestLogs();
        return OkJson();
    }
}
