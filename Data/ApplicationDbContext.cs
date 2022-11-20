using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TransportesMR.ViewModels;

namespace TransportesMR.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<ApplicationUser> ApplicationUser { get; set; }
        public DbSet<Camion> Camion{ get; set; }
        public DbSet<MarcaVehiculo> MarcaVehiculo { get; set; }
        public DbSet<ModeloVehiculo> ModeloVehiculo { get; set; }        
        public DbSet<Camion> Camiones { get; set; }        
        public DbSet<Trabajador> Trabajador { get; set; }
        public DbSet<Empresa> Empresa { get; set; }
        public DbSet<Remolque> Remolque { get; set; }
        public DbSet<MarcaRemolque> MarcaRemolque { get; set; }
        public DbSet<ModeloRemolque> ModeloRemolque { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}