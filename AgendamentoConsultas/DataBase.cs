﻿using AgendamentoConsultas.Models.Anamenese;
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
        public DbSet<AnameneseEntity> Anameneses { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)

        {
            optionsBuilder.UseMySql("server=localhost;database=AgentamentoConsultas;user=root;password=");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }


       
    }
}

