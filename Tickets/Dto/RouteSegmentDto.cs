using System;
using Microsoft.AspNetCore.Mvc;

namespace Tickets.Infrastructure
{
    [ModelBinder(typeof(CustomBinder))]
    public class RouteSegmentDto
    {
        public string AirlineCode { get; set; }
        public int FlightNum { get; set; }
        public string DepartPlace { get; set; }
        public DateTime DepartDatetime { get; set; }
        public string ArrivePlace { get; set; }
        public DateTime ArriveDatetime { get; set; }
        public string PnrId;
    }
}