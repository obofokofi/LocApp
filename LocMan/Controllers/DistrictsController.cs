using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LocMan.Models;
using LocMan.BusinessLogic;

namespace LocMan.Controllers
{
    public class DistrictsController : Controller
    {
        private readonly LocDbContext _context;
        private readonly GetLog _log;

        public DistrictsController(LocDbContext context, GetLog log)
        {
            _context = context;
            _log = log;
        }

        // GET: Districts
        [HttpGet]
        public async Task<IActionResult> SeeDistrict()
        {
            var locDbContext = _context.District.Include(d => d.DistrictCreatedByNavigation).Include(d => d.DistrictUpdatedByNavigation).Include(d => d.Region);
            return View(await locDbContext.ToListAsync());
        }

        // GET: Districts/Details/5
        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            
            //var district = await _log.GetDistrictLogAsync(id);
            var district = await _context.District
            .Include(d => d.DistrictCreatedByNavigation)
            .Include(d => d.DistrictUpdatedByNavigation)
            .Include(d => d.Region)
            .FirstOrDefaultAsync(m => m.DistrictId == id);
            if (district == null)
            {
                return NotFound();
            }
            string storeupdate,storeactive;
            if (district.DistrictUpdatedBy == null)
            {
                storeupdate = district.DistrictUpdatedBy.ToString();
                storeupdate = storeupdate + ("Not Updated");
                district.UpdateName = storeupdate;
            }
            else
            {
                storeupdate = district.DistrictUpdatedByNavigation.FirstName;
                district.UpdateName = storeupdate;
            }

            if (district.DistrictIsActive == true)
            {
                storeactive = "Yes";
                district.Active = storeactive;
            }
            else
            {
                storeactive = "No";
                district.Active = storeactive;
            }

            return View(district);
        }

        public async Task<IActionResult> GetLog(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var district = await _log.GetDistrictLogAsync(id);
            if (district == null)
            {
                return NotFound();
            }

            return View(district);
        }

        // GET: Districts/Create
        [HttpGet]
        public IActionResult Create()
        {
            ViewData["DistrictCreatedBy"] = new SelectList(_context.UserInfo, "UserInfoId", "FirstName");
            ViewData["DistrictUpdatedBy"] = new SelectList(_context.UserInfo, "UserInfoId", "FirstName");
            ViewData["RegionId"] = new SelectList(_context.Region, "RegionId", "RegionName");
            return View();
        }

        // POST: Districts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DistrictId,DistrictName,DistrictPopulation,DistrictDigitalAddress,DistrictIncorporatedOn,DistrictCreatedOn,DistrictUpdatedOn,DistrictIsActive,RegionId,DistrictCreatedBy,DistrictUpdatedBy")] District district)
        {
            if (ModelState.IsValid)
            {
                district.DistrictIsActive = true;
                district.DistrictCreatedBy = 1;
                district.DistrictCreatedOn = DateTime.Today;
                _context.Add(district);
                
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(SeeDistrict));
            }
            ViewData["DistrictCreatedBy"] = new SelectList(_context.UserInfo, "UserInfoId", "FirstName", district.DistrictCreatedBy);
            ViewData["DistrictUpdatedBy"] = new SelectList(_context.UserInfo, "UserInfoId", "FirstName", district.DistrictUpdatedBy);
            ViewData["RegionId"] = new SelectList(_context.Region, "RegionId", "RegionName", district.RegionId);
            return View(district);
        }

        // GET: Districts/Edit/5
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var district = await _context.District.FindAsync(id);
            if (district == null)
            {
                return NotFound();
            }
            ViewData["DistrictCreatedBy"] = new SelectList(_context.UserInfo, "UserInfoId", "FirstName", district.DistrictCreatedBy);
            ViewData["DistrictUpdatedBy"] = new SelectList(_context.UserInfo, "UserInfoId", "FirstName", district.DistrictUpdatedBy);
            ViewData["RegionId"] = new SelectList(_context.Region, "RegionId", "RegionName", district.RegionId);
            return View(district);
        }

        // POST: Districts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DistrictId,DistrictName,DistrictPopulation,DistrictDigitalAddress,DistrictIncorporatedOn,DistrictCreatedOn,DistrictUpdatedOn,DistrictIsActive,RegionId,DistrictCreatedBy,DistrictUpdatedBy")] District district)
        {
            if (id != district.DistrictId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(district);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DistrictExists(district.DistrictId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(SeeDistrict));
            }
            ViewData["DistrictCreatedBy"] = new SelectList(_context.UserInfo, "UserInfoId", "FirstName", district.DistrictCreatedBy);
            ViewData["DistrictUpdatedBy"] = new SelectList(_context.UserInfo, "UserInfoId", "FirstName", district.DistrictUpdatedBy);
            ViewData["RegionId"] = new SelectList(_context.Region, "RegionId", "RegionName", district.RegionId);
            return View(district);
        }

        // GET: Districts/Delete/5
        [HttpGet]
        
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var district = await _context.District
                .Include(d => d.DistrictCreatedByNavigation)
                .Include(d => d.DistrictUpdatedByNavigation)
                .Include(d => d.Region)
                .FirstOrDefaultAsync(m => m.DistrictId == id);
            if (district == null)
            {
                return NotFound();
            }

            return View(district);
        }

        // POST: Districts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var district = await _context.District.FindAsync(id);
            district.DistrictIsActive = false;
            _context.Add(district);
            _context.Update(district);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(SeeDistrict));

            //_context.District.Remove(district);
            //await _context.SaveChangesAsync();
           // return RedirectToAction(nameof(SeeDistrict));
        }

        private bool DistrictExists(int id)
        {
            return _context.District.Any(e => e.DistrictId == id);
        }
    }
}
