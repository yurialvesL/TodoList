using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoList.Domain.Entities;

namespace TodoList.Domain.Interfaces;

public interface ITasksRepository
{
    Task<IEnumerable<Tasks>> GetTasksAsync();
    Task<Tasks?> GetByIdAsync(Guid Id);

    Task<Tasks> CreateAsync(Tasks tasks);

    Task<Tasks> UpdateAsync(Tasks tasks);

    Task<Tasks> DeleteAsync(Tasks tasks);


}

