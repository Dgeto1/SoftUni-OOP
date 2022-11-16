using System;

namespace _01.Vehicles
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] segments = Console.ReadLine().Split();
            Car car = new Car(double.Parse(segments[1]), double.Parse(segments[2]));
            segments = Console.ReadLine().Split();
            Truck truck = new Truck(double.Parse(segments[1]), double.Parse(segments[2]));
            int n = int.Parse(Console.ReadLine());
            for(int i =0; i<n; i++)
            {
                segments = Console.ReadLine().Split();
                if (segments[0] == "Drive")
                {
                    if (segments[1]=="Car")
                    {
                        car.DrivenDistance(double.Parse(segments[2]));
                    }
                    else
                    {
                        truck.DrivenDistance(double.Parse(segments[2]));
                    }
                }
                else
                {
                    if (segments[1] == "Car")
                    {
                        car.Refueld(double.Parse(segments[2]));
                    }
                    else
                    {
                        truck.Refueld(double.Parse(segments[2]));
                    }
                }
            }
            Console.WriteLine($"Car: {car.FuelQuantity:f2}");
            Console.WriteLine($"Truck: {truck.FuelQuantity:f2}");
            Console.Read();
        }
    }
}

