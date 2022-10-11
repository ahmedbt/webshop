using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MercatorWebshop.Data;
using MercatorWebshop.Models;
using MercatorWebshop.NewFolder;

namespace MercatorWebshop.Controllers
{
    public class ProdavnicasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProdavnicasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Prodavnicas
        public async Task<IActionResult> Index()
        {
              return View(await _context.Prodavnica.ToListAsync());
        }

        // GET: Prodavnicas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Prodavnica == null)
            {
                return NotFound();
            }

            var prodavnica = await _context.Prodavnica
                .FirstOrDefaultAsync(m => m.ID == id);
            if (prodavnica == null)
            {
                return NotFound();
            }

            return View(prodavnica);
        }

        // GET: Prodavnicas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Prodavnicas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Naziv,Adresa,Telefon")] Prodavnica prodavnica, Artikl a)
        {
            /*if (ModelState.IsValid)
            {*/

 Prodavnica p = new Prodavnica()
 {
     Naziv = prodavnica.Naziv,
     Telefon = prodavnica.Telefon,
     Adresa = prodavnica.Adresa
 };

 Artikl artikl = new Artikl()
 {
     Naziv = "cokolada",
     Cijena = (decimal)10.0,
     Kolicina = 2,
     Prodavnica = p
 };

     _context.Artikl.Add(artikl);


    await _context.SaveChangesAsync();
    return RedirectToAction(nameof(Index));
//}
return View(prodavnica);
}

// GET: Prodavnicas/Edit/5
public async Task<IActionResult> Edit(int? id)
{
if (id == null || _context.Prodavnica == null)
{
    return NotFound();
}

var prodavnica = await _context.Prodavnica.FindAsync(id);
if (prodavnica == null)
{
    return NotFound();
}
return View(prodavnica);
}

// POST: Prodavnicas/Edit/5
// To protect from overposting attacks, enable the specific properties you want to bind to.
// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
[HttpPost]
[ValidateAntiForgeryToken]
public async Task<IActionResult> Edit(int id, [Bind("ID,Naziv,Adresa,Telefon")] Prodavnica prodavnica)
{
if (id != prodavnica.ID)
{
    return NotFound();
}

if (ModelState.IsValid)
{
    try
    {
        _context.Update(prodavnica);
        await _context.SaveChangesAsync();
    }
    catch (DbUpdateConcurrencyException)
    {
        if (!ProdavnicaExists(prodavnica.ID))
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
return View(prodavnica);
}

// GET: Prodavnicas/Delete/5
public async Task<IActionResult> Delete(int? id)
{
if (id == null || _context.Prodavnica == null)
{
    return NotFound();
}

var prodavnica = await _context.Prodavnica
    .FirstOrDefaultAsync(m => m.ID == id);
if (prodavnica == null)
{
    return NotFound();
}

return View(prodavnica);
}

// POST: Prodavnicas/Delete/5
[HttpPost, ActionName("Delete")]
[ValidateAntiForgeryToken]
public async Task<IActionResult> DeleteConfirmed(int id)
{
if (_context.Prodavnica == null)
{
    return Problem("Entity set 'ApplicationDbContext.Prodavnica'  is null.");
}
var prodavnica = await _context.Prodavnica.FindAsync(id);
if (prodavnica != null)
{
    _context.Prodavnica.Remove(prodavnica);
}

await _context.SaveChangesAsync();
return RedirectToAction(nameof(Index));
}

private bool ProdavnicaExists(int id)
{
return _context.Prodavnica.Any(e => e.ID == id);
}
}
}
