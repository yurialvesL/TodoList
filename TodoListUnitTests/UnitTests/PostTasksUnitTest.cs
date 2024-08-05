using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TodoList.Application.DTOs.Request;
using TodoList.Application.DTOs.Result;
using TodoList.Controllers;
using TodoList.Domain.Entities;

namespace TodoListUnitTests.UnitTests;

public class PostTasksUnitTest : IClassFixture<TasksUnitTestController>
{
    private readonly TasksUnitTestController _tasksUnitTestController;

    public PostTasksUnitTest(TasksUnitTestController controller)
    {
        _tasksUnitTestController = controller;
    }


    //[Fact]
    //public async Task PostTask_Return_CreatedStatusCode()
    //{
    //    //Arrange
    //    var task =  new TaskRequestDTO { Title= "teste unitario de post", Completed = false, Description= "Estou fazendo o teste unitario do método post para seguir com os outros testes" };

    //    //Act
    //    var data = await _tasksUnitTestController.TasksController.Post(task);

    //    //Assert
    //    var CreatedResult = Assert.IsType<OkObjectResult>(data.Result);
    //    Assert.IsType<TasksResultDTO>(CreatedResult.Value);
    //    Assert.Equal(200, CreatedResult.StatusCode);
    //}

    //[Fact]

    //public async Task PostTask_Return_BadRequest()
    //{
    //    //Arrange
    //    _tasksUnitTestController.TasksController.ModelState.AddModelError("Title", "Title is a field required");
    //    var taskResquestDto = new TaskRequestDTO { Title = null , Description = "rhjbhjbjhbhjdshjdfbhjg jfdsgbfdjh",Completed = false };


    //    var result = await _tasksUnitTestController.TasksController.Post(taskResquestDto);

    //    // Assert
    //    var badRequestResult = Assert.IsType<BadRequestObjectResult>(result.Result);
    //    badRequestResult.StatusCode.Should().Be(StatusCodes.Status400BadRequest);
    //    badRequestResult.Value.Should().BeOfType<SerializableError>();

    //}
}
