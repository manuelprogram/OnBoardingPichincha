using AutoMapper;
using CreditCar.Domain.Interfaces;
using CreditCar.Entity.Models;
using CreditCar.Repository.Context;

namespace CreditCar.Infrastructure.Services
{
    public class MarcaVehiculoService : BaseService<MarcaVehiculo, MarcaVehiculoDto>, IMarcaVehiculoDomain
    {
        public MarcaVehiculoService(IMapper mapper, Repository.DataAccess.Interfaces.IRepository<MarcaVehiculo> sqlData) : base(mapper, sqlData)
        {
        }

        public async Task<IEnumerable<MarcaVehiculo>> InsertListAsync(IEnumerable<MarcaVehiculo>? marcasVehiculos)
        {
            ArgumentNullException.ThrowIfNull(marcasVehiculos);

            var marcas = new List<MarcaVehiculo>();

            foreach (var marca in marcasVehiculos)
            {
                try
                {
                    MarcaVehiculo marcaVehiculo = repositoryData.Insert(marca);
                    _ = await repositoryData.SaveAsync();
                    marcas.Add(marcaVehiculo);
                }
                catch (Exception e)
                {

                }

            }


            return marcas;
        }
    }
}
