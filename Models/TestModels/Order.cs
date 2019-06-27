using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NBS2019.Models.TestModels
{
    public class Order
    {
        public int Id { get; set; }

        [Display(Name = "Ordered By")]
        public int? PersonId { get; set; }
        [Display(Name = "Ordered By")]
        [ForeignKey("PersonId")]
        public Person OrderedBy { get; set; }

        [Display(Name = "Article #1")]
        public int? OrderPostId { get; set; }
        [Display(Name = "Article #1")]
        [ForeignKey("PersonId")]
        public OrderPost OrderPost1 { get; set; }

    }
}
