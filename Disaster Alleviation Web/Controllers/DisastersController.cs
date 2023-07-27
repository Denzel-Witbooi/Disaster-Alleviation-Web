using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Disaster_Alleviation_Web.Data;
using Disaster_Alleviation_Web.Models;
using Microsoft.AspNetCore.Authorization;

namespace Disaster_Alleviation_Web.Controllers
{
    public class DisastersController : Controller
    {
        private readonly DisasterReliefContext _context;

        public DisastersController(DisasterReliefContext context)
        {
            _context = context;
        }

        // GET: Disasters
        [Authorize]
        public async Task<IActionResult> Index()
        {
            var disasterReliefContext = _context.Disasters.Include(d => d.AidType);
            return View(await disasterReliefContext.ToListAsync());
        }

        // GET: Disasters/Details/5
        [Authorize]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var disaster = await _context.Disasters
                .Include(d => d.AidType)
                .FirstOrDefaultAsync(m => m.DisasterID == id);
            if (disaster == null)
            {
                return NotFound();
            }

            return View(disaster);
        }

        // GET: Disasters/Create
        [Authorize]
        public IActionResult Create()
        {
            ViewData["AidTypeID"] = new SelectList(_context.AidTypes, "AidTypeID", "Name");
            return View();
        }

        // POST: Disasters/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DisasterID,StartDate,EndDate,Description,Location,AidTypeID")] Disaster disaster)
        {
            if (ModelState.IsValid)
            {
                _context.Add(disaster);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AidTypeID"] = new SelectList(_context.AidTypes, "AidTypeID", "Name", disaster.AidTypeID);
            return View(disaster);
        }

        // GET: Disasters/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var disaster = await _context.Disasters.FindAsync(id);
            if (disaster == null)
            {
                return NotFound();
            }
            ViewData["AidTypeID"] = new SelectList(_context.AidTypes, "AidTypeID", "Name", disaster.AidTypeID);
            return View(disaster);
        }

        // POST: Disasters/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DisasterID,StartDate,EndDate,Description,Location,AidTypeID")] Disaster disaster)
        {
            if (id != disaster.DisasterID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(disaster);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DisasterExists(disaster.DisasterID))
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
            ViewData["AidTypeID"] = new SelectList(_context.AidTypes, "AidTypeID", "Name", disaster.AidTypeID);
            return View(disaster);
        }

        // GET: Disasters/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var disaster = await _context.Disasters
                .Include(d => d.AidType)
                .FirstOrDefaultAsync(m => m.DisasterID == id);
            if (disaster == null)
            {
                return NotFound();
            }

            return View(disaster);
        }

        // POST: Disasters/Delete/5
        [HttpPost, ActionName("Delete")]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var disaster = await _context.Disasters.FindAsync(id);
            _context.Disasters.Remove(disaster);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DisasterExists(int id)
        {
            return _context.Disasters.Any(e => e.DisasterID == id);
        }
    }
}
