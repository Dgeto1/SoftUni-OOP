using System;
using Formula1.Core;
using Formula1.Core.Contracts;
using Formula1.Models.Contracts;
using Formula1.Utilities;

namespace Formula1.Models
{
	public abstract class FormulaOneCar : IFormulaOneCar
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
					throw new ArgumentException(String.Format(ExceptionMessages.InvalidF1CarModel, value));
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
					throw new ArgumentException(String.Format(ExceptionMessages.InvalidF1HorsePower, value));
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
					throw new ArgumentException(String.Format(ExceptionMessages.InvalidF1EngineDisplacement, value));
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

