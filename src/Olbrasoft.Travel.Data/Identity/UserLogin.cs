using System;
using Olbrasoft.Travel.Data.Base;

namespace Olbrasoft.Travel.Data.Identity
{
    public class UserLogin : Microsoft.AspNetCore.Identity.IdentityUserLogin<int>, IHaveDateAndTimeOfCreation
    {
        public DateTime Created { get; set; }
    }
}