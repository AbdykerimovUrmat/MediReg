namespace Models
{
    public static class AuthModel
    {
        public class JwtSettings
        {
            public string Key { get; set; }

            public string Issuer { get; set; }

            public string Audience { get; set; }

            public int AccessTokenLifeTimeInMinutes { get; set; }

            public int RefreshTokenLifeTimeInMinutes { get; set; }
        }

        public class Login
        {
            /// <summary>
            /// Имя пользователя
            /// </summary>
            public string UserName { get; set; }

            /// <summary>
            /// Пароль
            /// </summary>
            public string Password { get; set; }
        }

        public class Response
        {
            /// <summary>
            /// Токен доступа
            /// </summary>
            public string AccessToken { get; set; }


        }
    }
}
