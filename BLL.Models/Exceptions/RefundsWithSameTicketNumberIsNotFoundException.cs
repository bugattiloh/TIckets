using System;

namespace BLL.Models.Exceptions
{
    public class RefundsWithSameTicketNumberIsNotFoundException : Exception
    {
        public RefundsWithSameTicketNumberIsNotFoundException(string message) : base(message)
        {
            //409
        }
    }
}