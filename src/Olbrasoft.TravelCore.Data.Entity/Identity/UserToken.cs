using Microsoft.AspNetCore.Identity;
using System;

namespace Olbrasoft.TravelCore.Data.Entity.Identity
{
    public class UserToken : IdentityUserToken<int>, IHaveDateTimeOfCreation
    {
        public DateTime DateAndTimeOfCreation { get; set; }
    }
}