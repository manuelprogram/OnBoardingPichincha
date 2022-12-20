namespace CreditCar.Entity.Models
{
    public class AsignarClienteDto
    {
        public int IdAsignarCliente { get; set; }
        public int IdCliente { get; set; }
        public int IdPatio { get; set; }
        public DateTime FechaAsignacion { get; set; }
    }
}
