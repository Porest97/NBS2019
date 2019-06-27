using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NBS2019.Models
{
    public class SupportTicket
    {
        public int Id { get; set; }


        public DateTime TimeStampCreated { get; set; } = DateTime.Now;


        public DateTime? TimeStampResolved { get; set; }


        public DateTime? TimeStampClosed { get; set; }

        [ForeignKey("BusinessCentreId")]
        public int? BusinessCentreId { get; set; }
        public BusinessCentre BusinessCentre { get; set; }


        public int? PersonId { get; set; }
        [ForeignKey("PersonId")]
        public Person OrderedBy { get; set; }


        public int? PersonId1 { get; set; }
        [ForeignKey("PersonId1")]
        public Person AssignedFE { get; set; }


        public string FaultDescription { get; set; }


        public string FaultReport { get; set; }


        public string TicketLog { get; set; }
    }
}
