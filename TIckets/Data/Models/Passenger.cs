using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TIckets.Models
{
    public class Passenger
    {
        [Key] public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public int DocumentType { get; set; }
        public int DocumentNumber { get; set; }
        public DateTime Birthday { get; set; }

        public string Gender { get; set; }

        public string PassengerType { get; set; }

        [ForeignKey(nameof(Passenger))] public int TicketNumber { get; set; }

        public virtual Ticket Ticket { get; set; }

        public Ticket.OperationType TicketTYpe { get; set; }

        public ICollection<Segment> Segments { get; set; }
    }
}