namespace Logs;

public class LogBusiness : Business<LogView, Log>
{
    protected override Write<Log> Write => Repository.Log;

    protected override Read<LogView> Read => Repository.LogView;

    public static bool TypesInitialDataExists = false;

    protected override Func<Sort> DefaultSort => () => new Sort
    {
        Property = nameof(Log.Id),
        Direction = SortDirection.Descending
    };

    public static void Persist(dynamic @object, MessageType messageType)
    {
        if (!TypesInitialDataExists)
        {
            CheckExistenceOfLogTypes();
        }
        if (TypesInitialDataExists)
        {
            var log = new Log();
            log.UtcDate = UniversalDateTime.Now;
            if (@object.GetType().Name == "String")
            {
                log.Text = (string)@object;
            }
            else
            {
                try
                {
                    log.Text = @object.Serialize();
                }
                catch (Exception ex)
                {
                    var message = ExceptionHelper.BuildExceptionString(ex);
                    log.Text = message; 
                }
            }
            log.TypeId = (int)GetType(messageType);
            new LogBusiness().Create(log);
        }
    }

    private static Logs.Type GetType(MessageType messageType)
    {
        var type = messageType.ToString().ToEnum<Logs.Type>();
        return type;
    }

    protected static void CheckExistenceOfLogTypes()
    {
        var logTypes = new Logs.TypeBusiness().GetAll();
        if (logTypes.Count > 0)
        {
            TypesInitialDataExists = true;
        }
    }

    public void Empty()
    {
        Write.Run("truncate table Logs");
    }

    public void CreateTestLogs()
    {
        Logger.LogSuccess("This is a test log for success");
        Logger.LogInfo("This is a test log for info");
        Logger.LogWarning("This is a test log for warning");
        Logger.LogError("This is a test log for error");
        throw new ServerException("This is a test exception for testing logs");
    }
}
