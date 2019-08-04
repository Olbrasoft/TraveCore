using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace Olbrasoft.Travel.Data.Base.Objects.Identity
{
    [Table("RolesClaims", Schema =nameof(Identity))]
    public class RoleClaim : IdentityRoleClaim<int>,IHaveDateAndTimeOfCreation
    {
        public DateTime Created { get; set; }
    }
}