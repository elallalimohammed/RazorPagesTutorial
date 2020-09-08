using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Moq;
using RazorPagesEventMaker;
using RazorPagesEventMaker.Interfaces;
using RazorPagesEventMaker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace EventMakerXUnitTests.Unit_Test
{
    public class EditEventUnitTest
    {
        private readonly Mock<IEventRepository> mockRepo;
        private readonly EditEventModel editmodel;
        public EditEventUnitTest()
        {
            mockRepo = new Mock<IEventRepository>();
            editmodel = new EditEventModel(mockRepo.Object);
        }
        [Fact]
        public void OnGetReturnsIActionResultWithEventFound()
        {          
            // Arrange
            int testEventId = 1;
            string eName = "Marathon";
            Event @event = new Event()
            {
                Id = testEventId,
                Name = eName
            };            
            mockRepo.Setup(repo => repo.GetEvent(testEventId))
               .Returns(@event);
           
            // Act
            var result = editmodel.OnGet(testEventId);

            // Assert
            Assert.IsType<PageResult>(result);
            Assert.Equal(testEventId, @event.Id);
            Assert.Equal(eName, @event.Name);

        }

        [Fact]
        public void OnGet_method_Event_Is_Null()
        {
            // Arrange
            int testEventId = 1;
            var mockRepo = new Mock<IEventRepository>();
            mockRepo.Setup(repo => repo.GetEvent(testEventId)).Returns(() => null);
            
            // Act
            var result = editmodel.OnGet(testEventId);

            // Assert
            Assert.IsNotType<PageResult>(result);
            Assert.Null(result);
            
        }
    }
}
