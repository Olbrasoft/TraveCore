namespace ConsoleApp1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class RegionsToSubclasses
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int RegionId { get; set; }

        public int SubclassId { get; set; }

        public virtual Regions Regions { get; set; }

        public virtual Subclasses Subclasses { get; set; }
    }
}
