using System;

namespace Olbrasoft.TravelCore.Data.Entity.Identity
{
    public class Role : Microsoft.AspNetCore.Identity.IdentityRole<int>, IHaveDateTimeOfCreation
    {
        public DateTime DateAndTimeOfCreation { get; set; }
    }
}