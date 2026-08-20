using Microsoft.AspNetCore.Mvc;
using InmobiliariaCC.Data;
using InmobiliariaCC.Models;
using Microsoft.EntityFrameworkCore;

namespace InmobiliariaCC.Controllers
{
    public class PropietarioController : Controller
    {
        private readonly AppDBContext _context;

        public PropietarioController(AppDBContext context)
        {
            _context = context;
        }

        // LISTAR
        [HttpGet]
        public async Task<IActionResult> Lista()
        {
            List<Propietario> lista =
                await _context.Propietarios.ToListAsync();

            return View(lista);
        }

        // FORMULARIO NUEVO
        [HttpGet]
        public IActionResult Nuevo()
        {
            return View();
        }

        // NUEVO PROPIETARIO
        [HttpPost]
        public async Task<IActionResult> Nuevo(Propietario propietario)
        {
            if (ModelState.IsValid)
            {
                await _context.Propietarios.AddAsync(propietario);

                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Lista));
            }

            return View(propietario);
        }

        // FORMULARIO EDITAR
        [HttpGet]
        public async Task<IActionResult> Editar(int id)
        {
            Propietario propietario =
                await _context.Propietarios
                    .FirstAsync(p => p.IdPropietario == id);

            return View(propietario);
        }

        // GUARDAR EDICIÓN
        [HttpPost]
        public async Task<IActionResult> Editar(Propietario propietario)
        {
            if (ModelState.IsValid)
            {
                _context.Propietarios.Update(propietario);

                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Lista));
            }

            return View(propietario);
        }

        // ELIMINAR
        [HttpGet]
        public async Task<IActionResult> Eliminar(int id)
        {
            Propietario propietario =
                await _context.Propietarios
                    .FirstAsync(p => p.IdPropietario == id);

            _context.Propietarios.Remove(propietario);

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Lista));
        }
    }
}