using System;
namespace _03.Raiding
{
    public class Druid : BaseHero
	{
        public const int POWER = 80;
        public Druid(string type, string name) : base(type, name, POWER)
        {

        }

        public override string CastAbility()
        {
            return $"{Type} - {Name} healed for {Power}";
        }
    }
}

