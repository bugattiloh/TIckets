using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tickets.Infrastructure.Models
{
    public class Route
    {
        
        public string AirlineCode { get; set; }
        
        public int FlightNum { get; set; }
        
        public string DepartPlace { get; set; }
        
        public DateTime DepartDatetime { get; set; }
        
        public string ArrivePlace { get; set; }
        
        public DateTime ArriveDatetime { get; set; }
        
        public string PnrId;
        
        public virtual Ticket Ticket { get; set; }
    }
}