using System;
using System.ComponentModel.DataAnnotations;

namespace TIckets.Models
{
    public class Ticket
    {
        [Key]
        public int Number;
        public enum OperationType
        {
            Sale = 1,
            Refund = 2
        }

        public DateTime OperationTime;
        public string OperationPlace;
    }
}