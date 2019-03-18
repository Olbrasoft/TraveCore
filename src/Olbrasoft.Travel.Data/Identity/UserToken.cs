using System;
using Microsoft.AspNetCore.Identity;
using Olbrasoft.Travel.Data.Base;

namespace Olbrasoft.Travel.Data.Identity
{
    public class UserToken : IdentityUserToken<int>, IHaveDateAndTimeOfCreation
    {
        public DateTime Created { get; set; }
    }
}