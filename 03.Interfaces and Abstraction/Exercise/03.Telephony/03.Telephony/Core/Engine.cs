using System;
using _03.Telephony.Core.Interfaces;
using _03.Telephony.Models;

namespace _03.Telephony.Core
{
	public class Engine : IEngine
	{
        private readonly IStationaryPhone stationaryPhone;
        private readonly ISmartphone smartphone;

        private Engine(IStationaryPhone stationaryPhone, ISmartphone smartphone)
        {
            this.stationaryPhone = new StationaryPhone();
            this.smartphone = new Spartphone();
        }
        public void Run()
        {
            try
            {

                string[] numbers = Console.ReadLine().Split();
                string[] urls = Console.ReadLine().Split();

                foreach (string phoneNumber in numbers)
                {
                    if (phoneNumber.Length == 7)
                    {
                        Console.WriteLine(this.stationaryPhone.Calling(phoneNumber));
                    }
                    else if (phoneNumber.Length == 10)
                    {
                        Console.Write(this.smartphone.Calling(phoneNumber));
                    }
                    else
                    {
                        throw new Exception("Invalid number!");
                    }
                }
                foreach (string url in urls)
                {
                    Console.WriteLine(this.smartphone.Browsing(url));
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}

