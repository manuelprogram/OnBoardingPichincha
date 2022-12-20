namespace CreditCar.Entity.Models
{
    public class PersonaDto
    {
        public int IdPersona { get; set; }
        public string Identificacion { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public string Apellidos { get; set; } = null!;
        public int Edad { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Direccion { get; set; } = null!;
        public string Telefono { get; set; } = null!;
    }
}
