using CreditCar.API.Controllers.Common;
using CreditCar.Domain.Interfaces;
using CreditCar.Entity.Models;
using CreditCar.Repository.Context;

namespace CreditCar.API.Controllers
{
    public class PatioController : BaseController<Patio, PatioDto>
    {
        public PatioController(IBaseDomain<Patio, PatioDto> baseDomain) : base(baseDomain) { }
    }
}
