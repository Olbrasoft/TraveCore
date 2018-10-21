using System;

namespace Olbrasoft.TravelCore.Data.Entity.Identity
{
    public class UserLogin : Microsoft.AspNetCore.Identity.IdentityUserLogin<int>, IHaveDateTimeOfCreation
    {
        public DateTime DateAndTimeOfCreation { get; set; }
    }
}