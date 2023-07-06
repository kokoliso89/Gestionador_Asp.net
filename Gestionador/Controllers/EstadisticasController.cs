using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Gestionador.Data;
using Gestionador.Models;
using Microsoft.AspNetCore.Authorization;

namespace Gestionador.Controllers
{

    public class EstadisticasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EstadisticasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Estadisticas
        public async Task<IActionResult> Index()
        {
              return _context.Estadisticas != null ? 
                          View(await _context.Estadisticas.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Estadisticas'  is null.");
        }

        // GET: Estadisticas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Estadisticas == null)
            {
                return NotFound();
            }

            var estadisticas = await _context.Estadisticas
                .FirstOrDefaultAsync(m => m.ID == id);
            if (estadisticas == null)
            {
                return NotFound();
            }

            return View(estadisticas);
        }

        // GET: Estadisticas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Estadisticas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,JugadorID,EquipoID,PartidosJugados,Canastas1Punto,Canastas2Puntos,Canastas3Puntos,PuntosTotales,RebotesTotales,AsistenciasTotales")] Estadisticas estadisticas)
        {
            if (ModelState.IsValid)
            {
                _context.Add(estadisticas);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(estadisticas);
        }

        // GET: Estadisticas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Estadisticas == null)
            {
                return NotFound();
            }

            var estadisticas = await _context.Estadisticas.FindAsync(id);
            if (estadisticas == null)
            {
                return NotFound();
            }
            return View(estadisticas);
        }

        // POST: Estadisticas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,JugadorID,EquipoID,PartidosJugados,Canastas1Punto,Canastas2Puntos,Canastas3Puntos,PuntosTotales,RebotesTotales,AsistenciasTotales")] Estadisticas estadisticas)
        {
            if (id != estadisticas.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(estadisticas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EstadisticasExists(estadisticas.ID))
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
            return View(estadisticas);
        }

        // GET: Estadisticas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Estadisticas == null)
            {
                return NotFound();
            }

            var estadisticas = await _context.Estadisticas
                .FirstOrDefaultAsync(m => m.ID == id);
            if (estadisticas == null)
            {
                return NotFound();
            }

            return View(estadisticas);
        }

        // POST: Estadisticas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Estadisticas == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Estadisticas'  is null.");
            }
            var estadisticas = await _context.Estadisticas.FindAsync(id);
            if (estadisticas != null)
            {
                _context.Estadisticas.Remove(estadisticas);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EstadisticasExists(int id)
        {
          return (_context.Estadisticas?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
