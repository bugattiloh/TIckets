using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Tickets.ValidationAttributes.ValidationSchemaAttribute;
using Tickets.ValidationAttributes.ValidationValuesAttributes;

namespace Tickets.Dto
{
    [ModelBinder(typeof(CustomBinder))]
    public class PassengerDto
    {
        [Required]
        [OnlyLetters]
        public string Name { get; set; }

        [Required]
        [OnlyLetters]
        public string Surname { get; set; }

        [Required]
        [OnlyLetters]
        public string Patronymic { get; set; }

        [Required]
        [OnlyNumbers]
        [StringLength(2,MinimumLength = 2)]
        public string DocType { get; set; }

        [Required]
        [OnlyNumbers] 
        public string DocNumber { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Birthdate { get; set; }

        [Required]
        [RegularExpression("[MF]{1}", ErrorMessage = "gender validation error")]
        public string Gender { get; set; }

        [Required]
        [RegularExpression("(youth|adult|senior){1}", ErrorMessage = "PassengerType validation error")]
        public string PassengerType { get; set; }

        [Required]
        [OnlyNumbers]
        [StringLength(13,MinimumLength = 13)]
        public string TicketNumber { get; set; }

        [Required]
        [Range(0, 2, ErrorMessage = "TicketType validation error")]
        public int TicketType { get; set; }
    }
}