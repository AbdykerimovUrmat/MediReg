using System.Collections.Generic;
using Common.Enums;
using API.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/Test")]
    public class TestController : BaseController
    {
        /// <summary>
        /// Тестовый Get метод
        /// </summary>
        
        [HttpGet]
        [Route("List")]
        [ProducesResponseType(typeof(IEnumerable<int>), StatusCodes.Status200OK)]

        public IEnumerable<int> TestGet()
        {
            return new List<int> { 1, 2, 3 };
        }
    }
}
