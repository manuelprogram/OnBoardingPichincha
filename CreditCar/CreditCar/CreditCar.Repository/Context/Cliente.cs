using System;
using System.Collections.Generic;

namespace CreditCar.Repository.Context
{
    public partial class Cliente
    {
        public Cliente()
        {
            AsignarClientes = new HashSet<AsignarCliente>();
            SolicitudCreditos = new HashSet<SolicitudCredito>();
        }

        public int IdPersona { get; set; }
        public string EstadoCivil { get; set; } = null!;
        public string? IdentificacionConyugue { get; set; }
        public string? NombreConyugue { get; set; }
        public string SujetoCredito { get; set; } = null!;
        public int IdCliente { get; set; }

        public virtual Persona IdPersonaNavigation { get; set; } = null!;
        public virtual ICollection<AsignarCliente> AsignarClientes { get; set; }
        public virtual ICollection<SolicitudCredito> SolicitudCreditos { get; set; }
    }
}
