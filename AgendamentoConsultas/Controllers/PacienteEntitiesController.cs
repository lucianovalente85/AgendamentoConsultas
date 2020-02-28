using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AgendamentoConsultas.Models.Paciente;

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
            return View();
        }

        public async Task<PartialViewResult> Listar(PacienteEntity paciente, int pagina = 1, int registros = 5)
        {
            var query = _context.Pacientes.AsQueryable();
            if (paciente.Codigo != 0)
                query = query.Where(p => p.Codigo.Equals(paciente.Codigo));

            if (paciente.Cpf != 0)
                query = query.Where(p => p.Cpf.Equals(paciente.Cpf));

            query = query.OrderBy(c => c.Id).Skip((pagina - 1) * registros).Take(registros);
            return PartialView("_Listar", await query.ToListAsync());
        }

        // GET: PacienteEntities/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pacienteEntity = await _context.Pacientes
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
            return View();
        }

        // POST: PacienteEntities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Codigo,Cpf,DataNascimento,ConsultaId")] PacienteEntity pacienteEntity)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pacienteEntity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pacienteEntity);
        }

        // GET: PacienteEntities/Edit/5
        public async Task<IActionResult> Edit(string id)
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
            return View(pacienteEntity);
        }

        // POST: PacienteEntities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,Codigo,Cpf,DataNascimento,ConsultaId")] PacienteEntity pacienteEntity)
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
            return View(pacienteEntity);
        }

        // GET: PacienteEntities/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pacienteEntity = await _context.Pacientes
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
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var pacienteEntity = await _context.Pacientes.FindAsync(id);
            _context.Pacientes.Remove(pacienteEntity);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PacienteEntityExists(string id)
        {
            return _context.Pacientes.Any(e => e.Id == id);
        }
    }
}
