namespace SeminarHub.Data
{
    public static class DataConstants
    {
        public const int SeminarTopicMinLength = 3;
        public const int SeminarTopicMaxLength = 100;

        public const int SeminarLecturerMinLength = 5;
        public const int SeminarLecturerMaxLength = 60;

        public const int SeminarDetailsMinLength = 10;
        public const int SeminarDetailsMaxLength = 500;

        public const int SeminarDurationMinValue = 30;
        public const int SeminarDurationMaxValue = 180;

        public const int CategoryNameMinLength = 3;
        public const int CategoryNameMaxLength = 50;

        public const string DateTimeFormat = "dd/MM/yyyy HH:mm";

        public const string RequireErrorMessage = "The {0} field is required.";
        public const string StringLengthErrorMessage = "The field {0} must be at least {2} and at max {1} characters long.";
    }
}
