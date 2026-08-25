using Assessment1ToDo.Helpers;
using Assessment1ToDo.Models;
using Assessment1ToDo.Repositories;

namespace Assessment1ToDo.Services
{
    internal class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            this._userRepository = userRepository;
        }

        public User? GetUser(string userId)
        {
            return _userRepository.GetById(userId);
        }

        public bool UpdateUser(User user)
        {
            if (!Validators.IsValidName(user.Name)
                || !Validators.IsValidId(user.Id))
            {
                return false;
            }

            User? existingUser = _userRepository.GetById(user.Id);

            if (existingUser == null)
            {
                return false;
            }

            _userRepository.Update(user);
            return true;
        }

        public bool DeleteUser(string userId)
        {
            User? user = _userRepository.GetById(userId);

            if (user == null)
            {
                return false;
            }

            _userRepository.Delete(userId);
            return true;
        }
    }
}
