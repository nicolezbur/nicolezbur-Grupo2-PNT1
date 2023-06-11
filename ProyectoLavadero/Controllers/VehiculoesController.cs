using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProyectoLavadero.Models;

namespace ProyectoLavadero.Controllers
{
    public class VehiculoesController : Controller
    {
        private readonly DB_LAVADEROContext _context;

        public VehiculoesController(DB_LAVADEROContext context)
        {
            _context = context;
        }

        // GET: Vehiculoes
        public async Task<IActionResult> Index(int? idUsuario)
        {
            ViewBag.Usuario = idUsuario;
            var listaVehiculas = new List<Vehiculo>();

            if (idUsuario == null)
            {
                listaVehiculas = await _context.Vehiculos
                                 .Include(v => v.IdUsuarioNavigation)                              
                                 .ToListAsync();
            }
            else
            {
                listaVehiculas = await _context.Vehiculos
                                 .Include(v => v.IdUsuarioNavigation)
                                 .Where(p => p.IdUsuario == idUsuario)
                                 .ToListAsync();
            }

            return View(listaVehiculas);
        }

        // GET: Vehiculoes/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Vehiculos == null)
            {
                return NotFound();
            }

            var vehiculo = await _context.Vehiculos
                .Include(v => v.IdUsuarioNavigation)
                .FirstOrDefaultAsync(m => m.Matricula == id);
            if (vehiculo == null)
            {
                return NotFound();
            }

            return View(vehiculo);
        }

        // GET: Vehiculoes/Create
        public IActionResult Create(int? idUsuario)
        {
            var listaSeleccionados = new SelectList(_context.Usuarios, "IdUsuario", "IdUsuario", idUsuario);

            foreach (var item in listaSeleccionados)
            {
                if (item.Selected)
                {
                    ViewData["IdUsuario"] = item.Value;
                }    
            }

            return View();
        }

        // POST: Vehiculoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Matricula,IdUsuario,Marca,Color")] Vehiculo vehiculo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vehiculo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index), new RouteValueDictionary(new { vehiculo.IdUsuario }));
            }
            ViewData["IdUsuario"] = new SelectList(_context.Usuarios, "IdUsuario", "IdUsuario", vehiculo.IdUsuario);
            return View(vehiculo);
        }

        // GET: Vehiculoes/Edit/5
        public async Task<IActionResult> Edit(string id, string idUsuario)
        {
            if (id == null || _context.Vehiculos == null)
            {
                return NotFound();
            }

            var vehiculo = await _context.Vehiculos.FindAsync(id);
            if (vehiculo == null)
            {
                return NotFound();
            }
            var listaSeleccionados = new SelectList(_context.Usuarios, "IdUsuario", "IdUsuario", vehiculo.IdUsuario);
            ViewData["IdUsuario"] = listaSeleccionados.SelectedValue;
            return View(vehiculo);
        }

        // POST: Vehiculoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Matricula,IdUsuario,Marca,Color")] Vehiculo vehiculo)
        {
            if (id != vehiculo.Matricula)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vehiculo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VehiculoExists(vehiculo.Matricula))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index), new RouteValueDictionary(new { vehiculo.IdUsuario }));
            }
            ViewData["IdUsuario"] = new SelectList(_context.Usuarios, "IdUsuario", "IdUsuario", vehiculo.IdUsuario);
            return View(vehiculo);
        }

        // GET: Vehiculoes/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Vehiculos == null)
            {
                return NotFound();
            }

            var vehiculo = await _context.Vehiculos
                .Include(v => v.IdUsuarioNavigation)
                .FirstOrDefaultAsync(m => m.Matricula == id);
            if (vehiculo == null)
            {
                return NotFound();
            }

            return View(vehiculo);
        }

        // POST: Vehiculoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Vehiculos == null)
            {
                return Problem("Entity set 'DB_LAVADEROContext.Vehiculos'  is null.");
            }
            var vehiculo = await _context.Vehiculos.FindAsync(id);
            if (vehiculo != null)
            {
                _context.Vehiculos.Remove(vehiculo);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index), new RouteValueDictionary(new { vehiculo.IdUsuario }));
        }

        private bool VehiculoExists(string id)
        {
          return (_context.Vehiculos?.Any(e => e.Matricula == id)).GetValueOrDefault();
        }
    }
}
