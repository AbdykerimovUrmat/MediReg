using System;
using System.Threading.Tasks;
using API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace API.Controllers
{
    [Route("api/Token")]
    public class AuthController : BaseController
    {
        private AuthService AuthService { get; }

        public AuthController(AuthService authService) 
        {
            AuthService = authService;
        }

        /// <summary>
        /// Получение токенов по логину и паролю
        /// </summary>
        /// <param name="model">Логин и пароль</param>
        [HttpPost]
        [Route("Access")]
        [ProducesResponseType(typeof(AuthModel.Response), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Exception), StatusCodes.Status500InternalServerError)]
        public async Task<AuthModel.Response> Auth(AuthModel.Login model)
        {
            return await AuthService.AccessToken(model);
        }
    }
}
