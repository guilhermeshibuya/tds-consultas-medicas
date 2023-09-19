using ConsultasMedicas.API.Models;
using Microsoft.EntityFrameworkCore;

namespace ConsultasMedicas.API.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<PacienteModel> Pacientes { get; set; }

        public DbSet<MedicoModel> Medicos { get; set; }

        public DbSet<RecepcionistaModel> Recepcionistas { get; set; }

        public DbSet<ConsultaModel> Consultas { get; set; }

        public DbSet<EspecialidadeModel> Especialidades { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("DataSource=tds.db;Cache=Shared");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PacienteModel>().HasKey(p => p.IdPaciente);
            modelBuilder.Entity<PacienteModel>().Property(p => p.IdPaciente)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<MedicoModel>().HasKey(m => m.IdMedico);
            modelBuilder.Entity<MedicoModel>().Property(m => m.IdMedico)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<HorarioModel>().HasKey(h => h.IdHorario);
            modelBuilder.Entity<HorarioModel>().Property(h => h.IdHorario)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<RecepcionistaModel>().HasKey(r => r.IdRecepcionista);
            modelBuilder.Entity<RecepcionistaModel>().Property(r => r.IdRecepcionista)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<EspecialidadeModel>().HasKey(e => e.IdEspecialidade);
            modelBuilder.Entity<EspecialidadeModel>().Property(e => e.IdEspecialidade)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<ConsultaModel>().HasKey(c => c.IdConsulta);
            modelBuilder.Entity<ConsultaModel>().Property(c => c.IdConsulta)
                .ValueGeneratedOnAdd();
            /*
            modelBuilder.Entity<MedicoModel>()
                .HasMany(m => m.Consultas)
                .WithOne(c => c.Medico)
                .HasForeignKey("IdMedico");

            modelBuilder.Entity<MedicoModel>()
                .HasMany(m => m.HorariosDisponiveis)
                .WithOne(h => h.Medico)
                .HasForeignKey("IdMedico");

            modelBuilder.Entity<PacienteModel>()
                .HasMany(p => p.Consultas)
                .WithOne(c => c.Paciente)
                .HasForeignKey("IdPaciente");
            */
            /*
            modelBuilder.Entity<MedicoModel>()
                .HasOne(m => m.Especialidade)
                .WithMany(e => e.Medicos)
                .HasForeignKey(m => m.IdEspecialidade);
            */
            /*
            modelBuilder.Entity<EspecialidadeModel>()
                .HasMany(e => e.Medicos)
                .WithOne(m => m.Especialidade)
                .HasForeignKey("IdEspecialidade");*/
            /*
            modelBuilder.Entity<RecepcionistaModel>()
                .HasMany(r => r.ConsultasAgendadas)
                .WithOne(c => c.Recepcionista)
                .HasForeignKey("IdRecepcionista");
            */
        }
    }
}
