using System;
using System.Collections.Generic;
using System.Linq;
using NavalVessels.Core.Contracts;
using NavalVessels.Models;
using NavalVessels.Models.Contracts;
using NavalVessels.Repositories;
using NavalVessels.Utilities.Messages;

namespace NavalVessels.Core
{
    public class Controller : IController
    {
        private VesselRepository vessels;
        private List<ICaptain> captains;

        public Controller()
        {
            vessels = new VesselRepository();
            captains = new List<ICaptain>();
        }
        public string HireCaptain(string fullName)
        {
            ICaptain captain = new Captain(fullName);
            if (captains.Any(c=>c.FullName==fullName))
            {
                return String.Format(OutputMessages.CaptainIsAlreadyHired, fullName);
            }

            captains.Add(captain);
            return String.Format(OutputMessages.SuccessfullyAddedCaptain, fullName);
        }

        public string ProduceVessel(string name, string vesselType, double mainWeaponCaliber, double speed)
        {
            IVessel ves = vessels.FindByName(name);
            if (ves != null)
            {
                return String.Format(OutputMessages.VesselIsAlreadyManufactured, name.GetType().Name, name);
            }

            Vessel vessel = null;
            if(vesselType=="Submarine")
            {
                vessel = new Submarine(name, mainWeaponCaliber, speed, 200);
            }
            else if(vesselType=="Battleship")
            {
                vessel = new Battleship(name, mainWeaponCaliber, speed, 300);
            }
            else
            {
                return String.Format(OutputMessages.InvalidVesselType);
            }
            vessels.Add(vessel);
            return String.Format(OutputMessages.SuccessfullyCreateVessel, vessel.GetType().Name, vessel.Name, vessel.MainWeaponCaliber, vessel.Speed);
        }

        public string AssignCaptain(string selectedCaptainName, string selectedVesselName)
        {
            IVessel vessel = vessels.FindByName(selectedVesselName);
            ICaptain captain = new Captain(selectedCaptainName);
            
            if(captains.Any(c=>c.FullName!=selectedCaptainName))
            {
                return String.Format(OutputMessages.CaptainNotFound, selectedCaptainName);
            }
            if(vessel == null)
            {
                return String.Format(OutputMessages.VesselNotFound, selectedVesselName);
            }
            if(vessel.Captain.Vessels.Count>0)
            {
                return String.Format(OutputMessages.VesselOccupied, selectedVesselName);
            }
            captain.AddVessel(vessel);
            return String.Format(OutputMessages.SuccessfullyAssignCaptain, selectedCaptainName, selectedVesselName);
        }

        public string CaptainReport(string captainFullName)
        {
            ICaptain captain = new Captain(captainFullName);

            return captain.Report();
        }

        public string VesselReport(string vesselName)
        {
            IVessel vessel = vessels.FindByName(vesselName);

            return vessel.ToString();
        }

        public string ToggleSpecialMode(string vesselName)
        {
            IVessel vessel = vessels.FindByName(vesselName);

            if(vessel.GetType().Name=="Battleship")
            {
                var ves = new Battleship(vessel.Name, vessel.MainWeaponCaliber, vessel.Speed, vessel.ArmorThickness);
                ves.ToggleSonarMode();
                return String.Format(OutputMessages.ToggleBattleshipSonarMode, vesselName);
            }
            else if(vessel.GetType().Name=="Submarine")
            {
                var ves = new Submarine(vessel.Name, vessel.MainWeaponCaliber, vessel.Speed, vessel.ArmorThickness);
                ves.ToggleSubmergeMode();
                return String.Format(OutputMessages.ToggleSubmarineSubmergeMode, vesselName);
            }
            else
            {
                return String.Format(OutputMessages.VesselNotFound, vesselName);
            }
        }

        public string ServiceVessel(string vesselName)
        {
            IVessel vessel = vessels.FindByName(vesselName);
            if(vessel==null)
            {
                return String.Format(OutputMessages.VesselNotFound, vesselName);
            }
            vessel.RepairVessel();
            return String.Format(OutputMessages.SuccessfullyRepairVessel, vesselName);
        }

        public string AttackVessels(string attackingVesselName, string defendingVesselName)
        {
            IVessel atackingVessel = vessels.FindByName(attackingVesselName);
            IVessel defendingVessel = vessels.FindByName(defendingVesselName);

            if(atackingVessel==null || defendingVessel==null)
            {
                return String.Format(OutputMessages.VesselNotFound, attackingVesselName);
            }
            if(atackingVessel.ArmorThickness==0 || defendingVessel.ArmorThickness==0)
            {
                return String.Format(OutputMessages.AttackVesselArmorThicknessZero, attackingVesselName);
            }
            atackingVessel.Attack(defendingVessel);
            atackingVessel.Captain.IncreaseCombatExperience();
            defendingVessel.Captain.IncreaseCombatExperience();

            return String.Format(OutputMessages.SuccessfullyAttackVessel, defendingVesselName, attackingVesselName, defendingVessel.ArmorThickness);

        }

        

       

       
    }
}

