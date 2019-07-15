using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LocMan.Models;
using Microsoft.EntityFrameworkCore;

namespace LocMan.BusinessLogic
{
    public class GetLog
    {
        private readonly LocDbContext dbContext;

        public GetLog(LocDbContext Context)
        {
            dbContext = Context;
        }
        public GetLog() { }

        public async Task<District> GetDistrictLogAsync(int? id)
        {
            //District district = new District();
            var dlog = await dbContext.District
                .Include(d => d.DistrictCreatedBy)
                .Include(d => d.DistrictCreatedOn)
                .Include(d => d.DistrictUpdatedBy)
                .Include(d => d.DistrictUpdatedOn)
                .Include(d => d.DistrictName)
                .FirstOrDefaultAsync(m => m.DistrictId == id);

            return dlog;
        }
        public async Task<Region> GetRegionAsync(int? id)
        {
            var rlog = await dbContext.Region
                .Include(r => r.RegionCreatedBy)
                .Include(r => r.RegionCreatedOn)
                .Include(r => r.RegionUpdatedBy)
                .Include(r => r.RegionUpdatedOn)
                .Include(r => r.RegionName)
                .FirstOrDefaultAsync(m=>m.RegionId==id);

            return rlog;
        }
    }
}
