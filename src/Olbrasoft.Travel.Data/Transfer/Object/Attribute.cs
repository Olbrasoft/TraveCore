using Olbrasoft.Data;
using Olbrasoft.Travel.Data.Entity;

namespace Olbrasoft.Travel.Data.Transfer.Object
{
    public class Attribute : IHaveId<int>
    {
        public int TypId { get; set; }
        public int SubTypeId { get; set; }
        public string Description { get; set; }
        public string Text { get; set; }
        public int Id { get; set; }
        public bool Ban { get; set; }
    }
}