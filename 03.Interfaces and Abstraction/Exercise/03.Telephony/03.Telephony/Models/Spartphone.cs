using System;
using System.Linq;

namespace _03.Telephony.Models
{
	public class Spartphone : ISmartphone
	{
		public Spartphone()
		{
		}

        public string Browsing(string url)
        {
            if(!IsValidURL(url))
            {
                throw new Exception("Invalid URL!");
            }
            return $"Browsing: {url!}";
        }

        public string Calling(string phoneNumber)
        {
            if(!IsValidNumber(phoneNumber))
            {
                throw new Exception("Invalid number!");
            }
            return $"Calling... {phoneNumber}";
        }

        private bool IsValidNumber(string phoneNumber)
            => phoneNumber.All(x => char.IsDigit(x));

        private bool IsValidURL(string url)
            => url.All(x => !char.IsDigit(x));
    }
}

