using System;
using System.Collections.Generic;

namespace CreditCar.Repository.Context
{
    public partial class SolicitudCredito
    {
        public int IdCliente { get; set; }
        public int IdEjecutivo { get; set; }
        public int IdPatio { get; set; }
        public int IdVehiculo { get; set; }
        public DateTime FechaElaboracion { get; set; }
        public int MesesPlazo { get; set; }
        public int Cuotas { get; set; }
        public byte[] Observacion { get; set; } = null!;
        public int IdSolicitudCredito { get; set; }
        public string Estado { get; set; } = null!;

        public virtual Cliente IdClienteNavigation { get; set; } = null!;
        public virtual Ejecutivo IdEjecutivoNavigation { get; set; } = null!;
        public virtual Patio IdPatioNavigation { get; set; } = null!;
        public virtual Vehiculo IdVehiculoNavigation { get; set; } = null!;
    }
}
