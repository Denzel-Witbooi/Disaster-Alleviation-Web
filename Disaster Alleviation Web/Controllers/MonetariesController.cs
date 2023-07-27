using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Disaster_Alleviation_Web.Data;
using Disaster_Alleviation_Web.Models.Donation;
using Microsoft.AspNetCore.Authorization;

namespace Disaster_Alleviation_Web.Controllers
{
    public class MonetariesController : Controller
    {
        private readonly DisasterReliefContext _context;

        public decimal totalDonation { get; set; }
        public MonetariesController(DisasterReliefContext context)
        {
            _context = context;
        }

        public decimal getTotalDonation()
        {
            totalDonation = _context.Monetaries
                .Sum(m => m.DonationAmount);
            return totalDonation;
        }
        // GET: Monetaries
        [Authorize]
        public async Task<IActionResult> Index()
        {
            totalDonation = _context.Monetaries
                .Sum(m => m.DonationAmount);
            ViewBag.totalDonation = totalDonation.ToString("C0");
            return View(await _context.Monetaries.ToListAsync());
        }

        // GET: Monetaries/Details/5
        [Authorize]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var monetary = await _context.Monetaries
                .FirstOrDefaultAsync(m => m.MonetaryID == id);
            if (monetary == null)
            {
                return NotFound();
            }

            return View(monetary);
        }

        // GET: Monetaries/Create
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Monetaries/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MonetaryID,DonationDate,DonationAmount,DonorName")] Monetary monetary)
        {
            if (ModelState.IsValid)
            {
                _context.Add(monetary);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(monetary);
        }

        // GET: Monetaries/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var monetary = await _context.Monetaries.FindAsync(id);
            if (monetary == null)
            {
                return NotFound();
            }
            return View(monetary);
        }

        // POST: Monetaries/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MonetaryID,DonationDate,DonationAmount,DonorName")] Monetary monetary)
        {
            if (id != monetary.MonetaryID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(monetary);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MonetaryExists(monetary.MonetaryID))
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
            return View(monetary);
        }

        // GET: Monetaries/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var monetary = await _context.Monetaries
                .FirstOrDefaultAsync(m => m.MonetaryID == id);
            if (monetary == null)
            {
                return NotFound();
            }

            return View(monetary);
        }

        // POST: Monetaries/Delete/5
        [HttpPost, ActionName("Delete")]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var monetary = await _context.Monetaries.FindAsync(id);
            _context.Monetaries.Remove(monetary);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MonetaryExists(int id)
        {
            return _context.Monetaries.Any(e => e.MonetaryID == id);
        }
    }
}
