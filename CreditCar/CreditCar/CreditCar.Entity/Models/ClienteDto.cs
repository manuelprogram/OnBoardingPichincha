namespace CreditCar.Entity.Models
{
    public class ClienteDto
    {
        public int IdCliente { get; set; }
        public int IdPersona { get; set; }
        public string EstadoCivil { get; set; } = null!;
        public string? IdentificacionConyugue { get; set; }
        public string? NombreConyugue { get; set; }
        public string SujetoCredito { get; set; } = null!;
    }
}
