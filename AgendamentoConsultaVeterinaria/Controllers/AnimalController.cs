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
    public class AnimalController : Controller
    {
        private readonly Contexto _context;

        public AnimalController(Contexto context)
        {
            _context = context;
        }

        // GET: Animal
        public async Task<IActionResult> Index()
        {
            var contexto = _context.Animal.Include(a => a.Cliente);
            return View(await contexto.ToListAsync());
        }

        // GET: Animal/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Animal == null)
            {
                return NotFound();
            }

            var animalModel = await _context.Animal
                .Include(a => a.Cliente)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (animalModel == null)
            {
                return NotFound();
            }

            return View(animalModel);
        }

        // GET: Animal/Create
        public IActionResult Create()
        {
            ViewData["ClienteId"] = new SelectList(_context.Cliente, "Id", "Nome");
            return View();
        }

        // POST: Animal/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,TipoAnimal,Raca,Sexo,DataNascimento,Peso,Castrado,ClienteId")] AnimalModel animalModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(animalModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClienteId"] = new SelectList(_context.Cliente, "Id", "Nome", animalModel.ClienteId);
            return View(animalModel);
        }

        // GET: Animal/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Animal == null)
            {
                return NotFound();
            }

            var animalModel = await _context.Animal.FindAsync(id);
            if (animalModel == null)
            {
                return NotFound();
            }
            ViewData["ClienteId"] = new SelectList(_context.Cliente, "Id", "Nome", animalModel.ClienteId);
            return View(animalModel);
        }

        // POST: Animal/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,TipoAnimal,Raca,Sexo,DataNascimento,Peso,Castrado,ClienteId")] AnimalModel animalModel)
        {
            if (id != animalModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(animalModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AnimalModelExists(animalModel.Id))
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
            ViewData["ClienteId"] = new SelectList(_context.Cliente, "Id", "Nome", animalModel.ClienteId);
            return View(animalModel);
        }

        // GET: Animal/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Animal == null)
            {
                return NotFound();
            }

            var animalModel = await _context.Animal
                .Include(a => a.Cliente)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (animalModel == null)
            {
                return NotFound();
            }

            return View(animalModel);
        }

        // POST: Animal/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Animal == null)
            {
                return Problem("Entity set 'Contexto.Animal'  is null.");
            }
            var animalModel = await _context.Animal.FindAsync(id);
            if (animalModel != null)
            {
                _context.Animal.Remove(animalModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AnimalModelExists(int id)
        {
            return (_context.Animal?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
