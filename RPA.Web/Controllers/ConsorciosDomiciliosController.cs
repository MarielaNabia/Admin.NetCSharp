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
    public class ConsorciosDomiciliosController : Controller
    {
        private readonly RPADBContext _context;

        public ConsorciosDomiciliosController(RPADBContext context)
        {
            _context = context;
        }

        // GET: ConsorciosDomicilios
        public async Task<IActionResult> Index()
        {
            var rPADBContext = _context.ConsorciosDomicilios.Include(c => c.Consorcio).Include(c => c.Domicilio).Include(c => c.TipoDomicilio);
            return View(await rPADBContext.ToListAsync());
        }

        //public async Task<IActionResult> Index(string filter)
        //{
        //    var results = from ConsorcioDomicilio in _context.ConsorciosDomicilios select ConsorcioDomicilio;
        //    if (!string.IsNullOrEmpty(filter))
        //    {
        //        results = results.Where(x => x.Domicilio!.Contains(filter));
        //    }
        //    return View(await results.ToListAsync());
        //}

        // GET: ConsorciosDomicilios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ConsorciosDomicilios == null)
            {
                return NotFound();
            }

            var consorcioDomicilio = await _context.ConsorciosDomicilios
                .Include(c => c.Consorcio)
                .Include(c => c.Domicilio)
                .Include(c => c.TipoDomicilio)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (consorcioDomicilio == null)
            {
                return NotFound();
            }

            return View(consorcioDomicilio);
        }

        // GET: ConsorciosDomicilios/Create
        public IActionResult Create()
        {
            ViewData["ConsorcioId"] = new SelectList(_context.Consorcios, "Id", "Id");
            ViewData["DomicilioId"] = new SelectList(_context.Domicilios, "Id", "Id");
            ViewData["TipoDomicilioId"] = new SelectList(_context.TipoDomicilios, "Id", "Id");
            return View();
        }

        // POST: ConsorciosDomicilios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ConsorcioId,DomicilioId,TipoDomicilioId,FechaAlta,FechaBaja")] ConsorcioDomicilio consorcioDomicilio)
        {
            if (ModelState.IsValid)
            {
                _context.Add(consorcioDomicilio);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ConsorcioId"] = new SelectList(_context.Consorcios, "Id", "Id", consorcioDomicilio.ConsorcioId);
            ViewData["DomicilioId"] = new SelectList(_context.Domicilios, "Id", "Id", consorcioDomicilio.DomicilioId);
            ViewData["TipoDomicilioId"] = new SelectList(_context.TipoDomicilios, "Id", "Id", consorcioDomicilio.TipoDomicilioId);
            return View(consorcioDomicilio);
        }

        // GET: ConsorciosDomicilios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ConsorciosDomicilios == null)
            {
                return NotFound();
            }

            var consorcioDomicilio = await _context.ConsorciosDomicilios.FindAsync(id);
            if (consorcioDomicilio == null)
            {
                return NotFound();
            }
            ViewData["ConsorcioId"] = new SelectList(_context.Consorcios, "Id", "Id", consorcioDomicilio.ConsorcioId);
            ViewData["DomicilioId"] = new SelectList(_context.Domicilios, "Id", "Id", consorcioDomicilio.DomicilioId);
            ViewData["TipoDomicilioId"] = new SelectList(_context.TipoDomicilios, "Id", "Id", consorcioDomicilio.TipoDomicilioId);
            return View(consorcioDomicilio);
        }

        // POST: ConsorciosDomicilios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ConsorcioId,DomicilioId,TipoDomicilioId,FechaAlta,FechaBaja")] ConsorcioDomicilio consorcioDomicilio)
        {
            if (id != consorcioDomicilio.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(consorcioDomicilio);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConsorcioDomicilioExists(consorcioDomicilio.Id))
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
            ViewData["ConsorcioId"] = new SelectList(_context.Consorcios, "Id", "Id", consorcioDomicilio.ConsorcioId);
            ViewData["DomicilioId"] = new SelectList(_context.Domicilios, "Id", "Id", consorcioDomicilio.DomicilioId);
            ViewData["TipoDomicilioId"] = new SelectList(_context.TipoDomicilios, "Id", "Id", consorcioDomicilio.TipoDomicilioId);
            return View(consorcioDomicilio);
        }

        // GET: ConsorciosDomicilios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ConsorciosDomicilios == null)
            {
                return NotFound();
            }

            var consorcioDomicilio = await _context.ConsorciosDomicilios
                .Include(c => c.Consorcio)
                .Include(c => c.Domicilio)
                .Include(c => c.TipoDomicilio)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (consorcioDomicilio == null)
            {
                return NotFound();
            }

            return View(consorcioDomicilio);
        }

        // POST: ConsorciosDomicilios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ConsorciosDomicilios == null)
            {
                return Problem("Entity set 'RPADBContext.ConsorciosDomicilios'  is null.");
            }
            var consorcioDomicilio = await _context.ConsorciosDomicilios.FindAsync(id);
            if (consorcioDomicilio != null)
            {
                _context.ConsorciosDomicilios.Remove(consorcioDomicilio);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ConsorcioDomicilioExists(int id)
        {
          return _context.ConsorciosDomicilios.Any(e => e.Id == id);
        }
    }
}
