using System;
using System.Collections.Generic;

namespace CreditCar.Repository.Context
{
    public partial class Patio
    {
        public Patio()
        {
            AsignarClientes = new HashSet<AsignarCliente>();
            Ejecutivos = new HashSet<Ejecutivo>();
            SolicitudCreditos = new HashSet<SolicitudCredito>();
        }

        public string Nombre { get; set; } = null!;
        public string Direcion { get; set; } = null!;
        public string Telefono { get; set; } = null!;
        public int NroPuntoVenta { get; set; }
        public int IdPatio { get; set; }

        public virtual ICollection<AsignarCliente> AsignarClientes { get; set; }
        public virtual ICollection<Ejecutivo> Ejecutivos { get; set; }
        public virtual ICollection<SolicitudCredito> SolicitudCreditos { get; set; }
    }
}
