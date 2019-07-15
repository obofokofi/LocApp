using System;
using System.Collections.Generic;

namespace LocApp.Models
{
    public partial class Region
    {
        public Region()
        {
            District = new HashSet<District>();
        }

        public int RegionId { get; set; }
        public string RegionName { get; set; }
        public int? RegionPopulation { get; set; }
        public string RegionDigitalAddress { get; set; }
        public DateTime RegionIncorporatedOn { get; set; }
        public bool RegionIsActive { get; set; }
        public DateTime RegionCreatedOn { get; set; }
        public DateTime? RegionUpdatedOn { get; set; }
        public int? RegionUpdatedBy { get; set; }
        public int RegionCreatedBy { get; set; }

        public virtual UserInfo RegionCreatedByNavigation { get; set; }
        public virtual UserInfo RegionUpdatedByNavigation { get; set; }
        public virtual ICollection<District> District { get; set; }
    }
}
