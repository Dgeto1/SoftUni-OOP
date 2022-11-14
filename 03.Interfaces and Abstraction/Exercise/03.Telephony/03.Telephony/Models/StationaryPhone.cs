using System;
using System.Linq;
namespace _03.Telephony
{
    public class StationaryPhone : IStationaryPhone
    {
        public string Calling(string phoneNumber)
        {
            if(!IsValidNumber(phoneNumber))
            {
                throw new Exception("Invalid number!");
            }
            return $"Dialing... {phoneNumber}";
        }

        private bool IsValidNumber(string phoneNumber)
            => phoneNumber.All(x => char.IsDigit(x));
    }
}

