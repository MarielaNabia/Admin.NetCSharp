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
    public class TipoPersonaController : Controller
    {
        private readonly RPADBContext _context;

        public TipoPersonaController(RPADBContext context)
        {
            _context = context;
        }

        // GET: TipoPersona
        /*public async Task<IActionResult> Index()
        {
              return View(await _context.TipoPersonas.ToListAsync());
        }*/

        public async Task<IActionResult> Index(string filter)
        {
            var results = from TipoPersona in _context.TipoPersonas select TipoPersona;
            if (!string.IsNullOrEmpty(filter))
            {
                results = results.Where(x => x.Descripcion!.Contains(filter));
            }
            return View(await results.ToListAsync());
        }

        // GET: TipoPersona/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TipoPersonas == null)
            {
                return NotFound();
            }

            var tipoPersona = await _context.TipoPersonas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipoPersona == null)
            {
                return NotFound();
            }

            return View(tipoPersona);
        }

        // GET: TipoPersona/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoPersona/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Descripcion")] TipoPersona tipoPersona)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoPersona);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoPersona);
        }

        // GET: TipoPersona/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TipoPersonas == null)
            {
                return NotFound();
            }

            var tipoPersona = await _context.TipoPersonas.FindAsync(id);
            if (tipoPersona == null)
            {
                return NotFound();
            }
            return View(tipoPersona);
        }

        // POST: TipoPersona/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Descripcion")] TipoPersona tipoPersona)
        {
            if (id != tipoPersona.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoPersona);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoPersonaExists(tipoPersona.Id))
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
            return View(tipoPersona);
        }

        // GET: TipoPersona/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TipoPersonas == null)
            {
                return NotFound();
            }

            var tipoPersona = await _context.TipoPersonas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipoPersona == null)
            {
                return NotFound();
            }

            return View(tipoPersona);
        }

        // POST: TipoPersona/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TipoPersonas == null)
            {
                return Problem("Entity set 'RPADBContext.TipoPersonas'  is null.");
            }
            var tipoPersona = await _context.TipoPersonas.FindAsync(id);
            if (tipoPersona != null)
            {
                _context.TipoPersonas.Remove(tipoPersona);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoPersonaExists(int id)
        {
          return _context.TipoPersonas.Any(e => e.Id == id);
        }
    }
}
