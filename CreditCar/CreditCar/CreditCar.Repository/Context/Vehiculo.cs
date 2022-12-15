using System;
using System.Collections.Generic;

namespace CreditCar.Repository.Context
{
    public partial class Vehiculo
    {
        public Vehiculo()
        {
            SolicitudCreditos = new HashSet<SolicitudCredito>();
        }

        public int IdVehiculo { get; set; }
        public int IdMarcaVehiculo { get; set; }
        public string Placa { get; set; } = null!;
        public int Modelo { get; set; }
        public int NroChasis { get; set; }
        public int Cilindraje { get; set; }
        public int Avaluo { get; set; }
        public bool? Estado { get; set; }
        public string? Tipo { get; set; }

        public virtual MarcaVehiculo IdMarcaVehiculoNavigation { get; set; } = null!;
        public virtual ICollection<SolicitudCredito> SolicitudCreditos { get; set; }
    }
}
