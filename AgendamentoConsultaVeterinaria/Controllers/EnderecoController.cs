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
    public class EnderecoController : Controller
    {
        private readonly Contexto _context;

        public EnderecoController(Contexto context)
        {
            _context = context;
        }

        // GET: Endereco
        public async Task<IActionResult> Index()
        {
              return _context.Endereco != null ? 
                          View(await _context.Endereco.ToListAsync()) :
                          Problem("Entity set 'Contexto.Endereco'  is null.");
        }

        // GET: Endereco/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Endereco == null)
            {
                return NotFound();
            }

            var enderecoModel = await _context.Endereco
                .FirstOrDefaultAsync(m => m.Id == id);
            if (enderecoModel == null)
            {
                return NotFound();
            }

            return View(enderecoModel);
        }

        // GET: Endereco/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Endereco/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Cep,Logradouro,Bairro,Localidade,Uf,Numero,Complemento")] EnderecoModel enderecoModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(enderecoModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(enderecoModel);
        }

        // GET: Endereco/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Endereco == null)
            {
                return NotFound();
            }

            var enderecoModel = await _context.Endereco.FindAsync(id);
            if (enderecoModel == null)
            {
                return NotFound();
            }
            return View(enderecoModel);
        }

        // POST: Endereco/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Cep,Logradouro,Bairro,Localidade,Uf,Numero,Complemento")] EnderecoModel enderecoModel)
        {
            if (id != enderecoModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(enderecoModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EnderecoModelExists(enderecoModel.Id))
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
            return View(enderecoModel);
        }

        // GET: Endereco/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Endereco == null)
            {
                return NotFound();
            }

            var enderecoModel = await _context.Endereco
                .FirstOrDefaultAsync(m => m.Id == id);
            if (enderecoModel == null)
            {
                return NotFound();
            }

            return View(enderecoModel);
        }

        // POST: Endereco/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Endereco == null)
            {
                return Problem("Entity set 'Contexto.Endereco'  is null.");
            }
            var enderecoModel = await _context.Endereco.FindAsync(id);
            if (enderecoModel != null)
            {
                _context.Endereco.Remove(enderecoModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EnderecoModelExists(int id)
        {
          return (_context.Endereco?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
