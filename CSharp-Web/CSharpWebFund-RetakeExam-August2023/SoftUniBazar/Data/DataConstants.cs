namespace SoftUniBazar.Data
{
    public static class DataConstants
    {
        public const int AdNameMinLength = 5;
        public const int AdNameMaxLength = 25;
        public const int AdDescriptionMinLength = 15;
        public const int AdDescriptionMaxLength = 250;
        public const string DateTimeFormat = "yyyy-MM-dd H:mm";
        public const int CategoryNameMinLength = 3;
        public const int CategoryNameMaxLength = 15;
        public const string RequireErrorMessage = "The {0} field is required.";
        public const string StringLengthErrorMessage = "The field {0} must be at least {2} and at max {1} characters long.";
    }
}
