using Assessment1ToDo.Helpers;
using Assessment1ToDo.Models;
using Assessment1ToDo.Repositories;

namespace Assessment1ToDo.Services
{
    /// <summary>
    /// Provides business logic for user authentication.
    /// </summary>
    internal class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private User? _currentUser;

        public AuthService(IUserRepository userRepository)
        {
            this._userRepository = userRepository;
        }

        public bool Register(User user)
        {
            if (!Validators.IsValidId(user.Id))
            {
                return false;
            }

            if (!Validators.IsValidName(user.Name))
            {
                return false;
            }
            if (_userRepository.GetById(user.Id) != null)
            {
                return false;
            }
            _userRepository.Add(user);
            return true;
        }

        public User? Login(string id, string password)
        {
            if (!Validators.IsValidId(id))
            {
                throw new Exception();
            }

            User? user = _userRepository.GetById(id);
            if (user == null || user.Password != password)
            {
                return null;
            }

            _currentUser = user;
            return _currentUser;
        }

        public void Logout()
        {
            _currentUser = null;
        }

        public User? GetCurrentUser()
        {
            return _currentUser;
        }

        public bool IsLoggedIn()
        {
            return _currentUser != null;
        }
    }
}
