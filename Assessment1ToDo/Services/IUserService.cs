using Assessment1ToDo.Models;

namespace Assessment1ToDo.Services
{
    /// <summary>
    /// Defines business logic for user management.
    /// </summary>
    internal interface IUserService
    {
        User? GetUser(string id);
        bool UpdateUser(User user);
        bool DeleteUser(string id);
    }
}
