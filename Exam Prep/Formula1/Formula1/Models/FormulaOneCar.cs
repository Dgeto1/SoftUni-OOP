using System;
using Formula1.Core;
using Formula1.Core.Contracts;

namespace Formula1.Models
{
	public abstract class FormulaOneCar
	{
		private string model;
		private int horsepower;
		private double engineDisplacement;

        protected FormulaOneCar(string model, int horsepower, double engineDisplacement)
        {
            this.Model = model;
            this.Horsepower = horsepower;
            this.EngineDisplacement = engineDisplacement;
        }

        public string Model
		{
			get { return model; }
			private set
			{
				if(string.IsNullOrEmpty(value) || value.Length < 3)
				{
					throw new ArgumentException($"Invalid car model: {value}.");
				}
				model = value;
			}
		}

		public int Horsepower
		{
			get { return horsepower; }
			private set
			{
				if(value<900 || value>1050)
				{
					throw new Exception($"Invalid car horsepower: {value}.");
                }
				horsepower = value;
			}
		}

		public double EngineDisplacement
		{
			get { return engineDisplacement; }
			private set
			{
				if(value<1.6 || value>2)
                {
					throw new ArgumentException($"Invalid car engine displacement: {value}.");
				}
				engineDisplacement = value;
			}
		}

		public double RaceScoreCalculator(int laps)
        {
			return engineDisplacement / horsepower * laps;
        }
    }
}

