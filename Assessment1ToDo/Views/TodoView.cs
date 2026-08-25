using Assessment1ToDo.Models;
using Assessment1ToDo.Services;

namespace Assessment1ToDo.Views
{
    /// <summary>
    /// Represents the console user interface.
    /// </summary>
    internal class TodoView
    {
        private readonly IAuthService authService;
        private readonly ITodoService todoService;
        public TodoView(
            IAuthService authService,
            ITodoService todoService)
        {
            this.authService = authService;
            this.todoService = todoService;
        }

        public void Show()
        {
            bool back = false;

            while (!back && this.authService.IsLoggedIn())
            {
                Console.Clear();
                Console.WriteLine("===== TODO MENU =====");
                Console.WriteLine("1. Add Todo");
                Console.WriteLine("2. View Todos");
                Console.WriteLine("3. Edit Todo");
                Console.WriteLine("4. Remove Todo");
                Console.WriteLine("5. Back");

                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine() ?? string.Empty;

                switch (choice)
                {
                    case "1":
                        this.AddTodo();
                        break;

                    case "2":
                        this.ViewTodos();
                        break;

                    case "3":
                        this.EditTodo();
                        break;

                    case "4":
                        this.RemoveTodo();
                        break;

                    case "5":
                        back = true;
                        break;

                    default:
                        Console.WriteLine("Invalid choice.");
                        Console.ReadKey();
                        break;
                }
            }
        }

        private void AddTodo()
        {
            User? user = this.authService.GetCurrentUser();

            if (user == null)
            {
                return;
            }

            Console.Clear();

            Console.WriteLine("===== ADD TODO =====");

            Console.Write("Enter Heading: ");
            string heading = Console.ReadLine() ?? string.Empty;

            Console.Write("Enter Description: ");
            string description = Console.ReadLine() ?? string.Empty;

            Console.Write("Enter Target Date (yyyy-MM-dd): ");
            string dateInput = Console.ReadLine() ?? string.Empty;

            if (!DateTime.TryParse(dateInput, out DateTime targetDate))
            {
                Console.WriteLine("Invalid date.");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("Recurrence:");
            Console.WriteLine("1. None");
            Console.WriteLine("2. Daily");
            Console.WriteLine("3. Weekly");
            Console.WriteLine("4. Monthly");
            Console.WriteLine("5. Yearly");

            Console.Write("Enter recurrence: ");
            string recurrenceChoice = Console.ReadLine() ?? "1";

            string recurrence = recurrenceChoice switch
            {
                "1" => "None",
                "2" => "Daily",
                "3" => "Weekly",
                "4" => "Monthly",
                "5" => "Yearly",
                _ => "None"
            };

            Todo todo = new Todo(
                Guid.NewGuid(),
                user.Id,
                heading,
                description,
                targetDate,
                recurrence);

            bool result = this.todoService.AddTodo(todo);

            Console.WriteLine(
                result
                    ? "Todo added successfully."
                    : "Unable to add Todo.");

            Console.ReadKey();
        }

        private void ViewTodos()
        {
            User? user = this.authService.GetCurrentUser();

            if (user == null)
            {
                return;
            }

            Console.Clear();

            Console.WriteLine("===== MY TODOS =====");

            List<Todo> todos =
                this.todoService.GetTodos(user.Id);

            if (todos.Count == 0)
            {
                Console.WriteLine("No Todos found.");
                Console.ReadKey();
                return;
            }

            foreach (Todo todo in todos)
            {
                Console.WriteLine($"Todo Id     : {todo.Id}");
                Console.WriteLine($"Heading     : {todo.Heading}");
                Console.WriteLine($"Description : {todo.Description}");
                Console.WriteLine($"Target Date : {todo.TargetDate:yyyy-MM-dd}");
                Console.WriteLine($"Recurrence  : {todo.Recurrence}");
                Console.WriteLine("----------------------------------------");
            }

            Console.ReadKey();
        }

        private void EditTodo()
        {
            User? user = this.authService.GetCurrentUser();

            if (user == null)
            {
                return;
            }

            Console.Clear();

            Console.WriteLine("===== EDIT TODO =====");

            List<Todo> todos =
                this.todoService.GetTodos(user.Id);

            if (todos.Count == 0)
            {
                Console.WriteLine("No Todos found.");
                Console.ReadKey();
                return;
            }

            foreach (Todo todo in todos)
            {
                Console.WriteLine($"{todo.Id} - {todo.Heading}");
            }

            Console.Write("Enter Todo Id: ");
            string input = Console.ReadLine() ?? string.Empty;

            if (!Guid.TryParse(input, out Guid id))
            {
                Console.WriteLine("Invalid Todo Id.");
                Console.ReadKey();
                return;
            }

            Todo? todoToEdit =
                todos.FirstOrDefault(todo => todo.Id == id);

            if (todoToEdit == null)
            {
                Console.WriteLine("Todo not found.");
                Console.ReadKey();
                return;
            }

            Console.Write("Enter new Heading: ");
            todoToEdit.Heading =
                Console.ReadLine() ?? todoToEdit.Heading;

            Console.Write("Enter new Description: ");
            todoToEdit.Description =
                Console.ReadLine() ?? todoToEdit.Description;

            Console.Write("Enter new Target Date (yyyy-MM-dd): ");
            string dateInput = Console.ReadLine() ?? string.Empty;

            if (!DateTime.TryParse(dateInput, out DateTime targetDate))
            {
                Console.WriteLine("Invalid date.");
                Console.ReadKey();
                return;
            }

            todoToEdit.TargetDate = targetDate;

            Console.Write("Enter new Recurrence: ");
            string recurrence = Console.ReadLine() ?? todoToEdit.Recurrence;

            todoToEdit.Recurrence = recurrence;

            bool result =
                this.todoService.UpdateTodo(todoToEdit);

            Console.WriteLine(
                result
                    ? "Todo updated successfully."
                    : "Unable to update Todo.");

            Console.ReadKey();
        }

        private void RemoveTodo()
        {
            User? user = this.authService.GetCurrentUser();

            if (user == null)
            {
                return;
            }

            Console.Clear();

            Console.WriteLine("===== REMOVE TODO =====");

            List<Todo> todos =
                this.todoService.GetTodos(user.Id);

            if (todos.Count == 0)
            {
                Console.WriteLine("No Todos found.");
                Console.ReadKey();
                return;
            }

            foreach (Todo todo in todos)
            {
                Console.WriteLine($"{todo.Id} - {todo.Heading}");
            }

            Console.Write("Enter Todo Id: ");
            string input = Console.ReadLine() ?? string.Empty;

            if (!Guid.TryParse(input, out Guid id))
            {
                Console.WriteLine("Invalid Todo Id.");
                Console.ReadKey();
                return;
            }

            bool result =
                this.todoService.DeleteTodo(id, user.Id);

            Console.WriteLine(
                result
                    ? "Todo removed successfully."
                    : "Todo not found.");

            Console.ReadKey();
        }
    }
}