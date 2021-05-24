using Common.Enums;
using System;

namespace Models.Tables
{
    public abstract class UserModel
    {
        public class Base
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

        public class Add : Base
        {
            /// <summary>
            /// Пароль
            /// </summary>
            public string Password { get; set; }
        }

        public class Edit : Base { }

        public class Get : Base { }
    }
}
