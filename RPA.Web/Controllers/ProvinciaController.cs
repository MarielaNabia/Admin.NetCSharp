using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RPA.Web;

namespace RPA.Web.Controllers
{
    public class ProvinciaController : Controller
    {
        private readonly RPADBContext _context;

        public ProvinciaController(RPADBContext context)
        {
            _context = context;
        }

        // GET: Provincia
        /*public async Task<IActionResult> Index()
        {
              return View(await _context.Provincias.ToListAsync());
        }*/

        /*public async Task<IActionResult> Index(string filter)
        {
            var results = from Provincia in _context.Provincias select Provincia;
            if (!string.IsNullOrEmpty(filter))
            {
                results = results.Where(x => x.Nombre!.Contains(filter));
            }
            return View(await results.ToListAsync());
        }*/

        public async Task<IActionResult> Index(string filter, string sortOrder)
        {
            ViewData["NombreSortParm"] = String.IsNullOrEmpty(sortOrder) ? "nombre_desc" : "";
            var results = from Provincia in _context.Provincias select Provincia;
            if (!string.IsNullOrEmpty(filter))
            {
                results = results.Where(x => x.Nombre!.Contains(filter));
            }
            switch (sortOrder)
            {
                case "nombre_desc":
                    results = results.OrderByDescending(r => r.Nombre);
                    break;
               
                default:
                    results = results.OrderBy(r => r.Nombre);
                    break;
            }
            return View(await results.AsNoTracking().ToListAsync());
        }

        // GET: Provincia/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Provincias == null)
            {
                return NotFound();
            }

            var provincia = await _context.Provincias
                .FirstOrDefaultAsync(m => m.Id == id);
            if (provincia == null)
            {
                return NotFound();
            }

            return View(provincia);
        }

        // GET: Provincia/Create
        public IActionResult Create()
        {
           
            return View();
        }

        // POST: Provincia/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre")] Provincia provincia)
        {
            if (ModelState.IsValid)
            {
                _context.Add(provincia);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(provincia);
        }

        // GET: Provincia/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Provincias == null)
            {
                return NotFound();
            }

            var provincia = await _context.Provincias.FindAsync(id);
            if (provincia == null)
            {
                return NotFound();
            }
            return View(provincia);
        }

        // POST: Provincia/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre")] Provincia provincia)
        {
            if (id != provincia.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(provincia);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProvinciaExists(provincia.Id))
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
            return View(provincia);
        }

        // GET: Provincia/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Provincias == null)
            {
                return NotFound();
            }

            var provincia = await _context.Provincias
                .FirstOrDefaultAsync(m => m.Id == id);
            if (provincia == null)
            {
                return NotFound();
            }

            return View(provincia);
        }

        // POST: Provincia/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Provincias == null)
            {
                return Problem("Entity set 'RPADBContext.Provincias'  is null.");
            }
            var provincia = await _context.Provincias.FindAsync(id);
            if (provincia != null)
            {
                _context.Provincias.Remove(provincia);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProvinciaExists(int id)
        {
          return _context.Provincias.Any(e => e.Id == id);
        }
    }
}
