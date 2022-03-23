using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using RentaCar.Data;
using RentaCar.Data.Migrations;
using RentaCar.Entities;
using RentaCar.Hubs;

namespace RentaCar.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AutomobilsController : Controller
    {
        private readonly ApplicationDbContext _context;
        IHubContext<MyHub> _hubContext;
        private readonly IWebHostEnvironment _hostEnvironment;

        public AutomobilsController(ApplicationDbContext context, IHubContext<MyHub> hubContext, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _hubContext = hubContext;
            this._hostEnvironment = hostEnvironment;
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
        public async Task<IActionResult> Create([Bind("Id,Tablice,ModelId,TipAutomobilaId,LokacijaId,SlikaFile")] Automobil automobil)
        {
            if (ModelState.IsValid)
            {
                string wwwRootPath = _hostEnvironment.WebRootPath;
                string fileName = Path.GetFileNameWithoutExtension(automobil.SlikaFile.FileName);
                string extension = Path.GetExtension(automobil.SlikaFile.FileName);
                automobil.Slika= fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                string path = Path.Combine(wwwRootPath + "/Image/Automobili/", fileName);
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await automobil.SlikaFile.CopyToAsync(fileStream);
                }

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
            await _hubContext.Clients.Group(User.Identity.Name).SendAsync("prijemPoruke", User.Identity.Name, "novo auto");
           
            return View(automobil);
        }

        // POST: Admin/Automobils/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Tablice,ModelId,TipAutomobilaId,LokacijaId,SlikaFile")] Automobil automobil)
        {
            if (id != automobil.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {

                try
                {
                    string wwwRootPath = _hostEnvironment.WebRootPath;
                    string fileName = Path.GetFileNameWithoutExtension(automobil.SlikaFile.FileName);
                    string extension = Path.GetExtension(automobil.SlikaFile.FileName);
                    automobil.Slika = fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                    string path = Path.Combine(wwwRootPath + "/Image/Automobili/", fileName);
                    using (var fileStream = new FileStream(path, FileMode.Create))
                    {
                        await automobil.SlikaFile.CopyToAsync(fileStream);
                    }

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


            var imagePath = Path.Combine(_hostEnvironment.WebRootPath, "image", automobil.Slika);
            if (System.IO.File.Exists(imagePath))
            {
                System.IO.File.Delete(imagePath);
            }

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
