using System;
namespace _01.Vehicles
{
	public interface IVehicle
	{
		public double FuelQuantity { get; set; }
		public double FuelConsumption { get; set; }
		public int TankCapacity { get; set; }

		void DrivenDistance(double distance);

		void Refueld(double liters);

	}
}

