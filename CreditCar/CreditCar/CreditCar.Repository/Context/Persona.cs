using System;
using System.Collections.Generic;

namespace CreditCar.Repository.Context
{
    public partial class Persona
    {
        public Persona()
        {
            Clientes = new HashSet<Cliente>();
            Ejecutivos = new HashSet<Ejecutivo>();
        }

        public string Identificacion { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public string Apellidos { get; set; } = null!;
        public int Edad { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Direccion { get; set; } = null!;
        public string Telefono { get; set; } = null!;
        public int IdPersona { get; set; }

        public virtual ICollection<Cliente> Clientes { get; set; }
        public virtual ICollection<Ejecutivo> Ejecutivos { get; set; }
    }
}
