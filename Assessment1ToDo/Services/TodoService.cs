using Assessment1ToDo.Models;
using Assessment1ToDo.Repositories;

namespace Assessment1ToDo.Services
{
    /// <summary>
    /// Provides business logic for todo management.
    /// </summary>
    internal class TodoService : ITodoService
    {
        private readonly ITodoRepository _todoRepository;
        public TodoService(ITodoRepository todoRepository)
        {
            this._todoRepository = todoRepository;
        }

        public bool AddTodo(Todo todo)
        {
            if (string.IsNullOrWhiteSpace(todo.Heading) || string.IsNullOrWhiteSpace(todo.Description))
            {
                return false;
            }

            if (todo.TargetDate < DateTime.Today)
            {
                return false;
            }

            this._todoRepository.Add(todo);
            return true;
        }

        public List<Todo> GetTodos(string userId)
        {
            return this._todoRepository.GetByUserId(userId);
        }

        public bool UpdateTodo(Todo todo)
        {
            Todo? existingTodo = this._todoRepository.GetById(todo.Id);
            if (existingTodo == null || existingTodo.UserId != todo.UserId)
            {
                return false;
            }

            if (string.IsNullOrWhiteSpace(todo.Heading) || string.IsNullOrWhiteSpace(todo.Description))
            {
                return false;
            }

            if (todo.TargetDate > DateTime.Today)
            {
                return false;
            }

            this._todoRepository.Update(todo);
            return true;
        }

        public bool DeleteTodo(Guid id, string userId)
        {
            Todo? todo = this._todoRepository.GetById(id);
            if (todo == null || todo.UserId != userId)
            {
                return false;
            }

            this._todoRepository.Delete(id);
            return true;
        }
    }
}