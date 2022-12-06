using System;
using System.Text;
using NavalVessels.Models.Contracts;

namespace NavalVessels.Models
{
    public class Submarine : Vessel, ISubmarine
    {
        public Submarine(string name, double mainWeaponCaliber, double speed, double armorThickness) : base(name, mainWeaponCaliber, speed, armorThickness)
        {
        }

        private bool submergeMode;
        public bool SubmergeMode
        {
            get { return submergeMode; }
            private set { submergeMode = value; }
        }

        public void ToggleSubmergeMode()
        {
            submergeMode = !submergeMode;

            if (submergeMode)
            {
                MainWeaponCaliber += 40;
                Speed -= 4;
            }
            else
            {
                MainWeaponCaliber -= 40;
                Speed += 4;
            }
        }

        public override void RepairVessel()
        {
            if (ArmorThickness < 200)
            {
                ArmorThickness = 200;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"*Submerge mode: {(submergeMode ? "ON" : "OFF")}");
            return base.ToString();
        }
    }
}

