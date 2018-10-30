using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Olbrasoft.Travel.Data.Entity.Property;

namespace Olbrasoft.Travel.Data.Entity.Configuration.Property
{
    public class CaptionConfiguration : PropertyConfiguration<Caption>
    {
        public CaptionConfiguration() : base("Captions")
        {
        }

        public override void Configuration(EntityTypeBuilder<Caption> builder)
        {
            builder.Property(caption => caption.Id).ValueGeneratedNever();
        }
    }
}