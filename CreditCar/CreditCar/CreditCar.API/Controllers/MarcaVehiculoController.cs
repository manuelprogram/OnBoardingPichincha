using CreditCar.API.Controllers.Common;
using CreditCar.Domain.Interfaces;
using CreditCar.Entity.Models;
using CreditCar.Entity.Utilities;
using CreditCar.Repository.Context;
using Microsoft.AspNetCore.Mvc;

namespace CreditCar.API.Controllers
{
    public class MarcaVehiculoController : BaseController<MarcaVehiculo, MarcaVehiculoDto>
    {
        private readonly IMarcaVehiculoDomain marcaVehiculo;
        public MarcaVehiculoController(IBaseDomain<MarcaVehiculo, MarcaVehiculoDto> baseDomain, IMarcaVehiculoDomain marcaVehiculo) : base(baseDomain)
        {
            this.marcaVehiculo = marcaVehiculo;
        }

        [HttpPost]
        public ActionResult UploadFileAsync([FromForm] IFormFile file)
        {
            try
            {
                var resultTable = Excel.CsvToTable(file.OpenReadStream());
                var result = marcaVehiculo.InsertListAsync(resultTable?.ToObjects<MarcaVehiculo>());
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
