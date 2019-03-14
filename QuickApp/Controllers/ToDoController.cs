using System.Linq;
using Microsoft.AspNetCore.Mvc;
using QuickApp.Models;

namespace QuickApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoController : ControllerBase
    {
        private readonly ToDoContext _context; //Entity Context

        public ToDoController(ToDoContext context)
        { //constructor
            _context = context;

            if (_context.ToDoItems.Count() == 0)
            {
                // Create a new TodoItem if collection is empty,
                // which means you can't delete all TodoItems.
                _context.ToDoItems.Add(new ToDoItem {Name = "Item1"});
                _context.SaveChanges();
            }
        }
    }
}