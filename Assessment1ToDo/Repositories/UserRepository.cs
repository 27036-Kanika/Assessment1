using System.Text.Json;
using Assessment1ToDo.Models;

namespace Assessment1ToDo.Repositories
{
    /// <summary>
    /// CRUD operations for user management.
    /// </summary>
    internal class UserRepository : IUserRepository
    {
        private readonly List<User> _users;
        private string _filePath;

        public UserRepository()
        {
            this._users = new List<User>();
            this._filePath = "User.json";
            this.Load();
        }

        public void Add(User user)
        {
            this._users.Add(user);
            this.Save();
        }

        public void Update(User user)
        {
            User? existingUser = this.GetById(user.Id);
            if (existingUser != null)
            {
                existingUser.Id = user.Id;
                existingUser.Name = user.Name;
                existingUser.Password = user.Password;
                this.Save();
            }
        }

        public void Delete(string id)
        {
            User? user = this.GetById(id);
            if (user != null)
            {
                this._users.Remove(user);
                this.Save();
            }
        }
        public List<User> GetAll()
        {
            return new List<User>(this._users);
        }

        public User? GetById(string id)
        {
            return this._users.FirstOrDefault(User => User.Id == id);
        }

        public void Save()
        {
            JsonSerializerOptions options =
                new JsonSerializerOptions
                {
                    WriteIndented = true
                };
            string json = JsonSerializer.Serialize(this._users, options);
            File.WriteAllText(this._filePath, json);
        }

        public void Load()
        {
            if (!File.Exists(this._filePath))
            {
                return;
            }

            string json = File.ReadAllText(this._filePath);
            if (string.IsNullOrEmpty(json))
            {
                return;
            }

            List<User>? loadUser = JsonSerializer.Deserialize<List<User>>(json);
            if (loadUser != null)
            {
                this._users.AddRange(loadUser);
            }
        }
    }
}
