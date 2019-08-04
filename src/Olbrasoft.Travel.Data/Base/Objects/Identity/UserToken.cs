using System;
using Microsoft.AspNetCore.Identity;

namespace Olbrasoft.Travel.Data.Base.Objects.Identity
{
    public class UserToken : IdentityUserToken<int>, IHaveDateAndTimeOfCreation
    {
        public DateTime Created { get; set; }
    }
}