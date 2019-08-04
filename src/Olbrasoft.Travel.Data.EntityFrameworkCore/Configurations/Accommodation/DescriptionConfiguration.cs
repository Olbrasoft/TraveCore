using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Olbrasoft.Travel.Data.Base.Objects.Accommodation;

namespace Olbrasoft.Travel.Data.EntityFrameworkCore.Configurations.Accommodation
{
    public class DescriptionConfiguration : NameAccommodationTypeConfiguration<Description>
    {
        public override void NameConfigure(EntityTypeBuilder<Description> builder)
        {
            //builder.HasIndex(p => p.Name).IsUnique();

            builder.HasOne(tod => tod.Creator).WithMany(user => user.Descriptions)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}