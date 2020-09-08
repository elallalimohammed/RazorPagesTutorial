using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Moq;
using RazorPagesEventMaker;
using RazorPagesEventMaker.Interfaces;
using RazorPagesEventMaker.Models;
using System;
using System.Collections.Generic;
using Xunit;

namespace EventMakerXUnitTests
{
    public class IndexUnitTest
    {
        private readonly Mock<IEventRepository> mockRepo;
        private readonly IndexModel indexmodel;
        public IndexUnitTest()
        {
            mockRepo = new Mock<IEventRepository>();
            indexmodel = new IndexModel(mockRepo.Object);
        }              
        [Fact]
        public void OnGet_ReturnsIActionResult_WithAListOfEvents()
        {
          // Arrange
             mockRepo.Setup(mockrepo => mockrepo.GetAllEvents()).Returns(GetTestEvents());       
             
         // Act
            var result = indexmodel.OnGet();
            List<Event> myList = indexmodel.Events;

            // Assert
            Assert.IsAssignableFrom<IActionResult>(result) ;
            var viewResult = Assert.IsType<PageResult>(result);
            var actualMessages = Assert.IsType<List<Event>>(myList);
            Assert.Equal(2, myList.Count);
            Assert.Equal("Test 1", myList[0].Name);
            Assert.Equal("Test 2", myList[1].Name);
        }

        private List<Event> GetTestEvents()
        {
            var events = new List<Event>();
            events.Add(new Event()
            {
                Id = 1,
                Name = "Test 1",
                 Description="Test Description",
                  City="CPH",
               DateTime = new DateTime(2021, 8, 19),
                
            });
            events.Add(new Event()
            {
                Id = 2,
                Name = "Test 2",
                Description = "Test 2 Description",
                City = "Odense",
                DateTime = new DateTime(2021, 10, 22),

            });
            return events;
        }

       [Fact]
        public void FilterCriteria_Null()
        {
            // Arrange
            var mockRepo = new Mock<IEventRepository>();
            
            IndexModel indexmodel = new IndexModel(mockRepo.Object);
            string FilterCriteria = "CPH";

            // Act
            var result = indexmodel.OnGet();

            // Assert
            Assert.IsAssignableFrom<IActionResult>(result);
            var viewResult = Assert.IsType<PageResult>(result);
            mockRepo.Verify(m => m.FilterEvents(FilterCriteria), Times.Never);

        }
        
        [Fact]
        public void FilterCriteria_Not_Null()
        {
            // Arrange
            var mockRepo = new Mock<IEventRepository>();
            mockRepo.Setup(mockrepo => mockrepo.GetAllEvents())
            .Returns(GetTestEvents()).Verifiable();

            IndexModel indexmodel = new IndexModel(mockRepo.Object);
            indexmodel.FilterCriteria = "CPH";

            // Act
            var result = indexmodel.OnGet();
            var filtered = indexmodel.Events;

            // Assert
            Assert.IsAssignableFrom<IActionResult>(result);
            mockRepo.VerifyAll();
         }
    }
}
