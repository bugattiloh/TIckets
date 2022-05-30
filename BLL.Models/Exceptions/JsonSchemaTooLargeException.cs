using System;

namespace BLL.Models.Exceptions
{
    public class JsonSchemaTooLargeException : Exception
    {
        public JsonSchemaTooLargeException(string message) : base(message)
        {
            //413
        }
    }
}