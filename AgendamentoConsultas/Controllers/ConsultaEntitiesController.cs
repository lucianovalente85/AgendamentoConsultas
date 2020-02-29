﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AgendamentoConsultas;
using AgendamentoConsultas.Models.Consultas;

namespace AgendamentoConsultas.Controllers
{
    public class ConsultaEntitiesController : Controller
    {
        private readonly DataBase _context;

        public ConsultaEntitiesController()
        {
            _context = new DataBase();
        }

        // GET: ConsultaEntities
        public IActionResult Index()
        {
            return View();
        }

        public async Task<PartialViewResult> Listar(ConsultaEntity consultaEntity, int pagina = 1, int registros = 5)
        {
            var query = _context.Consultas.AsQueryable();

            var dataHoje = DateTime.Today;
            var dataAmanha = DateTime.Today.AddDays(1);


            query = query.Where(e => e.DataConsulta >= dataHoje && e.DataConsulta < dataAmanha);


            query = query.OrderBy(c => c.DataConsulta).Skip((pagina - 1) * registros).Take(registros);

            return PartialView("_Listar", await query.ToListAsync());
        }


        // GET: ConsultaEntities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consultaEntity = await _context.Consultas
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
            return View();
        }

        // POST: ConsultaEntities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DataConsulta,NomeProcedimeneto,HorarioConsulta")] ConsultaEntity consultaEntity)
        {
            if (ModelState.IsValid)
            {
                _context.Add(consultaEntity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
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
            return View(consultaEntity);
        }

        // POST: ConsultaEntities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DataConsulta,NomeProcedimeneto,HorarioConsulta")] ConsultaEntity consultaEntity)
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
