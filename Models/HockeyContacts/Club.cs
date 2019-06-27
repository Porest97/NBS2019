using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NBS2019.Models.HockeyContacts
{
    public class Club
    {
        public int Id { get; set; }

        public string ClubName { get; set; }

        [Display(Name = "Distrikt")]
        public int? DistrictId { get; set; }
        [Display(Name = "Distrikt")]
        [ForeignKey("DistrictId")]
        public District District { get; set; }
    }
}
