namespace Holism.Logs.Models;

public class LogView : IEntity
{
    public LogView()
    {
        RelatedItems = new ExpandoObject();
    }

    public long Id { get; set; }

    public DateTime UtcDate { get; set; }

    public string Text { get; set; }

    public long LogTypeId { get; set; }

    public string TypeKey { get; set; }

    public dynamic RelatedItems { get; set; }
}
