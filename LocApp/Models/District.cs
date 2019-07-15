using System;
using System.Collections.Generic;

namespace LocApp.Models
{
    public partial class District
    {
        public int DistrictId { get; set; }
        public string DistrictName { get; set; }
        public int DistrictPopulation { get; set; }
        public string DistrictDigitalAddress { get; set; }
        public DateTime DistrictIncorporatedOn { get; set; }
        public DateTime DistrictCreatedOn { get; set; }
        public DateTime? DistrictUpdatedOn { get; set; }
        public bool DistrictIsActive { get; set; }
        public int? RegionId { get; set; }
        public int DistrictCreatedBy { get; set; }
        public int? DistrictUpdatedBy { get; set; }

        public virtual UserInfo DistrictCreatedByNavigation { get; set; }
        public virtual UserInfo DistrictUpdatedByNavigation { get; set; }
        public virtual Region Region { get; set; }
    }
}
