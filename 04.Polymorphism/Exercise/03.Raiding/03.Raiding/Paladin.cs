using System;
namespace _03.Raiding
{
	public class Paladin : BaseHero
	{
        public const int POWER = 100;

        public Paladin(string type, string name) : base(type, name, POWER)
        {
        }

        public override string CastAbility()
        {
            return $"{Type} - {Name} healed for {POWER}";
        }
    }
}

