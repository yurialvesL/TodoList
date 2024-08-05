using Microsoft.AspNetCore.Mvc;
using TodoList.Application.DTOs.Request;
using TodoList.Application.DTOs.Result;
using TodoList.Application.Interfaces;
using TodoList.Domain.Entities;
using Microsoft.AspNetCore.Http;

namespace TodoList.Controllers;


[Route("api/[controller]")]
[ApiController]
[Produces("application/json")]
[ApiConventionType(typeof(DefaultApiConventions))]
public class TasksController : ControllerBase
{
    private readonly ITasksService _tasksService;
    public TasksController(ITasksService tasksService)
    {
        _tasksService = tasksService;
    }


    /// <summary>
    /// Get all tasks
    /// </summary>
    /// <returns>List of tasks</returns>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult<IEnumerable<TasksResultDTO>>> Get()
    {

        var tasks = await _tasksService.GetTasks();

        if(tasks.Count() == 0 || tasks is null)
            return NotFound("Tasks not found");

        return Ok(tasks);

    }


    /// <summary>
    /// Get a tasks by id
    /// </summary>
    /// <param name="id"></param>
    /// <returns>Tasks Object</returns>
    [HttpGet("{id}", Name = "GetTaskById")]
    public async Task<ActionResult<TasksResultDTO>> GetById(Guid id)
    {
        if (id == Guid.Empty)
            return BadRequest("Id is invalid");


        var task = await _tasksService.GetById(id);

        if (task is null)
            return NotFound("Task not found");

        return Ok(task);
    }

    /// <summary>
    /// Add a new tasks
    /// </summary>
    ///<remarks>
    /// Sample of request:
    /// 
    ///    POST api/tasks
    ///     {
    ///         "title": "Title of task",
    ///         "description": "Description of task",
    ///         "completed": false
    ///     }
    ///     
    ///</remarks>
    /// <param name="tasksDTO"></param>
    /// <returns>Tasks Object created</returns>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary), StatusCodes.Status400BadRequest)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult<TasksResultDTO>> Post([FromBody] TaskRequestDTO tasksDTO)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var tasksResult = await _tasksService.Create(tasksDTO);

        return Ok(tasksResult);
    }

    /// <summary>
    /// Update a task
    /// </summary>
    /// <param name="id"></param>
    /// <param name="tasksDTO"></param>
    /// <returns>Tasks Object Updated</returns>
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult<TasksResultDTO>> Put(Guid id, [FromBody] TaskRequestDTO tasksDTO)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var task = await _tasksService.GetById(id);

        if (task is null)
            return NotFound("Tasks not found");

        var taskResultUpdate = await _tasksService.Update(id, task, tasksDTO);
        return Ok(taskResultUpdate);

    }

    /// <summary>
    /// Delete a Task
    /// </summary>
    /// <param name="id"></param>
    /// <returns>Tasks object deleted</returns>
    [HttpDelete("{id}")]
    public async Task<ActionResult<Tasks>> Delete(Guid id)
    {
        var tasksDTO = await _tasksService.GetById(id);

        if (tasksDTO is null)
            return NotFound("Tasks not found");

        await _tasksService.Delete(tasksDTO);
        return Ok(tasksDTO);
    }


}
