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
    public class AutomobilsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AutomobilsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/Automobils
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Automobils.Include(a => a.Lokacija).Include(a => a.Model).Include(a => a.TipAutomobila);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Admin/Automobils/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var automobil = await _context.Automobils
                .Include(a => a.Lokacija)
                .Include(a => a.Model)
                .Include(a => a.TipAutomobila)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (automobil == null)
            {
                return NotFound();
            }

            return View(automobil);
        }

        // GET: Admin/Automobils/Create
        public IActionResult Create()
        {
            ViewData["LokacijaId"] = new SelectList(_context.Lokacijas, "Id", "Code");
            ViewData["ModelId"] = new SelectList(_context.Models, "Id", "Ime");
            ViewData["TipAutomobilaId"] = new SelectList(_context.TipAutomobilas, "Id", "Ime");
            return View();
        }

        // POST: Admin/Automobils/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Tablice,ModelId,TipAutomobilaId,LokacijaId")] Automobil automobil)
        {
            if (ModelState.IsValid)
            {
                _context.Add(automobil);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["LokacijaId"] = new SelectList(_context.Lokacijas, "Id", "Code", automobil.LokacijaId);
            ViewData["ModelId"] = new SelectList(_context.Models, "Id", "Ime", automobil.ModelId);
            ViewData["TipAutomobilaId"] = new SelectList(_context.TipAutomobilas, "Id", "Ime", automobil.TipAutomobilaId);
            return View(automobil);
        }

        // GET: Admin/Automobils/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var automobil = await _context.Automobils.FindAsync(id);
            if (automobil == null)
            {
                return NotFound();
            }
            ViewData["LokacijaId"] = new SelectList(_context.Lokacijas, "Id", "Code", automobil.LokacijaId);
            ViewData["ModelId"] = new SelectList(_context.Models, "Id", "Ime", automobil.ModelId);
            ViewData["TipAutomobilaId"] = new SelectList(_context.TipAutomobilas, "Id", "Ime", automobil.TipAutomobilaId);
            return View(automobil);
        }

        // POST: Admin/Automobils/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Tablice,ModelId,TipAutomobilaId,LokacijaId")] Automobil automobil)
        {
            if (id != automobil.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(automobil);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AutomobilExists(automobil.Id))
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
            ViewData["LokacijaId"] = new SelectList(_context.Lokacijas, "Id", "Code", automobil.LokacijaId);
            ViewData["ModelId"] = new SelectList(_context.Models, "Id", "Ime", automobil.ModelId);
            ViewData["TipAutomobilaId"] = new SelectList(_context.TipAutomobilas, "Id", "Ime", automobil.TipAutomobilaId);
            return View(automobil);
        }

        // GET: Admin/Automobils/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var automobil = await _context.Automobils
                .Include(a => a.Lokacija)
                .Include(a => a.Model)
                .Include(a => a.TipAutomobila)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (automobil == null)
            {
                return NotFound();
            }

            return View(automobil);
        }

        // POST: Admin/Automobils/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var automobil = await _context.Automobils.FindAsync(id);
            _context.Automobils.Remove(automobil);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AutomobilExists(int id)
        {
            return _context.Automobils.Any(e => e.Id == id);
        }
    }
}
