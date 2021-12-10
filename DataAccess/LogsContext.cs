namespace Holism.Logs.DataAccess;

public class LogsContext : DatabaseContext
{
    public override string ConnectionStringName => "Logs";

    public DbSet<Log> Logs { get; set; }

    public DbSet<LogView> LogViews { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
    }
}
