namespace Logs;

public class Repository
{
    public static Write<Logs.Log> Log
    {
        get
        {
            return new Write<Logs.Log>(new LogsContext());
        }
    }

    public static Write<Logs.LogView> LogView
    {
        get
        {
            return new Write<Logs.LogView>(new LogsContext());
        }
    }
}
