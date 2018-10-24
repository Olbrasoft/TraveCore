using System;

namespace Olbrasoft.Travel.Data.Entity.Identity
{
    public class UserLogin : Microsoft.AspNetCore.Identity.IdentityUserLogin<int>, IHaveDateTimeOfCreation
    {
        public DateTime DateAndTimeOfCreation { get; set; }
    }
}