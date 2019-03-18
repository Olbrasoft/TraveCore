using System;
using Olbrasoft.Travel.Data.Base;

namespace Olbrasoft.Travel.Data.Identity
{
    public class UserRole : Microsoft.AspNetCore.Identity.IdentityUserRole<int>, IHaveDateAndTimeOfCreation
    {
        public DateTime Created { get; set; }
    }
}