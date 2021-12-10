namespace Holism.Logs.DataAccess;

public class Repository
{
    public static Repository<Log> Log
    {
        get
        {
            return new Repository<Log>(new LogsContext());
        }
    }

    public static Repository<LogView> LogView
    {
        get
        {
            return new Repository<LogView>(new LogsContext());
        }
    }
}
