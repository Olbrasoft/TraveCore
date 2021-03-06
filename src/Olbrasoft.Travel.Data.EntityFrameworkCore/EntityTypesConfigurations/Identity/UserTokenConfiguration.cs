﻿using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Olbrasoft.Travel.Data.Identity;

namespace Olbrasoft.Travel.Data.EntityFrameworkCore.EntityTypesConfigurations.Identity
{
    public class UserTokenConfiguration : TravelTypeConfiguration<UserToken>
    {
        public UserTokenConfiguration() : base("UsersTokens")
        {
        }

        public override void Configuration(EntityTypeBuilder<UserToken> builder)
        {
            builder.HasKey(userToken => new { userToken.UserId, userToken.LoginProvider, userToken.Name });
        }
    }
}