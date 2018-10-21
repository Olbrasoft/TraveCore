using System;

namespace Olbrasoft.TravelCore.Data.Entity.Identity
{
    public class Membership : Microsoft.AspNetCore.Identity.IdentityUserRole<int> ,IHaveDateTimeOfCreation
    {
        
        public DateTime DateAndTimeOfCreation { get; set; }
    }
}