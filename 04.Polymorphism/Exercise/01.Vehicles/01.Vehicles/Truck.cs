using System;
namespace _01.Vehicles
{
    public class Truck : IVehicle
    {
        private double fuelQuantity, fuelConsumption;

        public Truck(double fuelQuantity, double fuelConsumption)
        {
            FuelQuantity = fuelQuantity;
            FuelConsumption = fuelConsumption + 1.6;
        }

        public double FuelQuantity { get { return fuelQuantity; } set { fuelQuantity = value; } }
        public double FuelConsumption { get { return fuelConsumption; } set { fuelConsumption = value; } }

        public int TankCapacity { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void DrivenDistance(double distance)
        {
            double fuelNeed = distance * this.FuelConsumption;
            if (fuelNeed <= this.FuelQuantity)
            {
                Console.WriteLine($"Truck travelled {distance} km");
                this.FuelQuantity -= fuelNeed;
            }
            else
            {
                Console.WriteLine($"Truck needs refueling");
            }
        }

        public void Refueld(double liters)
        {
            liters *= 0.95;
            this.FuelQuantity += liters;
            //this.FuelQuantity *= 0.95;
        }
    }
}

