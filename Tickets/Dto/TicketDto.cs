using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Tickets.Infrastructure.Models;

namespace Tickets.Infrastructure
{
    [ModelBinder(typeof(CustomBinder))]
    public class TicketDto
    {
        public string OperationType { get; set; }
        public DateTime OperationTime { get; set; }
        public string OperationPlace { get; set; }
        public PassengerDto Passenger { get; set; }
        public ICollection<RouteSegmentDto> Routes { get; set; }
    }
}