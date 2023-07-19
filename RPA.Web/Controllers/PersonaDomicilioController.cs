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
    public class PersonaDomicilioController : Controller
    {
        private readonly RPADBContext _context;

        public PersonaDomicilioController(RPADBContext context)
        {
            _context = context;
        }

        // GET: PersonaDomicilio
         public async Task<IActionResult> Index()
         {
             var rPADBContext = _context.PersonasDomicilios.Include(p => p.Domicilio).Include(p => p.Persona).Include(p => p.TipoDomicilio);
             return View(await rPADBContext.ToListAsync());
         }
        /*
        public async Task<IActionResult> Index(string filter)
        {
            var results = from PersonaDomicilio in _context.PersonasDomicilios select PersonaDomicilio;
            if (!string.IsNullOrEmpty(filter))
            {
                results = results.Where(x => x.Domicilio!.Contains(filter));
            }
            return View(await results.ToListAsync());
        }
        */


        // GET: PersonaDomicilio/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.PersonasDomicilios == null)
            {
                return NotFound();
            }

            var personaDomicilio = await _context.PersonasDomicilios
                .Include(p => p.Domicilio)
                .Include(p => p.Persona)
                .Include(p => p.TipoDomicilio)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (personaDomicilio == null)
            {
                return NotFound();
            }

            return View(personaDomicilio);
        }

        // GET: PersonaDomicilio/Create
        public IActionResult Create()
        {
            /* ViewData["DomicilioId"] = new SelectList(_context.Domicilios, "Id", "Id");
             ViewData["PersonaId"] = new SelectList(_context.Personas, "Id", "Id");
             ViewData["TipoDomicilioId"] = new SelectList(_context.TipoDomicilios, "Id", "Id");*/
            ViewData["Domicilio"] = new SelectList(_context.Domicilios, "Domicilio", "Domicilio");
            ViewData["Persona"] = new SelectList(_context.Personas, "Persona", "Persona");
            ViewData["TipoDomicilio"] = new SelectList(_context.TipoDomicilios, "TipoDomicilio", "TipoDomicilio");
            return View();
        }

        // POST: PersonaDomicilio/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PersonaId,DomicilioId,TipoDomicilioId,FechaAlta,FechaBaja")] PersonaDomicilio personaDomicilio)
        {
            if (ModelState.IsValid)
            {
                _context.Add(personaDomicilio);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            /*ViewData["DomicilioId"] = new SelectList(_context.Domicilios, "Id", "Id", personaDomicilio.DomicilioId);
            ViewData["PersonaId"] = new SelectList(_context.Personas, "Id", "Id", personaDomicilio.PersonaId);
            ViewData["TipoDomicilioId"] = new SelectList(_context.TipoDomicilios, "Id", "Id", personaDomicilio.TipoDomicilioId);*/
            ViewData["Domicilio"] = new SelectList(_context.Domicilios, "Domicilio", "Domicilio");
            ViewData["Persona"] = new SelectList(_context.Personas, "Persona", "Persona");
            ViewData["TipoDomicilio"] = new SelectList(_context.TipoDomicilios, "TipoDomicilio", "TipoDomicilio");
            return View(personaDomicilio);
        }

        // GET: PersonaDomicilio/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.PersonasDomicilios == null)
            {
                return NotFound();
            }

            var personaDomicilio = await _context.PersonasDomicilios.FindAsync(id);
            if (personaDomicilio == null)
            {
                return NotFound();
            }
            /*ViewData["DomicilioId"] = new SelectList(_context.Domicilios, "Id", "Id", personaDomicilio.DomicilioId);
            ViewData["PersonaId"] = new SelectList(_context.Personas, "Id", "Id", personaDomicilio.PersonaId);
            ViewData["TipoDomicilioId"] = new SelectList(_context.TipoDomicilios, "Id", "Id", personaDomicilio.TipoDomicilioId);*/
            ViewData["Domicilio"] = new SelectList(_context.Domicilios, "Domicilio", "Domicilio");
            ViewData["Persona"] = new SelectList(_context.Personas, "Persona", "Persona");
            ViewData["TipoDomicilio"] = new SelectList(_context.TipoDomicilios, "TipoDomicilio", "TipoDomicilio");
            return View(personaDomicilio);
        }

        // POST: PersonaDomicilio/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PersonaId,DomicilioId,TipoDomicilioId,FechaAlta,FechaBaja")] PersonaDomicilio personaDomicilio)
        {
            if (id != personaDomicilio.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(personaDomicilio);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PersonaDomicilioExists(personaDomicilio.Id))
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
            /*ViewData["DomicilioId"] = new SelectList(_context.Domicilios, "Id", "Id", personaDomicilio.DomicilioId);
            ViewData["PersonaId"] = new SelectList(_context.Personas, "Id", "Id", personaDomicilio.PersonaId);
            ViewData["TipoDomicilioId"] = new SelectList(_context.TipoDomicilios, "Id", "Id", personaDomicilio.TipoDomicilioId);*/
            ViewData["Domicilio"] = new SelectList(_context.Domicilios, "Domicilio", "Domicilio");
            ViewData["Persona"] = new SelectList(_context.Personas, "Persona", "Persona");
            ViewData["TipoDomicilio"] = new SelectList(_context.TipoDomicilios, "TipoDomicilio", "TipoDomicilio");
            return View(personaDomicilio);
        }

        // GET: PersonaDomicilio/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.PersonasDomicilios == null)
            {
                return NotFound();
            }

            var personaDomicilio = await _context.PersonasDomicilios
                .Include(p => p.Domicilio)
                .Include(p => p.Persona)
                .Include(p => p.TipoDomicilio)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (personaDomicilio == null)
            {
                return NotFound();
            }

            return View(personaDomicilio);
        }

        // POST: PersonaDomicilio/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.PersonasDomicilios == null)
            {
                return Problem("Entity set 'RPADBContext.PersonasDomicilios'  is null.");
            }
            var personaDomicilio = await _context.PersonasDomicilios.FindAsync(id);
            if (personaDomicilio != null)
            {
                _context.PersonasDomicilios.Remove(personaDomicilio);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PersonaDomicilioExists(int id)
        {
          return _context.PersonasDomicilios.Any(e => e.Id == id);
        }
    }
}
