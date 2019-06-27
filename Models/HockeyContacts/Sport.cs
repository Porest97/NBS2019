using System.ComponentModel.DataAnnotations;

namespace NBS2019.Models.HockeyContacts
{
    public class Sport
    {
        public int Id { get; set; }

        [Display(Name="Sport")]
        public string SportName { get; set; }
    }
}