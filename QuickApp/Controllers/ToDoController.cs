using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        [HttpGet]
        public async Task<ActionResult<List<ToDoItem>>> GetToDoItems()
        {
            return await _context.ToDoItems.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ToDoItem>> GetToDoItem(long id)
        {
            var todoItem = await _context.ToDoItems.FindAsync(id);

            if (todoItem == null)
            {
                return NotFound();
            }

            return todoItem;
        }
    }
}