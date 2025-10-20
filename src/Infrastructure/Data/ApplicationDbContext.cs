using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Domicilio> Domicilios { get; set; }
        public DbSet<CtaCte> CtaCtes { get; set; }
        public DbSet<Movimiento> Movimientos { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuración de Cliente
            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Nombre).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Apellido).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Telefono).HasMaxLength(20);

                // Relación con Domicilio
                entity.HasOne(e => e.Domicilio)
                      .WithMany()
                      .HasForeignKey("DomicilioId");
            });

            // Configuración de Domicilio
            modelBuilder.Entity<Domicilio>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Direccion).IsRequired().HasMaxLength(200);
                entity.Property(e => e.Ciudad).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Provincia).IsRequired().HasMaxLength(100);
            });

            // Configuración de CtaCte
            modelBuilder.Entity<CtaCte>(entity =>
            {
                entity.HasKey(e => e.Id);

                // Relación con Movimientos
                entity.HasMany(e => e.Movimientos)
                      .WithOne()
                      .HasForeignKey("CtaCteId");
            });

            // Configuración de Movimiento
            modelBuilder.Entity<Movimiento>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Descripcion).HasMaxLength(200);
                entity.Property(e => e.Haber).HasColumnType("decimal(18,2)");
                entity.Property(e => e.Debe).HasColumnType("decimal(18,2)");
                entity.Property(e => e.Fecha).HasColumnType("datetime");
            });

            // Configuracion de User
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Password).IsRequired().HasMaxLength(255);
                entity.HasIndex(e => e.Name).IsUnique();
            });
        }
    }
}