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
    public class LocalidadesController : Controller
    {
        private readonly RPADBContext _context;

        public LocalidadesController(RPADBContext context)
        {
            _context = context;
        }

        // GET: Localidades
        /*
        public async Task<IActionResult> Index()
        {
            var rPADBContext = _context.Localidades.Include(l => l.Provincia);
            return View(await rPADBContext.ToListAsync());
        }
        */

        

        public async Task<IActionResult> Index(string filter, string sortOrder)
        {
            ViewData["NombreSortParm"] = String.IsNullOrEmpty(sortOrder) ? "nombre_desc" : "";
            ViewData["ProvinciaSortParm"] = sortOrder == "provincia" ? "provincia_desc" : "provincia";
                var results = from Localidades in _context.Localidades.Include(l => l.Provincia) select Localidades;
            if (!string.IsNullOrEmpty(filter))
            {
                results = results.Where(x => x.Nombre!.Contains(filter));
            }
            switch (sortOrder)
            {
                case "nombre_desc":
                    results = results.OrderByDescending(r => r.Nombre);
                    break;
                case "provincia":
                    results = results.OrderBy(r => r.Provincia.Nombre);
                    break;
                case "provincia_desc":
                    results = results.OrderByDescending(r => r.Provincia.Nombre);
                    break;

                    default:
                    results = results.OrderBy(r => r.Nombre);
                    break;
            }

            /*var results = from Localidades in _context.Localidades.Include(l => l.Provincia) select Localidades;
            if (!string.IsNullOrEmpty(filter))
            {
                results = results.Where(x => x.Nombre!.Contains(filter));
            }*/
            return View(await results.AsNoTracking().ToListAsync());
            
            
        }

        // GET: Localidades/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Localidades == null)
            {
                return NotFound();
            }

            var localidad = await _context.Localidades
                .Include(l => l.Provincia)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (localidad == null)
            {
                return NotFound();
            }

            return View(localidad);
        }

        // GET: Localidades/Create
        public IActionResult Create()
        {
            ViewData["selectListProvincias"] = new SelectList(_context.Provincias, "Id", "Nombre");

            
            return View();
        }

        // POST: Localidades/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,ProvinciaId")] Localidad localidad)
        {
            if (ModelState.IsValid)
            {
                _context.Add(localidad);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["selectListProvincias"] = new SelectList(_context.Provincias, "Id", "Nombre");
            return View(localidad);
        }

        // GET: Localidades/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Localidades == null)
            {
                return NotFound();
            }

            var localidad = await _context.Localidades.FindAsync(id);
            if (localidad == null)
            {
                return NotFound();
            }
            ViewData["selectListProvincias"] = new SelectList(_context.Provincias, "Id", "Nombre", localidad.ProvinciaId);
            return View(localidad);
        }

        // POST: Localidades/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,ProvinciaId")] Localidad localidad)
        {
            if (id != localidad.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(localidad);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LocalidadExists(localidad.Id))
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
            ViewData["selectListProvincias"] = new SelectList(_context.Provincias, "Id", "Nombre", localidad.ProvinciaId);
            return View(localidad);
        }

        // GET: Localidades/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Localidades == null)
            {
                return NotFound();
            }

            var localidad = await _context.Localidades
                .Include(l => l.Provincia)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (localidad == null)
            {
                return NotFound();
            }

            return View(localidad);
        }

        // POST: Localidades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Localidades == null)
            {
                return Problem("Entity set 'RPADBContext.Localidades'  is null.");
            }
            var localidad = await _context.Localidades.FindAsync(id);
            if (localidad != null)
            {
                _context.Localidades.Remove(localidad);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LocalidadExists(int id)
        {
            return _context.Localidades.Any(e => e.Id == id);
        }
    }
}
