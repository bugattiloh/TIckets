using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tickets.Infrastructure.Models
{
    public class RouteSegment
    {
        [Key] public int Id { get; set; }
        public string AirlineCode { get; set; }
        public int FlightNum { get; set; }
        public string DepartPlace { get; set; }
        public DateTime DepartDatetime { get; set; }
        public string ArrivePlace { get; set; }
        public DateTime ArriveDatetime { get; set; }
        public string PnrId;


        [ForeignKey(nameof(Ticket))] public int TicketId { get; set; }

        public virtual Ticket Ticket { get; set; }

        public RouteSegment(string pnrId, int id, string airlineCode, int flightNum, string departPlace,
            DateTime departDatetime, string arrivePlace, DateTime arriveDatetime, int ticketId)
        {
            PnrId = pnrId;
            Id = id;
            AirlineCode = airlineCode;
            FlightNum = flightNum;
            DepartPlace = departPlace;
            DepartDatetime = departDatetime;
            ArrivePlace = arrivePlace;
            ArriveDatetime = arriveDatetime;
            TicketId = ticketId;
        }
    }
}