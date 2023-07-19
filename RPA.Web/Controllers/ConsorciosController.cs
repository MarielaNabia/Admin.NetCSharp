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
    public class ConsorciosController : Controller
    {
        private readonly RPADBContext _context;

        public ConsorciosController(RPADBContext context)
        {
            _context = context;
        }

        // GET: Consorcios
        /*public async Task<IActionResult> Index()
        {
              return View(await _context.Consorcios.ToListAsync());
        }*/
        public async Task<IActionResult> Index(string filter)
        {
            var results = from Consorcios in _context.Consorcios select Consorcios;
            if (!string.IsNullOrEmpty(filter))
            {
                results = results.Where(x => x.Denominacion!.Contains(filter));
            }
            return View(await results.ToListAsync());
        }


        // GET: Consorcios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Consorcios == null)
            {
                return NotFound();
            }

            var consorcio = await _context.Consorcios
                .FirstOrDefaultAsync(m => m.Id == id);
            if (consorcio == null)
            {
                return NotFound();
            }

            return View(consorcio);
        }

        // GET: Consorcios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Consorcios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Cuit,Denominacion,FechaAlta,FechaBaja")] Consorcio consorcio)
        {
            if (ModelState.IsValid)
            {
                _context.Add(consorcio);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(consorcio);
        }

        // GET: Consorcios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Consorcios == null)
            {
                return NotFound();
            }

            var consorcio = await _context.Consorcios.FindAsync(id);
            if (consorcio == null)
            {
                return NotFound();
            }
            return View(consorcio);
        }

        // POST: Consorcios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Cuit,Denominacion,FechaAlta,FechaBaja")] Consorcio consorcio)
        {
            if (id != consorcio.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(consorcio);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConsorcioExists(consorcio.Id))
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
            return View(consorcio);
        }

        // GET: Consorcios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Consorcios == null)
            {
                return NotFound();
            }

            var consorcio = await _context.Consorcios
                .FirstOrDefaultAsync(m => m.Id == id);
            if (consorcio == null)
            {
                return NotFound();
            }

            return View(consorcio);
        }

        // POST: Consorcios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Consorcios == null)
            {
                return Problem("Entity set 'RPADBContext.Consorcios'  is null.");
            }
            var consorcio = await _context.Consorcios.FindAsync(id);
            if (consorcio != null)
            {
                _context.Consorcios.Remove(consorcio);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ConsorcioExists(int id)
        {
          return _context.Consorcios.Any(e => e.Id == id);
        }
    }
}
