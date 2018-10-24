using System;

namespace Olbrasoft.Travel.Data.Entity.Identity
{
    public class Role : Microsoft.AspNetCore.Identity.IdentityRole<int>, IHaveDateTimeOfCreation
    {

       // public virtual ICollection<User> Users { get; set; }
        public DateTime DateAndTimeOfCreation { get; set; }
    }
}