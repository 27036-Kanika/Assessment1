using Assessment1ToDo.Models;

namespace Assessment1ToDo.Repositories
{
    /// <summary>
    /// Defines CRUD operations for todo management.
    /// </summary>
    internal interface ITodoRepository
    {
        List<Todo> GetByUserId(string userId);
        Todo? GetById(Guid id);
        void Add(Todo todo);
        void Update(Todo todo);
        void Delete(Guid id);
    }
}
