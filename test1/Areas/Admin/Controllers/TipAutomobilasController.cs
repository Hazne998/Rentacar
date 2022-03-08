using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RentaCar.Data;
using RentaCar.Entities;

namespace RentaCar.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TipAutomobilasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TipAutomobilasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/TipAutomobilas
        public async Task<IActionResult> Index()
        {
            return View(await _context.TipAutomobilas.ToListAsync());
        }

        // GET: Admin/TipAutomobilas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipAutomobila = await _context.TipAutomobilas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipAutomobila == null)
            {
                return NotFound();
            }

            return View(tipAutomobila);
        }

        // GET: Admin/TipAutomobilas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/TipAutomobilas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Ime,Opis")] TipAutomobila tipAutomobila)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipAutomobila);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipAutomobila);
        }

        // GET: Admin/TipAutomobilas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipAutomobila = await _context.TipAutomobilas.FindAsync(id);
            if (tipAutomobila == null)
            {
                return NotFound();
            }
            return View(tipAutomobila);
        }

        // POST: Admin/TipAutomobilas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Ime,Opis")] TipAutomobila tipAutomobila)
        {
            if (id != tipAutomobila.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipAutomobila);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipAutomobilaExists(tipAutomobila.Id))
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
            return View(tipAutomobila);
        }

        // GET: Admin/TipAutomobilas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipAutomobila = await _context.TipAutomobilas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipAutomobila == null)
            {
                return NotFound();
            }

            return View(tipAutomobila);
        }

        // POST: Admin/TipAutomobilas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tipAutomobila = await _context.TipAutomobilas.FindAsync(id);
            _context.TipAutomobilas.Remove(tipAutomobila);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipAutomobilaExists(int id)
        {
            return _context.TipAutomobilas.Any(e => e.Id == id);
        }
    }
}
