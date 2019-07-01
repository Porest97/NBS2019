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
    public class PurchaseOrdersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PurchaseOrdersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PurchaseOrders
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.PurchaseOrder.Include(p => p.AssignedFE).Include(p => p.BusinessCentre).Include(p => p.OrderedBy);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: PurchaseOrders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var purchaseOrder = await _context.PurchaseOrder
                .Include(p => p.AssignedFE)
                .Include(p => p.BusinessCentre)
                .Include(p => p.OrderedBy)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (purchaseOrder == null)
            {
                return NotFound();
            }

            return View(purchaseOrder);
        }

        // GET: PurchaseOrders/Create
        public IActionResult Create()
        {
            ViewData["PersonId1"] = new SelectList(_context.Person, "Id", "Id");
            ViewData["BusinessCentreId"] = new SelectList(_context.BusinessCentre, "Id", "Id");
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "Id");
            return View();
        }

        // POST: PurchaseOrders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PurchaseOrderNumber,BusinessCentreId,PersonId,PersonId1,Descrition,TimeOnSite,KostPerHour,TotalKost,JobbScheduled,JobbStarted,JobbEnded")] PurchaseOrder purchaseOrder)
        {
            if (ModelState.IsValid)
            {
                _context.Add(purchaseOrder);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PersonId1"] = new SelectList(_context.Person, "Id", "Id", purchaseOrder.PersonId1);
            ViewData["BusinessCentreId"] = new SelectList(_context.BusinessCentre, "Id", "Id", purchaseOrder.BusinessCentreId);
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "Id", purchaseOrder.PersonId);
            return View(purchaseOrder);
        }

        // GET: PurchaseOrders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var purchaseOrder = await _context.PurchaseOrder.FindAsync(id);
            if (purchaseOrder == null)
            {
                return NotFound();
            }
            ViewData["PersonId1"] = new SelectList(_context.Person, "Id", "Id", purchaseOrder.PersonId1);
            ViewData["BusinessCentreId"] = new SelectList(_context.BusinessCentre, "Id", "Id", purchaseOrder.BusinessCentreId);
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "Id", purchaseOrder.PersonId);
            return View(purchaseOrder);
        }

        // POST: PurchaseOrders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PurchaseOrderNumber,BusinessCentreId,PersonId,PersonId1,Descrition,TimeOnSite,KostPerHour,TotalKost,JobbScheduled,JobbStarted,JobbEnded")] PurchaseOrder purchaseOrder)
        {
            if (id != purchaseOrder.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(purchaseOrder);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PurchaseOrderExists(purchaseOrder.Id))
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
            ViewData["PersonId1"] = new SelectList(_context.Person, "Id", "Id", purchaseOrder.PersonId1);
            ViewData["BusinessCentreId"] = new SelectList(_context.BusinessCentre, "Id", "Id", purchaseOrder.BusinessCentreId);
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "Id", purchaseOrder.PersonId);
            return View(purchaseOrder);
        }

        // GET: PurchaseOrders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var purchaseOrder = await _context.PurchaseOrder
                .Include(p => p.AssignedFE)
                .Include(p => p.BusinessCentre)
                .Include(p => p.OrderedBy)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (purchaseOrder == null)
            {
                return NotFound();
            }

            return View(purchaseOrder);
        }

        // POST: PurchaseOrders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var purchaseOrder = await _context.PurchaseOrder.FindAsync(id);
            _context.PurchaseOrder.Remove(purchaseOrder);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PurchaseOrderExists(int id)
        {
            return _context.PurchaseOrder.Any(e => e.Id == id);
        }
    }
}
