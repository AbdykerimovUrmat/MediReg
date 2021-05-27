using System.Threading.Tasks;
using BLL.Services.Tables;
using Microsoft.AspNetCore.Mvc;
using Models.Tables;

namespace API.Controllers
{
    [Route("api/Cards")]
    public class CardsController : BaseController
    {
        private CardService Service { get; }

        public CardsController(CardService service)
        {
            Service = service;
        }

        /// <summary>
        /// Add Card
        /// </summary>
        /// <param name="model">card model</param>
        /// <returns>Card Id</returns>
        [HttpPost]
        [Route("")]
        public async Task<int> Add(CardModel.Add model)
        {
            return await Service.Add(model);
        }

        /// <summary>
        /// Get By Id
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns>Card Model</returns>
        [HttpGet]
        [Route("{id}")]
        public async Task<CardModel.Get> Get(int id)
        {
            return await Service.ById<CardModel.Get>(id);
        }

        /// <summary>
        /// Edit card
        /// </summary>
        /// <param name="model">Card model</param>
        /// <returns></returns>
        [HttpPut]
        [Route("")]
        public async Task Edit(CardModel.Edit model)
        {
            await Service.Edit(model);
        }
    }
}
