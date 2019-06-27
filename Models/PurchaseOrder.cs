using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NBS2019.Models
{
    public class PurchaseOrder
    {
        public int Id { get; set; }

        [Display(Name = "PO#")]
        public string PurchaseOrderNumber { get; set; }


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

        [Display(Name = "Time OnSite")]
        public decimal TimeOnSite { get; set; }


        [Display(Name = "Kost per Hour")]
        public decimal KostPerHour { get; set; }


        [Display(Name = "Total Kost")]
        public decimal TotalKost { get; set; }

        [Display(Name = "Scheduled")]
        public DateTime? JobbScheduled { get; set; }

        [Display(Name = "Started")]
        public DateTime? JobbStarted { get; set; }

        [Display(Name = "Done")]
        public DateTime? JobbEnded { get; set; }

        public string POName { get { return string.Format("{0} {1} ", PurchaseOrderNumber, Descrition); } }
    }
}
