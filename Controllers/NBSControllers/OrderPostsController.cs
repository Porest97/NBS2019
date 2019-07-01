using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NBS2019.Data;
using NBS2019.Models.TestModels;

namespace NBS2019.Controllers.NBSControllers
{
    public class OrderPostsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OrderPostsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: OrderPosts
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.OrderPost.Include(o => o.Article);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: OrderPosts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderPost = await _context.OrderPost
                .Include(o => o.Article)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (orderPost == null)
            {
                return NotFound();
            }

            return View(orderPost);
        }

        // GET: OrderPosts/Create
        public IActionResult Create()
        {
            ViewData["ArticleId"] = new SelectList(_context.Article, "Id", "Id");
            return View();
        }

        // POST: OrderPosts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Description,ArticleId,Quantity,Price,Total")] OrderPost orderPost)
        {
            if (ModelState.IsValid)
            {
                _context.Add(orderPost);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ArticleId"] = new SelectList(_context.Article, "Id", "Id", orderPost.ArticleId);
            return View(orderPost);
        }

        // GET: OrderPosts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderPost = await _context.OrderPost.FindAsync(id);
            if (orderPost == null)
            {
                return NotFound();
            }
            ViewData["ArticleId"] = new SelectList(_context.Article, "Id", "Id", orderPost.ArticleId);
            return View(orderPost);
        }

        // POST: OrderPosts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Description,ArticleId,Quantity,Price,Total")] OrderPost orderPost)
        {
            if (id != orderPost.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(orderPost);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderPostExists(orderPost.Id))
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
            ViewData["ArticleId"] = new SelectList(_context.Article, "Id", "Id", orderPost.ArticleId);
            return View(orderPost);
        }

        // GET: OrderPosts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderPost = await _context.OrderPost
                .Include(o => o.Article)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (orderPost == null)
            {
                return NotFound();
            }

            return View(orderPost);
        }

        // POST: OrderPosts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var orderPost = await _context.OrderPost.FindAsync(id);
            _context.OrderPost.Remove(orderPost);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderPostExists(int id)
        {
            return _context.OrderPost.Any(e => e.Id == id);
        }
    }
}
