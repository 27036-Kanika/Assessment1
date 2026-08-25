using Assessment1ToDo.Repositories;
using Assessment1ToDo.Services;
using Assessment1ToDo.Views;

namespace Assessment1ToDo
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            IUserRepository? userRepository = new UserRepository();
            IAuthService authService = new AuthService(userRepository);
            IUserService userService = new UserService(userRepository);
            UserView userView = new UserView(authService, userService);
            MainView mainView = new MainView(authService, userView);
            mainView.Show();
        }
    }
}
