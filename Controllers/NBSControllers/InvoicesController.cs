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
    public class InvoicesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public InvoicesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Invoices
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Invoice.Include(i => i.Article).Include(i => i.ArticlePrice).Include(i => i.BillTo).Include(i => i.Company);
            return View(await applicationDbContext.ToListAsync());
        }
        //// GET: WorkReports HttpPost !
        //[HttpPost]
        //public IActionResult Index(Invoice invoice)
        //{
        //    var applicationContext = _context.Invoice.Include(i => i.Article).Include(i => i.ArticlePrice).Include(i => i.BillTo).Include(i => i.Company);
        //    invoice.Amount = invoice.Qantity1 * invoice.ArticlePrice;
            
        //    return View(invoice);
        //}

        // GET: Invoices/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invoice = await _context.Invoice
                .Include(i => i.Article)
                .Include(i => i.ArticlePrice)
                .Include(i => i.BillTo)
                .Include(i => i.Company)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (invoice == null)
            {
                return NotFound();
            }

            return View(invoice);
        }

        // GET: Invoices/Create
        public IActionResult Create()
        {
            ViewData["ArticleId"] = new SelectList(_context.Article, "Id", "ArticleDescription");
            ViewData["ArticleId1"] = new SelectList(_context.Article, "Id", "Price");
            ViewData["CompanyId1"] = new SelectList(_context.Company, "Id", "CompanyName");
            ViewData["CompanyId"] = new SelectList(_context.Company, "Id", "CompanyName");
            return View();
        }

        // POST: Invoices/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CompanyId,CompanyId1,Qantity1,ArticleId,ArticleId1,Amount")] Invoice invoice)
        {
            if (ModelState.IsValid)
            {
                _context.Add(invoice);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ArticleId"] = new SelectList(_context.Article, "Id", "ArticleDescription", invoice.ArticleId);
            ViewData["ArticleId1"] = new SelectList(_context.Article, "Id", "Price", invoice.ArticleId1);
            ViewData["CompanyId1"] = new SelectList(_context.Company, "Id", "CompanyName", invoice.CompanyId1);
            ViewData["CompanyId"] = new SelectList(_context.Company, "Id", "CompanyName", invoice.CompanyId);
            return View(invoice);
        }

        // GET: Invoices/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invoice = await _context.Invoice.FindAsync(id);
            if (invoice == null)
            {
                return NotFound();
            }
            ViewData["ArticleId"] = new SelectList(_context.Article, "Id", "ArticleDescription", invoice.ArticleId);
            ViewData["ArticleId1"] = new SelectList(_context.Article, "Id", "Price", invoice.ArticleId1);
            ViewData["CompanyId1"] = new SelectList(_context.Company, "Id", "CompanyName", invoice.CompanyId1);
            ViewData["CompanyId"] = new SelectList(_context.Company, "Id", "CompanyName", invoice.CompanyId);
            return View(invoice);
        }

        // POST: Invoices/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CompanyId,CompanyId1,Qantity1,ArticleId,ArticleId1,Amount")] Invoice invoice)
        {
            if (id != invoice.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(invoice);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InvoiceExists(invoice.Id))
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
            ViewData["ArticleId"] = new SelectList(_context.Article, "Id", "ArticleDescription", invoice.ArticleId);
            ViewData["ArticleId1"] = new SelectList(_context.Article, "Id", "Price", invoice.ArticleId1);
            ViewData["CompanyId1"] = new SelectList(_context.Company, "Id", "CompanyName", invoice.CompanyId1);
            ViewData["CompanyId"] = new SelectList(_context.Company, "Id", "CompanyName", invoice.CompanyId);
            return View(invoice);
        }

        // GET: Invoices/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invoice = await _context.Invoice
                .Include(i => i.Article)
                .Include(i => i.ArticlePrice)
                .Include(i => i.BillTo)
                .Include(i => i.Company)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (invoice == null)
            {
                return NotFound();
            }

            return View(invoice);
        }

        // POST: Invoices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var invoice = await _context.Invoice.FindAsync(id);
            _context.Invoice.Remove(invoice);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InvoiceExists(int id)
        {
            return _context.Invoice.Any(e => e.Id == id);
        }
    }
}
