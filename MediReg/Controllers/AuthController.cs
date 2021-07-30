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
        /// <response code="400"> Model data error </response>
        /// <response code="500"> Uncaught, unknown error </response>
        [HttpPost]
        [Route("Login")]
        [ProducesResponseType(typeof(AuthModel.Response), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BadRequestModel), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(BadRequestModel), StatusCodes.Status500InternalServerError)]
        public async Task<AuthModel.Response> Login(AuthModel.Login model)
        {
            return await AuthService.AccessToken(model);
        }
    }
}
