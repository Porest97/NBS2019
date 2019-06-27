using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NBS2019.Models.TestModels
{
    public class Salary
    {
        public int Id { get; set; }

        [Display(Name = "Start Date")]
        [DataType(DataType.Date)]
        public DateTime PeriodStartDate { get; set; }


        [Display(Name = "End Date")]
        [DataType(DataType.Date)]
        public DateTime PeriodEndDate { get; set; }

        [Display(Name = "Employee")]
        public int? PersonId { get; set; }
        [Display(Name = "Employee")]
        [ForeignKey("PersonId")]
        public Person Emplyee { get; set; }


        [Display(Name = "Description")]
        public int? ArticleId { get; set; }
        [Display(Name = "Description")]
        [ForeignKey("ArticleId")]
        public Article Article { get; set; }


        [Display(Name = "Hours")]
        public decimal Hours { get; set; }

        [Display(Name = "Salary")]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }


        [Display(Name = "Total Salary")]
        [DataType(DataType.Currency)]
        public decimal TotalSalary { get; set; }

        [Display(Name = "Paid")]
        public bool Paid { get; set; } = false;

        [Display(Name = "Amount Paid")]
        [DataType(DataType.Currency)]
        public decimal AmountPaidOut { get; set; }

        [Display(Name = "Date Paid")]
        public DateTime? DatePaidOut { get; set; } = DateTime.Now.Date;


        [Display(Name = "Amount Due TO Pay")]
        [DataType(DataType.Currency)]
        public decimal AmountDueToPayOut { get; set; }
    }
}
