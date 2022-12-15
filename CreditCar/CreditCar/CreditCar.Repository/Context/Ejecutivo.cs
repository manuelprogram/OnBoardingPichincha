using System;
using System.Collections.Generic;

namespace CreditCar.Repository.Context
{
    public partial class Ejecutivo
    {
        public Ejecutivo()
        {
            SolicitudCreditos = new HashSet<SolicitudCredito>();
        }

        public int IdPersona { get; set; }
        public int IdPatio { get; set; }
        public string Celular { get; set; } = null!;
        public int IdEjecutivo { get; set; }

        public virtual Patio IdPatioNavigation { get; set; } = null!;
        public virtual Persona IdPersonaNavigation { get; set; } = null!;
        public virtual ICollection<SolicitudCredito> SolicitudCreditos { get; set; }
    }
}
