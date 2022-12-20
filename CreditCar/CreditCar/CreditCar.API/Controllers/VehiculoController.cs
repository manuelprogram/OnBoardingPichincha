using CreditCar.API.Controllers.Common;
using CreditCar.Domain.Interfaces;
using CreditCar.Entity.Models;
using CreditCar.Repository.Context;

namespace CreditCar.API.Controllers
{
    public class VehiculoController : BaseController<Vehiculo, VehiculoDto>
    {
        public VehiculoController(IBaseDomain<Vehiculo, VehiculoDto> baseDomain) : base(baseDomain) { }
    }
}