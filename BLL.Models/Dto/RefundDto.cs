using System;
using System.ComponentModel.DataAnnotations;
using BLL.Models.ValidationAttributes.ValidationSchemaAttribute;
using BLL.Models.ValidationAttributes.ValidationValuesAttributes;
using Microsoft.AspNetCore.Mvc;

namespace BLL.Models.Dto
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
        [StringLength(13,MinimumLength = 13)]
        public string TicketNumber { get; set; }
    }
}