using BusinessLayer.DTO;

namespace BusinessLayer.Domain.ToDoTask
{
    public class ToDoTask
    {
        public ToDoTask(ToDoTaskDTO toDoTaskDTO)
        {
            InitializeFields(toDoTaskDTO);
        }
        public ToDoTask() { }

        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public bool IsCompleted { get; set; }


        public void InitializeFields(ToDoTaskDTO toDoTaskDTO)
        {
            Id = toDoTaskDTO.Id;

            Title = toDoTaskDTO.Title;

            Description = toDoTaskDTO.Description;

            IsCompleted = toDoTaskDTO.IsCompleted;
        }
    }
}
