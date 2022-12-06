using System;
using System.Collections.Generic;
using System.Text;
using NavalVessels.Models.Contracts;
using NavalVessels.Utilities.Messages;

namespace NavalVessels.Models
{
    public abstract class Vessel : IVessel
    {
        private string name;
        private ICaptain captain;
        private double armorThickness;
        private double mainWeaponCaliber;
        private double speed;
        private ICollection<string> targets;

        protected Vessel(string name, double mainWeaponCaliber, double speed, double armorThickness)
        {
            Name = name;
            MainWeaponCaliber = mainWeaponCaliber;
            Speed = speed;
            ArmorThickness = armorThickness;

        }

        public string Name
        {
            get { return name; }
            private set
            {
                if(string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidVesselName));
                }
                name = value;
            }
        }

        public ICaptain Captain
        {
            get { return captain; }
            set
            {
                if(value==null)
                {
                    throw new NullReferenceException(string.Format(ExceptionMessages.InvalidCaptainToVessel));
                }
                captain = value;
            }
        }
        public double ArmorThickness
        {
            get { return armorThickness; }
            set { armorThickness = value; }
        }

        public double MainWeaponCaliber
        {
            get { return mainWeaponCaliber; }
            set { mainWeaponCaliber = value; }
        }

        public double Speed
        {
            get { return speed; }
            set { speed = value; }
        }


        public ICollection<string> Targets
        {
            get { return targets; }
        }

        public void Attack(IVessel target)
        {
            if(target==null)
            {
                throw new NullReferenceException(string.Format(ExceptionMessages.InvalidTarget));   
            }

            target.ArmorThickness -= mainWeaponCaliber;

            if(target.ArmorThickness<0)
            {
                target.ArmorThickness = 0;
            }

            targets.Add(target.Name);
        }

        public abstract void RepairVessel();

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"- {Name}");
            sb.AppendLine($"*Type: {Captain}");
            sb.AppendLine($"*Armor thickness: {ArmorThickness}");
            sb.AppendLine($"*Main weapon caliber: {MainWeaponCaliber}");
            sb.AppendLine($"*Speed: {Speed} knots");
            if(targets.Count==0)
            {
                sb.AppendLine($"*Targets: None");
            }
            else
            {
                sb.AppendLine($"*Targets: {String.Join(", ", targets)}");
            }

            return sb.ToString().Trim();
        }
    }
}

