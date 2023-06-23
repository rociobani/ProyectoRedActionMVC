﻿using System;
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
    public class UsuarioController : Controller
    {
        private readonly EscuelaDBContext _context;

        public UsuarioController(EscuelaDBContext context)
        {
            _context = context;
        }

        // GET: Usuario
        public async Task<IActionResult> Index()

        {
            var ListaRedactores = await _context.Usuarios.Where(t => t.tipo == TipoUsuario.REDACTOR).ToListAsync();
            return View(ListaRedactores);
        }

        // GET: Usuario/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuarios
                .FirstOrDefaultAsync(m => m.Id == id);
            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        // GET: Usuario/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Usuario/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Dni,nombreCompleto,mail")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                if (await UsuarioDuplicado(usuario.Dni))
                { 
                    return RedirectToAction("MensajeError", "Home");
                }


                usuario.nomUsuario = usuario.Dni;
                usuario.pass = usuario.Dni;
                usuario.tipo = TipoUsuario.REDACTOR;
                _context.Add(usuario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(usuario);
        }

        // GET: Usuario/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }
            return View(usuario);
        }

        // POST: Usuario/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Dni,nombreCompleto,mail,tipo,nomUsuario,pass")] Usuario usuario)
        {
            if (id != usuario.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(usuario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsuarioExists(usuario.Id))
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
            return View(usuario);
        }

        // GET: Usuario/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuarios
                .FirstOrDefaultAsync(m => m.Id == id);
            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        // POST: Usuario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UsuarioExists(int id)
        {
            return _context.Usuarios.Any(e => e.Id == id);
        }

        private async Task<bool> UsuarioDuplicado(string dni)
        {
            var resultado = false;
            var usuario = await _context.Usuarios.Where(u => u.Dni.Equals(dni)).FirstOrDefaultAsync(); 
            if (usuario != null)
            {
                resultado = true;
            }

            return resultado;
        }

        public async Task<bool> EsJefeDeRedaccion(int id)
        {
            var resultado = false;
            var jdr = await _context.Usuarios.FindAsync(id);
            if (jdr != null && jdr.tipo == TipoUsuario.JEFE_DE_REDACCION)
            {
                resultado = true;
            }

            return resultado;
        }

    }

       
 



    }

