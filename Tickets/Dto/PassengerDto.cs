using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Tickets.Utils;

namespace Tickets.Dto
{
    [ModelBinder(typeof(CustomBinder))]
    public class PassengerDto
    {
        public string Name { get; set; }  
        
        public string Surname { get; set; }
        
        public string Patronymic { get; set; }
        
        public string DocType { get; set; }
        
        public string DocNumber { get; set; }
        
        [DataType(DataType.Date)]
        public DateTime Birthdate { get; set; }
        
        public string Gender { get; set; }
        
        public string PassengerType { get; set; }
        public string TicketNumber { get; set; }
        
        public int TicketType { get; set; }
    }
}