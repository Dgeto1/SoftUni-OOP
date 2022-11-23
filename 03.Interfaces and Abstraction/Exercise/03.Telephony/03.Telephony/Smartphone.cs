using System;
using System.Linq;

namespace _03.Telephony
{
    public class Smartphone : IPhone, IBrowse
    {
        //private string phoneNumber, url;

        public Smartphone(string phoneNumber, string uRL)
        {
            PhoneNumber = phoneNumber;
            URL = uRL;
        }

        public string PhoneNumber { get; set; }
        public string URL { get; set; }

        public void Calling(string phoneNumber)
        {
            if (!phoneNumber.All(x => char.IsDigit(x)))
            {
                Console.WriteLine("Invalid number!");
            }
            else
            {
                Console.WriteLine($"Calling... {phoneNumber}");
            }
        }

        public void Browsing(string url)
        {
            if(url.Any(x=>char.IsDigit(x)))
            {
                Console.WriteLine("Invalid URL!");
            }
            else
            {
                Console.WriteLine($"Browsing: {url}!");
            }
        }
    }
}

