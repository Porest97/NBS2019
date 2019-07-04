using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NBS2019.Models
{
    public class Invoice
    {
        public int Id { get; set; }

        [Display(Name = "Company")]
        public int CompanyId { get; set; }
        [Display(Name = "Company")]
        [ForeignKey("CompanyId")]
        public Company Company { get; set; }

        [Display(Name = "Bill To")]
        public int CompanyId1 { get; set; }
        [Display(Name = "Bill To")]
        [ForeignKey("CompanyId1")]
        public Company BillTo { get; set; }

        [Display(Name = "Qty")]
        public int Qantity1 { get; set; }

        [Display(Name = "Article")]
        public int ArticleId { get; set; }
        [Display(Name = "Article")]
        [ForeignKey("ArticleId")]
        public Article Article { get; set; }

        [Display(Name = "Price")]
        public int ArticleId1 { get; set; }
        [Display(Name = "Price")]
        [ForeignKey("ArticleId1")]
        public Article ArticlePrice { get; set; }


        [Display(Name = "Amount")]
        public decimal Amount { get; set; }
    }
}
