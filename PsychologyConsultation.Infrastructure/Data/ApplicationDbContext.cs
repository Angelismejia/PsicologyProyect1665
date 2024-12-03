using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PsychologyConsultation.Domain.Entities;

namespace PsychologyConsultation.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        // Constructor
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        // DbSets
        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<Consulta> Consultas { get; set; }
        public DbSet<Tratamiento> Tratamientos { get; set; }
        public DbSet<SeccionSeguimiento> SeccionesSeguimiento { get; set; }

        // Configuración de modelos
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Relación Paciente - Consulta (1:N)
            modelBuilder.Entity<Consulta>()
                .HasOne(c => c.Paciente)
                .WithMany(p => p.Consultas)
                .HasForeignKey(c => c.PacienteId)
                .OnDelete(DeleteBehavior.Cascade);

            // Relación Consulta - Tratamiento (1:N)
            modelBuilder.Entity<Tratamiento>()
                .HasOne(t => t.Consulta)
                .WithMany(c => c.Tratamientos)
                .HasForeignKey(t => t.ConsultaId)
                .OnDelete(DeleteBehavior.Cascade);

            // Relación Tratamiento - Sección Seguimiento (1:N)
            modelBuilder.Entity<SeccionSeguimiento>()
                .HasOne(s => s.Tratamiento)
                .WithMany()
                .HasForeignKey(s => s.TratamientoId)
                .OnDelete(DeleteBehavior.Cascade);

            // Restricciones adicionales (opcional)
            modelBuilder.Entity<Paciente>().Property(p => p.Nombre).HasMaxLength(100).IsRequired();
            modelBuilder.Entity<Paciente>().Property(p => p.Apellido).HasMaxLength(100);
            modelBuilder.Entity<Tratamiento>().Property(t => t.Nombre).HasMaxLength(200);
        }
    }
}
