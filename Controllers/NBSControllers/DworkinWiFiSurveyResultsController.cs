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
    public class DworkinWiFiSurveyResultsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DworkinWiFiSurveyResultsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: DworkinWiFiSurveyResults
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.DworkinWiFiSurveyResult.Include(d => d.AssignedFE).Include(d => d.BusinessCentre);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: DworkinWiFiSurveyResults/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dworkinWiFiSurveyResult = await _context.DworkinWiFiSurveyResult
                .Include(d => d.AssignedFE)
                .Include(d => d.BusinessCentre)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dworkinWiFiSurveyResult == null)
            {
                return NotFound();
            }

            return View(dworkinWiFiSurveyResult);
        }

        // GET: DworkinWiFiSurveyResults/Create
        public IActionResult Create()
        {
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "Id");
            ViewData["BusinessCentreId"] = new SelectList(_context.BusinessCentre, "Id", "Id");
            return View();
        }

        // POST: DworkinWiFiSurveyResults/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,BusinessCentreId,ReportDate,Version,PersonId,TimeOnSite,AccessPoints,AccessPointsBrandModel,A,B,C,D,E,F,G")] DworkinWiFiSurveyResult dworkinWiFiSurveyResult)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dworkinWiFiSurveyResult);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "Id", dworkinWiFiSurveyResult.PersonId);
            ViewData["BusinessCentreId"] = new SelectList(_context.BusinessCentre, "Id", "Id", dworkinWiFiSurveyResult.BusinessCentreId);
            return View(dworkinWiFiSurveyResult);
        }

        // GET: DworkinWiFiSurveyResults/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dworkinWiFiSurveyResult = await _context.DworkinWiFiSurveyResult.FindAsync(id);
            if (dworkinWiFiSurveyResult == null)
            {
                return NotFound();
            }
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "Id", dworkinWiFiSurveyResult.PersonId);
            ViewData["BusinessCentreId"] = new SelectList(_context.BusinessCentre, "Id", "Id", dworkinWiFiSurveyResult.BusinessCentreId);
            return View(dworkinWiFiSurveyResult);
        }

        // POST: DworkinWiFiSurveyResults/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,BusinessCentreId,ReportDate,Version,PersonId,TimeOnSite,AccessPoints,AccessPointsBrandModel,A,B,C,D,E,F,G")] DworkinWiFiSurveyResult dworkinWiFiSurveyResult)
        {
            if (id != dworkinWiFiSurveyResult.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dworkinWiFiSurveyResult);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DworkinWiFiSurveyResultExists(dworkinWiFiSurveyResult.Id))
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
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "Id", dworkinWiFiSurveyResult.PersonId);
            ViewData["BusinessCentreId"] = new SelectList(_context.BusinessCentre, "Id", "Id", dworkinWiFiSurveyResult.BusinessCentreId);
            return View(dworkinWiFiSurveyResult);
        }

        // GET: DworkinWiFiSurveyResults/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dworkinWiFiSurveyResult = await _context.DworkinWiFiSurveyResult
                .Include(d => d.AssignedFE)
                .Include(d => d.BusinessCentre)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dworkinWiFiSurveyResult == null)
            {
                return NotFound();
            }

            return View(dworkinWiFiSurveyResult);
        }

        // POST: DworkinWiFiSurveyResults/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dworkinWiFiSurveyResult = await _context.DworkinWiFiSurveyResult.FindAsync(id);
            _context.DworkinWiFiSurveyResult.Remove(dworkinWiFiSurveyResult);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DworkinWiFiSurveyResultExists(int id)
        {
            return _context.DworkinWiFiSurveyResult.Any(e => e.Id == id);
        }
    }
}
