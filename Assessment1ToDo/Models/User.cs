namespace Assessment1ToDo.Models
{
    /// <summary>
    /// Represents the user details
    /// </summary>
    internal class User
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="User"/> class. 
        /// </summary>
        public User()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="User"/> class.
        /// </summary>
        /// <param name="id">Id</param>
        /// <param name="name">Name</param>
        /// <param name="password">Password</param>
        public User(string id, string name, string password)
        {
            this.Id = id;
            this.Name = name;
            this.Password = password;
        }

        /// <summary>
        /// Gets and sets the user id
        /// </summary>
        public string Id { get; set; } = String.Empty;

        /// <summary>
        /// Gets and sets the name
        /// </summary>
        public string Name { get; set; } = String.Empty;

        /// <summary>
        /// Gets and sets the password
        /// </summary>
        public string Password { get; set; } = String.Empty;
    }
}
