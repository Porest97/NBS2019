using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NBS2019.Data;
using NBS2019.Models;

namespace NBS2019.Controllers.NBSControllers
{
    public class BusinessCentresController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BusinessCentresController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: BusinessCentres
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.BusinessCentre.Include(b => b.CentreContact).Include(b => b.CentreManager).Include(b => b.Company);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: BusinessCentres/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var businessCentre = await _context.BusinessCentre
                .Include(b => b.CentreContact)
                .Include(b => b.CentreManager)
                .Include(b => b.Company)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (businessCentre == null)
            {
                return NotFound();
            }

            return View(businessCentre);
        }

        // GET: BusinessCentres/Create
        public IActionResult Create()
        {
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "Id");
            ViewData["PersonId1"] = new SelectList(_context.Person, "Id", "Id");
            ViewData["CompanyId"] = new SelectList(_context.Company, "Id", "Id");
            return View();
        }

        // POST: BusinessCentres/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CompanyId,CentreNumber,CentreName,StreetAddress,ZipCode,County,Country,NumberOfFloors,PersonId,PersonId1,CentreNotes")] BusinessCentre businessCentre)
        {
            if (ModelState.IsValid)
            {
                _context.Add(businessCentre);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "Id", businessCentre.PersonId);
            ViewData["PersonId1"] = new SelectList(_context.Person, "Id", "Id", businessCentre.PersonId1);
            ViewData["CompanyId"] = new SelectList(_context.Company, "Id", "Id", businessCentre.CompanyId);
            return View(businessCentre);
        }

        // GET: BusinessCentres/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var businessCentre = await _context.BusinessCentre.FindAsync(id);
            if (businessCentre == null)
            {
                return NotFound();
            }
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "Id", businessCentre.PersonId);
            ViewData["PersonId1"] = new SelectList(_context.Person, "Id", "Id", businessCentre.PersonId1);
            ViewData["CompanyId"] = new SelectList(_context.Company, "Id", "Id", businessCentre.CompanyId);
            return View(businessCentre);
        }

        // POST: BusinessCentres/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CompanyId,CentreNumber,CentreName,StreetAddress,ZipCode,County,Country,NumberOfFloors,PersonId,PersonId1,CentreNotes")] BusinessCentre businessCentre)
        {
            if (id != businessCentre.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(businessCentre);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BusinessCentreExists(businessCentre.Id))
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
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "Id", businessCentre.PersonId);
            ViewData["PersonId1"] = new SelectList(_context.Person, "Id", "Id", businessCentre.PersonId1);
            ViewData["CompanyId"] = new SelectList(_context.Company, "Id", "Id", businessCentre.CompanyId);
            return View(businessCentre);
        }

        // GET: BusinessCentres/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var businessCentre = await _context.BusinessCentre
                .Include(b => b.CentreContact)
                .Include(b => b.CentreManager)
                .Include(b => b.Company)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (businessCentre == null)
            {
                return NotFound();
            }

            return View(businessCentre);
        }

        // POST: BusinessCentres/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var businessCentre = await _context.BusinessCentre.FindAsync(id);
            _context.BusinessCentre.Remove(businessCentre);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BusinessCentreExists(int id)
        {
            return _context.BusinessCentre.Any(e => e.Id == id);
        }
    }
}
