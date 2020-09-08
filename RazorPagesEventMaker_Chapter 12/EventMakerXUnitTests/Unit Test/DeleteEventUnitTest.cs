using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Moq;
using RazorPagesEventMaker;
using RazorPagesEventMaker.Interfaces;
using RazorPagesEventMaker.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using Xunit;

namespace EventMakerXUnitTests.Unit_Test
{
   public class DeleteEventUnitTest
    {
        private readonly Mock<IEventRepository> mockRepo;
        private readonly DeleteEventModel deletemodel;
        public DeleteEventUnitTest()
        {
            mockRepo = new Mock<IEventRepository>();
           deletemodel = new DeleteEventModel(mockRepo.Object);
        }
        [Fact]
        public void Can_Delete_Valid_Events()
        {
            // Arrange - create an event 
            Event @event = new Event { Id = 2, Name = "Test2" };
            mockRepo.Setup(m => m.GetAllEvents()).Returns(new List<Event> {
                    new Event {Id = 1, Name = "Test1"},@event, 
                    new Event { Id = 3, Name = "Test3"},});
            var deletemodel = new DeleteEventModel(mockRepo.Object);           
            deletemodel.Event = @event;            
            
            // Act - 
            var result= deletemodel.OnPost();

            // Assert - ensure that the repository delete method was invoked 
            var redirectToActionResult = Assert.IsType<RedirectToPageResult>(result);
            Assert.Equal("Index", redirectToActionResult.PageName);
            mockRepo.Verify(m => m.DeleteEvent(@event), Times.Once);
            Assert.NotNull(result);
        }

    }
}
