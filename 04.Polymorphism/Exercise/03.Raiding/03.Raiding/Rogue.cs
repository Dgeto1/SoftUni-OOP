using System;
namespace _03.Raiding
{
	public class Rogue : BaseHero
	{
        public const int POWER = 80;
        public Rogue(string type, string name) : base(type, name, POWER)
        {
        }

        public override string CastAbility()
        {
            return $"{Type} - {Name} hit for {POWER} damage";
        }
    }
}

