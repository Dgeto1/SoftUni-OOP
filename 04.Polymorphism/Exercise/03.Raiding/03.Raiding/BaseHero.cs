using System;
namespace _03.Raiding
{
	public abstract class BaseHero
	{
        protected BaseHero(string type, string name, int power)
        {
            Type = type;
            Name = name;
            Power = power; 
        }

        public string Type { get; set; }
		public string Name { get; set; }
        public int Power { get; set; }

        public abstract string CastAbility();
	}
}

