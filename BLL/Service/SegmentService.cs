﻿using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BLL.Models.Dto;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models.Db;
using Npgsql;

namespace BLL.Service
{
    public class SegmentService : ISegmentService
    {
        private readonly ISegmentRepository _repository;
        private IMapper _mapper;

        public SegmentService(ISegmentRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<BaseResponse> Sale([FromBody] TicketDto ticketDto)
        {
            var tickets = _mapper.Map<Ticket>(ticketDto);
            var segments = ticketDto.Routes.Select((route, i) => new Segment()
            {
                Name = tickets.Passenger.Name,
                Surname = tickets.Passenger.Surname,
                Patronymic = tickets.Passenger.Patronymic,
                DocType = tickets.Passenger.DocType,
                DocNumber = tickets.Passenger.DocNumber,
                Birthdate = tickets.Passenger.Birthdate,
                TicketNumber = tickets.Passenger.TicketNumber,
                PassengerType = tickets.Passenger.PassengerType,
                Gender = tickets.Passenger.Gender,
                TicketType = tickets.Passenger.TicketType,
                OperationType = tickets.OperationType,
                OperationTime = tickets.OperationTime,
                OperationPlace = tickets.OperationPlace,
                AirlineCode = route.AirlineCode,
                ArriveDatetime = route.ArriveDatetime,
                ArrivePlace = route.ArrivePlace,
                DepartDatetime = route.DepartDatetime,
                DepartPlace = route.DepartPlace,
                FlightNum = route.FlightNum,
                PnrId = route.PnrId,
                SerialNumber = i,
            }).ToList();
            try
            {
                await _repository.InsertRangeAsync(segments);
            }
            catch (DbUpdateException ex)
            {
                if (ex.InnerException is PostgresException {SqlState: PostgresErrorCodes.UniqueViolation})
                {
                    return new BaseResponse(409, "Duplicate error");
                }

                return new BaseResponse(400, "Unknown error");
            }

            return new BaseResponse(200, "Ok");
        }

        public async Task<BaseResponse> Refund([FromBody] RefundDto refundDto)
        {
            var refund = _mapper.Map<Refund>(refundDto);
            var refundSegmentsFromDb =
                await _repository.FindRefundSegmentsWithSameTicketNumberAsync(refund.TicketNumber);
            if (refundSegmentsFromDb.Count == 0)
            {
                return new BaseResponse(409, "Conflict");
            }

            foreach (var segment in refundSegmentsFromDb)
            {
                segment.OperationType = "refund";
            }

            await _repository.SaveChangesAsync();
            
            return new BaseResponse(200, "OK");
        }
    }
}