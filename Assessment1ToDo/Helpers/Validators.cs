namespace Assessment1ToDo.Helpers
{
    internal class Validators
    {
        public static bool IsValidName(string value)
        {
            return !string.IsNullOrWhiteSpace(value) && value.All(char.IsLetter);
        }

        public static bool IsValidId(string value)
        {
            return !string.IsNullOrWhiteSpace(value) && value.Length == 10 && value.All(char.IsDigit);
        }
    }
}
