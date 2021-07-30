using System.Threading.Tasks;
using BLL.Services.Tables;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.Tables;

namespace API.Controllers
{
    [Route("api/Topics")]
    public class TopicsController : BaseController
    {
        private TopicService Service { get; }

        public TopicsController(TopicService service)
        {
            Service = service;
        }

        /// <summary>
        /// Get topic by Id
        /// </summary>
        /// <param name="id">Topic Id</param>
        /// <returns>Topic model</returns>
        /// <response code="400"> Not found </response>
        /// <response code="500"> Uncaught, unknown error </response>
        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(TopicModel.ByIdOut), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BadRequestModel), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(BadRequestModel), StatusCodes.Status500InternalServerError)]
        public async Task<TopicModel.ByIdOut> ById(int id)
        {
            return await Service.ByIdAsync<TopicModel.ByIdOut>(id);
        }

        /// <summary>
        /// Create new topic with no cards
        /// </summary>
        /// <param name="model">Topic model</param>
        /// <returns>Topic Id</returns>
        /// <response code="400"> Model data error </response>
        /// <response code="500"> Uncaught, unknown error </response>
        [HttpPost]
        [Route("")]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BadRequestModel), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(BadRequestModel), StatusCodes.Status500InternalServerError)]
        public async Task<int> Add(TopicModel.AddIn model)
        {
            return await Service.AddAsync(model);
        }
    }
}
