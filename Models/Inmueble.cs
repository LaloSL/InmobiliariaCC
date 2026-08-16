namespace InmobiliariaCC.Models;

public class Inmueble
{
    public int IdInmueble { get; set; }
    public int IdPropietario { get; set; }
    public string Direccion { get; set; }
    public int Cupo { get; set; }
    public string TipoInmueble { get; set; }
    public decimal Latitud { get; set; }
    public decimal Longitud { get; set; }
    public decimal PrecioPorDia { get; set; }
    public bool Disponible { get; set; }
    public decimal PorcentajeReserva { get; set; }
}