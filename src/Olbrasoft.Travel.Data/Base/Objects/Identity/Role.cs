using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Olbrasoft.Travel.Data.Base.Objects.Identity
{
    [Table(nameof(Role)+"s",Schema =nameof(Identity))]
    public class Role : Microsoft.AspNetCore.Identity.IdentityRole<int>, IHaveDateAndTimeOfCreation
    {
       // public virtual ICollection<User> Users { get; set; }
        public DateTime Created { get; set; }
    }
}