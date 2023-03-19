namespace VaporStore
{
    public static class GlobalConstants
    {
        //Game
        public const string GamePriceMinValue = "0.0";
        public const string GamePriceMaxValue = "79228162514264337593543950335";

        //Username
        public const int UserUsernameMinLength = 3;
        public const int UserUsernameMaxLength = 20;
        public const int UserAgeMinValue = 3;
        public const int UserAgeMaxValue = 103;
        public const string UserFullNameRegex = "^([A-Z]{1}[a-z]+)\\s([A-Z]{1}[a-z]+)$";

        //Card
        public const int CardCvcMaxLength = 3;
        public const string CardCvcRegex = "^(\\d{3})$";
        public const string CardNumberRegex = "^(\\d{4})\\s(\\d{4})\\s(\\d{4})\\s(\\d{4})$";

        //Purchase
        public const string PurchaseKeyRegex = "^([A-Z0-9]{4})\\-([A-Z0-9]{4})\\-([A-Z0-9]{4})$";
    }
}
