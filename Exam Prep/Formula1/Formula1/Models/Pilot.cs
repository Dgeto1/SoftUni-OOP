using System;
using System.Reflection;
using Formula1.Models.Contracts;
using Formula1.Utilities;

namespace Formula1.Models
{
	public class Pilot : IPilot
	{
		private string fullName;
		private bool canRace;
		private IFormulaOneCar car;
		private int numberOfWins;

        public Pilot(string fullName)
        {
            FullName = fullName;
        }

        public string FullName
        {
            get { return fullName; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 5)
                {
                    throw new ArgumentException(String.Format(ExceptionMessages.InvalidPilot, value));
                }
                fullName = value;
            }
        }

        public bool CanRace
        {
            get { return CanRace; }
            private set { canRace = value; }
        }

        public IFormulaOneCar Car
        {
            get { return car; }
            private set
            {
                if(value==null)
                {
                    throw new ArgumentException(String.Format(ExceptionMessages.InvalidCarForPilot));
                }
            }
        }
        public int NumberOfWins
        {   get { return numberOfWins; }
            private set { numberOfWins = value; }
        }

        public void AddCar(IFormulaOneCar car)
        {
            Car = car;
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

