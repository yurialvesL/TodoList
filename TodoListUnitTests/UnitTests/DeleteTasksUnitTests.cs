using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoList.Controllers;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TodoListUnitTests.UnitTests;
public class DeleteTasksUnitTests : IClassFixture<TasksUnitTestController>
{
    private readonly TasksUnitTestController _tasksUnitTestController;
    public DeleteTasksUnitTests(TasksUnitTestController controller)
    {
        _tasksUnitTestController = controller;

    }

    [Fact]
    public async Task DeleteTaskById_Return_OkResult()
    {
        //Arrange
        _tasksUnitTestController.ClearDatabase();
        _tasksUnitTestController.SeedDatabase();
        var taskId = new Guid("4bb74f8a-c82a-4ba8-aede-0c91af32d3f5");

        //Act
        var data = await _tasksUnitTestController.TasksController.Delete(taskId);

        //Assert
        var okResult = Assert.IsType<OkObjectResult>(data.Result);
        Assert.Equal(200, okResult.StatusCode);


    }

    [Fact]
    public async Task DeleteTaskByid_Return_NotFound()
    {
        //Arrange
        _tasksUnitTestController.SeedDatabase();
        var taskId = Guid.NewGuid();

        //Act
        var data = await _tasksUnitTestController.TasksController.Delete(taskId);

        //Assert
        var okResult = Assert.IsType<NotFoundObjectResult>(data.Result);
        Assert.Equal(404, okResult.StatusCode);
    }
}
