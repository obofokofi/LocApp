using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LocMan.Models
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

        [Required(ErrorMessage = "Enter your first name")]
        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Enter other name(s)")]
        [DisplayName("Other Names")]
        public string LastName { get; set; }

        [DisplayName("Your Username")]
        public string Username { get; set; }
        public bool? IsActive { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }

        [Required(ErrorMessage ="Enter a password")]
        [DisplayName("Password")]
        [DataType(DataType.Password)]
        public string UserPass { get; set; }

        [Required(ErrorMessage = "Repeat password to confirm")]
        [DisplayName("Confirm Password")]
        [DataType(DataType.Password)]
        [Compare("UserPass")]
        public string PassConfirm { get; }

        public virtual UserInfo UpdatedByNavigation { get; set; }
        public virtual ICollection<District> DistrictDistrictCreatedByNavigation { get; set; }
        public virtual ICollection<District> DistrictDistrictUpdatedByNavigation { get; set; }
        public virtual ICollection<UserInfo> InverseUpdatedByNavigation { get; set; }
        public virtual ICollection<Region> RegionRegionCreatedByNavigation { get; set; }
        public virtual ICollection<Region> RegionRegionUpdatedByNavigation { get; set; }
    }
}
