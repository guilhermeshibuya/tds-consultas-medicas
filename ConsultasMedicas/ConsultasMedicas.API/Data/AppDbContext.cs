using ConsultasMedicas.API.Models;
using Microsoft.EntityFrameworkCore;

namespace ConsultasMedicas.API.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<MedicoModel> Medicos { get; set; }

        public DbSet<PacienteModel> Pacientes { get; set;}

        public DbSet<RecepcionistaModel> Recepcionistas { get; set; }

        public DbSet<EspecialidadeModel> Especialidades { get; set; }

        public DbSet<ConsultaModel> Consultas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ConsultaModel>()
                .HasOne(c => c.Medico)
                .WithMany()
                .HasForeignKey(c => c.MedicoId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ConsultaModel>()
                .HasOne(c => c.Paciente)
                .WithMany()
                .HasForeignKey(c => c.PacienteId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ConsultaModel>()
               .HasOne(c => c.Recepcionista)
               .WithMany()
               .HasForeignKey(c => c.RecepcionistaId)
               .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<MedicoModel>()
                .HasMany(m => Consultas)
                .WithOne(c => c.Medico)
                .HasForeignKey(c => c.MedicoId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<PacienteModel>()  
                .HasMany(p => p.Consultas)
                .WithOne(c => c.Paciente)
                .HasForeignKey(c => c.PacienteId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<RecepcionistaModel>()
                .HasMany(r => r.Consultas)
                .WithOne(c => c.Recepcionista)
                .HasForeignKey(c => c.RecepcionistaId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<MedicoModel>()
                .HasIndex(m => m.CRM)
                .IsUnique();

            modelBuilder.Entity<PacienteModel>()
                .HasIndex(p => p.CPF)
                .IsUnique();
        }
    }
}
