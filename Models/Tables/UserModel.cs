using Common.Enums;
using Common.Interfaces;
using System;

namespace Models.Tables
{
    public abstract class UserModel
    {
        public class AddIn
        {
            /// <summary>
            /// Логин
            /// </summary>
            public string UserName { get; set; }

            /// <summary>
            /// Имя
            /// </summary>
            public string FirstName { get; set; }

            /// <summary>
            /// Фамилия
            /// </summary>
            public string LastName { get; set; }

            /// <summary>
            /// Обо мне
            /// </summary>
            public string AboutMe { get; set; }

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

            /// <summary>
            /// Пароль
            /// </summary>
            public string Password { get; set; }
        }

        public class EditIn
        {
            /// <summary>
            /// Логин
            /// </summary>
            public string UserName { get; set; }

            /// <summary>
            /// Имя
            /// </summary>
            public string FirstName { get; set; }

            /// <summary>
            /// Фамилия
            /// </summary>
            public string LastName { get; set; }

            /// <summary>
            /// Обо мне
            /// </summary>
            public string AboutMe { get; set; }

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

        public class ByIdOut : IIdHas<string>
        {
            /// <summary>
            /// Логин
            /// </summary>
            public string UserName { get; set; }

            /// <summary>
            /// Имя
            /// </summary>
            public string FirstName { get; set; }

            /// <summary>
            /// Фамилия
            /// </summary>
            public string LastName { get; set; }

            /// <summary>
            /// Обо мне
            /// </summary>
            public string AboutMe { get; set; }

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

            /// <summary>
            /// Код
            /// </summary>
            public string Id { get; set; }
        }

        public class ListOut : IIdHas<string>
        {
            /// <summary>
            /// Логин
            /// </summary>
            public string UserName { get; set; }

            /// <summary>
            /// Имя
            /// </summary>
            public string FirstName { get; set; }

            /// <summary>
            /// Фамилия
            /// </summary>
            public string LastName { get; set; }

            /// <summary>
            /// Обо мне
            /// </summary>
            public string AboutMe { get; set; }

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

            /// <summary>
            /// Код
            /// </summary>
            public string Id { get; set; }
        }
    }
}
