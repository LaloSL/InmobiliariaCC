using Microsoft.EntityFrameworkCore;
using InmobiliariaCC.Models;

namespace InmobiliariaCC.Data;

public class AppDBContext : DbContext
{
    public AppDBContext(DbContextOptions<AppDBContext> options)
        : base(options)
    {
    }

    // Tablas que manejará Entity Framework
    public DbSet<Propietario> Propietarios { get; set; }
    public DbSet<Inquilino> Inquilinos { get; set; }
    public DbSet<Inmueble> Inmuebles { get; set; }
    public DbSet<Reserva> Reservas { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
       
        // PROPIETARIO
        

        modelBuilder.Entity<Propietario>(tb =>
        {
            // Clave primaria
            tb.HasKey(col => col.IdPropietario);

            // Id autoincremental
            tb.Property(col => col.IdPropietario)
                .ValueGeneratedOnAdd();

            tb.Property(col => col.NombreCompleto)
                .HasMaxLength(100);

            tb.Property(col => col.DNI)
                .HasMaxLength(20);

            tb.Property(col => col.Telefono)
                .HasMaxLength(30);

            tb.Property(col => col.Email)
                .HasMaxLength(100);

            // Nombre de la tabla en MySQL
            tb.ToTable("Propietario");
        });


        
        // INQUILINO
    

        modelBuilder.Entity<Inquilino>(tb =>
        {
            // Clave primaria
            tb.HasKey(col => col.IdInquilino);

            // Id autoincremental
            tb.Property(col => col.IdInquilino)
                .ValueGeneratedOnAdd();

            tb.Property(col => col.NombreCompleto)
                .HasMaxLength(100);

            tb.Property(col => col.DNI)
                .HasMaxLength(20);

            tb.Property(col => col.Telefono)
                .HasMaxLength(30);

            tb.Property(col => col.Email)
                .HasMaxLength(100);

            // Nombre de la tabla en MySQL
            tb.ToTable("Inquilino");
        });


      
        // INMUEBLE
      

        modelBuilder.Entity<Inmueble>(tb =>
        {
            // Clave primaria
            tb.HasKey(col => col.IdInmueble);

            // Id autoincremental
            tb.Property(col => col.IdInmueble)
                .ValueGeneratedOnAdd();

            tb.Property(col => col.Direccion)
                .HasMaxLength(150);

            tb.Property(col => col.TipoInmueble)
                .HasMaxLength(50);

            tb.Property(col => col.Latitud)
                .HasPrecision(10, 7);

            tb.Property(col => col.Longitud)
                .HasPrecision(10, 7);

            tb.Property(col => col.PrecioPorDia)
                .HasPrecision(12, 2);

            tb.Property(col => col.PorcentajeReserva)
                .HasPrecision(5, 2);

            // Relación:
            // Un Propietario puede tener muchos Inmuebles
            tb.HasOne<Propietario>()
                .WithMany()
                .HasForeignKey(col => col.IdPropietario);

            // Nombre de la tabla en MySQL
            tb.ToTable("Inmueble");
        });


        
        // RESERVA
       

        modelBuilder.Entity<Reserva>(tb =>
        {
            // Clave primaria
            tb.HasKey(col => col.IdReserva);

            // Id autoincremental
            tb.Property(col => col.IdReserva)
                .ValueGeneratedOnAdd();

            tb.Property(col => col.MontoPorDia)
                .HasPrecision(12, 2);

            // Relación:
            // Un Inquilino puede tener muchas Reservas
            tb.HasOne<Inquilino>()
                .WithMany()
                .HasForeignKey(col => col.IdInquilino);

            // Relación:
            // Un Inmueble puede tener muchas Reservas
            tb.HasOne<Inmueble>()
                .WithMany()
                .HasForeignKey(col => col.IdInmueble);

            // Nombre de la tabla en MySQL
            tb.ToTable("Reserva");
        });
    }
}