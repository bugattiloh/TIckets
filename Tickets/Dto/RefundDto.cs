using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Tickets.ValidationAttributes.ValidationSchemaAttribute;
using Tickets.ValidationAttributes.ValidationValuesAttributes;

namespace Tickets.Dto
{
    [ModelBinder(typeof(CustomBinder))]
    public class RefundDto
    {
        [Required]
        [RegularExpression("(sale|refund){1}", ErrorMessage = "OperationType error")]
        public string OperationType { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime OperationTime { get; set; }

        [Required]
        public string OperationPlace { get; set; }

        [Required]
        [OnlyNumbers]
        public string TicketNumber { get; set; }
    }
}