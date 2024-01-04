using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AgendamentoConsultaVeterinaria.Context;
using AgendamentoConsultaVeterinaria.Models;

namespace AgendamentoConsultaVeterinaria.Controllers
{
    public class MedicoController : Controller
    {
        private readonly Contexto _context;

        public MedicoController(Contexto context)
        {
            _context = context;
        }

        // GET: Medico
        public async Task<IActionResult> Index()
        {
            var contexto = _context.Medico.Include(m => m.Unidade);
            return View(await contexto.ToListAsync());
        }

        // GET: Medico/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Medico == null)
            {
                return NotFound();
            }

            var medicoModel = await _context.Medico
                .Include(m => m.Unidade)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (medicoModel == null)
            {
                return NotFound();
            }

            return View(medicoModel);
        }

        // GET: Medico/Create
        public IActionResult Create()
        {
            ViewData["UnidadeId"] = new SelectList(_context.Unidade, "Id", "Id");
            return View();
        }

        // POST: Medico/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Email,Senha,Crmv,Descricao,UnidadeId")] MedicoModel medicoModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(medicoModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UnidadeId"] = new SelectList(_context.Unidade, "Id", "Id", medicoModel.UnidadeId);
            return View(medicoModel);
        }

        // GET: Medico/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Medico == null)
            {
                return NotFound();
            }

            var medicoModel = await _context.Medico.FindAsync(id);
            if (medicoModel == null)
            {
                return NotFound();
            }
            ViewData["UnidadeId"] = new SelectList(_context.Unidade, "Id", "Id", medicoModel.UnidadeId);
            return View(medicoModel);
        }

        // POST: Medico/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Email,Senha,Crmv,Descricao,UnidadeId")] MedicoModel medicoModel)
        {
            if (id != medicoModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(medicoModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MedicoModelExists(medicoModel.Id))
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
            ViewData["UnidadeId"] = new SelectList(_context.Unidade, "Id", "Id", medicoModel.UnidadeId);
            return View(medicoModel);
        }

        // GET: Medico/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Medico == null)
            {
                return NotFound();
            }

            var medicoModel = await _context.Medico
                .Include(m => m.Unidade)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (medicoModel == null)
            {
                return NotFound();
            }

            return View(medicoModel);
        }

        // POST: Medico/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Medico == null)
            {
                return Problem("Entity set 'Contexto.Medico'  is null.");
            }
            var medicoModel = await _context.Medico.FindAsync(id);
            if (medicoModel != null)
            {
                _context.Medico.Remove(medicoModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MedicoModelExists(int id)
        {
          return (_context.Medico?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
