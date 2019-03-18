namespace ConsoleApp1
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<Regions> Regions { get; set; }
        public virtual DbSet<RegionsToSubclasses> RegionsToSubclasses { get; set; }
        public virtual DbSet<Subclasses> Subclasses { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RegionsToSubclasses>()
                .HasOptional(e => e.Regions)
                .WithRequired(e => e.RegionsToSubclasses);

            modelBuilder.Entity<Subclasses>()
                .HasMany(e => e.RegionsToSubclasses)
                .WithRequired(e => e.Subclasses)
                .HasForeignKey(e => e.SubclassId)
                .WillCascadeOnDelete(false);
        }
    }
}
