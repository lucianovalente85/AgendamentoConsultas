using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AgendamentoConsultas;
using AgendamentoConsultas.Models.Consultas;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace AgendamentoConsultas.Controllers
{
     
    public class ConsultaEntitiesController : Controller
    {
        private readonly DataBase _context;

        public class FormPesquisa
        {
            //[DataType(DataType.Date)]
            //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
            public string DataConsultaInicio { get; set; }
            //[DataType(DataType.Date)]
           // [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
            public string DataConsultaFinal { get; set; }
            public int PlanoDeSaudeId { get; set; }
        }


        public ConsultaEntitiesController()
        {
            _context = new DataBase();
        }

        // GET: ConsultaEntities
        public IActionResult Index()
        {
            ViewBag.PlanoDeSaudeId = new SelectList(_context.PlanoSaudes, "Id", "Nome");
            return View();
        }
        //Criação da lista para filtrar as consultas.
        public async Task<PartialViewResult> Listar(FormPesquisa formPesquisa, int pagina = 1, int registros = 5)
        {
            CultureInfo ptBR = new CultureInfo("pt-BR");
            var query = _context.Consultas.AsQueryable();
            
                //Busca um agendamento cadastrado com Data que será cadastrada e tambem faz o filtro por data inicial
                if (formPesquisa.DataConsultaInicio != null)
                {
                    DateTime dataHoje = DateTime.ParseExact(formPesquisa.DataConsultaInicio, "yyyy-MM-dd", ptBR);
                    query = query.Where(e => e.DataConsulta >= dataHoje);
                }
                //Busca um agendamento cadastrado com Data Final que será cadastrada
                if (formPesquisa.DataConsultaFinal != null)
                {
                    DateTime dataAmanha = DateTime.ParseExact(formPesquisa.DataConsultaFinal, "yyyy-MM-dd", ptBR);
                    query = query.Where(e => e.DataConsulta < dataAmanha);
                }
                //Busca um agendamento cadastrado pelo Plano de Saude que será cadastrado
                if (formPesquisa.PlanoDeSaudeId != null)
                {
                    query = query.Where(e => e.Paciente.PlanoDeSaudeId == formPesquisa.PlanoDeSaudeId);
                }
            query = query.OrderBy(c => c.DataConsulta).Skip((pagina - 1) * registros).Take(registros);
            //Traz os objetos Paciente e Anaminese para a view da consulta
            var pacienteAnaminese = query.ToList();
            pacienteAnaminese.ForEach(p => {
                p.Anamnese = _context.Anamneses.Where(e => e.Id == p.AnamneseId).FirstOrDefault();
                p.Paciente = _context.Pacientes.Where(e => e.Id == p.PacienteId).FirstOrDefault();
            });

            return PartialView("_Listar", pacienteAnaminese);
            
            
            

           
        }

        // GET: ConsultaEntities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consultaEntity = await _context.Consultas
                .Include(c => c.Anamnese)
                .Include(c => c.Paciente)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (consultaEntity == null)
            {
                return NotFound();
            }

            return View(consultaEntity);
        }

        // GET: ConsultaEntities/Create
        public IActionResult Create()
        {
            
            ViewData["AnamneseId"] = new SelectList(_context.Anamneses, "Id", "Sintomas");
            ViewData["PacienteId"] = new SelectList(_context.Pacientes, "Id", "Nome");
            return View();
        }

        // POST: ConsultaEntities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DataConsulta,NomeProcedimeneto,HorarioConsulta,PacienteId,AnamneseId")] ConsultaEntity consultaEntity)
        {
            if (ModelState.IsValid)
            {
                _context.Add(consultaEntity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AnamneseId"] = new SelectList(_context.Anamneses, "Id", "Sintomas", consultaEntity.AnamneseId);
            ViewData["PacienteId"] = new SelectList(_context.Pacientes, "Id", "Nome", consultaEntity.PacienteId);
            return View(consultaEntity);
        }

        // GET: ConsultaEntities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consultaEntity = await _context.Consultas.FindAsync(id);
            if (consultaEntity == null)
            {
                return NotFound();
            }
            ViewData["AnamneseId"] = new SelectList(_context.Anamneses, "Id", "Sintomas", consultaEntity.AnamneseId);
            ViewData["PacienteId"] = new SelectList(_context.Pacientes, "Id", "Nome", consultaEntity.PacienteId);
            return View(consultaEntity);
        }

        // POST: ConsultaEntities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DataConsulta,NomeProcedimeneto,HorarioConsulta,PacienteId,AnamneseId")] ConsultaEntity consultaEntity)
        {
            if (id != consultaEntity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(consultaEntity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConsultaEntityExists(consultaEntity.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["AnamneseId"] = new SelectList(_context.Anamneses, "Id", "Sintomas", consultaEntity.AnamneseId);
            ViewData["PacienteId"] = new SelectList(_context.Pacientes, "Id", "Nome", consultaEntity.PacienteId);
            return View(consultaEntity);
        }

        // GET: ConsultaEntities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consultaEntity = await _context.Consultas
                .Include(c => c.Anamnese)
                .Include(c => c.Paciente)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (consultaEntity == null)
            {
                return NotFound();
            }

            return View(consultaEntity);
        }

        // POST: ConsultaEntities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var consultaEntity = await _context.Consultas.FindAsync(id);
            _context.Consultas.Remove(consultaEntity);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ConsultaEntityExists(int id)
        {
            return _context.Consultas.Any(e => e.Id == id);
        }
    }
}
