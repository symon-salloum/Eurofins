using BusinessLayer.DTO;
using BusinessLayer.Exceptions;
using BusinessLayer.Filters;
using BusinessLayer.Service.ToDoTask;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;

namespace EurofinsWebApplication.Controllers.ToDoTask
{
    public class ToDoTasksController : ApiController
    {
        private readonly IToDoTaskService _toDoTaskService;

        public ToDoTasksController(IToDoTaskService toDoTaskService)
        {
            _toDoTaskService = toDoTaskService;
        }

        // GET: api/ToDoTasks/GetAllToDoTasks
        public IHttpActionResult GetAllToDoTasks()
        {
            IEnumerable<ToDoTaskDTO> toDoTaskDTOs = _toDoTaskService.GetAll();

            return Ok(toDoTaskDTOs);
        }

        // GET: api/ToDoTasks/GetToDoTasks?Title=""&Description=""&IsCompleted={true,false}&IsStricktFilter={true,false}
        public IHttpActionResult GetToDoTask([FromUri] FilterModel filterModel)
        {
            if (!filterModel.IsValidFilter()) return BadRequest(ModelState);

            IEnumerable<ToDoTaskDTO> toDoTaskDTOs = _toDoTaskService.GetMultiple(filterModel);

            return Ok(toDoTaskDTOs);
        }

        // GET: api/ToDoTasks/GetToDoTask/{id}
        public IHttpActionResult GetToDoTask(int id)
        {
            try
            {
                return Ok(_toDoTaskService.GetById(id));
            }
            catch (GetEntityException)
            {
                return NotFound();
            }
        }

        // POST: api/ToDoTasks/PostToDoTask
        public IHttpActionResult PostToDoTask(ToDoTaskDTO toDoTaskDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            toDoTaskDTO = _toDoTaskService.Create(toDoTaskDTO);

            return CreatedAtRoute("DefaultApi", new { id = toDoTaskDTO.Id }, toDoTaskDTO);
        }

        // PUT: api/ToDoTasks/PutToDoTask/{id}
        public IHttpActionResult PutToDoTask(int id, ToDoTaskDTO toDoTaskDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != toDoTaskDTO.Id)
            {
                return BadRequest();
            }

            _toDoTaskService.Update(toDoTaskDTO);

            return StatusCode(HttpStatusCode.NoContent);
        }

        // DELETE: api/ToDoTasks/DeleteToDoTask/{id}
        public IHttpActionResult DeleteToDoTask(int id)
        {
            try
            {
                var toDoTaskDTO = _toDoTaskService.Delete(id);

                return Ok(toDoTaskDTO);
            }
            catch (DeleteEntityException)
            {
                return NotFound();
            }
        }

    }
}
