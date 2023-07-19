using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RPA.Web;

namespace RPA.Web.Controllers
{
    public class PersonasController : Controller
    {
        private readonly RPADBContext _context;

        public PersonasController(RPADBContext context)
        {
            _context = context;
        }

        // GET: Personas

        /*
        public async Task<IActionResult> Index()
        {
            var rPADBContext = _context.Personas.Include(p => p.Genero).Include(p => p.TipoDocumento).Include(p => p.TipoPersona);
            return View(await rPADBContext.ToListAsync());
        }
        */

        public async Task<IActionResult> Index(string filter)
        {

            var results = (from Personas in _context.Personas.Include(l => l.TipoPersona) select Personas);
            results = (from Personas in _context.Personas.Include(l => l.TipoDocumento) select Personas);

            if (!string.IsNullOrEmpty(filter))
            {
                results = results.Where(x => x.CuitCuil!.Contains(filter));
            }
            return View(await results.ToListAsync());
        }

        // GET: Personas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Personas == null)
            {
                return NotFound();
            }

            var persona = await _context.Personas
                .Include(p => p.Genero)
                .Include(p => p.TipoDocumento)
                .Include(p => p.TipoPersona)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (persona == null)
            {
                return NotFound();
            }

            return View(persona);
        }

        // GET: Personas/Create
        public IActionResult Create()
        {
            ViewData["selectListTipoPersona"] = new SelectList(_context.TipoPersonas, "Id", "Descripcion");
            ViewData["selectListGenero"] = new SelectList(_context.Generos, "Id", "Descripcion");
            ViewData["selectListTipoDocumento"] = new SelectList(_context.TipoDocumentos, "Id", "Descripcion");

            return View();
        }

        // POST: Personas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TipoPersonaId,CuitCuil,RazonSocial,Nombre,Apellido,TipoDocumentoId,NumeroDocumento,GeneroId,FechaNacimiento,Telefono1,Telefono2,Celular1,Celular2,Email1,Email2")] Persona persona)
        {
            if (ModelState.IsValid)
            {
                _context.Add(persona);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["selectListTipoPersona"] = new SelectList(_context.TipoPersonas, "Id", "Descripcion");
            ViewData["selectListGenero"] = new SelectList(_context.Generos, "Id", "Descripcion");
            ViewData["selectListTipoDocumento"] = new SelectList(_context.TipoDocumentos, "Id", "Descripcion");
            Console.WriteLine(persona);
            return View(persona);
        }

        // GET: Personas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Personas == null)
            {
                return NotFound();
            }

            var persona = await _context.Personas.FindAsync(id);
            if (persona == null)
            {
                return NotFound();
            }
            ViewData["GeneroId"] = new SelectList(_context.Generos, "Id", "Codigo", persona.GeneroId);
            ViewData["TipoDocumentoId"] = new SelectList(_context.TipoDocumentos, "Id", "Id", persona.TipoDocumentoId);
            ViewData["TipoPersonaId"] = new SelectList(_context.TipoPersonas, "Id", "Id", persona.TipoPersonaId);
            return View(persona);
        }

        // POST: Personas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TipoPersonaId,CuitCuil,RazonSocial,Nombre,Apellido,TipoDocumentoId,NumeroDocumento,GeneroId,FechaNacimiento,Telefono1,Telefono2,Celular1,Celular2,Email1,Email2")] Persona persona)
        {
            if (id != persona.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(persona);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PersonaExists(persona.Id))
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
            ViewData["GeneroId"] = new SelectList(_context.Generos, "Id", "Codigo", persona.GeneroId);
            ViewData["TipoDocumentoId"] = new SelectList(_context.TipoDocumentos, "Id", "Id", persona.TipoDocumentoId);
            ViewData["TipoPersonaId"] = new SelectList(_context.TipoPersonas, "Id", "Id", persona.TipoPersonaId);
            return View(persona);
        }

        // GET: Personas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Personas == null)
            {
                return NotFound();
            }

            var persona = await _context.Personas
                .Include(p => p.Genero)
                .Include(p => p.TipoDocumento)
                .Include(p => p.TipoPersona)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (persona == null)
            {
                return NotFound();
            }

            return View(persona);
        }

        // POST: Personas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Personas == null)
            {
                return Problem("Entity set 'RPADBContext.Personas'  is null.");
            }
            var persona = await _context.Personas.FindAsync(id);
            if (persona != null)
            {
                _context.Personas.Remove(persona);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PersonaExists(int id)
        {
            return _context.Personas.Any(e => e.Id == id);
        }





      
    }
}
