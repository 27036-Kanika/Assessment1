using Assessment1ToDo.Models;

namespace Assessment1ToDo.Repositories
{
    /// <summary>
    /// Defines CRUD operations for todo management.
    /// </summary>
    internal interface ITodoRepository
    {
        /// <summary>
        /// Get todo by user id.
        /// </summary>
        /// <param name="userId">The transaction to add.</param>
        List<Todo> GetByUserId(string userId);

        /// <summary>
        /// Get by id
        /// </summary>
        /// <param name="id">The transaction to add.</param>
        Todo? GetById(Guid id);

        /// <summary>
        /// Adds a todo
        /// </summary>
        /// <param name="todo">The transaction to add.</param>
        void Add(Todo todo);

        /// <summary>
        /// Updates a todo
        /// </summary>
        /// <param name="todo">The transaction to add.</param>
        void Update(Todo todo);

        /// <summary>
        /// Deletes a todo
        /// </summary>
        /// <param name="id">id</param>
        void Delete(Guid id);
    }
}
