using BusinessLayer.DTO;
using BusinessLayer.Filters;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BusinessLayer.Service.ToDoTask
{
    public interface IToDoTaskService
    {
        ToDoTaskDTO GetById(int id);

        IEnumerable<ToDoTaskDTO> GetAll();

        IEnumerable<ToDoTaskDTO> GetMultiple(FilterModel filter);

        ToDoTaskDTO Create(ToDoTaskDTO toDoTaskDTO);

        void Update(ToDoTaskDTO toDoTaskDTO);

        ToDoTaskDTO Delete(int id);
    }
}
