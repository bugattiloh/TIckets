using System;
using Microsoft.AspNetCore.Mvc;

namespace Tickets.Infrastructure
{
    [ModelBinder(typeof(CustomBinder))]
    public class RefundDto
    {
        public string OperationType { get; set; }
        public DateTime OperationTime { get; set; }
        public string OperationPlace { get; set; }
        public string TicketNumber { get; set; }
    }
}