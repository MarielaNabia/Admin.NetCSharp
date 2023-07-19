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
    public class AdministradorController : Controller
    {
        private readonly RPADBContext _context;

        public AdministradorController(RPADBContext context)
        {
            _context = context;
        }

        // GET: Administrador
        public async Task<IActionResult> Index()
       {
           var rPADBContext = _context.Administradores.Include(a => a.EstadoMatricula).Include(a => a.Persona);
           return View(await rPADBContext.ToListAsync());
        }

        //public async Task<IActionResult> Index(string filter)
        //{
        //    var results = from Administrador in _context.Administradores select Administrador;
        //    if (!string.IsNullOrEmpty(filter))
        //    {
        //        results = results.Where(x => x.ConsorciosAdministradores!.Contains(filter));
        //    }
        //    return View(await results.ToListAsync());
        //}

        // GET: Administrador/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Administradores == null)
            {
                return NotFound();
            }

            var administrador = await _context.Administradores
                .Include(a => a.EstadoMatricula)
                .Include(a => a.Persona)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (administrador == null)
            {
                return NotFound();
            }

            return View(administrador);
        }

        // GET: Administrador/Create
        public IActionResult Create()
        {
            ViewData["EstadoMatriculaId"] = new SelectList(_context.EstadoMatriculas, "Id", "Id");
            ViewData["PersonaId"] = new SelectList(_context.Personas, "Id", "Id");
            return View();
        }

        // POST: Administrador/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Matricula,Oneroso,PersonaId,FechaAlta,FechaBaja,FechaActualizacion,FechaSuspension,Observaciones,EstadoMatriculaId")] Administrador administrador)
        {
            if (ModelState.IsValid)
            {
                _context.Add(administrador);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EstadoMatriculaId"] = new SelectList(_context.EstadoMatriculas, "Id", "Id", administrador.EstadoMatriculaId);
            ViewData["PersonaId"] = new SelectList(_context.Personas, "Id", "Id", administrador.PersonaId);
            return View(administrador);
        }

        // GET: Administrador/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Administradores == null)
            {
                return NotFound();
            }

            var administrador = await _context.Administradores.FindAsync(id);
            if (administrador == null)
            {
                return NotFound();
            }
            ViewData["EstadoMatriculaId"] = new SelectList(_context.EstadoMatriculas, "Id", "Id", administrador.EstadoMatriculaId);
            ViewData["PersonaId"] = new SelectList(_context.Personas, "Id", "Id", administrador.PersonaId);
            return View(administrador);
        }

        // POST: Administrador/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Matricula,Oneroso,PersonaId,FechaAlta,FechaBaja,FechaActualizacion,FechaSuspension,Observaciones,EstadoMatriculaId")] Administrador administrador)
        {
            if (id != administrador.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(administrador);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AdministradorExists(administrador.Id))
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
            ViewData["EstadoMatriculaId"] = new SelectList(_context.EstadoMatriculas, "Id", "Id", administrador.EstadoMatriculaId);
            ViewData["PersonaId"] = new SelectList(_context.Personas, "Id", "Id", administrador.PersonaId);
            return View(administrador);
        }

        // GET: Administrador/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Administradores == null)
            {
                return NotFound();
            }

            var administrador = await _context.Administradores
                .Include(a => a.EstadoMatricula)
                .Include(a => a.Persona)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (administrador == null)
            {
                return NotFound();
            }

            return View(administrador);
        }

        // POST: Administrador/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Administradores == null)
            {
                return Problem("Entity set 'RPADBContext.Administradores'  is null.");
            }
            var administrador = await _context.Administradores.FindAsync(id);
            if (administrador != null)
            {
                _context.Administradores.Remove(administrador);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AdministradorExists(int id)
        {
          return _context.Administradores.Any(e => e.Id == id);
        }
    }
}
