using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.OpenApi.Models;
using Moq;
using NUnit.Framework;
using Tickets.Infrastructure;
using Tickets.Infrastructure.Models;
using Tickets.Repository;


namespace Test.TestMethods
{
    public class SegmentTest
    {
        private Mock<ISegmentRepository> _segmentRepositoryMock;
        private ICollection<Segment> _segments;


        [SetUp]
        public void Setup()
        {
            _segmentRepositoryMock = new Mock<ISegmentRepository>();
            _segments = new List<Segment>();
            _segments.Add(new Segment()
                {Id = 1, TicketNumber = "1", SerialNumber = 1, OperationType = "sale"});
            _segments.Add(new Segment()
                {Id = 2, TicketNumber = "2", SerialNumber = 2, OperationType = "sale"});
            _segments.Add(new Segment()
                {Id = 3, TicketNumber = "3", SerialNumber = 3, OperationType = "refund"});
            _segments.Add(new Segment()
                {Id = 4, TicketNumber = "4", SerialNumber = 4, OperationType = "sale"});
        }

        [Test]
        public async Task TestFindRefundSegmentsWithSameTicketNumberAsync()
        {
            //arrange
            _segmentRepositoryMock.Setup(s => s.FindRefundSegmentsWithSameTicketNumberAsync("3"))
                .ReturnsAsync(new List<Segment>() {_segments.ElementAt(2)});
            var repository = _segmentRepositoryMock.Object;
            var number = "3";

            //act
            var trueRefunds = await repository.FindRefundSegmentsWithSameTicketNumberAsync(number);


            //assert
            Assert.IsTrue(trueRefunds.Count == 1);
            Assert.IsTrue(trueRefunds.All(t=>t.OperationType == "refunds"));
            
            
        }
        
        [Test]
        public async Task TestInsertRangeAsync()
        {
            //arrange
            var segmentsToAdd = new List<Segment>();
            segmentsToAdd.Add(new Segment());
            segmentsToAdd.Add(new Segment());
            _segmentRepositoryMock.Setup(s => s.InsertRangeAsync(segmentsToAdd));
            var repository = _segmentRepositoryMock.Object;
            
            //act
            await repository.InsertRangeAsync(segmentsToAdd);
            
            //assert
            

        }
    }
}