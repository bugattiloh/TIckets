﻿using System;

namespace Tickets.Middleware.Exceptions
{
    public class RefundsWithSameTicketNumberIsNotFoundException : Exception
    {
        public RefundsWithSameTicketNumberIsNotFoundException(string message) : base(message)
        {
            //409
        }
    }
}