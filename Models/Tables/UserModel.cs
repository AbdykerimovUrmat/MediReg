using Common.Enums;
using System;

namespace Models.Tables
{
    public class UserModel
    {
        /// <summary>
        /// Логин
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Пароль
        /// </summary>
        public string Password { get; set; }

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
        /// Телефон
        /// </summary>
        public string PhoneNumber { get; set; }
    }
}
