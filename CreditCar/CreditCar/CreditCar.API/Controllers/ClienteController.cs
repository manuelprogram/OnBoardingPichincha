using CreditCar.API.Controllers.Common;
using CreditCar.Domain.Interfaces;
using CreditCar.Entity.Models;
using CreditCar.Repository.Context;
using Microsoft.AspNetCore.Mvc;

namespace CreditCar.API.Controllers
{
    public class ClienteController : BaseController<Cliente, ClienteDto>
    {
        public ClienteController(IBaseDomain<Cliente, ClienteDto> baseDomain) : base(baseDomain) { }

        [HttpPost]
        public ActionResult UploadFileAsync([FromForm] IFormFile file)
        {
            try
            {
                string processId = Guid.NewGuid().ToString();

                return Ok(processId);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
