using System;
using System.Collections.Generic;

namespace LocApp.Models
{
    public partial class UserInfo
    {
        public UserInfo()
        {
            DistrictDistrictCreatedByNavigation = new HashSet<District>();
            DistrictDistrictUpdatedByNavigation = new HashSet<District>();
            InverseUpdatedByNavigation = new HashSet<UserInfo>();
            RegionRegionCreatedByNavigation = new HashSet<Region>();
            RegionRegionUpdatedByNavigation = new HashSet<Region>();
        }

        public int UserInfoId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public bool? IsActive { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }

        public virtual UserInfo UpdatedByNavigation { get; set; }
        public virtual ICollection<District> DistrictDistrictCreatedByNavigation { get; set; }
        public virtual ICollection<District> DistrictDistrictUpdatedByNavigation { get; set; }
        public virtual ICollection<UserInfo> InverseUpdatedByNavigation { get; set; }
        public virtual ICollection<Region> RegionRegionCreatedByNavigation { get; set; }
        public virtual ICollection<Region> RegionRegionUpdatedByNavigation { get; set; }
    }
}
