using System.Text.Json;
using Assessment1ToDo.Models;

namespace Assessment1ToDo.Repositories
{
    /// <summary>
    /// CRUD operations for todo management.
    /// </summary>
    internal class TodoRepository : ITodoRepository
    {
        private readonly List<Todo> _todos;
        private readonly string _filePath;

        public TodoRepository()
        {
            this._todos = new List<Todo>();
            this._filePath = "Todo.json";
            this.Load();
        }

        public List<Todo> GetByUserId(string userId)
        {
            return this._todos
                .Where(todo => todo.UserId == userId)
                .ToList();
        }

        public Todo? GetById(Guid id)
        {
            return this._todos.FirstOrDefault(todo => todo.Id == id);
        }

        public void Add(Todo todo)
        {
            this._todos.Add(todo);
            this.Save();
        }

        public void Update(Todo todo)
        {
            Todo? existingTodo = this.GetById(todo.Id);

            if (existingTodo == null)
            {
                return;
            }

            existingTodo.Heading = todo.Heading;
            existingTodo.Description = todo.Description;
            existingTodo.TargetDate = todo.TargetDate;
            existingTodo.Recurrence = todo.Recurrence;
            this.Save();
        }

        public void Delete(Guid id)
        {
            Todo? todo = this.GetById(id);

            if (todo == null)
            {
                return;
            }

            this._todos.Remove(todo);
            this.Save();
        }

        private void Save()
        {
            JsonSerializerOptions options = new JsonSerializerOptions
            {
                WriteIndented = true
            };

            string json = JsonSerializer.Serialize(this._todos, options);
            File.WriteAllText(this._filePath, json);
        }

        private void Load()
        {
            if (!File.Exists(this._filePath))
            {
                return;
            }

            string json = File.ReadAllText(this._filePath);

            if (string.IsNullOrEmpty(json))
            {
                return;
            }

            List<Todo>? todos = JsonSerializer.Deserialize<List<Todo>>(json);

            if (todos != null)
            {
                this._todos.AddRange(todos);
            }
        }
    }
}