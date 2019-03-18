using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using Olbrasoft.Travel.Data.Base;

namespace Olbrasoft.Travel.Data.Identity
{
    [Table("RolesClaims", Schema =nameof(Identity))]
    public class RoleClaim : IdentityRoleClaim<int>,IHaveDateAndTimeOfCreation
    {
        public DateTime Created { get; set; }
    }
}