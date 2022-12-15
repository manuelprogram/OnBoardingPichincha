using System;
using System.Collections.Generic;

namespace CreditCar.Repository.Context
{
    public partial class MarcaVehiculo
    {
        public MarcaVehiculo()
        {
            Vehiculos = new HashSet<Vehiculo>();
        }

        public string Marca { get; set; } = null!;
        public int IdMarcaVehiculo { get; set; }

        public virtual ICollection<Vehiculo> Vehiculos { get; set; }
    }
}
