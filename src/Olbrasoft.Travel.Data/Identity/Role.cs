using System;
using System.ComponentModel.DataAnnotations.Schema;
using Olbrasoft.Travel.Data.Base;

namespace Olbrasoft.Travel.Data.Identity
{
    [Table(nameof(Role)+"s",Schema =nameof(Identity))]
    public class Role : Microsoft.AspNetCore.Identity.IdentityRole<int>, IHaveDateAndTimeOfCreation
    {
       // public virtual ICollection<User> Users { get; set; }
        public DateTime Created { get; set; }
    }
}