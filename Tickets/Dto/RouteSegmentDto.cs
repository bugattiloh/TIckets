using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace Tickets.Infrastructure
{
    [ModelBinder(typeof(CustomBinder))]
    public class RouteSegmentDto
    {
        public string AirlineCode { get; set; }

        public int FlightNum { get; set; }

        public string DepartPlace { get; set; }
        
        [DataType(DataType.DateTime)]
        public DateTime DepartDatetime { get; set; }
        
        public string ArrivePlace { get; set; }
        
        [DataType(DataType.DateTime)]
        public DateTime ArriveDatetime { get; set; }
        
        public string PnrId;
    }
}