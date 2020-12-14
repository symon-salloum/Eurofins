using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.DTO
{
    public class ToDoTaskDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Missing Title")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Missing Description")]
        public string Description { get; set; }

        public bool IsCompleted { get; set; }
    }
}
