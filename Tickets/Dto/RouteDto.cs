using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Tickets.ValidationAttributes.ValidationSchemaAttribute;

namespace Tickets.Dto
{
    [ModelBinder(typeof(CustomBinder))]
    public class RouteDto
    {
        [Required]
        public string AirlineCode { get; set; }

        [Required]
        public int FlightNum { get; set; }

        [Required]
        public string DepartPlace { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime DepartDatetime { get; set; }

        [Required]
        public string ArrivePlace { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime ArriveDatetime { get; set; }

        [Required]
        public string PnrId { get; set; }
    }
}