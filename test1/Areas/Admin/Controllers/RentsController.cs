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
    public class RentsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/Rents
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Rents.Include(r => r.Automobil).Include(r => r.Status);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Admin/Rents/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rent = await _context.Rents
                .Include(r => r.Automobil)
                .Include(r => r.Status)
                .FirstOrDefaultAsync(m => m.RentId == id);
            if (rent == null)
            {
                return NotFound();
            }

            return View(rent);
        }

        // GET: Admin/Rents/Create
        public IActionResult Create()
        {
            ViewData["AutomobilId"] = new SelectList(_context.Automobils, "Id", "Tablice");
            ViewData["StatusId"] = new SelectList(_context.Statuses, "Id", "Code");
            return View();
        }

        // POST: Admin/Rents/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RentId,DatumPocetka,DatumZavrsetka,StatusId,AutomobilId")] Rent rent)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rent);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AutomobilId"] = new SelectList(_context.Automobils, "Id", "Tablice", rent.AutomobilId);
            ViewData["StatusId"] = new SelectList(_context.Statuses, "Id", "Code", rent.StatusId);
            return View(rent);
        }

        // GET: Admin/Rents/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rent = await _context.Rents.FindAsync(id);
            if (rent == null)
            {
                return NotFound();
            }
            ViewData["AutomobilId"] = new SelectList(_context.Automobils, "Id", "Tablice", rent.AutomobilId);
            ViewData["StatusId"] = new SelectList(_context.Statuses, "Id", "Code", rent.StatusId);
            return View(rent);
        }

        // POST: Admin/Rents/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RentId,DatumPocetka,DatumZavrsetka,StatusId,AutomobilId")] Rent rent)
        {
            if (id != rent.RentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rent);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RentExists(rent.RentId))
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
            ViewData["AutomobilId"] = new SelectList(_context.Automobils, "Id", "Tablice", rent.AutomobilId);
            ViewData["StatusId"] = new SelectList(_context.Statuses, "Id", "Code", rent.StatusId);
            return View(rent);
        }

        // GET: Admin/Rents/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rent = await _context.Rents
                .Include(r => r.Automobil)
                .Include(r => r.Status)
                .FirstOrDefaultAsync(m => m.RentId == id);
            if (rent == null)
            {
                return NotFound();
            }

            return View(rent);
        }

        // POST: Admin/Rents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rent = await _context.Rents.FindAsync(id);
            _context.Rents.Remove(rent);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RentExists(int id)
        {
            return _context.Rents.Any(e => e.RentId == id);
        }
    }
}
