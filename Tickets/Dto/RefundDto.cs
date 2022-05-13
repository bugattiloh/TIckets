using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Tickets.Utils;

namespace Tickets.Dto
{
    [ModelBinder(typeof(CustomBinder))]
    public class RefundDto
    {
        public string OperationType { get; set; }
        
        [DataType(DataType.DateTime)]
        public DateTime OperationTime { get; set; }
        
        public string OperationPlace { get; set; }
        public string TicketNumber { get; set; }
    }
}