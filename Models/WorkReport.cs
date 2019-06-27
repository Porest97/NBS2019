using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NBS2019.Models
{
    public class WorkReport
    {
        public int Id { get; set; }

        [Display(Name = "Business Center")]
        [ForeignKey("BusinessCentreId")]
        public int? BusinessCentreId { get; set; }
        public BusinessCentre BusinessCentre { get; set; }

        [Display(Name = "Assingd FE")]
        public int? PersonId { get; set; }
        [ForeignKey("PersonId")]
        public Person AssignedFE { get; set; }

        [Display(Name = "Work Started")]
        public DateTime WorkStarted { get; set; }

        [Display(Name = "Work Ended")]
        public DateTime WorkEnded { get; set; }

        [Display(Name = "ToS(H)")]
        public decimal TimeWorked { get; set; }

        [Display(Name = "CpH(kr)")]
        [DataType(DataType.Currency)]
        public decimal PaymentPerHour { get; set; }

        [Display(Name = "TF(kr)")]
        [DataType(DataType.Currency)]
        public decimal TotalPayment { get; set; }

        [Display(Name = "Work Notes")]
        public string WorkNote { get; set; }

        [Display(Name = "Paid")]
        public bool Paid { get; set; } = false;

        [Display(Name = "Paid(kr)")]
        [DataType(DataType.Currency)]
        public decimal AmountPaid { get; set; }

        [Display(Name = "Remaining")]
        [DataType(DataType.Currency)]
        public decimal DueToPay { get; set; }
    }
}
