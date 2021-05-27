using System;
using System.Collections.Generic;
using Common.Enums;
using Common.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace DAL.Entities
{
    public class User : IdentityUser, IIdHas<string>
    {
        /// <summary>
        /// Имя
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Фамилия
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Дата рождения
        /// </summary>
        public DateTime BirthDate { get; set; }

        /// <summary>
        /// Гендер
        /// </summary>
        public GenderType Gender { get; set; }

        /// <summary>
        /// Обо мне
        /// </summary>
        public string AboutMe { get; set; }

        /// <summary>
        /// Юзер роли
        /// </summary>
        public virtual IEnumerable<UserRole> Roles { get; set; }

        /// <summary>
        /// Карты
        /// </summary>
        public virtual IEnumerable<Card> Cards { get; set; }
    }
}
