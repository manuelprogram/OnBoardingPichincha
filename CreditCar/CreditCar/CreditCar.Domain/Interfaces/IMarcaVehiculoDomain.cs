using CreditCar.Entity.Models;
using CreditCar.Repository.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditCar.Domain.Interfaces
{
    public interface IMarcaVehiculoDomain : IBaseDomain<MarcaVehiculo, MarcaVehiculoDto>
    {
        Task<IEnumerable<MarcaVehiculo>> InsertListAsync(IEnumerable<MarcaVehiculo>? marcasVehiculos);
    }
}
