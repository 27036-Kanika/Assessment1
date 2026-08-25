using Assessment1ToDo.Models;

namespace Assessment1ToDo.Repositories
{
    /// <summary>
    /// Defines CRUD operations for user management.
    /// </summary>
    internal interface IUserRepository
    {
        List<User> GetAll();
        User? GetById(string Id);
        void Add(User user);
        void Update(User user);
        void Delete(string id);
        void Save();
        void Load();
    }
}
