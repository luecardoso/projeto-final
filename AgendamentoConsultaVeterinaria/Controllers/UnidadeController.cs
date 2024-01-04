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
    public class UnidadeController : Controller
    {
        private readonly Contexto _context;

        public UnidadeController(Contexto context)
        {
            _context = context;
        }

        // GET: Unidade
        public async Task<IActionResult> Index()
        {
            var contexto = _context.Unidade.Include(u => u.Endereco);
            return View(await contexto.ToListAsync());
        }

        // GET: Unidade/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Unidade == null)
            {
                return NotFound();
            }

            var unidadeModel = await _context.Unidade
                .Include(u => u.Endereco)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (unidadeModel == null)
            {
                return NotFound();
            }

            return View(unidadeModel);
        }

        // GET: Unidade/Create
        public IActionResult Create()
        {
            ViewData["EnderecoId"] = new SelectList(_context.Endereco, "Id", "Cep");
            return View();
        }

        // POST: Unidade/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,HoraId,Telefone,EnderecoId")] UnidadeModel unidadeModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(unidadeModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EnderecoId"] = new SelectList(_context.Endereco, "Id", "Cep", unidadeModel.EnderecoId);
            return View(unidadeModel);
        }

        // GET: Unidade/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Unidade == null)
            {
                return NotFound();
            }

            var unidadeModel = await _context.Unidade.FindAsync(id);
            if (unidadeModel == null)
            {
                return NotFound();
            }
            ViewData["EnderecoId"] = new SelectList(_context.Endereco, "Id", "Cep", unidadeModel.EnderecoId);
            return View(unidadeModel);
        }

        // POST: Unidade/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,HoraId,Telefone,EnderecoId")] UnidadeModel unidadeModel)
        {
            if (id != unidadeModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(unidadeModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UnidadeModelExists(unidadeModel.Id))
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
            ViewData["EnderecoId"] = new SelectList(_context.Endereco, "Id", "Cep", unidadeModel.EnderecoId);
            return View(unidadeModel);
        }

        // GET: Unidade/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Unidade == null)
            {
                return NotFound();
            }

            var unidadeModel = await _context.Unidade
                .Include(u => u.Endereco)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (unidadeModel == null)
            {
                return NotFound();
            }

            return View(unidadeModel);
        }

        // POST: Unidade/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Unidade == null)
            {
                return Problem("Entity set 'Contexto.Unidade'  is null.");
            }
            var unidadeModel = await _context.Unidade.FindAsync(id);
            if (unidadeModel != null)
            {
                _context.Unidade.Remove(unidadeModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UnidadeModelExists(int id)
        {
          return (_context.Unidade?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
