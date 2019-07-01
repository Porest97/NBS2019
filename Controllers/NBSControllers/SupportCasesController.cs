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
    public class SupportCasesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SupportCasesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SupportCases
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.SupportCase.Include(s => s.AssignedFE).Include(s => s.BusinessCentre).Include(s => s.OrderedBy).Include(s => s.PurchaseOrder);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: SupportCases/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var supportCase = await _context.SupportCase
                .Include(s => s.AssignedFE)
                .Include(s => s.BusinessCentre)
                .Include(s => s.OrderedBy)
                .Include(s => s.PurchaseOrder)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (supportCase == null)
            {
                return NotFound();
            }

            return View(supportCase);
        }

        // GET: SupportCases/Create
        public IActionResult Create()
        {
            ViewData["PersonId1"] = new SelectList(_context.Person, "Id", "Id");
            ViewData["BusinessCentreId"] = new SelectList(_context.BusinessCentre, "Id", "Id");
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "Id");
            ViewData["PurchaseOrderId"] = new SelectList(_context.PurchaseOrder, "Id", "Id");
            return View();
        }

        // POST: SupportCases/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TimeReported,TimeStarted,TimeFEScheduled,TimeSolved,TotalTimeOnSite,BusinessCentreId,PersonId,PersonId1,Descrition,PurchaseOrderId")] SupportCase supportCase)
        {
            if (ModelState.IsValid)
            {
                _context.Add(supportCase);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PersonId1"] = new SelectList(_context.Person, "Id", "Id", supportCase.PersonId1);
            ViewData["BusinessCentreId"] = new SelectList(_context.BusinessCentre, "Id", "Id", supportCase.BusinessCentreId);
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "Id", supportCase.PersonId);
            ViewData["PurchaseOrderId"] = new SelectList(_context.PurchaseOrder, "Id", "Id", supportCase.PurchaseOrderId);
            return View(supportCase);
        }

        // GET: SupportCases/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var supportCase = await _context.SupportCase.FindAsync(id);
            if (supportCase == null)
            {
                return NotFound();
            }
            ViewData["PersonId1"] = new SelectList(_context.Person, "Id", "Id", supportCase.PersonId1);
            ViewData["BusinessCentreId"] = new SelectList(_context.BusinessCentre, "Id", "Id", supportCase.BusinessCentreId);
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "Id", supportCase.PersonId);
            ViewData["PurchaseOrderId"] = new SelectList(_context.PurchaseOrder, "Id", "Id", supportCase.PurchaseOrderId);
            return View(supportCase);
        }

        // POST: SupportCases/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TimeReported,TimeStarted,TimeFEScheduled,TimeSolved,TotalTimeOnSite,BusinessCentreId,PersonId,PersonId1,Descrition,PurchaseOrderId")] SupportCase supportCase)
        {
            if (id != supportCase.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(supportCase);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SupportCaseExists(supportCase.Id))
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
            ViewData["PersonId1"] = new SelectList(_context.Person, "Id", "Id", supportCase.PersonId1);
            ViewData["BusinessCentreId"] = new SelectList(_context.BusinessCentre, "Id", "Id", supportCase.BusinessCentreId);
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "Id", supportCase.PersonId);
            ViewData["PurchaseOrderId"] = new SelectList(_context.PurchaseOrder, "Id", "Id", supportCase.PurchaseOrderId);
            return View(supportCase);
        }

        // GET: SupportCases/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var supportCase = await _context.SupportCase
                .Include(s => s.AssignedFE)
                .Include(s => s.BusinessCentre)
                .Include(s => s.OrderedBy)
                .Include(s => s.PurchaseOrder)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (supportCase == null)
            {
                return NotFound();
            }

            return View(supportCase);
        }

        // POST: SupportCases/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var supportCase = await _context.SupportCase.FindAsync(id);
            _context.SupportCase.Remove(supportCase);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SupportCaseExists(int id)
        {
            return _context.SupportCase.Any(e => e.Id == id);
        }
    }
}
