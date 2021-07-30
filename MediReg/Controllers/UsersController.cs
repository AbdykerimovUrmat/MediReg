using BLL.Services.Tables;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.Tables;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/Users")]
    public class UsersController : BaseController
    {
        private UserService Service { get; }

        public UsersController(UserService userService) 
        {
            Service = userService;
        }

        /// <summary>
        /// Registers new user
        /// </summary>
        /// <param name="model"> New user model </param>
        /// <returns> string Id of registered account </returns>
        /// <response code="400"> Model data error </response>
        /// <response code="500"> Uncaught, unknown error </response>
        [HttpPost]
        [Route("")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BadRequestModel), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(BadRequestModel), StatusCodes.Status500InternalServerError)]
        public async Task<string> Register(UserModel.AddIn model)
        {
            return await Service.RegisterAsync(model);
        }

        /// <summary>
        /// List of all users
        /// </summary>
        /// <response code="500"> Uncaught, unknown error </response>
        [HttpGet]
        [Route("List")]
        [ProducesResponseType(typeof(IEnumerable<UserModel.ListOut>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BadRequestModel), StatusCodes.Status500InternalServerError)]
        public async Task<IEnumerable<UserModel.ListOut>> ListAsync()
        {
            return await Service.List<UserModel.ListOut>();
        }

        /// <summary>
        /// Get user by Id
        /// </summary>
        /// <param name="id"> Id of user </param>
        /// <returns> user model </returns>
        /// <response code="400"> Not found </response>
        /// <response code="500"> Uncaught, unknown error </response>
        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(UserModel.ByIdOut), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BadRequestModel), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(BadRequestModel), StatusCodes.Status500InternalServerError)]
        public async Task<UserModel.ByIdOut> ById(string id)
        {
            return await Service.GetById<UserModel.ByIdOut>(id);
        }

        /// <summary>
        /// Edits user
        /// </summary>
        /// <param name="id"> Id of user </param>
        /// <param name="model"> user model </param>
        /// <response code="400"> Model data error, not found </response>
        /// <response code="500"> Uncaught, unknown error </response>
        [HttpPut]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BadRequestModel), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(BadRequestModel), StatusCodes.Status500InternalServerError)]
        public async Task EditUser(string id, UserModel.EditIn model)
        {
            await Service.Edit(id, model);
        }
    }
}
