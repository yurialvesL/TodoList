using AutoMapper;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using Moq.AutoMock;
using System;
using System.Runtime.CompilerServices;
using TodoList.Application.Interfaces;
using TodoList.Application.Mappings;
using TodoList.Application.Services;
using TodoList.Controllers;
using TodoList.Domain.Interfaces;
using TodoList.Infrastructure.Context;
using TodoList.Domain.Entities;
using Xunit;
using System.Collections.Immutable;
using TodoList.Infrastructure.Repositories;

namespace TodoListUnitTests.UnitTests;

public class TasksUnitTestController : IDisposable
{
    public ApplicationDbContext Context { get; private set; }
    public TasksRepository TasksRepository { get; private set; }
    public IMapper Mapper { get; private set; }
    public Mock<ILogger<TasksService>> Logger { get; private set; }
    public TasksService TasksService { get; private set; }
    public TasksController TasksController { get; private set; }

    private readonly SqliteConnection _connection;

    public TasksUnitTestController()
    {
        var connectionString = "App_Data/TodoList.db";
        _connection = new SqliteConnection($"DataSource = :memory: ");
        _connection.Open();

        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseSqlite(_connection)
            .EnableSensitiveDataLogging()
            .Options;

        Context = new ApplicationDbContext(options);
        Context.Database.EnsureCreated();


        var autoMocker = new AutoMocker();

  
        TasksRepository = new TasksRepository(Context);


        var config = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile(new DomainToDTOMappingProfile());
        });
        Mapper = config.CreateMapper();


        Logger = autoMocker.GetMock<ILogger<TasksService>>();

        TasksService = new TasksService(TasksRepository, Mapper, Logger.Object);

        TasksController = new TasksController(TasksService);
    }

    public void SeedDatabase()
    {
        

        Context.Tasks.AddRange(
            new Tasks { Id = new Guid("8e5bdef4-6e07-421b-8362-968e06e8d67b"), Completed = false, Title = "Teste de unidade Mock 01", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nunc interdum in lectus in maximus. Morbi eu pretium sapien, nec lobortis justo. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos." },
            new Tasks { Id = new Guid("f0263c26-7e93-46ae-af7e-4852461c6cc4"), Completed = true, Title = "Teste de unidade Mock 02", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nunc interdum in lectus in maximus. Morbi eu pretium sapien, nec lobortis justo. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos." },
            new Tasks { Id = new Guid("4bb74f8a-c82a-4ba8-aede-0c91af32d3f5"), Completed = false, Title = "Teste de unidade Mock 03", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nunc interdum in lectus in maximus. Morbi eu pretium sapien, nec lobortis justo. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos." },
            new Tasks { Id = new Guid("a9762884-979e-419a-a997-cb6e3242d856"), Completed = true, Title = "Teste de unidade Mock 04", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nunc interdum in lectus in maximus. Morbi eu pretium sapien, nec lobortis justo. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos." },
            new Tasks { Id = new Guid("99b9ac83-b6a0-4cfa-8106-f21148b1d7e5"), Completed = false, Title = "Teste de unidade Mock 05", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nunc interdum in lectus in maximus. Morbi eu pretium sapien, nec lobortis justo. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos." }
            );
        Context.SaveChanges();
    }

    public void DetachEntity<T>(T entity) where T : class
    {
        var entry = Context.Entry(entity);
        if (entry.State == EntityState.Detached)
        {
            return;
        }
        entry.State = EntityState.Detached;
    }

    public void ClearDatabase()
    {
        Context.Tasks.RemoveRange(Context.Tasks);
        Context.SaveChanges();  
    }

    public void Dispose()
    {
        Context.Database.EnsureDeleted();
        Context.Dispose();
        _connection.Close();
    }
}
