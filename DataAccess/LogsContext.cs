namespace Logs;

public class LogsContext : DatabaseContext
{
    public override string ConnectionStringName => "Logs";

    public DbSet<Logs.Log> Logs { get; set; }

    public DbSet<Logs.LogView> LogViews { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
    }
}
