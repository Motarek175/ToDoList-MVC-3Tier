using Microsoft.EntityFrameworkCore;
using ToDoList.DAL.Database;
using ToDoList.DAL.Entity;
using ToDoList.DAL.Repositories.Interfaces;

namespace ToDoList.DAL.Repositories.Implementations
{
    public class TaskRepository : ITaskRepository
    {
        private readonly TaskContext _context;
        public TaskRepository(TaskContext context)
        {
            _context = context;
        }
        public void Add(TDLTask task)
        {
            _context.Tasks.Add(task);
            _context.SaveChanges();
        }
        public void Delete(int id)
        {
            var task = _context.Tasks.FirstOrDefault(t => t.Id == id);
            if (task == null)
            {
                throw new KeyNotFoundException($"Task with ID {id} not found.");
            }
            _context.Tasks.Remove(task);
            _context.SaveChanges();
        }
        public IEnumerable<TDLTask> GetAll()
        {
            return _context.Tasks.Include(t => t.User).ToList();
        }
        public IEnumerable<TDLTask> GetAll(string userId)
        {
            return _context.Tasks
                .Include(t => t.User)
                .Where(t => t.UserId == userId)
                .ToList();
        }
        public TDLTask GetById(int id)
        {
            var task = _context.Tasks.Include(t => t.User).FirstOrDefault(t => t.Id == id);
            if (task == null)
            {
                throw new KeyNotFoundException($"Task with ID {id} not found.");
            }
            return task;
        }
        public void Update(TDLTask task)
        {
            _context.Tasks.Update(task);
            _context.SaveChanges();
        }
    }
}
