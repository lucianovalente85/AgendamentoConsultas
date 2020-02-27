using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AgendamentoConsultas;
using AgendamentoConsultas.Models.Consulta;

namespace AgendamentoConsultas.Controllers
{
    public class ConsultaEntitiesController : Controller
    {
        private readonly DataBase _context;

        public ConsultaEntitiesController(DataBase context)
        {
            _context = context;
        }

        // GET: ConsultaEntities
        public async Task<IActionResult> Index()
        {
            var dataBase = _context.Consultas.Include(c => c.Anamenese);
            return View(await dataBase.ToListAsync());
        }

        // GET: ConsultaEntities/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consultaEntity = await _context.Consultas
                .Include(c => c.Anamenese)
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
            ViewData["AnameneseId"] = new SelectList(_context.Anameneses, "Id", "Id");
            return View();
        }

        // POST: ConsultaEntities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DataConsulta,NomeProcedimento,HorarioConsulta,AnameneseId")] ConsultaEntity consultaEntity)
        {
            if (ModelState.IsValid)
            {
                _context.Add(consultaEntity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AnameneseId"] = new SelectList(_context.Anameneses, "Id", "Id", consultaEntity.AnameneseId);
            return View(consultaEntity);
        }

        // GET: ConsultaEntities/Edit/5
        public async Task<IActionResult> Edit(string id)
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
            ViewData["AnameneseId"] = new SelectList(_context.Anameneses, "Id", "Id", consultaEntity.AnameneseId);
            return View(consultaEntity);
        }

        // POST: ConsultaEntities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,DataConsulta,NomeProcedimento,HorarioConsulta,AnameneseId")] ConsultaEntity consultaEntity)
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
            ViewData["AnameneseId"] = new SelectList(_context.Anameneses, "Id", "Id", consultaEntity.AnameneseId);
            return View(consultaEntity);
        }

        // GET: ConsultaEntities/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consultaEntity = await _context.Consultas
                .Include(c => c.Anamenese)
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
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var consultaEntity = await _context.Consultas.FindAsync(id);
            _context.Consultas.Remove(consultaEntity);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ConsultaEntityExists(string id)
        {
            return _context.Consultas.Any(e => e.Id == id);
        }
    }
}
