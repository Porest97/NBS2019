using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NBS2019.Models.TestModels
{
    public class PROWorkReport
    {
        public int Id { get; set; }

        [Display(Name = "Company")]
        [ForeignKey("CompanyId")]
        public int? CompanyId { get; set; }
        public Company Company { get; set; }

        [Display(Name = "Assigned Person")]
        public int? PersonId { get; set; }
        [ForeignKey("PersonId")]
        public Person AssignedPerson { get; set; }

        [Display(Name = "Ordered By")]
        public int? PersonId1 { get; set; }
        [ForeignKey("PersonId1")]
        public Person OrderedBy { get; set; }

        [Display(Name = "Work Started")]
        public DateTime WorkStarted { get; set; }

        [Display(Name = "Work Ended")]
        public DateTime WorkEnded { get; set; }

        [Display(Name = "Time Worked (H)")]
        public int TimeWorked { get; set; }

        [Display(Name = "Fee per hour")]
        [DataType(DataType.Currency)]
        public int FeePerHour { get; set; }

        [Display(Name = "Total Fee")]
        [DataType(DataType.Currency)]
        public int TotalPayment { get; set; }

        [Display(Name = "Purche Order")]
        public int PurchaseOrderId { get; set; }
        [ForeignKey("PurchaseOrderId")]
        public PurchaseOrder PurchaseOrder { get; set; }

        [Display(Name = "Work Description")]
        public string WorkDescription { get; set; }

        [Display(Name = "Paid")]
        public bool Paid { get; set; } = false;

        [Display(Name = "Amount Paid")]
        [DataType(DataType.Currency)]
        public int AmountPaid { get; set; }

        [Display(Name = "Due To Pay")]
        [DataType(DataType.Currency)]
        public int DueToPay { get; set; }
    }
}
