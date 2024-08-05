using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoList.Application.Filters;
using TodoList.Application.Interfaces;
using TodoList.Application.Mappings;
using TodoList.Application.Services;
using TodoList.Domain.Interfaces;
using TodoList.Infrastructure.Context;
using TodoList.Infrastructure.Repositories;

namespace TodoList.CrossCutting.IoC;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        //db

        //verifico se existe a app_data, se não eu crio
        string dataDirectory = Path.Combine(AppContext.BaseDirectory, "App_Data");
        if (!Directory.Exists(dataDirectory))
        {
            Directory.CreateDirectory(dataDirectory);
        }

        string connectionString = configuration.GetConnectionString("DefaultConnection");
        string dbPath = Path.Combine(AppContext.BaseDirectory, connectionString.Replace("App_Data/", "App_Data\\"));

        services.AddDbContext<ApplicationDbContext>(options =>
         options.UseSqlite($"Data Source={dbPath}"));


        //services
        services.AddScoped<ITasksService, TasksService>();
        services.AddScoped<ApiLoggingFilter>();


        //repositories
        services.AddScoped<ITasksRepository, TasksRepository>();

        //autoMapper
        services.AddAutoMapper(typeof(DomainToDTOMappingProfile));


        return services;
    }
}
