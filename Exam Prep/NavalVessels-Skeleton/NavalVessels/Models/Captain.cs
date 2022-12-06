using System;
using System.Collections.Generic;
using NavalVessels.Models.Contracts;
using NavalVessels.Utilities.Messages;

namespace NavalVessels.Models
{
    public class Captain : ICaptain
    {
        private string fullName;
        private int combatExperience;
        private ICollection<IVessel> vessels;

        public Captain(string fullName)
        {
            FullName = fullName;
        }

        public string FullName
        {
            get { return fullName; }
            private set
            {
                if(string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidCaptainName));
                }
                fullName = value;
            }
        }

        public int CombatExperience
        {
            get { return combatExperience; }
            set { combatExperience = value; }
        }

        public ICollection<IVessel> Vessels => vessels;

        public void AddVessel(IVessel vessel)
        {
            if(vessel == null)
            {
                throw new NullReferenceException(string.Format(ExceptionMessages.InvalidVesselForCaptain));
            }
            Vessels.Add(vessel);
        }

        public void IncreaseCombatExperience()
        {
            CombatExperience += 10;
        }

        public string Report()
        {
            return $"{FullName} has {CombatExperience} combat experience and commands {Vessels.Count} vessels.";
        }
    }
}

