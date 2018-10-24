using System;

namespace Olbrasoft.Travel.Data.Entity.Identity
{
    public class Membership : Microsoft.AspNetCore.Identity.IdentityUserRole<int> ,IHaveDateTimeOfCreation
    {
        public DateTime DateAndTimeOfCreation { get; set; }
    }
}