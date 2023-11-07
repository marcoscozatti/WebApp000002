using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApp000002.Data;
using WebApp000002.Models;

namespace WebApp000002.Controllers
{
    public class pacientesController : Controller
    {
        private readonly DBContext _context;

        public pacientesController(DBContext context)
        {
            _context = context;
        }

        // GET: pacientes
        public async Task<IActionResult> Index()
        {
              return _context.paciente != null ? 
                          View(await _context.paciente.ToListAsync()) :
                          Problem("Entity set 'DBContext.paciente'  is null.");
        }

        // GET: pacientes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.paciente == null)
            {
                return NotFound();
            }

            var paciente = await _context.paciente
                .FirstOrDefaultAsync(m => m.IdPaciente == id);
            if (paciente == null)
            {
                return NotFound();
            }

            return View(paciente);
        }

        // GET: pacientes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: pacientes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPaciente,NomePaciente,SobrenomePaciente")] paciente paciente)
        {
            if (ModelState.IsValid)
            {
                _context.Add(paciente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(paciente);
        }

        // GET: pacientes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.paciente == null)
            {
                return NotFound();
            }

            var paciente = await _context.paciente.FindAsync(id);
            if (paciente == null)
            {
                return NotFound();
            }
            return View(paciente);
        }

        // POST: pacientes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPaciente,NomePaciente,SobrenomePaciente")] paciente paciente)
        {
            if (id != paciente.IdPaciente)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(paciente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!pacienteExists(paciente.IdPaciente))
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
            return View(paciente);
        }

        // GET: pacientes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.paciente == null)
            {
                return NotFound();
            }

            var paciente = await _context.paciente
                .FirstOrDefaultAsync(m => m.IdPaciente == id);
            if (paciente == null)
            {
                return NotFound();
            }

            return View(paciente);
        }

        // POST: pacientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.paciente == null)
            {
                return Problem("Entity set 'DBContext.paciente'  is null.");
            }
            var paciente = await _context.paciente.FindAsync(id);
            if (paciente != null)
            {
                _context.paciente.Remove(paciente);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool pacienteExists(int id)
        {
          return (_context.paciente?.Any(e => e.IdPaciente == id)).GetValueOrDefault();
        }
    }
}
