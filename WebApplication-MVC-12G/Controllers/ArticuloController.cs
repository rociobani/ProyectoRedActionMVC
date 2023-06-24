using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication_MVC_12G.Context;
using WebApplication_MVC_12G.Models;

namespace WebApplication_MVC_12G.Controllers
{
    public class ArticuloController : Controller
    {
        private readonly EscuelaDBContext _context;

        public ArticuloController(EscuelaDBContext context)
        {
            _context = context;
        }

        // GET: Articulo
        public async Task<IActionResult> Index()
        {

            var escuelaDBContext = await _context.Articulos.Include(a => a.autor).ToListAsync(); // HAGO UNA LISTA POR AUTOR
            var listaArticulos = escuelaDBContext.Where(a => a.estado != EstadoArticulo.ESPERANDO_APROBACION).ToList(); // FILTRO SACANDO SACANDO ESPERANDO APROBACION
                                                                                                                        // ver que pasa si el autor es el Administrador
                                                                                                                        //ver el index que se modifico los botones                                                                                                                   // ver que pasa si el autor es el Administrador
                                                                                                                        
        }


        // GET: Articulo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var articulo = await _context.Articulos
                .Include(a => a.autor)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (articulo == null)
            {
                return NotFound();
            }

            return View(articulo);
        }

        // GET: Articulo/Create
        public IActionResult Create()
        {
            ViewData["AutorId"] = new SelectList(_context.Usuarios.Where(t => t.tipo != TipoUsuario.JEFE_DE_REDACCION), "Id", "nombreCompleto");
            return View();
        }

        // POST: Articulo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,AutorId,contenido,seccion,estado,observaciones")] Articulo articulo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(articulo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AutorId"] = new SelectList(_context.Usuarios.Where(t => t.tipo != TipoUsuario.JEFE_DE_REDACCION), "Id", "Dni", articulo.AutorId);
            return View(articulo);
        }

        // GET: Articulo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var articulo = await _context.Articulos.FindAsync(id);
            if (articulo == null)
            {
                return NotFound();
            }
            ViewData["AutorId"] = new SelectList(_context.Usuarios.Where(t => t.tipo != TipoUsuario.JEFE_DE_REDACCION), "Id", "Dni", articulo.AutorId);
            return View(articulo);
        }

        // POST: Articulo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,AutorId,contenido,seccion,estado,observaciones")] Articulo articulo)
        {
            if (id != articulo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(articulo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArticuloExists(articulo.Id))
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
            ViewData["AutorId"] = new SelectList(_context.Usuarios.Where(t => t.tipo != TipoUsuario.JEFE_DE_REDACCION), "Id", "Dni", articulo.AutorId);
            return View(articulo);
        }

        // GET: Articulo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var articulo = await _context.Articulos
                .Include(a => a.autor)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (articulo == null)
            {
                return NotFound();
            }

            return View(articulo);
        }

        // POST: Articulo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var articulo = await _context.Articulos.FindAsync(id);
            _context.Articulos.Remove(articulo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ArticuloExists(int id)
        {
            return _context.Articulos.Any(e => e.Id == id);
        }

        
    }
}
