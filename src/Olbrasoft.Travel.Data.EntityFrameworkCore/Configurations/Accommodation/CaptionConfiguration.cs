using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Olbrasoft.Travel.Data.Base.Objects.Accommodation;

namespace Olbrasoft.Travel.Data.EntityFrameworkCore.Configurations.Accommodation
{
    public class CaptionConfiguration : TravelTypeConfiguration<Caption>
    {
        public override void Configuration(EntityTypeBuilder<Caption> builder)
        {
            builder.Property(caption => caption.Id).ValueGeneratedNever();
        }
    }
}