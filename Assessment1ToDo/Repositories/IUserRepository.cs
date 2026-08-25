using Assessment1ToDo.Models;

namespace Assessment1ToDo.Repositories
{
    /// <summary>
    /// Defines CRUD operations for user management.
    /// </summary>
    internal interface IUserRepository
    {
        /// <summary>
        /// Get all user
        /// </summary>
        /// <returns>Returns all user</returns>
        List<User> GetAll();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Id">id</param>
        /// <returns>user</returns>
        User? GetById(string Id);

        /// <summary>
        /// Adds a user
        /// </summary>
        /// <param name="user">user</param>
        void Add(User user);

        /// <summary>
        /// Updates user
        /// </summary>
        /// <param name="user">user</param>
        void Update(User user);

        /// <summary>
        /// Deletes a user
        /// </summary>
        /// <param name="id">id</param>
        void Delete(string id);

        /// <summary>
        /// Saves data to file
        /// </summary>
        void Save();

        /// <summary>
        /// Loads data from file
        /// </summary>
        void Load();
    }
}
