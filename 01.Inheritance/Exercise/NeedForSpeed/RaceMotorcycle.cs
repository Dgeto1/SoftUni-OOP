using System;
namespace NeedForSpeed
{
	public class RaceMotorcycle : Motorcycle
	{
		private const double DEFAULT_MOTORCYCLE_FUEL_CONSUMPTION = 8;

        public RaceMotorcycle(int horsePower, double fuel) : base(horsePower, fuel)
        {
        }

        public override double FuelConsumption => DEFAULT_MOTORCYCLE_FUEL_CONSUMPTION;
    }
}

