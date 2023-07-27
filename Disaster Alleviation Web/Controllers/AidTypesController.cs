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
    public class AidTypesController : Controller
    {
        private readonly DisasterReliefContext _context;

        public AidTypesController(DisasterReliefContext context)
        {
            _context = context;
        }

        // GET: AidTypes
        [Authorize]
        public async Task<IActionResult> Index()
        {
            return View(await _context.AidTypes.ToListAsync());
        }

        // GET: AidTypes/Details/5
        [Authorize]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aidType = await _context.AidTypes
                .FirstOrDefaultAsync(m => m.AidTypeID == id);
            if (aidType == null)
            {
                return NotFound();
            }

            return View(aidType);
        }

        // GET: AidTypes/Create
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: AidTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AidTypeID,Name")] AidType aidType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(aidType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(aidType);
        }

        // GET: AidTypes/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aidType = await _context.AidTypes.FindAsync(id);
            if (aidType == null)
            {
                return NotFound();
            }
            return View(aidType);
        }

        // POST: AidTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AidTypeID,Name")] AidType aidType)
        {
            if (id != aidType.AidTypeID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(aidType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AidTypeExists(aidType.AidTypeID))
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
            return View(aidType);
        }

        // GET: AidTypes/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aidType = await _context.AidTypes
                .FirstOrDefaultAsync(m => m.AidTypeID == id);
            if (aidType == null)
            {
                return NotFound();
            }

            return View(aidType);
        }

        // POST: AidTypes/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var aidType = await _context.AidTypes.FindAsync(id);
            _context.AidTypes.Remove(aidType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AidTypeExists(int id)
        {
            return _context.AidTypes.Any(e => e.AidTypeID == id);
        }
    }
}
