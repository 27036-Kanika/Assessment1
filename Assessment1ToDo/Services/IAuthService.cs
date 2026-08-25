using Assessment1ToDo.Models;

namespace Assessment1ToDo.Services
{
    /// <summary>
    /// Provides business logic for transaction management.
    /// </summary>
    internal interface IAuthService
    {
        bool Register(User user);
        User? Login(string id, string password);
        void Logout();
        User? GetCurrentUser();
        bool IsLoggedIn();
    }
}
