using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CentroAdopcion.Data;
using CentroAdopcion.Models;
using Microsoft.AspNetCore.Authorization;

namespace CentroAdopcion.Controllers
{
    [Authorize]
    public class RefugiosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RefugiosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Refugios
        public async Task<IActionResult> Index()
        {
            return View(await _context.Refugios.ToListAsync());
        }

        // GET: Refugios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var refugio = await _context.Refugios
                .FirstOrDefaultAsync(m => m.Id == id);
            if (refugio == null)
            {
                return NotFound();
            }

            return View(refugio);
        }

        // GET: Refugios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Refugios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Direccion,Capacidad,Telefono")] Refugio refugio)
        {
            if (ModelState.IsValid)
            {
                _context.Add(refugio);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(refugio);
        }

        // GET: Refugios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var refugio = await _context.Refugios.FindAsync(id);
            if (refugio == null)
            {
                return NotFound();
            }
            return View(refugio);
        }

        // POST: Refugios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Direccion,Capacidad,Telefono")] Refugio refugio)
        {
            if (id != refugio.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(refugio);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RefugioExists(refugio.Id))
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
            return View(refugio);
        }

        // GET: Refugios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var refugio = await _context.Refugios
                .FirstOrDefaultAsync(m => m.Id == id);
            if (refugio == null)
            {
                return NotFound();
            }

            return View(refugio);
        }

        // POST: Refugios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var refugio = await _context.Refugios.FindAsync(id);
            if (refugio != null)
            {
                _context.Refugios.Remove(refugio);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RefugioExists(int id)
        {
            return _context.Refugios.Any(e => e.Id == id);
        }
    }
}
