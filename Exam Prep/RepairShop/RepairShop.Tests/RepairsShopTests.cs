using System;
using NUnit.Framework;

namespace RepairShop.Tests
{
    public class Tests
    {
        public class RepairsShopTests
        {
            private Car car;
            private Garage garage;

            private string carModel = "Mercedes";
            private int numberOfIssues = 3;

            private string garageName = "Kiro";
            private int mechanicsAvailable = 2;

            [SetUp]
            public void SetUp()
            {
                car = new Car(carModel, numberOfIssues);
                garage = new Garage(garageName, mechanicsAvailable);
            }

            [Test]
            public void Test_Constructor()
            {
                Assert.AreEqual(mechanicsAvailable, garage.MechanicsAvailable);
                Assert.AreEqual(0, garage.CarsInGarage);
            }

            [Test]
            public void Test_NameNull()
            {
                Assert.Throws<ArgumentNullException>(() =>
                {
                    garage = new Garage(String.Empty, 3);
                });
            }

            [Test]
            public void Test_NegativeMechanicsCount()
            {
                Assert.Throws<ArgumentException>(() =>
                {
                    garage = new Garage(garageName, -2);
                });
            }

            [Test]
            public void Test_AddCar()
            {
                garage.AddCar(car);
                Assert.AreEqual(1, garage.CarsInGarage);
            }

            [Test]
            public void Test_AddCarNoMechanics()
            {
                garage.AddCar(new Car("1", 1));
                garage.AddCar(new Car("2", 1));
                Assert.Throws<InvalidOperationException>(() =>
                {
                    garage.AddCar(new Car("3", 1));
                });
            }

            [Test]
            public void Test_FixCar()
            {
                garage.AddCar(car);
                garage.FixCar(car.CarModel);

                Assert.AreEqual(0, car.NumberOfIssues);
            }

            [Test]
            public void Test_FixNullCar()
            {
                Assert.Throws<InvalidOperationException>(() =>
                {
                    garage.FixCar(null);
                });
            }

            [Test]
            public void Test_RemoveFixedCar()
            {
                garage.AddCar(car);
                garage.FixCar(car.CarModel);
                garage.RemoveFixedCar();

                Assert.AreEqual(true, car.IsFixed);
            }

            [Test]
            public void Test_RemoveFixedCarNull()
            {
                Assert.Throws<InvalidOperationException>(() =>
                {
                    garage.RemoveFixedCar();
                });
            }

            /*[Test]
            public void Test_Fix()
            {
                garage.AddCar(car);
                garage.FixCar(car.CarModel);
                garage.Report();
                string report = $"There are {garage.} which are not fixed: {carsNames}.";

                Assert.AreEqual();
            }*/
        }
    }
}