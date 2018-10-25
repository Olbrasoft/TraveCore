using System.Collections.Generic;

namespace Olbrasoft.Travel.Data.Entity
{
    public class LogLevel : OwnerCreatorIdAndCreator, IHaveName, IHaveDescription
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Log> Logs { get; set; }
    }
}