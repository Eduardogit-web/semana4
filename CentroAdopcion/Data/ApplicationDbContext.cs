using CentroAdopcion.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CentroAdopcion.Data;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    public DbSet<Animal> Animales { get; set; }
    public DbSet<Especie> Especies { get; set; }
    public DbSet<Refugio> Refugios { get; set; }
    public DbSet<Adopcion> Adopciones { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<Animal>()
            .HasOne(a => a.Especie)
            .WithMany(e => e.Animales)
            .HasForeignKey(a => a.EspecieId);

        builder.Entity<Animal>()
            .HasOne(a => a.Refugio)
            .WithMany(r => r.Animales)
            .HasForeignKey(a => a.RefugioId);

        builder.Entity<Adopcion>()
            .HasOne(a => a.Animal)
            .WithMany(a => a.Adopciones)
            .HasForeignKey(a => a.AnimalId);

        builder.Entity<Adopcion>()
            .HasOne(a => a.User)
            .WithMany(u => u.Adopciones)
            .HasForeignKey(a => a.UserId);
    }
}
