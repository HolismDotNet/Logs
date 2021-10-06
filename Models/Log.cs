using System;

namespace Holism.Logs.Models
{
    public class Log : Holism.Models.IEntity
    {
        public Log()
        {
            RelatedItems = new System.Dynamic.ExpandoObject();
        }

        public long Id { get; set; }

        public DateTime Date { get; set; }

        public string Text { get; set; }

        public long TypeId { get; set; }

        public dynamic RelatedItems { get; set; }
    }
}
