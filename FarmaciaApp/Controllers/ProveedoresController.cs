using FarmaciaApp.Data;
using FarmaciaApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FarmaciaApp.Controllers
{
    public class ProveedoresController : Controller
    {
        private readonly FarmaciaDbContext _context;

        public ProveedoresController(FarmaciaDbContext context)
        {
            _context = context;
        }

        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Proovedores.ToListAsync());
        }
        [Authorize(Roles = "Administrador")]
        public IActionResult Create() => View();

        // POST: ProveedoresController/Create
        [HttpPost]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> Create(Proveedor proveedor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(proveedor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(proveedor);
        }

        // GET: ProveedoresController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var proveedor = await _context.Proovedores.FindAsync(id);
            return proveedor == null ? NotFound() : View(proveedor);
        }

        // POST: ProveedoresController/Edit/5
        [HttpPost]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> Edit(int id, Proveedor proveedor)
        {
            if (id != proveedor.Id) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(proveedor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Proovedores.Any(m => m.Id == id)) return NotFound();
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(proveedor);
        }

        // POST: ProveedoresController/Delete/5
        [HttpPost]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> Delete(int id)
        {
            var proveedor = await _context.Proovedores.FindAsync(id);
            if (proveedor != null)
            {
                _context.Proovedores.Remove(proveedor);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
