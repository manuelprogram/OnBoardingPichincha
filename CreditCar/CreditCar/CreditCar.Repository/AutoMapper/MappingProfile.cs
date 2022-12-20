using AutoMapper;
using CreditCar.Entity.Models;
using CreditCar.Repository.Context;

namespace CreditCar.Repository.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AsignarCliente, AsignarClienteDto>().ReverseMap();
            CreateMap<Cliente, ClienteDto>().ReverseMap();
            CreateMap<Ejecutivo, EjecutivoDto>().ReverseMap();
            CreateMap<MarcaVehiculo, MarcaVehiculoDto>().ReverseMap();
            CreateMap<Patio, PatioDto>().ReverseMap();
            CreateMap<Persona, PersonaDto>().ReverseMap();
            CreateMap<SolicitudCredito, SolicitudCredito>().ReverseMap();
            CreateMap<Vehiculo, VehiculoDto>().ReverseMap();
        }
    }
}
