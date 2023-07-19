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
    public class EstadoMatriculaController : Controller
    {
        private readonly RPADBContext _context;

        public EstadoMatriculaController(RPADBContext context)
        {
            _context = context;
        }

        // GET: EstadoMatricula
        /*
        public async Task<IActionResult> Index()
        {
              return View(await _context.EstadoMatriculas.ToListAsync());
        }
        */

        public async Task<IActionResult> Index(string filter)
        {
            var results = from EstadoMatricula in _context.EstadoMatriculas select EstadoMatricula;
            if (!string.IsNullOrEmpty(filter))
            {
                results = results.Where(x => x.Descripcion!.Contains(filter));
            }
            return View(await results.ToListAsync());
        }

        // GET: EstadoMatricula/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.EstadoMatriculas == null)
            {
                return NotFound();
            }

            var estadoMatricula = await _context.EstadoMatriculas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (estadoMatricula == null)
            {
                return NotFound();
            }

            return View(estadoMatricula);
        }

        // GET: EstadoMatricula/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EstadoMatricula/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Descripcion")] EstadoMatricula estadoMatricula)
        {
            if (ModelState.IsValid)
            {
                _context.Add(estadoMatricula);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(estadoMatricula);
        }

        // GET: EstadoMatricula/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.EstadoMatriculas == null)
            {
                return NotFound();
            }

            var estadoMatricula = await _context.EstadoMatriculas.FindAsync(id);
            if (estadoMatricula == null)
            {
                return NotFound();
            }
            return View(estadoMatricula);
        }

        // POST: EstadoMatricula/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Descripcion")] EstadoMatricula estadoMatricula)
        {
            if (id != estadoMatricula.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(estadoMatricula);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EstadoMatriculaExists(estadoMatricula.Id))
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
            return View(estadoMatricula);
        }

        // GET: EstadoMatricula/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.EstadoMatriculas == null)
            {
                return NotFound();
            }

            var estadoMatricula = await _context.EstadoMatriculas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (estadoMatricula == null)
            {
                return NotFound();
            }

            return View(estadoMatricula);
        }

        // POST: EstadoMatricula/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.EstadoMatriculas == null)
            {
                return Problem("Entity set 'RPADBContext.EstadoMatriculas'  is null.");
            }
            var estadoMatricula = await _context.EstadoMatriculas.FindAsync(id);
            if (estadoMatricula != null)
            {
                _context.EstadoMatriculas.Remove(estadoMatricula);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EstadoMatriculaExists(int id)
        {
          return _context.EstadoMatriculas.Any(e => e.Id == id);
        }
    }
}
