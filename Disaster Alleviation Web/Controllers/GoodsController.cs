using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Disaster_Alleviation_Web.Data;
using Disaster_Alleviation_Web.Models.Donation;
using Microsoft.AspNetCore.Authorization;

namespace Disaster_Alleviation_Web.Controllers
{
    public class GoodsController : Controller
    {
        private readonly DisasterReliefContext _context;

        public GoodsController(DisasterReliefContext context)
        {
            _context = context;
        }


        // GET: Goods
        [Authorize]
        public async Task<IActionResult> Index()
        {

            var goods = _context.Goods.
                Include(g => g.Category)
                .Include(g => g.Disaster)
                .AsNoTracking();
            return View(await goods.ToListAsync());
        }

        // GET: Goods/Details/5
        [Authorize]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var good = await _context.Goods
                .Include(g => g.Category)
                .Include(g => g.Disaster)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.GoodID == id);
            if (good == null)
            {
                return NotFound();
            }

            return View(good);
        }

        // GET: Goods/Create
        [Authorize]
        public IActionResult Create()
        {
            ViewData["CategoryID"] = new SelectList(_context.Categories, "CategoryID", "Name");
            ViewData["DisasterID"] = new SelectList(_context.Disasters, "DisasterID", "DisasterID");
            return View();
        }

        // POST: Goods/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GoodID,DonationDate,NumberOfItems,Description,DonorName,CategoryID,DisasterID")] Good good)
        {
            if (ModelState.IsValid)
            {
                _context.Add(good);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryID"] = new SelectList(_context.Categories, "CategoryID", "Name", good.CategoryID);
            ViewData["DisasterID"] = new SelectList(_context.Disasters, "DisasterID", "DisasterID", good.DisasterID);
            return View(good);
        }

        // GET: Goods/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var good = await _context.Goods.FindAsync(id);
            if (good == null)
            {
                return NotFound();
            }
            ViewData["CategoryID"] = new SelectList(_context.Categories, "CategoryID", "Name", good.CategoryID);
            ViewData["DisasterID"] = new SelectList(_context.Disasters, "DisasterID", "DisasterID", good.DisasterID);
            return View(good);
        }

        // POST: Goods/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("GoodID,DonationDate,NumberOfItems,Description,DonorName,CategoryID,DisasterID")] Good good)
        {
            if (id != good.GoodID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(good);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GoodExists(good.GoodID))
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
            ViewData["CategoryID"] = new SelectList(_context.Categories, "CategoryID", "CategoryID", good.CategoryID);
            ViewData["DisasterID"] = new SelectList(_context.Disasters, "DisasterID", "DisasterID", good.DisasterID);
            return View(good);
        }

        // GET: Goods/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var good = await _context.Goods
                .Include(g => g.Category)
                .Include(g => g.Disaster)
                .FirstOrDefaultAsync(m => m.GoodID == id);
            if (good == null)
            {
                return NotFound();
            }

            return View(good);
        }

        // POST: Goods/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var good = await _context.Goods.FindAsync(id);
            _context.Goods.Remove(good);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GoodExists(int id)
        {
            return _context.Goods.Any(e => e.GoodID == id);
        }
    }
}
