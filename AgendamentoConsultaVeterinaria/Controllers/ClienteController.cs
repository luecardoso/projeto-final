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
    public class ClienteController : Controller
    {
        private readonly Contexto _context;

        public ClienteController(Contexto context)
        {
            _context = context;
        }

        // GET: Cliente
        public async Task<IActionResult> Index()
        {
            var contexto = _context.Cliente.Include(c => c.Endereco);
            return View(await contexto.ToListAsync());
        }

        // GET: Cliente/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Cliente == null)
            {
                return NotFound();
            }

            var clienteModel = await _context.Cliente
                .Include(c => c.Endereco)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (clienteModel == null)
            {
                return NotFound();
            }

            return View(clienteModel);
        }

        // GET: Cliente/Create
        public IActionResult Create()
        {
            ViewData["EnderecoId"] = new SelectList(_context.Endereco, "Id", "Cep");
            return View();
        }

        // POST: Cliente/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Telefone,Email,Senha,EnderecoId")] ClienteModel clienteModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(clienteModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EnderecoId"] = new SelectList(_context.Endereco, "Id", "Cep", clienteModel.EnderecoId);
            return View(clienteModel);
        }

        // GET: Cliente/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Cliente == null)
            {
                return NotFound();
            }

            var clienteModel = await _context.Cliente.FindAsync(id);
            if (clienteModel == null)
            {
                return NotFound();
            }
            ViewData["EnderecoId"] = new SelectList(_context.Endereco, "Id", "Cep", clienteModel.EnderecoId);
            return View(clienteModel);
        }

        // POST: Cliente/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Telefone,Email,Senha,EnderecoId")] ClienteModel clienteModel)
        {
            if (id != clienteModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(clienteModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClienteModelExists(clienteModel.Id))
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
            ViewData["EnderecoId"] = new SelectList(_context.Endereco, "Id", "Cep", clienteModel.EnderecoId);
            return View(clienteModel);
        }

        // GET: Cliente/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Cliente == null)
            {
                return NotFound();
            }

            var clienteModel = await _context.Cliente
                .Include(c => c.Endereco)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (clienteModel == null)
            {
                return NotFound();
            }

            return View(clienteModel);
        }

        // POST: Cliente/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Cliente == null)
            {
                return Problem("Entity set 'Contexto.Cliente'  is null.");
            }
            var clienteModel = await _context.Cliente.FindAsync(id);
            if (clienteModel != null)
            {
                _context.Cliente.Remove(clienteModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClienteModelExists(int id)
        {
            return (_context.Cliente?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
