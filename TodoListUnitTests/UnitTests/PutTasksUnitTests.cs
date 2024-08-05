using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoList.Application.DTOs.Request;
using TodoList.Application.DTOs.Result;
using TodoList.Controllers;

namespace TodoListUnitTests.UnitTests;

public class PutTasksUnitTests : IClassFixture<TasksUnitTestController>
{
    private readonly TasksUnitTestController _tasksUnitTestController;

    public PutTasksUnitTests(TasksUnitTestController controller)
    {
        _tasksUnitTestController = controller;
    }

    //[Fact]
    //public async Task PutTask_Update_Return_OKResult()
    //{
    //    //Arrange

    //    _tasksUnitTestController.SeedDatabase();
    //    var taskId = new Guid("4bb74f8a-c82a-4ba8-aede-0c91af32d3f5");
    //    var taskResquestDto = new TaskRequestDTO { Title = "Testando método put", Description = "Estou testando o método put no seu teste unitário para ver ser não tem erros", Completed = false };
    //    //Act
    //    var result = await _tasksUnitTestController.TasksController.Put(taskId, taskResquestDto);
    //    //Assert
    //    var OkResult = Assert.IsType<OkObjectResult>(result.Result);
    //    Assert.IsType<TasksResultDTO>(OkResult.Value);
    //    Assert.Equal(200, OkResult.StatusCode);

    //}

    //[Fact]
    //public async Task PutTask_Update_Return_BadRequest()
    //{
    //    //Arrange
    //    _tasksUnitTestController.TasksController.ModelState.AddModelError("Title", "Title is a field required");
    //    var taskId = new Guid("4bb74f8a-c82a-4ba8-aede-0c91af32d3f5");
    //    var taskResquestDto = new TaskRequestDTO { Title = null, Description = "rhjbhjbjhbhjdshjdfbhjg jfdsgbfdjh", Completed = false };

    //    //Act
    //    var result = await _tasksUnitTestController.TasksController.Put(taskId,taskResquestDto);

    //    // Assert
    //    var badRequestResult = Assert.IsType<BadRequestObjectResult>(result.Result);
    //    Assert.IsType<BadRequestObjectResult>(badRequestResult);
    //    Assert.IsType<SerializableError>(badRequestResult.Value);
    //    Assert.Equal(400, badRequestResult.StatusCode);
   
    //}
}
