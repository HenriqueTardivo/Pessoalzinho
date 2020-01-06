using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Pessoalzinho.Data;
using Pessoalzinho.Models;

namespace Pessoalzinho.Controllers
{
    public class GentesController : Controller
    {
        private readonly PessoalzinhoContext _context;

        public GentesController(PessoalzinhoContext context)
        {
            _context = context;
        }

        // GET: Gentes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Gente.ToListAsync());
        }

        // GET: Gentes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gente = await _context.Gente
                .FirstOrDefaultAsync(m => m.Id == id);
            if (gente == null)
            {
                return NotFound();
            }

            return View(gente);
        }

        // GET: Gentes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Gentes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome")] Gente gente)
        {
            if (ModelState.IsValid)
            {
                _context.Add(gente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(gente);
        }

        // GET: Gentes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gente = await _context.Gente.FindAsync(id);
            if (gente == null)
            {
                return NotFound();
            }
            return View(gente);
        }

        // POST: Gentes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome")] Gente gente)
        {
            if (id != gente.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(gente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GenteExists(gente.Id))
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
            return View(gente);
        }

        // GET: Gentes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gente = await _context.Gente
                .FirstOrDefaultAsync(m => m.Id == id);
            if (gente == null)
            {
                return NotFound();
            }

            return View(gente);
        }

        // POST: Gentes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var gente = await _context.Gente.FindAsync(id);
            _context.Gente.Remove(gente);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GenteExists(int id)
        {
            return _context.Gente.Any(e => e.Id == id);
        }
    }
}
