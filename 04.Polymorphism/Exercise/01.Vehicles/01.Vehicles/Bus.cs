using System;
namespace _01.Vehicles
{
    public class Bus : IVehicle
    {
        private double fuelQuantity, fuelConsumption;
        private int tankCapacity;

        public double FuelQuantity { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public double FuelConsumption { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int TankCapacity { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void DrivenDistance(double distance)
        {
            throw new NotImplementedException();
        }

        public void Refueld(double liters)
        {
            throw new NotImplementedException();
        }
    }
}

