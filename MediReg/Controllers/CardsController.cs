using System.Collections.Generic;
using System.Threading.Tasks;
using BLL.Services.Tables;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
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

        public async Task<IEnumerable<CardModel.ListOut>> List()
        {
            return await Service.ListAsync<CardModel.ListOut>();
        }

        /// <summary>
        /// Add Card
        /// </summary>
        /// <param name="model">card model</param>
        /// <returns>Card Id</returns>
        /// <response code="400"> Model data error </response>
        /// <response code="500"> Uncaught, unknown error </response>
        [HttpPost]
        [Route("")]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BadRequestModel), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(BadRequestModel), StatusCodes.Status500InternalServerError)]
        public async Task<int> Add(CardModel.AddIn model)
        {
            return await Service.AddAsync(model);
        }

        /// <summary>
        /// Get By Id
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns>Card Model</returns>
        /// <response code="400"> Not found </response>
        /// <response code="500"> Uncaught, unknown error </response>
        [ProducesResponseType(typeof(CardModel.ByIdOut), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BadRequestModel), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(BadRequestModel), StatusCodes.Status500InternalServerError)]
        [HttpGet]
        [Route("{id}")]
        public async Task<CardModel.ByIdOut> ById(int id)
        {
            return await Service.ByIdAsync<CardModel.ByIdOut>(id);
        }

        /// <summary>
        /// Edit card
        /// </summary>
        /// <param name="model">Card model</param>
        /// <response code="400"> Model data error </response>
        /// <response code="500"> Uncaught, unknown error </response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BadRequestModel), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(BadRequestModel), StatusCodes.Status500InternalServerError)]
        [HttpPut]
        [Route("")]
        public async Task Edit(CardModel.EditIn model)
        {
            await Service.EditAsync(model);
        }
    }
}
