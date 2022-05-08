using System;
using Microsoft.AspNetCore.Mvc;

namespace Tickets.Infrastructure
{
    [ModelBinder(typeof(CustomBinder))]
    public class PassengerDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public string DocType { get; set; }
        public string DocNumber { get; set; }
        public DateTime Birthdate { get; set; }
        public string Gender { get; set; }
        public string PassengerType { get; set; }
        public string TicketNumber { get; set; }
        public string TicketType { get; set; }

    }
}