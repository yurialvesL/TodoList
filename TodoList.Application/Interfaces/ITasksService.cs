using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoList.Application.DTOs.Request;
using TodoList.Application.DTOs.Result;
using TodoList.Domain.Entities;

namespace TodoList.Application.Interfaces;

public interface ITasksService
{
    Task<IEnumerable<TasksResultDTO>> GetTasks();
    Task<TasksResultDTO> GetById(Guid id);
    Task<TasksResultDTO> Create(TaskRequestDTO tasksDTO);
    Task<TasksResultDTO> Update(Guid id,TasksResultDTO task,TaskRequestDTO tasksDTO);
    Task Delete(TasksResultDTO taskDto);
}
