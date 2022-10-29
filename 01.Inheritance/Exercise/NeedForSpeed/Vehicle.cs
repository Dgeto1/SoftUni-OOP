using System;
namespace NeedForSpeed
{
	public class Vehicle
	{
        private const double DEFAULT_FUEL_CONSUMPTION = 1.25;   
		public int HorsePower { get; set; }
		public double Fuel { get; set; }

        public Vehicle(int horsePower, double fuel)
        {
            HorsePower = horsePower;
            Fuel = fuel;
        }

        public virtual double FuelConsumption => DEFAULT_FUEL_CONSUMPTION;

        public virtual void Drive(double kilometers)
        {
            double fuelLeft = Fuel - FuelConsumption * kilometers;

            if(fuelLeft>=0)
            {
                Fuel = fuelLeft;
            }
        }
    }
}

