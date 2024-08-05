using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoList.Domain.Entities;
using TodoList.Domain.Interfaces;
using TodoList.Infrastructure.Context;

namespace TodoList.Infrastructure.Repositories;

public class TasksRepository : ITasksRepository
{

    private ApplicationDbContext _context;

    public TasksRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Tasks> CreateAsync(Tasks tasks)
    {
        _context.Tasks.Add(tasks);
        await _context.SaveChangesAsync();
        return tasks;
    }

    public async Task<Tasks> DeleteAsync(Tasks tasks)
    {

        _context.Tasks.Remove(tasks);  
        await _context.SaveChangesAsync();
        return tasks;
    }

    public async Task<Tasks?> GetByIdAsync(Guid Id)
    {
      
        return await _context.Tasks.AsNoTracking().FirstOrDefaultAsync(t => t.Id == Id);
         
    }

    public async Task<IEnumerable<Tasks>> GetTasksAsync()
    {
        try
        {
            var tasks =  await _context.Tasks.AsNoTracking().ToListAsync();
            return tasks;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<Tasks> UpdateAsync(Tasks tasks)
    {
        _context.Tasks.Attach(tasks);
        _context.Entry(tasks).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return tasks;
    }
}
