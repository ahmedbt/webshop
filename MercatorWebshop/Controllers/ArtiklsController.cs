using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MercatorWebshop.Data;
using MercatorWebshop.Models;

namespace MercatorWebshop.Controllers
{
    public class ArtiklsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ArtiklsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Artikls
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Artikl.Include(a => a.Prodavnica);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Artikls/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Artikl == null)
            {
                return NotFound();
            }

            var artikl = await _context.Artikl
                .Include(a => a.Prodavnica)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (artikl == null)
            {
                return NotFound();
            }

            return View(artikl);
        }

        // GET: Artikls/Create
        public IActionResult Create()
        {
            ViewData["ProdavnicaID"] = new SelectList(_context.Set<Prodavnica>(), "ID", "ID");
            return View();
        }

        // POST: Artikls/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Naziv,Cijena,Kolicina,ProdavnicaID")] Artikl artikl)
        {
           // if (ModelState.IsValid)
            {
                _context.Add(artikl);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProdavnicaID"] = new SelectList(_context.Set<Prodavnica>(), "ID", "ID", artikl.ProdavnicaID);
            return View(artikl);
        }

        // GET: Artikls/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Artikl == null)
            {
                return NotFound();
            }

            var artikl = await _context.Artikl.FindAsync(id);
            if (artikl == null)
            {
                return NotFound();
            }
            ViewData["ProdavnicaID"] = new SelectList(_context.Set<Prodavnica>(), "ID", "ID", artikl.ProdavnicaID);
            return View(artikl);
        }

        // POST: Artikls/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Naziv,Cijena,Kolicina,ProdavnicaID")] Artikl artikl)
        {
            if (id != artikl.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(artikl);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArtiklExists(artikl.ID))
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
            ViewData["ProdavnicaID"] = new SelectList(_context.Set<Prodavnica>(), "ID", "ID", artikl.ProdavnicaID);
            return View(artikl);
        }

        // GET: Artikls/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Artikl == null)
            {
                return NotFound();
            }

            var artikl = await _context.Artikl
                .Include(a => a.Prodavnica)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (artikl == null)
            {
                return NotFound();
            }

            return View(artikl);
        }

        // POST: Artikls/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Artikl == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Artikl'  is null.");
            }
            var artikl = await _context.Artikl.FindAsync(id);
            if (artikl != null)
            {
                _context.Artikl.Remove(artikl);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ArtiklExists(int id)
        {
          return _context.Artikl.Any(e => e.ID == id);
        }
    }
}
