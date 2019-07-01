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
    public class SupportTicketsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SupportTicketsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SupportTickets
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.SupportTicket.Include(s => s.AssignedFE).Include(s => s.BusinessCentre).Include(s => s.OrderedBy);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: SupportTickets/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var supportTicket = await _context.SupportTicket
                .Include(s => s.AssignedFE)
                .Include(s => s.BusinessCentre)
                .Include(s => s.OrderedBy)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (supportTicket == null)
            {
                return NotFound();
            }

            return View(supportTicket);
        }

        // GET: SupportTickets/Create
        public IActionResult Create()
        {
            ViewData["PersonId1"] = new SelectList(_context.Person, "Id", "Id");
            ViewData["BusinessCentreId"] = new SelectList(_context.BusinessCentre, "Id", "Id");
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "Id");
            return View();
        }

        // POST: SupportTickets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TimeStampCreated,TimeStampResolved,TimeStampClosed,BusinessCentreId,PersonId,PersonId1,FaultDescription,FaultReport,TicketLog")] SupportTicket supportTicket)
        {
            if (ModelState.IsValid)
            {
                _context.Add(supportTicket);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PersonId1"] = new SelectList(_context.Person, "Id", "Id", supportTicket.PersonId1);
            ViewData["BusinessCentreId"] = new SelectList(_context.BusinessCentre, "Id", "Id", supportTicket.BusinessCentreId);
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "Id", supportTicket.PersonId);
            return View(supportTicket);
        }

        // GET: SupportTickets/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var supportTicket = await _context.SupportTicket.FindAsync(id);
            if (supportTicket == null)
            {
                return NotFound();
            }
            ViewData["PersonId1"] = new SelectList(_context.Person, "Id", "Id", supportTicket.PersonId1);
            ViewData["BusinessCentreId"] = new SelectList(_context.BusinessCentre, "Id", "Id", supportTicket.BusinessCentreId);
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "Id", supportTicket.PersonId);
            return View(supportTicket);
        }

        // POST: SupportTickets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TimeStampCreated,TimeStampResolved,TimeStampClosed,BusinessCentreId,PersonId,PersonId1,FaultDescription,FaultReport,TicketLog")] SupportTicket supportTicket)
        {
            if (id != supportTicket.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(supportTicket);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SupportTicketExists(supportTicket.Id))
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
            ViewData["PersonId1"] = new SelectList(_context.Person, "Id", "Id", supportTicket.PersonId1);
            ViewData["BusinessCentreId"] = new SelectList(_context.BusinessCentre, "Id", "Id", supportTicket.BusinessCentreId);
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "Id", supportTicket.PersonId);
            return View(supportTicket);
        }

        // GET: SupportTickets/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var supportTicket = await _context.SupportTicket
                .Include(s => s.AssignedFE)
                .Include(s => s.BusinessCentre)
                .Include(s => s.OrderedBy)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (supportTicket == null)
            {
                return NotFound();
            }

            return View(supportTicket);
        }

        // POST: SupportTickets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var supportTicket = await _context.SupportTicket.FindAsync(id);
            _context.SupportTicket.Remove(supportTicket);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SupportTicketExists(int id)
        {
            return _context.SupportTicket.Any(e => e.Id == id);
        }
    }
}
