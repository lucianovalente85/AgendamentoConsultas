using AgendamentoConsultas.Models.Anamnese;
using AgendamentoConsultas.Models.Consultas;
using AgendamentoConsultas.Models.Pacientes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgendamentoConsultas
{
    public class DataBase : DbContext
    {
        public DbSet<PacienteEntity> Pacientes { get; set; }
        public DbSet<AnamneseEntity> Anamneses { get; set; }
        public DbSet<ConsultaEntity> Consultas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)

        {
            optionsBuilder.UseMySql("server=localhost;database=agentamentoconsultas;user=root;password=123456");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ParteDoCorpoEntity>(e =>
            {
                e.HasData(new[]
                {
                    new ParteDoCorpoEntity(){ Id=1, Nome="Cabeça" },
                    new ParteDoCorpoEntity(){ Id=2, Nome="Abdomem" },
                    new ParteDoCorpoEntity(){ Id=3, Nome="Membros Superiores" },
                    new ParteDoCorpoEntity(){ Id=4, Nome="Membros Inferiores" },
                });
            });

            modelBuilder.Entity<PlanoSaudeEntity>(e =>
            {
                e.HasData(new[]
                {
                    new PlanoSaudeEntity(){ Id=1, Nome="UNIMED" },
                    new PlanoSaudeEntity(){ Id=2, Nome="AMIL" },
                    new PlanoSaudeEntity(){ Id=3, Nome="SAUDE SERVIDOR" },
                    new PlanoSaudeEntity(){ Id=4, Nome="BRADESCO" },
                    new PlanoSaudeEntity(){ Id=5, Nome="OUTROS" },
                });
            });
        }
    }
}
