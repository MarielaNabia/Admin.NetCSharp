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
    public class ConsorciosAdministradoresController : Controller
    {
        private readonly RPADBContext _context;

        public ConsorciosAdministradoresController(RPADBContext context)
        {
            _context = context;
        }

        // GET: ConsorciosAdministradores
        public async Task<IActionResult> Index()
        {
            var rPADBContext = _context.ConsorciosAdministradores.Include(c => c.Administrador).Include(c => c.Consorcio);
            return View(await rPADBContext.ToListAsync());
        }

        //public async Task<IActionResult> Index(string filter)
        //{
        //    var results = from ConsorcioAdministrador in _context.ConsorciosAdministradores select ConsorcioAdministrador;
        //    if (!string.IsNullOrEmpty(filter))
        //    {
        //        results = results.Where(x => x.!.Contains(filter));
        //    }
        //    return View(await results.ToListAsync());
        //}

        // GET: ConsorciosAdministradores/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ConsorciosAdministradores == null)
            {
                return NotFound();
            }

            var consorcioAdministrador = await _context.ConsorciosAdministradores
                .Include(c => c.Administrador)
                .Include(c => c.Consorcio)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (consorcioAdministrador == null)
            {
                return NotFound();
            }

            return View(consorcioAdministrador);
        }

        // GET: ConsorciosAdministradores/Create
        public IActionResult Create()
        {
            ViewData["AdministradorId"] = new SelectList(_context.Administradores, "Id", "Id");
            ViewData["ConsorcioId"] = new SelectList(_context.Consorcios, "Id", "Id");
            return View();
        }

        // POST: ConsorciosAdministradores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ConsorcioId,AdministradorId,FechaAlta,FechaBaja")] ConsorcioAdministrador consorcioAdministrador)
        {
            if (ModelState.IsValid)
            {
                _context.Add(consorcioAdministrador);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AdministradorId"] = new SelectList(_context.Administradores, "Id", "Id", consorcioAdministrador.AdministradorId);
            ViewData["ConsorcioId"] = new SelectList(_context.Consorcios, "Id", "Id", consorcioAdministrador.ConsorcioId);
            return View(consorcioAdministrador);
        }

        // GET: ConsorciosAdministradores/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ConsorciosAdministradores == null)
            {
                return NotFound();
            }

            var consorcioAdministrador = await _context.ConsorciosAdministradores.FindAsync(id);
            if (consorcioAdministrador == null)
            {
                return NotFound();
            }
            ViewData["AdministradorId"] = new SelectList(_context.Administradores, "Id", "Id", consorcioAdministrador.AdministradorId);
            ViewData["ConsorcioId"] = new SelectList(_context.Consorcios, "Id", "Id", consorcioAdministrador.ConsorcioId);
            return View(consorcioAdministrador);
        }

        // POST: ConsorciosAdministradores/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ConsorcioId,AdministradorId,FechaAlta,FechaBaja")] ConsorcioAdministrador consorcioAdministrador)
        {
            if (id != consorcioAdministrador.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(consorcioAdministrador);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConsorcioAdministradorExists(consorcioAdministrador.Id))
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
            ViewData["AdministradorId"] = new SelectList(_context.Administradores, "Id", "Id", consorcioAdministrador.AdministradorId);
            ViewData["ConsorcioId"] = new SelectList(_context.Consorcios, "Id", "Id", consorcioAdministrador.ConsorcioId);
            return View(consorcioAdministrador);
        }

        // GET: ConsorciosAdministradores/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ConsorciosAdministradores == null)
            {
                return NotFound();
            }

            var consorcioAdministrador = await _context.ConsorciosAdministradores
                .Include(c => c.Administrador)
                .Include(c => c.Consorcio)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (consorcioAdministrador == null)
            {
                return NotFound();
            }

            return View(consorcioAdministrador);
        }

        // POST: ConsorciosAdministradores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ConsorciosAdministradores == null)
            {
                return Problem("Entity set 'RPADBContext.ConsorciosAdministradores'  is null.");
            }
            var consorcioAdministrador = await _context.ConsorciosAdministradores.FindAsync(id);
            if (consorcioAdministrador != null)
            {
                _context.ConsorciosAdministradores.Remove(consorcioAdministrador);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ConsorcioAdministradorExists(int id)
        {
          return _context.ConsorciosAdministradores.Any(e => e.Id == id);
        }
    }
}
