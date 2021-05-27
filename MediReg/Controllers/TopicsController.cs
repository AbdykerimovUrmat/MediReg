
using BLL.Services.Tables;
using Microsoft.AspNetCore.Mvc;
using Models.Tables;
using System.Threading.Tasks;

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
        [HttpGet]
        [Route("{id}")]
        public async Task<TopicModel.Get> Get(int id)
        {
            return await Service.ById<TopicModel.Get>(id);
        }

        /// <summary>
        /// Create new topic with no cards
        /// </summary>
        /// <param name="model">Topic model</param>
        /// <returns>Topic Id</returns>
        [HttpPost]
        [Route("")]
        public async Task<int> Add(TopicModel.Add model)
        {
            return await Service.Add(model);
        }
    }
}
