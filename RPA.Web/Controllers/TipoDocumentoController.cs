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
    public class TipoDocumentoController : Controller
    {
        private readonly RPADBContext _context;

        public TipoDocumentoController(RPADBContext context)
        {
            _context = context;
        }

        // GET: TipoDocumento
        /*public async Task<IActionResult> Index()
        {
              return View(await _context.TipoDocumentos.ToListAsync());
        }
        */

        /*public async Task<IActionResult> Index(string filter)
        {
            var results = from TipoDocumento in _context.TipoDocumentos select TipoDocumento;
            if (!string.IsNullOrEmpty(filter))
            {
                results = results.Where(x => x.Descripcion!.Contains(filter));
            }
            return View(await results.ToListAsync());
        }*/

        public async Task<IActionResult> Index(string filter, string sortOrder)
        {
            ViewData["CodigoSortParm"] = String.IsNullOrEmpty(sortOrder) ? "codigo_desc" : "";
            ViewData["DescripcionSortParm"] = sortOrder == "descripcion" ? "descripcion_desc" : "descripcion";
            var results = from TipoDocumento in _context.TipoDocumentos select TipoDocumento;
            if (!string.IsNullOrEmpty(filter))
            {
                results = results.Where(x => x.Descripcion!.Contains(filter));
            }
            switch (sortOrder)
            {
                case "codigo_desc":
                    results = results.OrderByDescending(r => r.Codigo);
                    break;
                case "descripcion":
                    results = results.OrderBy(r => r.Descripcion);
                    break;
                case "descripcion_desc":
                    results = results.OrderByDescending(r => r.Descripcion);
                    break;
                default:
                    results = results.OrderBy(r => r.Codigo);
                    break;
            }
            return View(await results.AsNoTracking().ToListAsync());
        }

        // GET: TipoDocumento/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TipoDocumentos == null)
            {
                return NotFound();
            }

            var tipoDocumento = await _context.TipoDocumentos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipoDocumento == null)
            {
                return NotFound();
            }

            return View(tipoDocumento);
        }

        // GET: TipoDocumento/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoDocumento/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Codigo,Descripcion")] TipoDocumento tipoDocumento)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoDocumento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoDocumento);
        }

        // GET: TipoDocumento/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TipoDocumentos == null)
            {
                return NotFound();
            }

            var tipoDocumento = await _context.TipoDocumentos.FindAsync(id);
            if (tipoDocumento == null)
            {
                return NotFound();
            }
            return View(tipoDocumento);
        }

        // POST: TipoDocumento/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Codigo,Descripcion")] TipoDocumento tipoDocumento)
        {
            if (id != tipoDocumento.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoDocumento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoDocumentoExists(tipoDocumento.Id))
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
            return View(tipoDocumento);
        }

        // GET: TipoDocumento/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TipoDocumentos == null)
            {
                return NotFound();
            }

            var tipoDocumento = await _context.TipoDocumentos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipoDocumento == null)
            {
                return NotFound();
            }

            return View(tipoDocumento);
        }

        // POST: TipoDocumento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TipoDocumentos == null)
            {
                return Problem("Entity set 'RPADBContext.TipoDocumentos'  is null.");
            }
            var tipoDocumento = await _context.TipoDocumentos.FindAsync(id);
            if (tipoDocumento != null)
            {
                _context.TipoDocumentos.Remove(tipoDocumento);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoDocumentoExists(int id)
        {
          return _context.TipoDocumentos.Any(e => e.Id == id);
        }
    }
}
