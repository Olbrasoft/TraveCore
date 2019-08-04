using System;

namespace Olbrasoft.Travel.Data.Base.Objects.Identity
{
    public class UserRole : Microsoft.AspNetCore.Identity.IdentityUserRole<int>, IHaveDateAndTimeOfCreation
    {
        public DateTime Created { get; set; }
    }
}