using BLL.Services.Tables;
using Microsoft.AspNetCore.Mvc;
using Models.Tables;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/User")]
    public class UserController : BaseController
    {
        private UserService Service { get; }

        public UserController(UserService userService) 
        {
            Service = userService;
        }

        /// <summary>
        /// Registers new user
        /// </summary>
        /// <param name="model">New user model</param>
        /// <returns>string Id of registered account</returns>
        [HttpPost]
        [Route("")]
        public async Task<string> Register(UserModel.Add model)
        {
            return await Service.RegisterAsync(model);
        }

        /// <summary>
        /// Get user by Id
        /// </summary>
        /// <param name="id">Id of user</param>
        /// <returns>user model</returns>
        [HttpGet]
        [Route("{id}")]
        public async Task<UserModel.Get> GetById(string id)
        {
            return await Service.GetById<UserModel.Get>(id);
        }

        /// <summary>
        /// Edits user
        /// </summary>
        /// <param name="id">Id of user</param>
        /// <param name="model">user model</param>
        [HttpPut]
        [Route("{id}")]
        public async Task EditUser(string id, UserModel.Edit model)
        {
            await Service.Edit(id, model);
        }
    }
}
