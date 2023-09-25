using Consultas.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Consultas.API.Data
{
    public class AppDbContext : DbContext    
    {
        public DbSet<MedicoModel> Medicos { get; set; }

        public DbSet<PacienteModel> Pacientes { get; set; }

        public DbSet<RecepcionistaModel> Recepcionistas { get; set; }

        public DbSet<EspecialidadeModel> Especialidades { get; set; }

        public DbSet<ConsultaModel> Consultas { get; set; }

        public DbSet<HorarioModel> HorariosMedico { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("DataSource=tds.db;Cache=Shared");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ConsultaModel>()
                .HasOne(c => c.Medico)
                .WithMany()
                .HasForeignKey(c => c.IdMedico)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ConsultaModel>()
                .HasOne(c => c.Paciente)
                .WithMany()
                .HasForeignKey(c => c.IdPaciente)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ConsultaModel>()
               .HasOne(c => c.Recepcionista)
               .WithMany()
               .HasForeignKey(c => c.IdRecepcionista)
               .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<MedicoModel>()
                .HasMany(m => m.Consultas)
                .WithOne(c => c.Medico)
                .HasForeignKey(c => c.IdMedico)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<PacienteModel>()
                .HasMany(p => p.Consultas)
                .WithOne(c => c.Paciente)
                .HasForeignKey(c => c.IdPaciente)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<RecepcionistaModel>()
                .HasMany(r => r.Consultas)
                .WithOne(c => c.Recepcionista)
                .HasForeignKey(c => c.IdRecepcionista)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<MedicoModel>()
                .HasOne(m => m.Especialidade)
                .WithMany()
                .HasForeignKey(m => m.IdEspecialidade);

            modelBuilder.Entity<EspecialidadeModel>()
                .HasMany(e => e.Medicos)
                .WithOne(m => m.Especialidade)
                .HasForeignKey(m => m.IdEspecialidade);

            modelBuilder.Entity<MedicoModel>()
                .HasIndex(m => m.CRM)
                .IsUnique();

            modelBuilder.Entity<PacienteModel>()
                .HasIndex(p => p.CPF)
                .IsUnique();

            modelBuilder.Entity<RecepcionistaModel>()
             .HasIndex(p => p.CPF)
             .IsUnique();

            modelBuilder.Entity<MedicoModel>()
                .HasMany(m => m.HorariosDisponiveis)
                .WithOne(h => h.Medico)
                .HasForeignKey(h => h.IdMedico);

            modelBuilder.Entity<HorarioModel>()
                .HasOne(h => h.Medico)
                .WithMany(m => m.HorariosDisponiveis)
                .HasForeignKey(h => h.IdMedico);
        }
    }
}
