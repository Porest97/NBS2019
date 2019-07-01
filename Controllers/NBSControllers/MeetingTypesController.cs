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
    public class MeetingTypesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MeetingTypesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: MeetingTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.MeetingType.ToListAsync());
        }

        // GET: MeetingTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var meetingType = await _context.MeetingType
                .FirstOrDefaultAsync(m => m.Id == id);
            if (meetingType == null)
            {
                return NotFound();
            }

            return View(meetingType);
        }

        // GET: MeetingTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MeetingTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,MeetingTypeName")] MeetingType meetingType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(meetingType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(meetingType);
        }

        // GET: MeetingTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var meetingType = await _context.MeetingType.FindAsync(id);
            if (meetingType == null)
            {
                return NotFound();
            }
            return View(meetingType);
        }

        // POST: MeetingTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,MeetingTypeName")] MeetingType meetingType)
        {
            if (id != meetingType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(meetingType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MeetingTypeExists(meetingType.Id))
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
            return View(meetingType);
        }

        // GET: MeetingTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var meetingType = await _context.MeetingType
                .FirstOrDefaultAsync(m => m.Id == id);
            if (meetingType == null)
            {
                return NotFound();
            }

            return View(meetingType);
        }

        // POST: MeetingTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var meetingType = await _context.MeetingType.FindAsync(id);
            _context.MeetingType.Remove(meetingType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MeetingTypeExists(int id)
        {
            return _context.MeetingType.Any(e => e.Id == id);
        }
    }
}
