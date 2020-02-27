using AgendamentoConsultas.Models.Consulta;
using AgendamentoConsultas.Models.Paciente;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using DbContext = System.Data.Entity.DbContext;

namespace AgendamentoConsultas
{
    public class DataBase : DbContext
    {
         
        public System.Data.Entity.DbSet<pacienteEntity> pacientes { get; set; }
        public System.Data.Entity.DbSet<ConsultaEntity> consultas { get; set; }

      

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("server=localhost;database=blog;user=root;password=123456");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
}
