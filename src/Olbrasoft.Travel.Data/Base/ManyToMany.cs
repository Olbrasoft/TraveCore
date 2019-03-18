using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Olbrasoft.Travel.Data.Base
{
    public class ManyToMany : OwnerCreatorIdAndCreator
    {
        [Key]
        [Column(Order = 2)]
        public int ToId { get; set; }
    }
}