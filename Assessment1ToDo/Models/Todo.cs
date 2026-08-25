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

        public string UserId { get; set; } = string.Empty;

        public string Heading { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public DateTime TargetDate { get; set; }

        public string Recurrence { get; set; } = string.Empty;
    }
}
