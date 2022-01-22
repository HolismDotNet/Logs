namespace Logs;

public class Log : IEntity
{
    public Log()
    {
        RelatedItems = new ExpandoObject();
    }

    public long Id { get; set; }

    public DateTime UtcDate { get; set; }

    public string Text { get; set; }

    public long TypeId { get; set; }

    public dynamic RelatedItems { get; set; }
}
