using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TIckets.Models
{
    public class Segment
    {
        [Key]
        public int Id{ get; set; }
        public string AirlineCode{ get; set; }
        public int FlightNumber{ get; set; }
        public string DepartPlace{ get; set; }
        public DateTime DepartDateTime{ get; set; }
        public string ArrivePlace{ get; set; }
        public DateTime ArriveDateTime{ get; set; }
        
        [ForeignKey(nameof(Passenger))]
        public int PassengerId;
        public virtual Passenger Passenger { get; set; }

    }
}