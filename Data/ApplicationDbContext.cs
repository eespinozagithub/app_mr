using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TransportesMR.ViewModels;
using TransportesMR.ViewReports;

namespace TransportesMR.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<ApplicationUser> ApplicationUser { get; set; }        
        public DbSet<MarcaVehiculo> MarcaVehiculo { get; set; }
        public DbSet<ModeloVehiculo> ModeloVehiculo { get; set; }        
        public DbSet<Camion> Camion { get; set; }        
        public DbSet<Trabajador> Trabajador { get; set; }
        public DbSet<Empresa> Empresa { get; set; }
        public DbSet<Remolque> Remolque { get; set; }
        public DbSet<MarcaRemolque> MarcaRemolque { get; set; }
        public DbSet<ModeloRemolque> ModeloRemolque { get; set; }
        public DbSet<CargaCombustible> CargaCombustible { get; set; }
        public DbSet<CargaCombustibleRemolque> CargaCombustibleRemolque { get; set; }
        public DbSet<Ciudades> Ciudades { get; set; }
        public DbSet<Vueltas> Vueltas { get; set; }
        public virtual DbSet<DetalleVuelta> DetalleVueltas { get; set; } //agregar por cada reporte
        public virtual DbSet<DetalleSueldo> DetalleSueldos { get; set; } 

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder); // agregar por cada reporte
            builder.Entity<DetalleVuelta>()
                .HasNoKey();

            builder.Entity<Vueltas>()
                 .HasOne(x => x.EmpresaResponsable)
                 .WithMany(x => x.EmpresaResponsable)
                 .HasForeignKey(x => x.IdEmpresaResponsable)
                 .OnDelete(DeleteBehavior.ClientSetNull);

            builder.Entity<Vueltas>()
                 .HasOne(x => x.EmpresaCarga)
                 .WithMany(x => x.EmpresaCarga)
                 .HasForeignKey(x => x.IdEmpresaCarga)
                 .OnDelete(DeleteBehavior.ClientSetNull);

            builder.Entity<Vueltas>()
                 .HasOne(x => x.EmpresaDescarga)
                 .WithMany(x => x.EmpresaDescarga)
                 .HasForeignKey(x => x.IdEmpresaDescarga)
                 .OnDelete(DeleteBehavior.ClientSetNull);

            builder.Entity<Vueltas>()
                .HasOne(x => x.CiudadCarga)
                .WithMany(x => x.CiudadCarga)
                .HasForeignKey(x => x.IdCiudadCarga)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder.Entity<Vueltas>()
                .HasOne(x => x.CiudadDescarga)
                .WithMany(x => x.CiudadDescarga)
                .HasForeignKey(x => x.IdCiudadDescarga)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}