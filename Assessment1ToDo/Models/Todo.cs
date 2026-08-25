namespace Assessment1ToDo.Models
{
    /// <summary>
    /// Represents a Todo.
    /// </summary>
    internal class Todo
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Todo"/> class.
        /// </summary>
        public Todo()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Todo"/> class.
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="userId">user id</param>
        /// <param name="heading">heading</param>
        /// <param name="description">description</param>
        /// <param name="targetDate">date</param>
        /// <param name="recurrence">recurrence</param>
        public Todo(
            Guid id,
            string userId,
            string heading,
            string description,
            DateTime targetDate,
            string recurrence)
        {
            this.Id = id;
            this.UserId = userId;
            this.Heading = heading;
            this.Description = description;
            this.TargetDate = targetDate;
            this.Recurrence = recurrence;
        }

        /// <summary>
        /// Gets and sets the todo id
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets and sets the user id
        /// </summary>
        public string UserId { get; set; } = string.Empty;

        /// <summary>
        /// Gets and sets the heading
        /// </summary>
        public string Heading { get; set; } = string.Empty;

        /// <summary>
        /// Gets and sets the description
        /// </summary>
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// Gets and sets the date
        /// </summary>
        public DateTime TargetDate { get; set; }

        /// <summary>
        /// Gets and sets the recurrence
        /// </summary>
        public string Recurrence { get; set; } = string.Empty;
    }
}
