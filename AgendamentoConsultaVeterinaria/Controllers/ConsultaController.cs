using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AgendamentoConsultaVeterinaria.Models;
using AgendamentoConsultaVeterinaria.Context;

namespace AgendamentoConsultaVeterinaria.Controllers
{
    public class ConsultaController : Controller
    {
        private readonly Contexto _context;

        public ConsultaController(Contexto context)
        {
            _context = context;
        }

        // GET: Consulta
        public async Task<IActionResult> Index()
        {
            var contexto = _context.Consulta.Include(c => c.Animal).Include(c => c.DataHora).Include(c => c.Medico).Include(c => c.Unidade);
            return View(await contexto.ToListAsync());
        }

        // GET: Consulta/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Consulta == null)
            {
                return NotFound();
            }

            var consultaModel = await _context.Consulta
                .Include(c => c.Animal)
                .Include(c => c.DataHora)
                .Include(c => c.Medico)
                .Include(c => c.Unidade)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (consultaModel == null)
            {
                return NotFound();
            }

            return View(consultaModel);
        }

        // GET: Consulta/Create
        public IActionResult Create()
        {
            ViewData["AnimalId"] = new SelectList(_context.Animal, "Id", "Nome");
            ViewData["DataConsultaId"] = new SelectList(_context.DataHora, "Id", "Id");
            ViewData["MedicoId"] = new SelectList(_context.Medico, "Id", "Id");
            ViewData["UnidadeId"] = new SelectList(_context.Unidade, "Id", "Id");
            return View();
        }

        // POST: Consulta/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DataConsultaId,StatusConsulta,UnidadeId,AnimalId,MedicoId")] ConsultaModel consultaModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(consultaModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AnimalId"] = new SelectList(_context.Animal, "Id", "Nome", consultaModel.AnimalId);
            ViewData["DataConsultaId"] = new SelectList(_context.DataHora, "Id", "Id", consultaModel.DataConsultaId);
            ViewData["MedicoId"] = new SelectList(_context.Medico, "Id", "Id", consultaModel.MedicoId);
            ViewData["UnidadeId"] = new SelectList(_context.Unidade, "Id", "Id", consultaModel.UnidadeId);
            return View(consultaModel);
        }

        // GET: Consulta/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Consulta == null)
            {
                return NotFound();
            }

            var consultaModel = await _context.Consulta.FindAsync(id);
            if (consultaModel == null)
            {
                return NotFound();
            }
            ViewData["AnimalId"] = new SelectList(_context.Animal, "Id", "Nome", consultaModel.AnimalId);
            ViewData["DataConsultaId"] = new SelectList(_context.DataHora, "Id", "Id", consultaModel.DataConsultaId);
            ViewData["MedicoId"] = new SelectList(_context.Medico, "Id", "Id", consultaModel.MedicoId);
            ViewData["UnidadeId"] = new SelectList(_context.Unidade, "Id", "Id", consultaModel.UnidadeId);
            return View(consultaModel);
        }

        // POST: Consulta/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DataConsultaId,StatusConsulta,UnidadeId,AnimalId,MedicoId")] ConsultaModel consultaModel)
        {
            if (id != consultaModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(consultaModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConsultaModelExists(consultaModel.Id))
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
            ViewData["AnimalId"] = new SelectList(_context.Animal, "Id", "Nome", consultaModel.AnimalId);
            ViewData["DataConsultaId"] = new SelectList(_context.DataHora, "Id", "Id", consultaModel.DataConsultaId);
            ViewData["MedicoId"] = new SelectList(_context.Medico, "Id", "Id", consultaModel.MedicoId);
            ViewData["UnidadeId"] = new SelectList(_context.Unidade, "Id", "Id", consultaModel.UnidadeId);
            return View(consultaModel);
        }

        // GET: Consulta/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Consulta == null)
            {
                return NotFound();
            }

            var consultaModel = await _context.Consulta
                .Include(c => c.Animal)
                .Include(c => c.DataHora)
                .Include(c => c.Medico)
                .Include(c => c.Unidade)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (consultaModel == null)
            {
                return NotFound();
            }

            return View(consultaModel);
        }

        // POST: Consulta/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Consulta == null)
            {
                return Problem("Entity set 'Contexto.Consulta'  is null.");
            }
            var consultaModel = await _context.Consulta.FindAsync(id);
            if (consultaModel != null)
            {
                _context.Consulta.Remove(consultaModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ConsultaModelExists(int id)
        {
            return (_context.Consulta?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
