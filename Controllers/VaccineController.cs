using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProgramaEstagio.Data;
using ProgramaEstagio.Models;

namespace ProgramaEstagio.Controllers
{
    [Authorize]
    public class VaccineController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VaccineController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Vaccine
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Vaccine.Include(v => v.Person);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Vaccine/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vaccine = await _context.Vaccine
                .Include(v => v.Person)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (vaccine == null)
            {
                return NotFound();
            }

            return View(vaccine);
        }

        // GET: Vaccine/Create
        public IActionResult Create()
        {
            ViewData["PersonID"] = new SelectList(_context.Person, "ID", "FullName");
            return View();
        }

        // POST: Vaccine/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,VaccineName,VaccinePrice,DataVaccination,PersonID")] Vaccine vaccine)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vaccine);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PersonID"] = new SelectList(_context.Person, "ID", "FullName", vaccine.PersonID);
            return View(vaccine);
        }

        // GET: Vaccine/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vaccine = await _context.Vaccine.FindAsync(id);
            if (vaccine == null)
            {
                return NotFound();
            }
            ViewData["PersonID"] = new SelectList(_context.Person, "ID", "FullName", vaccine.PersonID);
            return View(vaccine);
        }

        // POST: Vaccine/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,VaccineName,VaccinePrice,DataVaccination,PersonID")] Vaccine vaccine)
        {
            if (id != vaccine.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vaccine);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VaccineExists(vaccine.ID))
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
            ViewData["PersonID"] = new SelectList(_context.Person, "ID", "FullName", vaccine.PersonID);
            return View(vaccine);
        }

        // GET: Vaccine/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vaccine = await _context.Vaccine
                .Include(v => v.Person)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (vaccine == null)
            {
                return NotFound();
            }

            return View(vaccine);
        }

        // POST: Vaccine/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vaccine = await _context.Vaccine.FindAsync(id);
            _context.Vaccine.Remove(vaccine);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VaccineExists(int id)
        {
            return _context.Vaccine.Any(e => e.ID == id);
        }
    }
}
