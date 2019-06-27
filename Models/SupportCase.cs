using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NBS2019.Models
{
    public class SupportCase
    {
        public int Id { get; set; }

        public DateTime? TimeReported { get; set; }


        public DateTime? TimeStarted { get; set; }


        public DateTime? TimeFEScheduled { get; set; }


        public DateTime? TimeSolved { get; set; }


        public decimal? TotalTimeOnSite { get; set; }

        [Display(Name = "Business Center")]
        [ForeignKey("BusinessCentreId")]
        public int? BusinessCentreId { get; set; }
        public BusinessCentre BusinessCentre { get; set; }

        [Display(Name = "Ordered By")]
        public int? PersonId { get; set; }
        [ForeignKey("PersonId")]
        public Person OrderedBy { get; set; }

        [Display(Name = "Assingd FE")]
        public int? PersonId1 { get; set; }
        [ForeignKey("PersonId1")]
        public Person AssignedFE { get; set; }

        [Display(Name = "Description")]
        public string Descrition { get; set; }

        [Display(Name = "Purche Order")]
        public int? PurchaseOrderId { get; set; }
        [ForeignKey("PurchaseOrderId")]
        public PurchaseOrder PurchaseOrder { get; set; }
    }
}
