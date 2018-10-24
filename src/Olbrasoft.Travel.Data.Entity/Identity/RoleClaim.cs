using System;
using Microsoft.AspNetCore.Identity;

namespace Olbrasoft.Travel.Data.Entity.Identity
{
    public class RoleClaim : IdentityRoleClaim<int>,IHaveDateTimeOfCreation
    {
        public DateTime DateAndTimeOfCreation { get; set; }
    }
}