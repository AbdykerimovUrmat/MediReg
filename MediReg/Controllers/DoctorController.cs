using System.Collections.Generic;
using Common.Enums;
using API.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Tables;
using System.Threading.Tasks;
using BLL.Services.Tables;

namespace API.Controllers
{
    [Route("api/Doctor")]
    [AuthorizeRoles(RoleType.Admin)]
    public class DoctorController : BaseController
    {
        DoctorService DoctorService { get; }

        public DoctorController(DoctorService doctorService)
        {
            DoctorService = doctorService;
        }

        /// <summary>
        /// Добавить Админа
        /// </summary>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task CreateDoctor(DoctorModel.Base model)
        {
            await DoctorService.Add(model, model.Password);
        }
    }
}
