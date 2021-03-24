using Common.Interfaces;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace DAL.Entities
{
    public class User : IdentityUser, IIdHas<string>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public virtual ICollection<UserRole> Roles { get; set; }
    }
}
