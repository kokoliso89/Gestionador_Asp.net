﻿using System;
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
  
    public class JugadoresController : Controller
    {
        private readonly ApplicationDbContext _context;

        public JugadoresController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Jugadores
        public async Task<IActionResult> Index()
        {
              return _context.Jugadores != null ? 
                          View(await _context.Jugadores.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Jugadores'  is null.");
        }

        // GET: Jugadores/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Jugadores == null)
            {
                return NotFound();
            }

            var jugadores = await _context.Jugadores
                .FirstOrDefaultAsync(m => m.ID == id);
            if (jugadores == null)
            {
                return NotFound();
            }

            return View(jugadores);
        }

        // GET: Jugadores/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Jugadores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Nombre,Apellido,Edad,EquipoID")] Jugadores jugadores)
        {
            if (ModelState.IsValid)
            {
                _context.Add(jugadores);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(jugadores);
        }

        // GET: Jugadores/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Jugadores == null)
            {
                return NotFound();
            }

            var jugadores = await _context.Jugadores.FindAsync(id);
            if (jugadores == null)
            {
                return NotFound();
            }
            return View(jugadores);
        }

        // POST: Jugadores/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("ID,Nombre,Apellido,Edad,EquipoID")] Jugadores jugadores)
        {
            if (id != jugadores.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(jugadores);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JugadoresExists(jugadores.ID))
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
            return View(jugadores);
        }

        // GET: Jugadores/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Jugadores == null)
            {
                return NotFound();
            }

            var jugadores = await _context.Jugadores
                .FirstOrDefaultAsync(m => m.ID == id);
            if (jugadores == null)
            {
                return NotFound();
            }

            return View(jugadores);
        }

        // POST: Jugadores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Jugadores == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Jugadores'  is null.");
            }
            var jugadores = await _context.Jugadores.FindAsync(id);
            if (jugadores != null)
            {
                _context.Jugadores.Remove(jugadores);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JugadoresExists(string id)
        {
          return (_context.Jugadores?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
