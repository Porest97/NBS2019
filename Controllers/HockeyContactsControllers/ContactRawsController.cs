using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NBS2019.Data;
using NBS2019.Models.HockeyContacts;

namespace NBS2019.Controllers.HockeyContactsControllers
{
    public class ContactRawsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ContactRawsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ContactRaws
        public async Task<IActionResult> Index()
        {
            return View(await _context.ContactRaw.ToListAsync());
        }

        // GET: ContactRaws/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contactRaw = await _context.ContactRaw
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contactRaw == null)
            {
                return NotFound();
            }

            return View(contactRaw);
        }

        // GET: ContactRaws/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ContactRaws/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Club,Team,Role,Sport,District,FirstName,LastName,PhoneNumber1,PhoneNumber2,Email,Ssn,Season,AgeCategory")] ContactRaw contactRaw)
        {
            if (ModelState.IsValid)
            {
                _context.Add(contactRaw);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(contactRaw);
        }

        // GET: ContactRaws/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contactRaw = await _context.ContactRaw.FindAsync(id);
            if (contactRaw == null)
            {
                return NotFound();
            }
            return View(contactRaw);
        }

        // POST: ContactRaws/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Club,Team,Role,Sport,District,FirstName,LastName,PhoneNumber1,PhoneNumber2,Email,Ssn,Season,AgeCategory")] ContactRaw contactRaw)
        {
            if (id != contactRaw.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contactRaw);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContactRawExists(contactRaw.Id))
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
            return View(contactRaw);
        }

        // GET: ContactRaws/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contactRaw = await _context.ContactRaw
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contactRaw == null)
            {
                return NotFound();
            }

            return View(contactRaw);
        }

        // POST: ContactRaws/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var contactRaw = await _context.ContactRaw.FindAsync(id);
            _context.ContactRaw.Remove(contactRaw);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContactRawExists(int id)
        {
            return _context.ContactRaw.Any(e => e.Id == id);
        }
    }
}
