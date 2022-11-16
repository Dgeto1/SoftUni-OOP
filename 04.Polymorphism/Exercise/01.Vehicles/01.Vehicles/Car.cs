using System;
namespace _01.Vehicles
{
    public class Car : IVehicle
    {
        private double fuelQuantity, fuelConsumption;
        public double FuelQuantity { get { return fuelQuantity; } set { fuelQuantity = value; ; } }
        public double FuelConsumption { get { return fuelConsumption; } set { fuelConsumption = value; } }

        public int TankCapacity { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Car(double fuelQuantity, double fuelConsumption)
        {
            FuelQuantity = fuelQuantity;
            FuelConsumption = fuelConsumption + 0.9;
        }

        public void DrivenDistance(double distance)
        {
            double fuelNeed = distance * this.FuelConsumption;
            if(fuelNeed<=this.FuelQuantity)
            {
                Console.WriteLine($"Car travelled {distance} km");
                this.FuelQuantity -= fuelNeed;
            }
            else
            {
                Console.WriteLine($"Car needs refueling");
            }
        }

        public void Refueld(double refuel)
        {
            this.FuelQuantity += refuel;
        }
    }
}

