using System;
using System.Collections.Generic;
using Common.Enums;
using Common.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace DAL.Entities
{
    public class User : IdentityUser, IIdHas<string>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime BirthDate { get; set; }

        public GenderType Gender { get; set; }

        public virtual IEnumerable<UserRole> Roles { get; set; }

        public virtual IEnumerable<Vacancy> Vacancies { get; set; }
    }
}
