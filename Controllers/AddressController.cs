using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProgramaEstagio.Data;
using ProgramaEstagio.Models;

namespace ProgramaEstagio.Controllers
{
    public class AddressController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AddressController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Addresse
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Address.Include(a => a.Person);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Addresse/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var address = await _context.Address
                .Include(a => a.Person)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (address == null)
            {
                return NotFound();
            }

            return View(address);
        }

        // GET: Addresse/Create
        public IActionResult Create()
        {
            ViewData["PersonID"] = new SelectList(_context.Person, "ID", "FullName");
            return View();
        }

        // POST: Addresse/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Country,Complement,Distric,City,State,PersonID")] Address address)
        {
            if (ModelState.IsValid)
            {
                _context.Add(address);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PersonID"] = new SelectList(_context.Person, "ID", "FullName", address.PersonID);
            return View(address);
        }

        // GET: Addresse/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            RegisterViewModel register = new RegisterViewModel();
            if (id == null)
            {
                return NotFound();
            }

            var address = await _context.Address.FindAsync(id);
            if (address == null)
            {
                return NotFound();
            }
            ViewData["PersonID"] = new SelectList(_context.Person, "ID", "FullName", address.PersonID);
            register.Address = address;
            return View(register);
        }

        // POST: Addresse/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Country,Complement,Distric,City,State,PersonID")] Address address)
        {
            if (id != address.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(address);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AddressExists(address.ID))
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
            ViewData["PersonID"] = new SelectList(_context.Person, "ID", "FullName", address.PersonID);
            return View(address);
        }

        // GET: Addresse/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var address = await _context.Address
                .Include(a => a.Person)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (address == null)
            {
                return NotFound();
            }

            return View(address);
        }

        // POST: Addresse/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var address = await _context.Address.FindAsync(id);
            _context.Address.Remove(address);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AddressExists(int id)
        {
            return _context.Address.Any(e => e.ID == id);
        }
    }
}
