namespace Assessment1ToDo.Helpers
{
    /// <summary>
    /// Validates the user input
    /// </summary>
    internal class Validators
    {
        /// <summary>
        /// validates name
        /// </summary>
        /// <param name="value">name</param>
        /// <returns>true if the name is valid</returns>
        public static bool IsValidName(string value)
        {
            return !string.IsNullOrWhiteSpace(value) && value.All(char.IsLetter);
        }

        /// <summary>
        /// validates name
        /// </summary>
        /// <param name="value">id</param>
        /// <returns>true if the name is valid</returns>
        public static bool IsValidId(string value)
        {
            return !string.IsNullOrWhiteSpace(value) && value.Length == 10 && value.All(char.IsDigit);
        }
    }
}
