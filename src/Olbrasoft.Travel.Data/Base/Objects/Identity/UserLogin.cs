using System;

namespace Olbrasoft.Travel.Data.Base.Objects.Identity
{
    public class UserLogin : Microsoft.AspNetCore.Identity.IdentityUserLogin<int>, IHaveDateAndTimeOfCreation
    {
        public DateTime Created { get; set; }
    }
}