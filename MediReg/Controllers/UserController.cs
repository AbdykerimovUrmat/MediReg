using BLL.Services.Tables;
using Microsoft.AspNetCore.Mvc;
using Models.Tables;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/User")]
    public class UserController : BaseController
    {
        private UserService UserService { get; }

        public UserController(UserService userService) 
        {
            UserService = userService;
        }

        /// <summary>
        /// Registers new Account
        /// </summary>
        /// <param name="model">New user model</param>
        /// <returns>string Id of registered account</returns>
        [HttpPost]
        [Route("")]
        public async Task<string> Register(UserModel model)
        {
            return await UserService.RegisterAsync(model);
        }
    }
}
