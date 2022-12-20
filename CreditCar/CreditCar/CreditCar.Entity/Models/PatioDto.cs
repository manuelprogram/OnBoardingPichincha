namespace CreditCar.Entity.Models
{
    public class PatioDto
    {
        public int IdPatio { get; set; }
        public string Nombre { get; set; } = null!;
        public string Direcion { get; set; } = null!;
        public string Telefono { get; set; } = null!;
        public int NroPuntoVenta { get; set; }
    }
}
