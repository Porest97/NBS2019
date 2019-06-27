using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NBS2019.Models.HockeyContacts
{
    public class ContactRaw
    {
        public int Id { get; set; }

        [Display(Name = "Klubb")]
        public string Club { get; set; }
        [Display(Name = "Lag")]
        public string Team { get; set; }
        [Display(Name = "Roll")]
        public string Role { get; set; }
        [Display(Name = "Sport")]
        public string Sport { get; set; }
        [Display(Name = "Distrikt")]
        public string District { get; set; }
        [Display(Name = "Förnamn")]
        public string FirstName { get; set; }
        [Display(Name = "Efternamn")]
        public string LastName { get; set; }
        [Display(Name = "Telefon 1")]
        public string PhoneNumber1 { get; set; }
        [Display(Name = "Telefon 2")]
        public string PhoneNumber2 { get; set; }
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Display(Name = "SSN#")]
        public string Ssn { get; set; }
        [Display(Name = "Säsong")]
        public string Season { get; set; }
        [Display(Name = "Födda")]
        public string AgeCategory { get; set; }


        [Display(Name = "Namn")]
        public string FullName { get { return string.Format("{0} {1} ", FirstName, LastName); } }

        [Display(Name = "Telefonnummer")]
        public string PhoneNumbers { get { return string.Format("{0} {1} ", PhoneNumber1, PhoneNumber2); } }

    }
}
