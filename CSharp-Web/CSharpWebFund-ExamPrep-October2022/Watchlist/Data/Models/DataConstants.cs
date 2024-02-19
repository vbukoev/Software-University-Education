namespace Watchlist.Data.Models
{
    public static class DataConstants
    {
        public static class User
        {
            public const int EmailMinLength = 10;
            public const int EmailMaxLength = 60;

            public const int PasswordMinLength = 5;
            public const int PasswordMaxLength = 20;

            public const int UserNameMinLength = 5;
            public const int UserNameMaxLength = 20;
        }


        public static class Movie
        {
            public const int MovieTitleMinLength = 10;
            public const int MovieTitleMaxLength = 50;

            public const int MovieDirectorMinLength = 5;
            public const int MovieDirectorMaxLength = 50;

            public const int MovieDescriptionMinLength = 5;
            public const int MovieDescriptionMaxLength = 5000;
        }

        public static class Genre
        {
            public const int GenreNameMinLength = 5;
            public const int GenreNameMaxLength = 20;
        }

        public static class ErrorMessages
        {
            public const string RequireErrorMessage = "The {0} field is required.";
            public const string StringLengthErrorMessage = "The field {0} must be at least {2} and at max {1} characters long.";
        }
    }
}
