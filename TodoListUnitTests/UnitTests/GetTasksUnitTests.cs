using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using TodoList.Application.DTOs.Result;

namespace TodoListUnitTests.UnitTests;

public class GetTasksUnitTests : IClassFixture<TasksUnitTestController>
{
    private readonly TasksUnitTestController _tasksUnitTestController;



    public GetTasksUnitTests(TasksUnitTestController controller)
    {
       
        _tasksUnitTestController = controller;
    }

    [Fact]
    public async Task GetTasksById_Return_OkResult()
    {

        //Arrange
 
        var taskId = new Guid("8e5bdef4-6e07-421b-8362-968e06e8d67b");

        //Act
        var data = await _tasksUnitTestController.TasksController.GetById(taskId);

        //Assert
        var okResult = Assert.IsType<OkObjectResult>(data.Result);
        Assert.Equal(200, okResult.StatusCode);

    }

    [Fact]
    public async Task GetTasksById_Return_NotFound()
    {
        //Arrange 
        var taskId = Guid.NewGuid();

        //Act
        var data = await _tasksUnitTestController.TasksController.GetById(taskId);

        //Assert
        var notFoundResult = Assert.IsType<NotFoundObjectResult>(data.Result);
        Assert.Equal(404, notFoundResult.StatusCode);
    }

    [Fact]
    public async Task GetTasksById_Return_BadRequest()
    {
        //Arrange 
        var taskId = Guid.Empty;

        //Act
        var data = await _tasksUnitTestController.TasksController.GetById(taskId);


        //Assert
        var BadRequestResult = Assert.IsType<BadRequestObjectResult>(data.Result);
        Assert.Equal(400, BadRequestResult.StatusCode);
    }

    [Fact]
    public async Task GetTasks_Return_ListOfTasksResultDTO()
    {
        //Arrange
        _tasksUnitTestController.ClearDatabase(); 
        _tasksUnitTestController.SeedDatabase(); 

        //Act
        var data = await _tasksUnitTestController.TasksController.Get();
        //Assert
        data.Result.Should().BeOfType<OkObjectResult>()
            .Which.Value.Should().BeAssignableTo<IEnumerable<TasksResultDTO>>()
            .And.NotBeNull();
    }


    [Fact]
    public async Task GetTasks_Return_NotFoundResult()
    {
        //Arrange
        _tasksUnitTestController.ClearDatabase();

        //Act
        var data = await _tasksUnitTestController.TasksController.Get();

        //Assert
        var notFoundResult = Assert.IsType<NotFoundObjectResult>(data.Result);
        Assert.Equal(404, notFoundResult.StatusCode);
    }

}
