using System;
using System.Collections.Generic;

namespace CreditCar.Repository.Context
{
    public partial class AsignarCliente
    {
        public int IdAsignarCliente { get; set; }
        public int IdCliente { get; set; }
        public int IdPatio { get; set; }
        public DateTime FechaAsignacion { get; set; }

        public virtual Cliente IdClienteNavigation { get; set; } = null!;
        public virtual Patio IdPatioNavigation { get; set; } = null!;
    }
}
