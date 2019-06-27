using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NBS2019.Models
{
    public class Meeting
    {
        public int Id { get; set; }

        [Display(Name = "Date & Time")]
        public DateTime StartDateTime { get; set; }

        [Display(Name = "Meeting Location")]
        public int? CompanyId { get; set; }
        [Display(Name = "Meeting Location")]
        [ForeignKey("CompanyId")]
        public Company Company { get; set; }

        [Display(Name = "Meeting Guest")]
        public int? PersonId { get; set; }
        [Display(Name = "Meeting Guest")]
        [ForeignKey("PersonId")]
        public Person Employee { get; set; }

        [Display(Name = "Meeting Host")]
        public int? PersonId1 { get; set; }
        [Display(Name = "Meeting Host")]
        [ForeignKey("PersonId1")]
        public Person Person { get; set; }


        [Display(Name = "Meeting Note")]
        public string MeetingNote { get; set; }


        [Display(Name = "Meeting Type")]
        public int? MeetingTypeId { get; set; }
        [ForeignKey("MeetingTypeId")]
        public MeetingType MeetingType { get; set; }

        [Display(Name = "Status")]
        public bool Status { get; set; } = false;
    }
}
