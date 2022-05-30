using System;

namespace Models.Db
{
    public class Passenger
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
        
        public int TicketType { get; set; }
        public virtual Ticket Ticket { get; set; }
    }
}