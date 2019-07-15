using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LocMan.Models;

namespace LocMan.Controllers
{
    public class RegionsController : Controller
    {
        private readonly LocDbContext _context;

        public RegionsController(LocDbContext context)
        {
            _context = context;
        }

        // GET: Regions
        public async Task<IActionResult> SeeRegion()
        {
            var locDbContext = _context.Region.Include(r => r.RegionCreatedByNavigation).Include(r => r.RegionUpdatedByNavigation);
           return View(await locDbContext.ToListAsync());
        }

        // GET: Regions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var region = await _context.Region
                .Include(r => r.RegionCreatedByNavigation)
                .Include(r => r.RegionUpdatedByNavigation)
                .FirstOrDefaultAsync(m => m.RegionId == id);
            if (region == null)
            {
                return NotFound();
            }

            return View(region);
        }

        // GET: Regions/Create
        public IActionResult Create()
        {
            ViewData["RegionCreatedBy"] = new SelectList(_context.UserInfo, "UserInfoId", "FirstName");
            ViewData["RegionUpdatedBy"] = new SelectList(_context.UserInfo, "UserInfoId", "FirstName");
            return View();
        }

        // POST: Regions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RegionName,RegionPopulation,RegionDigitalAddress,RegionIsActive,RegionIncorporatedOn")] Region region)
        {
            if (ModelState.IsValid)
            {
                region.RegionCreatedBy = 1;
                region.RegionCreatedOn = DateTime.Today;
                region.RegionIsActive = true;
                _context.Add(region);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(SeeRegion));
            }
            ViewData["RegionCreatedBy"] = new SelectList(_context.UserInfo, "UserInfoId", "FirstName", region.RegionCreatedBy);
            ViewData["RegionUpdatedBy"] = new SelectList(_context.UserInfo, "UserInfoId", "FirstName", region.RegionUpdatedBy);
            return View(region);
        }

        // GET: Regions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var region = await _context.Region.FindAsync(id);
            if (region == null)
            {
                return NotFound();
            }
            ViewData["RegionCreatedBy"] = new SelectList(_context.UserInfo, "UserInfoId", "FirstName", region.RegionCreatedBy);
            ViewData["RegionUpdatedBy"] = new SelectList(_context.UserInfo, "UserInfoId", "FirstName", region.RegionUpdatedBy);
            return View(region);
        }

        // POST: Regions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RegionId,RegionName,RegionPopulation,RegionDigitalAddress,RegionIncorporatedOn,RegionIsActive,RegionCreatedOn,RegionUpdatedOn,RegionUpdatedBy,RegionCreatedBy")] Region region)
        {
            if (id != region.RegionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(region);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RegionExists(region.RegionId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(SeeRegion));
            }
            ViewData["RegionCreatedBy"] = new SelectList(_context.UserInfo, "UserInfoId", "FirstName", region.RegionCreatedBy);
            ViewData["RegionUpdatedBy"] = new SelectList(_context.UserInfo, "UserInfoId", "FirstName", region.RegionUpdatedBy);
            return View(region);
        }

        // GET: Regions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var region = await _context.Region
                .Include(r => r.RegionCreatedByNavigation)
                .Include(r => r.RegionUpdatedByNavigation)
                .FirstOrDefaultAsync(m => m.RegionId == id);
            if (region == null)
            {
                return NotFound();
            }

            return View(region);
        }

        // POST: Regions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var region = await _context.Region.FindAsync(id);
            _context.Region.Remove(region);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(SeeRegion));
        }

        private bool RegionExists(int id)
        {
            return _context.Region.Any(e => e.RegionId == id);
        }
    }
}
