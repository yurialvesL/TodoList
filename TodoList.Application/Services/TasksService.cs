using AutoMapper;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using TodoList.Application.DTOs.Request;
using TodoList.Application.DTOs.Result;
using TodoList.Application.Interfaces;
using TodoList.Domain.Entities;
using TodoList.Domain.Interfaces;

namespace TodoList.Application.Services;

public class TasksService : ITasksService
{
    private ITasksRepository _tasksRepository;
    private readonly IMapper _mapper;
    private readonly ILogger _logger;

    public TasksService(ITasksRepository tasksRepository, IMapper mapper, ILogger<TasksService> logger)
    {
        _tasksRepository = tasksRepository;
        _mapper = mapper;
        _logger = logger;
    }
    public async Task<TasksResultDTO> Create(TaskRequestDTO tasksDTO)
    {

        var tasksEntity = _mapper.Map<Tasks>(tasksDTO);
        tasksEntity.UpdateDates();
        await _tasksRepository.CreateAsync(tasksEntity);

        return _mapper.Map<TasksResultDTO>(tasksEntity);
    }

    public async Task Delete(TasksResultDTO tasks)
    {
        try
        {
            var tasksEntity = _mapper.Map<Tasks>(tasks);
            await _tasksRepository.DeleteAsync(tasksEntity);
        }
        catch (Exception)
        {

            throw;
        }
        
    }

    public async Task<TasksResultDTO> GetById(Guid id)
    {
        var tasksEntity = await _tasksRepository.GetByIdAsync(id);
        return _mapper.Map<TasksResultDTO>(tasksEntity);

    }

    public async Task<IEnumerable<TasksResultDTO>> GetTasks()
    {
        try
        {
            var tasksEntity = await _tasksRepository.GetTasksAsync();
            var tasksDTO = _mapper.Map<IEnumerable<TasksResultDTO>>(tasksEntity);

            return tasksDTO;
        }
        catch (Exception)
        {

            throw;
        }
    }

    public async Task<TasksResultDTO> Update(Guid id, TasksResultDTO task, TaskRequestDTO tasksDTO)
    {

        _mapper.Map(tasksDTO, task);

        var tasksSearch = _mapper.Map<Tasks>(task);

        tasksSearch.UpdateDates();

        var taskUpdate = await _tasksRepository.UpdateAsync(tasksSearch);

        return _mapper.Map<TasksResultDTO>(taskUpdate);

    }
}