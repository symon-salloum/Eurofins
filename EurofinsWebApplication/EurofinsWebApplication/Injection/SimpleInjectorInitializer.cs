using AutoMapper;
using BusinessLayer.Domain.ToDoTask;
using BusinessLayer.Mapping;
using BusinessLayer.Repository;
using BusinessLayer.Repository.ToDoTask;
using BusinessLayer.Service.ToDoTask;
using BusinessLayer.UnitOfWork;
using DataAccessLayer.DatabaseFactory;
using DataAccessLayer.Repository;
using DataAccessLayer.UnitOfWork;
using SimpleInjector;
using System;
using System.Linq;
using System.Reflection;

namespace EurofinsWebApplication.Injection
{
    public static class SimpleInjectorInitializer
    {
        public static void InitializeContainer(Container container)
        {
            container.Register<IUnitOfWork, UnitOfWork>();
            container.Register<IToDoTaskService, ToDoTaskService>();
            container.Register<IDatabaseFactory, DatabaseFactory>(Lifestyle.Scoped);
            container.Register<IToDoTaskRepository, ToDoTaskRepository>();
            container.Register<IRepository<ToDoTask>, Repository<ToDoTask>>();

            //register AutoMapper
            var config = new MapperConfiguration(cfg => cfg.AddProfile(new ToDoTaskProfile()));
            container.RegisterInstance(config);
            container.Register(() => config.CreateMapper(container.GetInstance));
        }
    }
}