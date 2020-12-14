using AutoMapper;
using AutoMapper.QueryableExtensions;
using BusinessLayer.DTO;
using BusinessLayer.Exceptions;
using BusinessLayer.Filters;
using BusinessLayer.Repository.ToDoTask;
using BusinessLayer.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLayer.Service.ToDoTask
{
    public class ToDoTaskService : IToDoTaskService
    {
        private readonly IMapper _mapper;
        private readonly IToDoTaskRepository _toDoTaskRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly MapperConfiguration _mapperConfig;

        public ToDoTaskService(IMapper mapper, IToDoTaskRepository toDoTaskRepository, IUnitOfWork unitOfWork, MapperConfiguration mapperConfig)
        {
            _mapper = mapper;
            _toDoTaskRepository = toDoTaskRepository;
            _unitOfWork = unitOfWork;
            _mapperConfig = mapperConfig;
        }


        public ToDoTaskDTO Create(ToDoTaskDTO toDoTaskDTO)
        {
            var toDoTask = new Domain.ToDoTask.ToDoTask(toDoTaskDTO);

            _toDoTaskRepository.Add(toDoTask);

            _unitOfWork.Commit();

            return _mapper.Map<ToDoTaskDTO>(toDoTask);
        }

        public ToDoTaskDTO Delete(int id)
        {
            var toDoTask = _toDoTaskRepository.GetById(id);

            if (toDoTask == null) throw new DeleteEntityException("Error deleting toDoTask");

            _toDoTaskRepository.Delete(toDoTask);

            _unitOfWork.Commit();

            return _mapper.Map<ToDoTaskDTO>(toDoTask);
        }

        public void Update(ToDoTaskDTO toDoTaskDTO)
        {
            var toDoTask = _toDoTaskRepository.GetById(toDoTaskDTO.Id);

            if (toDoTask == null) throw new UpdateEntityException("Error updating toDoTask");

            toDoTask.InitializeFields(toDoTaskDTO);

            _toDoTaskRepository.Update(toDoTask);

            _unitOfWork.Commit();
        }

        public IEnumerable<ToDoTaskDTO> GetAll()
        {
            return _toDoTaskRepository.GetAll().ProjectTo<ToDoTaskDTO>(_mapperConfig);
        }

        public ToDoTaskDTO GetById(int id)
        {
            var toDoTask = _toDoTaskRepository.GetById(id);

            if (toDoTask == null) throw new GetEntityException("Error getting toDoTask");

            return _mapper.Map<ToDoTaskDTO>(toDoTask);
        }

        public IEnumerable<ToDoTaskDTO> GetMultiple(FilterModel filter)
        {
            IQueryable<Domain.ToDoTask.ToDoTask> toDoTasks = null;

            if (filter.IsStricktFilter)
            {
                toDoTasks = _toDoTaskRepository.Where(t =>
                t.Title.ToLowerInvariant().Contains(filter.Title) &&
                t.Description.ToLowerInvariant().Contains(filter.Description) &&
                t.IsCompleted == filter.IsCompleted);
            }
            else
            {
                toDoTasks = _toDoTaskRepository.Where(t =>
                t.Title.ToLowerInvariant().Contains(filter.Title) ||
                t.Description.ToLowerInvariant().Contains(filter.Description) ||
                t.IsCompleted == filter.IsCompleted);
            }

            if (toDoTasks == null) throw new GetEntityException("Error getting Multiple toDoTasks");

            return toDoTasks.ProjectTo<ToDoTaskDTO>(_mapperConfig);

        }
    }
}
