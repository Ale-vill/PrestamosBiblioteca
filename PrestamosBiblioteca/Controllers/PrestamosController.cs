using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PrestamosBiblioteca.DataAccess;
using PrestamosBiblioteca.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrestamosBiblioteca.Controllers
{
    public class PrestamosController : Controller
    {
        private readonly AppDbContext _context;

        public PrestamosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Prestamos
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Prestamos.Include(p => p.Equipo).Include(p => p.Usuario);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Prestamos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prestamo = await _context.Prestamos
                .Include(p => p.Equipo)
                .Include(p => p.Usuario)
                .FirstOrDefaultAsync(m => m.PrestamoId == id);
            if (prestamo == null)
            {
                return NotFound();
            }

            return View(prestamo);
        }

        // GET: Prestamos/Create
        public async Task<IActionResult> Create()
        {
            
            ViewData["EquipoId"] = new SelectList(await GetEquiposDisponiblesAsync(), "EquipoId", "Codigo");
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "UsuarioId", "Codigo");
            return View();
        }

        // POST: Prestamos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PrestamoId,Entrega,Devolucion,Observacion,UsuarioId,EquipoId,Entregado")] Prestamo prestamo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(prestamo);
                var equipo = await _context.Equipos.FirstOrDefaultAsync(e => e.EquipoId == prestamo.EquipoId);
                if (equipo != null)
                {
                    equipo.Reservado = true;
                }
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EquipoId"] = new SelectList(await GetEquiposDisponiblesAsync(), "EquipoId", "Codigo", prestamo.EquipoId);
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "UsuarioId", "Codigo", prestamo.UsuarioId);
            return View(prestamo);
        }

        // GET: Prestamos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prestamo = await _context.Prestamos.FindAsync(id);

            if (prestamo == null)
            {
                return NotFound();
            }

            var equipos = await GetEquiposDisponiblesAsync();
            if (equipos.Count<=0)
            {
                equipos =_context.Equipos.Where(e => e.EquipoId == prestamo.EquipoId).ToList();
            }

            ViewData["EquipoId"] = new SelectList(equipos, "EquipoId", "Codigo", prestamo.EquipoId);
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "UsuarioId", "Codigo", prestamo.UsuarioId);
            return View(prestamo);
        }

        // POST: Prestamos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PrestamoId,Entrega,Devolucion,Observacion,UsuarioId,EquipoId,Entregado")] Prestamo prestamo)
        {
            if (id != prestamo.PrestamoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(prestamo);
                    if (prestamo.Entregado)
                    {
                        var equipo = await _context.Equipos.FirstOrDefaultAsync(e => e.EquipoId == prestamo.EquipoId);
                        if (equipo != null) equipo.Reservado = false;
                    }
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PrestamoExists(prestamo.PrestamoId))
                    {
                        return NotFound();
                    }

                    throw;
                }
                return RedirectToAction(nameof(Index));
            }

            var equipos = await GetEquiposDisponiblesAsync();
            if (equipos.Count<=0)
            {
                equipos =_context.Equipos.Where(e => e.EquipoId == prestamo.EquipoId).ToList();
            }
            ViewData["EquipoId"] = new SelectList(equipos, "EquipoId", "Codigo", prestamo.EquipoId);
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "UsuarioId", "Codigo", prestamo.UsuarioId);
            return View(prestamo);
        }

        // GET: Prestamos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prestamo = await _context.Prestamos
                .Include(p => p.Equipo)
                .Include(p => p.Usuario)
                .FirstOrDefaultAsync(m => m.PrestamoId == id);
            if (prestamo == null)
            {
                return NotFound();
            }

            return View(prestamo);
        }

        // POST: Prestamos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var prestamo = await _context.Prestamos.FindAsync(id);
            _context.Prestamos.Remove(prestamo);
            if (!prestamo.Entregado)
            {
                var equipo = await _context.Equipos.FirstOrDefaultAsync(e => e.EquipoId == prestamo.EquipoId);
                if (equipo != null) equipo.Reservado = false;
            }
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PrestamoExists(int id)
        {
            return _context.Prestamos.Any(e => e.PrestamoId == id);
        }

        private async Task<List<Equipo>> GetEquiposDisponiblesAsync()
        {
            return await _context.Equipos.Where(e=> !e.Reservado).ToListAsync();
        }
    }
}
