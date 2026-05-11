using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToDoList.DAL.Entity
{
    public class TDLTask
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }

        public IdentityUser User { get; set; }
    }
}
