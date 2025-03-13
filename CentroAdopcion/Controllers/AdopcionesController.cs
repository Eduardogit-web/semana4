using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CentroAdopcion.Data;
using CentroAdopcion.Models;

namespace CentroAdopcion.Controllers
{
    public class AdopcionesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdopcionesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Adopciones
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Adopciones.Include(a => a.Animal).Include(a => a.User);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Adopciones/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adopcion = await _context.Adopciones
                .Include(a => a.Animal)
                .Include(a => a.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (adopcion == null)
            {
                return NotFound();
            }

            return View(adopcion);
        }

        // GET: Adopciones/Create
        public IActionResult Create()
        {
            ViewData["AnimalId"] = new SelectList(_context.Animales, "Id", "Id");
            ViewData["UserId"] = new SelectList(_context.Set<ApplicationUser>(), "Id", "Id");
            return View();
        }

        // POST: Adopciones/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FechaAdopcion,Estado,Observaciones,UserId,AnimalId")] Adopcion adopcion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(adopcion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AnimalId"] = new SelectList(_context.Animales, "Id", "Id", adopcion.AnimalId);
            ViewData["UserId"] = new SelectList(_context.Set<ApplicationUser>(), "Id", "Id", adopcion.UserId);
            return View(adopcion);
        }

        // GET: Adopciones/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adopcion = await _context.Adopciones.FindAsync(id);
            if (adopcion == null)
            {
                return NotFound();
            }
            ViewData["AnimalId"] = new SelectList(_context.Animales, "Id", "Id", adopcion.AnimalId);
            ViewData["UserId"] = new SelectList(_context.Set<ApplicationUser>(), "Id", "Id", adopcion.UserId);
            return View(adopcion);
        }

        // POST: Adopciones/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FechaAdopcion,Estado,Observaciones,UserId,AnimalId")] Adopcion adopcion)
        {
            if (id != adopcion.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(adopcion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AdopcionExists(adopcion.Id))
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
            ViewData["AnimalId"] = new SelectList(_context.Animales, "Id", "Id", adopcion.AnimalId);
            ViewData["UserId"] = new SelectList(_context.Set<ApplicationUser>(), "Id", "Id", adopcion.UserId);
            return View(adopcion);
        }

        // GET: Adopciones/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adopcion = await _context.Adopciones
                .Include(a => a.Animal)
                .Include(a => a.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (adopcion == null)
            {
                return NotFound();
            }

            return View(adopcion);
        }

        // POST: Adopciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var adopcion = await _context.Adopciones.FindAsync(id);
            if (adopcion != null)
            {
                _context.Adopciones.Remove(adopcion);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AdopcionExists(int id)
        {
            return _context.Adopciones.Any(e => e.Id == id);
        }
    }
}
