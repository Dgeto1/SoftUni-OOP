using System;

namespace _03.Telephony
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Smartphone smartphone;
            string[] numbers = Console.ReadLine().Split();
            string[] urls = Console.ReadLine().Split();
            for(int i=0; i<numbers.Length; i++)
            {
                if (numbers[i].Length==7)
                {
                    StationaryPhone stationaryPhone = new StationaryPhone(numbers[i]);
                    stationaryPhone.Calling(numbers[i]);
                }
                else
                {
                    smartphone = new Smartphone(numbers[i], null);
                    smartphone.Calling(numbers[i]);
                    
                }
            }
            for(int i=0; i<urls.Length; i++)
            {
                smartphone = new Smartphone(null, urls[i]);
                smartphone.Browsing(urls[i]);
            }
        }
    }
}

