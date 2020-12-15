using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using System.Web.Http.Results;
using BusinessLayer.DTO;
using BusinessLayer.Exceptions;
using BusinessLayer.Filters;
using BusinessLayer.Service.ToDoTask;
using EurofinsWebApplication.Controllers.ToDoTask;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Eurofins.UnitTest.Controllers.ToDoTask
{
    [TestClass]
    public class ToDoTaskControllerTests
    {
        private Mock<IToDoTaskService> mockToDoTaskService = null;
        private ToDoTasksController toDoTasksController = null;

        [TestInitialize]
        public void Initialize()
        {
            mockToDoTaskService = new Mock<IToDoTaskService>();
            toDoTasksController = new ToDoTasksController(mockToDoTaskService.Object);
        }

        [TestMethod]
        public void GetAllToDoTasks_Return_ListOfToDoTasks()
        {
            // ARRANGE
            mockToDoTaskService.Setup(cs => cs.GetAll()).Returns(new List<ToDoTaskDTO>()
            {
                new ToDoTaskDTO { },
                new ToDoTaskDTO { }
            });

            // ACT
            var result = toDoTasksController.GetAllToDoTasks();

            // ASSERT
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(IHttpActionResult));
        }

        [TestMethod]
        public void GetToDoTaskWithFilter_Return_ListOfToDoTasks()
        {
            // ARRANGE
            mockToDoTaskService.Setup(s => s.GetMultiple(It.IsAny<FilterModel>())).Returns(new List<ToDoTaskDTO>()
            {
                new ToDoTaskDTO { },
                new ToDoTaskDTO { }
            });


            // ACT
            var result = toDoTasksController.GetToDoTask(new FilterModel
            {
                Title = "drive",
                Description = "drive to city center",
                IsStricktFilter = false,
                IsCompleted = false
            });

            // ASSERT
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(IHttpActionResult));
        }

        [TestMethod]
        public void GetToDoTaskById_Return_ToDoTaskIfFound()
        {
            // ARRANGE
            mockToDoTaskService.Setup(s => s.GetById(1)).Returns(new ToDoTaskDTO
            {
                Id = 1
            });

            // ACT
            var result = toDoTasksController.GetToDoTask(1) as OkNegotiatedContentResult<ToDoTaskDTO>;

            // ASSERT
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Content);
            Assert.IsTrue(result.Content.Id == 1);
            Assert.IsInstanceOfType(result, typeof(OkNegotiatedContentResult<ToDoTaskDTO>));
        }

        [TestMethod]
        public void GetToDoTaskById_Return_NotFound()
        {
            // ARRANGE
            mockToDoTaskService.Setup(s => s.GetById(1)).Throws<GetEntityException>();

            // ACT
            var result = toDoTasksController.GetToDoTask(1) as NotFoundResult;

            // ASSERT
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }

        [TestMethod]
        public void CreateToDoTask_Should_CreateToDoTask()
        {
            // ARRANGE
            mockToDoTaskService.Setup(s => s.Create(It.IsAny<ToDoTaskDTO>())).Returns(new ToDoTaskDTO
            {
                Id = 1,
                Title = "buy",
                Description = "new phone brand samsung",
                IsCompleted = false
            });

            // ACT
            var result = toDoTasksController.PostToDoTask(new ToDoTaskDTO
            {
                Title = "buy",
                Description = "new phone brand samsung"
            }) as CreatedAtRouteNegotiatedContentResult<ToDoTaskDTO>;


            // ASSERT
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(CreatedAtRouteNegotiatedContentResult<ToDoTaskDTO>));
            Assert.AreEqual(1, result.Content.Id);
            Assert.AreEqual("buy", result.Content.Title);
            Assert.AreEqual("new phone brand samsung", result.Content.Description);
            Assert.AreEqual(false, result.Content.IsCompleted);
        }

        [TestMethod]
        public void UpdateToDoTask_Return_NoContent()
        {
            // ACT
            var result = toDoTasksController.PutToDoTask(1, new ToDoTaskDTO { Id = 1 }) as StatusCodeResult;

            // ASSERT 
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(StatusCodeResult));
            Assert.AreEqual(HttpStatusCode.NoContent, result.StatusCode);
        }

        [TestMethod]
        public void UpdateToDoTask_Return_BadRequestWhenIdDoesnotMatch()
        {
            // ACT
            var result = toDoTasksController.PutToDoTask(1, new ToDoTaskDTO { Id = 2 }) as BadRequestResult;

            // ASSERT
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(BadRequestResult));
        }

        [TestMethod]
        public void DeleteToDoTask_Return_CopyOfToDoTaskDTOafterDeletion()
        {
            // ARRANGE
            mockToDoTaskService.Setup(s => s.Delete(1)).Returns(new ToDoTaskDTO
            {
                Id = 1
            });

            // ACT
            var result = toDoTasksController.DeleteToDoTask(1) as OkNegotiatedContentResult<ToDoTaskDTO>;

            // ASSERT
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(OkNegotiatedContentResult<ToDoTaskDTO>));
            Assert.AreEqual(1, result.Content.Id);
        }

        [TestMethod]
        public void DeleteToDoTask_Return_NotFoundWhenTryingToDeleteNotFoundRecord()
        {
            // ARRANGE
            mockToDoTaskService.Setup(s => s.Delete(2)).Throws<DeleteEntityException>();

            // ACT
            var result = toDoTasksController.DeleteToDoTask(2) as NotFoundResult;

            // ASSERT
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }
    }
}
