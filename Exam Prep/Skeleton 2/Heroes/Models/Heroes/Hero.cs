using System;
using Heroes.Models.Contracts;

namespace Heroes.Models.Heroes
{
    public abstract class Hero : IHero
    {
        private string name;
        private int health;
        private int armour;
        private IWeapon weapon;
        private bool isAlive;

        protected Hero(string name, int health, int armour)
        {
            Name = name;
            Health = health;
            Armour = armour;
        }

        public string Name
        {
            get { return name; }
            private set
            {
                if(string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Hero name cannot be null or empty.");
                }
                name = value;
            }
        }

        public int Health
        {
            get { return health; }
            private set
            {
                if(value<0)
                {
                    throw new ArgumentException("Hero health cannot be below 0.");
                }
                health = value;
            }
        }

        public int Armour
        {
            get { return armour; }
            private set
            {
                if(value<0)
                {
                    throw new ArgumentException("Hero armour cannot be below 0.");
                }
                armour = value;
            }
        }

        public bool IsAlive
        {
            get { return isAlive; }
            set
            {
                if (Health > 0)
                {
                    value = true;
                }
                isAlive = value;
            }
        }

        public IWeapon Weapon
        {
            get { return weapon; }
            set
            {
                if(value==null)
                {
                    throw new ArgumentException("Weapon cannot be null.");
                }
            }
        }

        public void AddWeapon(IWeapon weapon)
        {
            Weapon = weapon;
        }

        public void TakeDamage(int points)
        {
            Armour -= points;
            if(armour<=0)
            {
                Armour = 0;
            }
            Health -= points;
            if(Health<=0)
            {
                Health = 0;
                isAlive = false;
            }
        }
    }
}

