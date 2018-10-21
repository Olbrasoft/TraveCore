using System;
using Microsoft.AspNetCore.Identity;

namespace Olbrasoft.TravelCore.Data.Entity.Identity
{
    public class UserToken : IdentityUserToken<int>,IHaveDateTimeOfCreation
    {
        public DateTime DateAndTimeOfCreation { get; set; }
    }
}