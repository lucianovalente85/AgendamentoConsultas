using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AgendamentoConsultas;
using AgendamentoConsultas.Models.Anamnese;

namespace AgendamentoConsultas.Controllers
{
    public class AnamneseEntitiesController : Controller
    {
        private readonly DataBase _context;

        public AnamneseEntitiesController()
        {
            _context = new DataBase();
        }

        // GET: AnamneseEntities
        public async Task<IActionResult> Index()
        {
            var dataBase = _context.Anamneses.Include(a => a.ParteDoCorpo);
            return View(await dataBase.ToListAsync());
        }


        // GET: AnamneseEntities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var anamneseEntity = await _context.Anamneses
                .Include(a => a.ParteDoCorpo)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (anamneseEntity == null)
            {
                return NotFound();
            }

            return View(anamneseEntity);
        }

        // GET: AnamneseEntities/Create
        public IActionResult Create()
        {
            ViewData["ParteDoCorpoId"] = new SelectList(_context.Set<ParteDoCorpoEntity>(), "Id", "Nome");
            return View();
        }

        // POST: AnamneseEntities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Sintomas,DoencasPreExistentes,ParteDoCorpoId")] AnamneseEntity anamneseEntity)
        {
            if (ModelState.IsValid)
            {
                _context.Add(anamneseEntity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ParteDoCorpoId"] = new SelectList(_context.Set<ParteDoCorpoEntity>(), "Id", "Nome", anamneseEntity.ParteDoCorpoId);
            return View(anamneseEntity);
        }

        // GET: AnamneseEntities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var anamneseEntity = await _context.Anamneses.FindAsync(id);
            if (anamneseEntity == null)
            {
                return NotFound();
            }
            ViewData["ParteDoCorpoId"] = new SelectList(_context.Set<ParteDoCorpoEntity>(), "Id", "Nome", anamneseEntity.ParteDoCorpoId);
            return View(anamneseEntity);
        }

        // POST: AnamneseEntities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Sintomas,DoencasPreExistentes,ParteDoCorpoId")] AnamneseEntity anamneseEntity)
        {
            if (id != anamneseEntity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(anamneseEntity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AnamneseEntityExists(anamneseEntity.Id))
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
            ViewData["ParteDoCorpoId"] = new SelectList(_context.Set<ParteDoCorpoEntity>(), "Id", "Nome", anamneseEntity.ParteDoCorpoId);
            return View(anamneseEntity);
        }

        // GET: AnamneseEntities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var anamneseEntity = await _context.Anamneses
                .Include(a => a.ParteDoCorpo)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (anamneseEntity == null)
            {
                return NotFound();
            }

            return View(anamneseEntity);
        }

        // POST: AnamneseEntities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var anamneseEntity = await _context.Anamneses.FindAsync(id);
            _context.Anamneses.Remove(anamneseEntity);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AnamneseEntityExists(int id)
        {
            return _context.Anamneses.Any(e => e.Id == id);
        }
    }
}
