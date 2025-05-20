using FarmaciaApp.Data;
using FarmaciaApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace FarmaciaApp.Controllers
{
    public class ProductosController : Controller
    {
        private readonly FarmaciaDbContext _context;
        private readonly IWebHostEnvironment _env;

        public ProductosController(FarmaciaDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Medicamentos.ToListAsync());
        }
        [Authorize(Roles = "Administrador")]
        public IActionResult Create() => View();

        [HttpPost]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> Create(Medicamento medicamento, IFormFile RutaImagen)
        {
            if (ModelState.IsValid)
            {
                if (RutaImagen != null)
                {
                    var fileName = Path.GetFileName(RutaImagen.FileName);
                    var path = Path.Combine(_env.WebRootPath, "images", fileName);
                    using var stream = new FileStream(path, FileMode.Create);
                    await RutaImagen.CopyToAsync(stream);
                    medicamento.RutaImagen = "/images/" + fileName;
                }

                _context.Add(medicamento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(medicamento);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var medicamento = await _context.Medicamentos.FindAsync(id);
            return medicamento == null ? NotFound() : View(medicamento);
        }

        [HttpPost]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> Edit(int id, Medicamento medicamento, IFormFile RutaImagen)
        {
            if (id != medicamento.Id) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    if (RutaImagen != null)
                    {
                        var fileName = Path.GetFileName(RutaImagen.FileName);
                        var path = Path.Combine(_env.WebRootPath, "images", fileName);
                        using var stream = new FileStream(path, FileMode.Create);
                        await RutaImagen.CopyToAsync(stream);
                        medicamento.RutaImagen = "/images/" + fileName;
                    }
                    _context.Update(medicamento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Medicamentos.Any(m => m.Id == id)) return NotFound();
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(medicamento);
        }
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> Delete(int id)
        {
            var medicamento = await _context.Medicamentos.FindAsync(id);
            if (medicamento != null)
            {
                _context.Medicamentos.Remove(medicamento);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }

}

