using System;

namespace Tickets.Middleware.Exceptions
{
    public class JsonSchemaTooLargeException : Exception
    {
        public JsonSchemaTooLargeException(string message) : base(message)
        {
            //413
        }
    }
}