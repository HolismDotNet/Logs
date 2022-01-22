namespace Logs;

public class Repository
{
    public static Repository<Logs.Log> Log
    {
        get
        {
            return new Repository<Logs.Log>(new LogsContext());
        }
    }

    public static Repository<Logs.LogView> LogView
    {
        get
        {
            return new Repository<Logs.LogView>(new LogsContext());
        }
    }
}
