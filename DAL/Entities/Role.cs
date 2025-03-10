﻿using System.Collections.Generic;
using Common.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace DAL.Entities
{
    public class Role : IdentityRole
    {
        public virtual ICollection<UserRole> Users { get; set; }
    }
}
