namespace CreditCar.Entity.Models
{
    public class SolicitudCreditoDto
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
    }
}
