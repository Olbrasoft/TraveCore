using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace Olbrasoft.Travel.Data.Base.Objects.Identity
{
    [Table("UsersClaims",Schema =nameof(Identity))]
    public class UserClaim : IdentityUserClaim<int>, IHaveDateAndTimeOfCreation
    {
        public DateTime Created { get; set; }
    }
}