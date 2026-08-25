using Assessment1ToDo.Enums;
using Assessment1ToDo.Helpers;
using Assessment1ToDo.Models;
using Assessment1ToDo.Services;

namespace Assessment1ToDo.Views
{
    /// <summary>
    /// Represents the console user interface.
    /// </summary>
    internal class MainView
    {
        private const int MaximumAttempts = 3;
        private readonly IAuthService authService;
        private readonly UserView userView;
        private readonly TodoView todoView;
        public MainView(IAuthService authService, UserView userView, TodoView todoView)
        {
            this.authService = authService;
            this.userView = userView;
            this.todoView = todoView;
        }

        public void Show()
        {
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine();
                Console.WriteLine("===== ToDo Application =====");
                Console.WriteLine("1. Register");
                Console.WriteLine("2. Login");
                Console.WriteLine("3. Exit");
                string? input = ReadMenuChoice();

                if (input == null)
                {
                    continue;
                }

                MainMenuChoice choice = (MainMenuChoice)int.Parse(input);
                switch (choice)
                {
                    case MainMenuChoice.Register:
                        Register();
                        break;

                    case MainMenuChoice.Login:
                        Login();
                        break;

                    case MainMenuChoice.Exit:
                        exit = true;
                        break;
                }
            }
        }

        private string? ReadMenuChoice()
        {
            for (int attempt = 1; attempt <= MaximumAttempts; attempt++)
            {
                Console.Write("Enter your choice: ");
                string input = Console.ReadLine() ?? string.Empty;
                if (int.TryParse(input, out int choice) && Enum.IsDefined(typeof(MainMenuChoice), choice))
                {
                    return input;
                }

                Console.WriteLine("Invalid choice.");
                DisplayRemainingAttempts(attempt);
            }

            Console.WriteLine("Maximum attempts reached.");
            return null;
        }

        private void Register()
        {
            Console.WriteLine();
            Console.WriteLine("===== Registration =====");

            string? Name = ReadField("Enter Name: ", Validators.IsValidName, "Name must contain only letters.");
            if (Name == null)
            {
                return;
            }
            string? Id = ReadField("Enter Id: ", Validators.IsValidId, "Id must contain exactly 10 digits.");
            if (Id == null)
            {
                return;
            }

            string? password = ReadPassword();
            if (password == null)
            {
                return;
            }

            User user = new()
            {
                Name = Name,
                Id = Id,
                Password = password
            };

            try
            {
                bool registered = authService.Register(user);

                if (registered)
                {
                    Console.WriteLine("Registration successful.");
                }
                else
                {
                    Console.WriteLine("Id already exists.");
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine($"Registration failed: {exception.Message}");
            }
        }

        private void Login()
        {
            Console.WriteLine();
            Console.WriteLine("===== Login =====");

            string? Id = ReadField("Enter Employee Id: ", Validators.IsValidId, "Enter a valid Employee id.");
            if (Id == null)
            {
                return;
            }

            string? password = ReadPassword();
            if (password == null)
            {
                return;
            }

            try
            {
                User? user = authService.Login(Id, password);

                if (user == null)
                {
                    Console.WriteLine("Invalid email or password.");
                    return;
                }

                Console.WriteLine($"Welcome, {user.Name}!");
                userView.Show();
            }
            catch (Exception exception)
            {
                Console.WriteLine($"Login failed: {exception.Message}");
            }
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

        private string? ReadPassword()
        {
            for (int attempt = 1; attempt <= MaximumAttempts; attempt++)
            {
                Console.Write("Enter Password: ");

                string password = ReadMaskedPassword();

                if (!string.IsNullOrWhiteSpace(password))
                {
                    return password;
                }

                Console.WriteLine("Password cannot be empty.");
                DisplayRemainingAttempts(attempt);
            }

            Console.WriteLine("Maximum attempts reached.");
            return null;
        }

        private string ReadMaskedPassword()
        {
            string password = string.Empty;
            ConsoleKeyInfo keyInfo;

            do
            {
                keyInfo = Console.ReadKey(intercept: true);
                if (keyInfo.Key == ConsoleKey.Backspace)
                {
                    if (password.Length > 0)
                    {
                        password = password[..^1];
                        Console.Write("\b \b");
                    }
                }
                else if (!char.IsControl(keyInfo.KeyChar))
                {
                    password += keyInfo.KeyChar;
                    Console.Write('*');
                }
            }
            while (keyInfo.Key != ConsoleKey.Enter);

            Console.WriteLine();
            return password;
        }

        private void DisplayRemainingAttempts(int attempt)
        {
            int remainingAttempts = MaximumAttempts - attempt;
            Console.WriteLine($"Remaining attempts: {remainingAttempts}");
        }
    }
}
