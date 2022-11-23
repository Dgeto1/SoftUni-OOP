using System;
using System.Linq;
namespace _03.Telephony
{
    public class StationaryPhone : IPhone
    {
        public StationaryPhone(string phoneNumber)
        {
            PhoneNumber = phoneNumber;
        }

        public string PhoneNumber { get; set; }

        public void Calling(string phoneNumber)
        {
            if(!phoneNumber.All(x=>char.IsDigit(x)))
            {
                Console.WriteLine("Invalid number!");
            }
            else
            {
                Console.WriteLine($"Dialing... {phoneNumber}");
            }
        }
    }
}

