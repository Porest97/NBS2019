using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NBS2019.Models
{
    public class DworkinWiFiSurveyResult
    {
        public int Id { get; set; }

        [Display(Name = "Business Centre")]
        public int? BusinessCentreId { get; set; }
        [Display(Name = "Business Centre")]
        [ForeignKey("BusinessCentreId")]
        public BusinessCentre BusinessCentre { get; set; }

        [Display(Name = "Report Date")]
        [DataType(DataType.Date)]
        public DateTime? ReportDate { get; set; }

        [Display(Name = "Version:")]
        public string Version { get; set; }

        [Display(Name = "Survey Completed By:")]
        public int? PersonId { get; set; }
        [Display(Name = "Survey Completed By:")]
        [ForeignKey("PersonId")]
        public Person AssignedFE { get; set; }

        [Display(Name = "Time Spent on Site:")]
        public decimal? TimeOnSite { get; set; }

        [Display(Name = "No. of Access Point/s Installed:")]
        public int? AccessPoints { get; set; }

        [Display(Name = "Brand/Model of Access Point/s:")]
        public string AccessPointsBrandModel { get; set; }

        [Display(Name = "A. Description of the issues (customer’s feedback).")]
        public string A { get; set; }

        [Display(Name = "B. Survey Details + Settings Netspot + Export options")]
        public string B { get; set; }

        [Display(Name = "C. Installed Access Point Locations (AP Floor Map)")]
        public string C { get; set; }

        [Display(Name = "D.	Photo of Installed Access Point/s")]
        public string D { get; set; }

        [Display(Name = "E.	Map Results")]
        public string E { get; set; }

        [Display(Name = "F.	Current AP connections in the Comms Room")]
        public string F { get; set; }

        [Display(Name = "G.	Conclusion/Recommendation")]
        public string G { get; set; }
    }
}
