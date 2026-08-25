using Assessment1ToDo.Repositories;
using Assessment1ToDo.Services;
using Assessment1ToDo.Views;

namespace Assessment1ToDo
{
    /// <summary>
    /// Represents the application entry point.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Starts the application.
        /// </summary>
        public static void Main(string[] args)
        {
            IUserRepository? userRepository = new UserRepository();
            ITodoRepository todoRepository = new TodoRepository();
            IAuthService authService = new AuthService(userRepository);
            IUserService userService = new UserService(userRepository);
            ITodoService todoService = new TodoService(todoRepository);
            TodoView todoView = new TodoView(authService, todoService);
            UserView userView = new UserView(authService, userService, todoView);
            MainView mainView = new MainView(authService, userView, todoView);
            mainView.Show();
        }
    }
}
