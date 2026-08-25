using Assessment1ToDo.Models;

namespace Assessment1ToDo.Services
{
    /// <summary>
    /// Defines business logic for todo management.
    /// </summary>
    internal interface ITodoService
    {
        bool AddTodo(Todo todo);
        List<Todo> GetTodos(string userId);
        bool UpdateTodo(Todo todo);
        bool DeleteTodo(Guid id, string userId);
    }
}