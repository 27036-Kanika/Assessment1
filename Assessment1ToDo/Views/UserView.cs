using Assessment1ToDo.Enums;
using Assessment1ToDo.Models;
using Assessment1ToDo.Services;

namespace Assessment1ToDo.Views
{
    /// <summary>
    /// Represents the console user interface.
    /// </summary>
    internal class UserView
    {
        private const int MaximumAttempts = 3;
        private readonly IAuthService authService;
        private readonly IUserService userService;
        private readonly TodoView todoView;
        public UserView(
            IAuthService authService,
            IUserService userService,
            TodoView todoView)
        {
            this.authService = authService;
            this.userService = userService;
            this.todoView = todoView;
        }

        public void Show()
        {
            bool logout = false;
            while (!logout && authService.IsLoggedIn())
            {
                Console.WriteLine();
                Console.WriteLine("===== User Menu =====");
                Console.WriteLine("1. Update Profile");
                Console.WriteLine("2. View Todos");
                Console.WriteLine("3. Logout");
                UserMenuChoice? choice = ReadMenuChoice();

                if (choice is null)
                {
                    return;
                }

                try
                {
                    switch (choice.Value)
                    {
                        case UserMenuChoice.UpdateProfile:
                            UpdateProfile();
                            break;

                        case UserMenuChoice.ViewToDos:
                            todoView.Show();
                            break;

                        case UserMenuChoice.Logout:
                            authService.Logout();
                            logout = true;
                            Console.WriteLine("Logged out successfully.");
                            break;
                    }
                }
                catch (Exception exception)
                {
                    Console.WriteLine($"An error occurred: {exception.Message}");
                }
            }
        }

        private UserMenuChoice? ReadMenuChoice()
        {
            for (int attempt = 1; attempt <= MaximumAttempts; attempt++)
            {
                Console.Write("Enter your choice: ");

                string input = Console.ReadLine() ?? string.Empty;

                if (int.TryParse(input, out int choice) && Enum.IsDefined(typeof(UserMenuChoice), choice))
                {
                    return (UserMenuChoice)choice;
                }

                Console.WriteLine("Invalid choice.");
                DisplayRemainingAttempts(attempt);
            }

            Console.WriteLine("Maximum attempts reached.");
            return null;
        }

        private void UpdateProfile()
        {
            User? currentUser = authService.GetCurrentUser();
            if (currentUser is null)
            {
                Console.WriteLine("User is not logged in.");
                return;
            }

            Console.WriteLine();
            Console.WriteLine("===== Update Profile =====");

            string? id = ReadField("Enter Employee Id: ", Helpers.Validators.IsValidId, "Id must contain exactly 10 digits.");
            if (id is null)
            {
                return;
            }

            string? Name = ReadField("Enter Name: ", Helpers.Validators.IsValidName, "Name must contain only letters.");
            if (Name is null)
            {
                return;
            }

            currentUser.Name = Name;
            currentUser.Id = id;

            bool updated = userService.UpdateUser(currentUser);

            Console.WriteLine(updated ? "Profile updated successfully." : "Profile update failed.");
        }

        private string? ReadField(string prompt, Func<string, bool> validator, string errorMessage)
        {
            for (int attempt = 1; attempt <= MaximumAttempts; attempt++)
            {
                Console.Write(prompt);
                string input = Console.ReadLine() ?? string.Empty;
                if (validator(input))
                {
                    return input;
                }

                Console.WriteLine(errorMessage);
                DisplayRemainingAttempts(attempt);
            }

            Console.WriteLine("Maximum attempts reached.");
            return null;
        }

        private void DisplayRemainingAttempts(int attempt)
        {
            int remainingAttempts = MaximumAttempts - attempt;
            Console.WriteLine($"Remaining attempts: {remainingAttempts}");
        }
    }
}
