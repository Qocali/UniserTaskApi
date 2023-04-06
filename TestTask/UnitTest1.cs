using Application.Dtos.Tasks;
using Application.Interface.Service;
using AutoMapper;
using Domain.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Moq;
using System.Net;
using System.Threading.Tasks;
using Task.Application.Mapping;
using Task.Rest.Api.Controllers;
using Task.Rest.Api.MediatR.Handlers;
using Task.Rest.Api.MediatR.Querys;
using static Domain.Domain.Enums.SelectionEnums;

namespace TestTask
{
    public class Tests
    {

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async System.Threading.Tasks.Task CreateTaskTesting()
        {
            var TaskService = new Mock<ITaskService>();
            var mediator = new Mock<IMediator>();
            TaskService.Setup(s => s.Create(It.IsAny<Tasks>()));
            var config = new MapperConfiguration(cfg => cfg.AddProfile<TaskProfile>());
            var mapper = config.CreateMapper();
            mapper.Map<Tasks>(It.IsAny<CreatenewTaskDto>());
            mapper.Map<GetTaskDto>(It.IsAny<Tasks>());


            var taskController = new TaskController(TaskService.Object, mediator.Object, mapper);
            var result = await taskController.CreateTaskAsync(new CreatenewTaskDto { TaskName = "task1", Deadline = DateTime.UtcNow, Work = "ghj" });
            Assert.IsTrue((result as AcceptedResult).StatusCode == (int?)HttpStatusCode.Accepted);
        }
        //[Test]
        //public async System.Threading.Tasks.Task GetTaskTesting()
        //{
        //    var TaskService = new Mock<ITaskService>();
        //    var mediator = new Mock<IMediator>();
        //    TaskService.Setup(s => s.Create(It.IsAny<Tasks>()));
        //    var config = new MapperConfiguration(cfg => cfg.AddProfile<TaskProfile>());
        //    var mapper = config.CreateMapper();
        //    var query = new GetTaskHandler(TaskService.Object, mapper);
        //    var task = mediator.Setup(m => m.Send(query));
        //    var result = mapper.Map<GetTaskDto>(task);
        //    var taskController = new TaskController(TaskService.Object, mediator.Object, mapper);
        //    var resultget = taskController.GetTask(5);
        //    Assert.IsTrue(((OkObjectResult)await resultget).StatusCode == (int?)HttpStatusCode.Accepted);
        //}

    }
}