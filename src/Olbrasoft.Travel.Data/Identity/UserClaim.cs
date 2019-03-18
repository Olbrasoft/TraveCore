using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using Olbrasoft.Travel.Data.Base;

namespace Olbrasoft.Travel.Data.Identity
{
    [Table("UsersClaims",Schema =nameof(Identity))]
    public class UserClaim : IdentityUserClaim<int>, IHaveDateAndTimeOfCreation
    {
        public DateTime Created { get; set; }
    }
}