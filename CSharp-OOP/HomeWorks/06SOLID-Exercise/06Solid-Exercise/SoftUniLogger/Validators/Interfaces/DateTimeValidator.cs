namespace SoftUniLogger.Validators.Interfaces
{
    using System;
    internal class DateTimeValidator : IValidator
    {
        public bool isValid(object value)
        => DateTime.TryParse((string)value, out DateTime date);
    }
}
