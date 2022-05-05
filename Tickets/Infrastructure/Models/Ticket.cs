using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tickets.Infrastructure.Models
{
    public class Ticket
    {
        [Key] public int Id { get; set; }

        public string OperationType { get; set; }
        public DateTime OperationTime { get; set; }
        public string OperationPlace { get; set; }
        public virtual Passenger Passenger { get; set; }
        public virtual ICollection<RouteSegment> Routes { get; set; }
    }
}