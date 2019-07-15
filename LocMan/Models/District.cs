using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace LocMan.Models
{
    public partial class District
    {
        public int DistrictId { get; set; }

        [Required(ErrorMessage ="Enter district name")]
        [DisplayName("Name of District")]
        public string DistrictName { get; set; }

        [Required(ErrorMessage ="Enter population of district")]
        [DisplayName("District Population")]
        public int DistrictPopulation { get; set; }

        [Required(ErrorMessage ="Enter digital address")]
        [DisplayName("District Address")]
        public string DistrictDigitalAddress { get; set; }

        [DisplayName("Year of Incorporation")]
        public DateTime DistrictIncorporatedOn { get; set; }

        [DisplayName("Created On")]
        public DateTime DistrictCreatedOn { get; set; }

        [DisplayName("Updated On")]
        public DateTime? DistrictUpdatedOn { get; set; }

        [DisplayName("District Active?")]
        public bool DistrictIsActive { get; set; }

        [DisplayName("Region")]
        public int? RegionId { get; set; }

        public int DistrictCreatedBy { get; set; }
        public int? DistrictUpdatedBy { get; set; }

        [DisplayName("Created By")]
        public virtual UserInfo DistrictCreatedByNavigation { get; set; }

        [DisplayName("Updated By")]
        public virtual UserInfo DistrictUpdatedByNavigation { get; set; }
        public virtual Region Region { get; set; }

        public string UpdateName;
        public string Active;
    }
}
