namespace Telephony.Models
{
    using System;

    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Models.Interfaces;
    using Exceptions;

    public class StationaryPhone : IStationaryPhone
    {
        public StationaryPhone()
        {

        }
        public string Call(string phoneNumber)
        {
            if (!this.ValidatePhoneNumber(phoneNumber))
            {
                throw new InvalidPhoneNumberException();
            }
            return $"Dialing... {phoneNumber}";
        }
        private bool ValidatePhoneNumber(string phoneNumber)
            => phoneNumber.All(ch => char.IsDigit(ch));
    }
}
