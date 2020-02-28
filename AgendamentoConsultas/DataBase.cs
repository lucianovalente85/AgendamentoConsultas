using AgendamentoConsultas.Models.Anamenese;
using AgendamentoConsultas.Models.Consulta;
using AgendamentoConsultas.Models.Paciente;
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
        public DbSet<ConsultaEntity> Consultas { get; set; }
        public DbSet<AnamneseEntity> Anamneses { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)

        {
            optionsBuilder.UseMySql("server=localhost;database=agentamentoconsultas;user=root;password=123456");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }


       
    }
}

