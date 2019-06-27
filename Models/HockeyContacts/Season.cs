using System.ComponentModel.DataAnnotations;

namespace NBS2019.Models.HockeyContacts
{
    public class Season
    {
        public int Id { get; set; }


        [Display(Name = "Säsong")]
        public string SeasonName { get; set; }
    }
}