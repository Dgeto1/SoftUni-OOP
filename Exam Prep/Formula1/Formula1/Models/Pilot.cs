using System;
using System.Reflection;
using Formula1.Models.Contracts;

namespace Formula1.Models
{
	public class Pilot
	{
		private string fullName;
		private bool canRace;
		private IFormulaOneCar car;
		private int numberOfWins;

        public Pilot(string fullName, bool canRace, IFormulaOneCar car, int numberOfWins)
        {
            FullName = fullName;
            CanRace = canRace;
            Car = car;
            NumberOfWins = numberOfWins;
        }

        public string FullName
        {
            get { return fullName; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 5)
                {
                    throw new ArgumentException($"Invalid pilot name: {value}.");
                }
                fullName = value;
            }
        }

        public bool CanRace
        {
            get { return CanRace; }
            private set { canRace = value = false; }
        }

        public IFormulaOneCar Car
        {
            get { return car; }
            private set
            {
                if(value==null)
                {
                    throw new ArgumentException("Pilot car can not be null.");
                }
            }
        }
        public int NumberOfWins
        {   get { return numberOfWins; }
            private set { numberOfWins = value; }
        }

        public void AddCar(IFormulaOneCar car)
        {
            car = ;
            CanRace = true;
        }
        public void WinRace()
        {
            NumberOfWins++;
        }
        public override string ToString()
        {
            return $"Pilot {FullName} has {NumberOfWins} wins.";
        }
    }
}

