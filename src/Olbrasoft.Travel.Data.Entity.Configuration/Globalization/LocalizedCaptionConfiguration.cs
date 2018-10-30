﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Olbrasoft.Travel.Data.Entity.Globalization;

namespace Olbrasoft.Travel.Data.Entity.Configuration.Globalization
{
    public class LocalizedCaptionConfiguration : LocalizedConfiguration<LocalizedCaption>
    {
        public LocalizedCaptionConfiguration() : base("LocalizedCaptions")
        {
        }

        public override void GlobalizationConfiguration(EntityTypeBuilder<LocalizedCaption> builder)
        {
            builder.Property(localizedCaption => localizedCaption.Text).HasMaxLength(255).IsRequired();

            builder.HasOne(localizedCaption => localizedCaption.Creator).WithMany(user => user.LocalizedCaptions)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(localizedCaption => localizedCaption.Language)
                .WithMany(language => language.LocalizedCaptions).OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(localizedCaption => localizedCaption.Caption).WithMany(caption => caption.LocalizedCaptions)
                .HasForeignKey(localizedCaption => localizedCaption.Id).OnDelete(DeleteBehavior.Cascade);
        }
    }
}