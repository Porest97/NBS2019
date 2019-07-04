using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NBS2019.Models.ViewModels
{
    public class WorkReportViewModel
    {
        public List<WorkReport> WorkReports { get; set; }


        public decimal TotalTimeWorked { get; internal set; }

        public decimal TotalPayment { get; internal set; }


        public int NumberOfPayedWRs { get; internal set; }


        public decimal TotalDueToPay { get; internal set; }
    }
}
