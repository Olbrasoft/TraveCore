using System;
using Microsoft.AspNetCore.Identity;

namespace Olbrasoft.TravelCore.Data.Entity.Identity
{
    public class UserClaim : IdentityUserClaim<int>, IHaveDateTimeOfCreation
    {
        public DateTime DateAndTimeOfCreation { get; set; }
    }
}