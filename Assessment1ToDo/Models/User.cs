namespace Assessment1ToDo.Models
{
    /// <summary>
    /// Represents the user details
    /// </summary>
    internal class User
    {
        /// <summary>
        /// Initializes a new instance for 
        /// </summary>
        public User()
        {
        }
        public User(string id, string name, string password)
        {
            this.Id = id;
            this.Name = name;
            this.Password = password;
        }

        public string Id { get; set; } = String.Empty;
        public string Name { get; set; } = String.Empty;
        public string Password { get; set; } = String.Empty;
    }
}
