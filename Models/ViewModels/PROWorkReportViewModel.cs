using NBS2019.Models.TestModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NBS2019.Models.ViewModels
{
    public class PROWorkReportViewModel
    {
        public List<PROWorkReport> PROWorkReports { get; set; }


        public decimal TotalTimeWorked { get; internal set; }

        public decimal TotalPayment { get; internal set; }


        public int NumberOfPayedWRs { get; internal set; }


        public decimal TotalDueToPay { get; internal set; }
    }
}
