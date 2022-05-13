using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Tickets.Utils;

namespace Tickets.Dto
{
    [ModelBinder(typeof(CustomBinder))]
    public class TicketDto
    {
        public string OperationType { get; set; }
        
        [DataType(DataType.DateTime)]
        public DateTime OperationTime { get; set; }
        
        public string OperationPlace { get; set; }
        public PassengerDto Passenger { get; set; }
        
        public ICollection<RouteDto> Routes { get; set; }
    }
}