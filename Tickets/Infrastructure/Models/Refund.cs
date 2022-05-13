using System;
using System.ComponentModel.DataAnnotations;

namespace Tickets.Infrastructure.Models
{
    public class Refund
    {
        
        public string OperationType { get; set; }
        
        public DateTime OperationTime { get; set; }
        
        public string OperationPlace { get; set; }
        
        public string TicketNumber { get; set; }
    }
}