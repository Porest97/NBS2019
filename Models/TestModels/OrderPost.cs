using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NBS2019.Models.TestModels
{
    public class OrderPost
    {
        public int Id { get; set; }

        public string Description { get; set; }


        [Display(Name = "Article")]
        public int? ArticleId { get; set; }
        [Display(Name = "Article")]
        [ForeignKey("ArticleId")]
        public Article Article { get; set; }


        [Display(Name = "Qty")]
        public decimal Quantity { get; set; }

        [Display(Name = "Price")]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }


        [Display(Name = "Total Price")]
        [DataType(DataType.Currency)]
        public decimal Total { get; set; }
    }
}
