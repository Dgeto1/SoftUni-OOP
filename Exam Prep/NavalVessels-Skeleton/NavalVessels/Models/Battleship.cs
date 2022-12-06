using System;
using System.Text;
using NavalVessels.Models.Contracts;

namespace NavalVessels.Models
{
    public class Battleship : Vessel, IBattleship
    {
        public Battleship(string name, double mainWeaponCaliber, double speed, double armorThickness) : base(name, mainWeaponCaliber, speed, armorThickness)
        {
        }

        private bool sonarMode;
        public bool SonarMode
        {
            get { return sonarMode; }
            private set { sonarMode = value; }
        }

        public void ToggleSonarMode()
        {
            sonarMode = !sonarMode;

            if(sonarMode)
            {
                MainWeaponCaliber += 40;
                Speed -= 5;
            }
            else
            {
                MainWeaponCaliber -= 40;
                Speed += 5;
            }
        }
        public override void RepairVessel()
        {
            if(ArmorThickness<300)
            {
                ArmorThickness = 300;
            }
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"*Sonar mode: {(sonarMode ? "ON" : "OFF")}");
            return base.ToString();
        }
    }
}

