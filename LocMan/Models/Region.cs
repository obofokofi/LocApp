using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LocMan.Models
{
    public partial class Region
    {
        public Region()
        {
            District = new HashSet<District>();
        }

        public int RegionId { get; set; }

        [Required(ErrorMessage ="Enter region name")]
        [DisplayName("Name of Region")]
        public string RegionName { get; set; }

        [DisplayName("Region Population")]
        public int? RegionPopulation { get; set; }

        [Required(ErrorMessage ="Enter digital address")]
        [DisplayName("Region Address")]
        public string RegionDigitalAddress { get; set; }

        [DisplayName("Year of Incorporation")]
        public DateTime RegionIncorporatedOn { get; set; }

        [DisplayName("Region Active?")]
        public bool RegionIsActive { get; set; }
        public DateTime RegionCreatedOn { get; set; }

        [DisplayName("Last Updated On")]
        public DateTime? RegionUpdatedOn { get; set; }

        [DisplayName("Last Updated By")]
        public int? RegionUpdatedBy { get; set; }

        [DisplayName("Created By")]
        public int RegionCreatedBy { get; set; }

        public virtual UserInfo RegionCreatedByNavigation { get; set; }
        public virtual UserInfo RegionUpdatedByNavigation { get; set; }
        public virtual ICollection<District> District { get; set; }
    }
}
