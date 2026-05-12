using ToDoList.DAL.Entity;

namespace ToDoList.DAL.Repositories.Interfaces
{
    public interface ITaskRepository
    {
        IEnumerable<TDLTask> GetAll();
        public IEnumerable<TDLTask> GetAll(string userId);
        public TDLTask GetById(int id);
        public void Add(TDLTask task);
        public void Update(TDLTask task);
        public void Delete(int id);
    }
}
