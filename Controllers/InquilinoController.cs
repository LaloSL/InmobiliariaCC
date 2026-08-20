using Microsoft.AspNetCore.Mvc;
using InmobiliariaCC.Data;
using InmobiliariaCC.Models;
using Microsoft.EntityFrameworkCore;

namespace InmobiliariaCC.Controllers
{
    public class InquilinoController : Controller
    {
        private readonly AppDBContext _context;

        public InquilinoController(AppDBContext context)
        {
            _context = context;
        }

        // LISTAR
        [HttpGet]
        public async Task<IActionResult> Lista()
        {
            List<Inquilino> lista =
                await _context.Inquilinos.ToListAsync();

            return View(lista);
        }

        // FORMULARIO NUEVO
        [HttpGet]
        public IActionResult Nuevo()
        {
            return View();
        }

        // NUEVO INQUILINO
        [HttpPost]
        public async Task<IActionResult> Nuevo(Inquilino inquilino)
        {
            if (ModelState.IsValid)
            {
                await _context.Inquilinos.AddAsync(inquilino);

                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Lista));
            }

            return View(inquilino);
        }

        // FORMULARIO EDITAR
        [HttpGet]
        public async Task<IActionResult> Editar(int id)
        {
            Inquilino inquilino =
                await _context.Inquilinos
                    .FirstAsync(i => i.IdInquilino == id);

            return View(inquilino);
        }

        // GUARDAR EDICIÓN
        [HttpPost]
        public async Task<IActionResult> Editar(Inquilino inquilino)
        {
            if (ModelState.IsValid)
            {
                _context.Inquilinos.Update(inquilino);

                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Lista));
            }

            return View(inquilino);
        }

        // ELIMINAR
        [HttpGet]
        public async Task<IActionResult> Eliminar(int id)
        {
            Inquilino inquilino =
                await _context.Inquilinos
                    .FirstAsync(i => i.IdInquilino == id);

            _context.Inquilinos.Remove(inquilino);

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Lista));
        }
    }
}