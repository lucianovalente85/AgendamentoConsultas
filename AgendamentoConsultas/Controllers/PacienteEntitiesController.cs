using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AgendamentoConsultas;
using AgendamentoConsultas.Models.Pacientes;
using AgendamentoConsultas.Util;

namespace AgendamentoConsultas.Controllers
{
    public class PacienteEntitiesController : Controller
    {
        private readonly DataBase _context;

        public PacienteEntitiesController()
        {
            _context = new DataBase();
        }

        // GET: PacienteEntities
        public IActionResult Index()
        {
            //
            return View();
        }
        //Lista os de um paciente
        public async Task<PartialViewResult> Listar(PacienteEntity paciente, int pagina = 1, int registros = 5)
        {
            var query = _context.Pacientes.AsQueryable();
            //Busca um paciente cadastrado com Código que será cadastrado 
            if (paciente.Codigo != 0)   
                query = query.Where(p => p.Codigo.Equals(paciente.Codigo));
            //Busca um paciente cadastrado com Nome que será cadastrado
            if (!String.IsNullOrWhiteSpace(paciente.Nome))
                query = query.Where(p => p.Nome.Equals(paciente.Nome));
            //Busca um paciente cadastrado com Cpf que será cadastrado
            if (!String.IsNullOrWhiteSpace(paciente.Cpf))
                query = query.Where(p => p.Cpf.Equals(paciente.Cpf));
            //Ordena a lista de pacientes por x registros pré estabecidos no método Listar
            query = query.OrderBy(c => c.Id).Skip((pagina - 1) * registros).Take(registros);

            var pacientes = await query.ToListAsync();
            pacientes.ForEach( p => {
                p.PlanoDeSaude = _context.PlanoSaudes.Where(e => e.Id == p.PlanoDeSaudeId).FirstOrDefault();
            });

            return PartialView("_Listar", pacientes);
        }



        // GET: PacienteEntities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pacienteEntity = await _context.Pacientes
                .Include(p => p.PlanoDeSaude)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pacienteEntity == null)
            {
                return NotFound();
            }

            return View(pacienteEntity);
        }

        // GET: PacienteEntities/Create
        public IActionResult Create()
        {
            ViewData["PlanoDeSaudeId"] = new SelectList(_context.PlanoSaudes, "Id", "Nome");
            ViewBag.PlanoDeSaude = new List<PlanoSaudeEntity>();
            return View();
        }

        // POST: PacienteEntities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Codigo,Nome,Cpf,Senha,DataNascimento,PlanoDeSaudeId")] PacienteEntity pacienteEntity)
        {
            ViewData["errorMessage"] = "";
            if (ModelState.IsValid )
            {
                //Validando o cadastro de pessoas maiores de idade.
                int idade = DateTime.Now.Year - pacienteEntity.DataNascimento.Year;
                if (idade >= 18)
                {
                    //Utilizando o método para validar o CPF
                    if (ValidaCPF.IsCpf(pacienteEntity.Cpf))
                    {
                        _context.Add(pacienteEntity);
                        await _context.SaveChangesAsync();
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        ViewData["errorMessage"] = "O CPF está inválido.";
                    }

                }
                else
                {
                    ViewData["errorMessage"] = "Não é permitido cadastrar menor de idade.";
                }

            }
            ViewData["PlanoDeSaudeId"] = new SelectList(_context.PlanoSaudes, "Id", "Nome", pacienteEntity.PlanoDeSaudeId);
            return View(pacienteEntity);
        }

        // GET: PacienteEntities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pacienteEntity = await _context.Pacientes.FindAsync(id);
            if (pacienteEntity == null)
            {
                return NotFound();
            }
            ViewData["PlanoDeSaudeId"] = new SelectList(_context.PlanoSaudes, "Id", "Nome", pacienteEntity.PlanoDeSaudeId);
            return View(pacienteEntity);
        }

        // POST: PacienteEntities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Codigo,Nome,Cpf,Senha,DataNascimento,PlanoDeSaudeId")] PacienteEntity pacienteEntity)
        {
            if (id != pacienteEntity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pacienteEntity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PacienteEntityExists(pacienteEntity.Id))
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
            ViewData["PlanoDeSaudeId"] = new SelectList(_context.PlanoSaudes, "Id", "Nome", pacienteEntity.PlanoDeSaudeId);
            return View(pacienteEntity);
        }

        // GET: PacienteEntities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pacienteEntity = await _context.Pacientes
                .Include(p => p.PlanoDeSaude)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pacienteEntity == null)
            {
                return NotFound();
            }

            return View(pacienteEntity);
        }

        // POST: PacienteEntities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pacienteEntity = await _context.Pacientes.FindAsync(id);
            _context.Pacientes.Remove(pacienteEntity);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PacienteEntityExists(int id)
        {
            return _context.Pacientes.Any(e => e.Id == id);
        }
    }
}
