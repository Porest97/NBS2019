using System.ComponentModel.DataAnnotations;

namespace NBS2019.Models
{
    public class PersonType
    {
        public int Id { get; set; }

        [Display(Name = "Person Type")]
        public string PersonTypeName { get; set; }
    }
}