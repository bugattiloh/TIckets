using System;
using System.ComponentModel.DataAnnotations;

namespace Tickets.Infrastructure.Models
{
    public class Refund
    {
        [Key] public int Id { get; set; }

        public string OperationType { get; set; }
        public DateTime OperationTime { get; set; }
        public string OperationPlace { get; set; }
        public string TicketNumber { get; set; }
    }
}