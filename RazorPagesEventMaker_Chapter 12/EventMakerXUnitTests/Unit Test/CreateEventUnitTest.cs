using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Moq;
using RazorPagesEventMaker;
using RazorPagesEventMaker.Interfaces;
using RazorPagesEventMaker.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace EventMakerXUnitTests.Unit_Test
{
    public class CreateEventUnitTest
    {
        [Fact]
        public void OnPost_InValidState()
        {
            // Arrange
            var mockRepo = new Mock<IEventRepository>();
            var createmodel = new CreateEventModel(mockRepo.Object);
            createmodel.ModelState.AddModelError("key1", "The Text field is required.");
            
            // Act
            var result = createmodel.OnPost();

            // Assert
            Assert.IsNotType<PageResult>(result);
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.IsType<SerializableError>(badRequestResult.Value);         
        }

      
        private List<Event> GetTestEvents()
        {
            var events = new List<Event>();
            events.Add(new Event()
            {
                Id = 1,
                Name = "Test 1",
                Description = "Test Description",
                City = " CPH test",
                DateTime = new DateTime(2021, 8, 19),

            });
            events.Add(new Event()
            {
                Id = 2,
                Name = "Test 2",
                Description = "Test 2 Description",
                City = " Odense test",
                DateTime = new DateTime(2021, 10, 22),

            });
            events.Add(new Event()
            {
                Id = 3,
                Name = "Test 3",
                Description = "Test 2 Description",
                City = " Roskilde test",
                DateTime = new DateTime(2021, 7, 29),

            });
            return events;
        }

        [Fact]
        public void CreateEvent_Post_ReturnsARedirectAndAddsEvent_WhenModelStateIsValid()
        {
            // Arrange

            var mockRepo = new Mock<IEventRepository>();
                  
            mockRepo.Setup(repo => repo.AddEvent(It.IsAny<Event>())).Verifiable();

            var @event = new Event() { Id = 1, Name = "Test" };

            var createmodel = new CreateEventModel(mockRepo.Object);

            createmodel.Event = @event;

            // Act
            var result = createmodel.OnPost();

            // Assert
            var redirectToActionResult = Assert.IsType<RedirectToPageResult>(result);
            Assert.Equal("Index", redirectToActionResult.PageName);
            mockRepo.Verify((e) => e.AddEvent(@event), Times.Once);
            
        }
    }
}
