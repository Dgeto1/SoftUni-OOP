using System;
namespace _03.Raiding
{
	public class Warrior : BaseHero
	{
        public const int POWER = 100;
        public Warrior(string type, string name) : base(type, name, POWER)
        {
        }

        public override string CastAbility()
        {
            return $"{Type} - {Name} hit for {POWER} damage";
        }
    }
}

