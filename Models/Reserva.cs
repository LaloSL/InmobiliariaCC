namespace InmobiliariaCC.Models;

public class Reserva
{
    public int IdReserva { get; set; }
    public int IdInquilino { get; set; }
    public int IdInmueble { get; set; }
    public DateTime FechaDesde { get; set; }
    public DateTime FechaHasta { get; set; }
    public decimal MontoPorDia { get; set; }
    public DateTime? FechaFinAnticipada { get; set; }
}
