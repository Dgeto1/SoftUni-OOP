using System;
using System.Text;
using ChristmasPastryShop.Models.Booths.Contracts;
using ChristmasPastryShop.Models.Cocktails;
using ChristmasPastryShop.Models.Cocktails.Contracts;
using ChristmasPastryShop.Models.Delicacies;
using ChristmasPastryShop.Models.Delicacies.Contracts;
using ChristmasPastryShop.Repositories;
using ChristmasPastryShop.Repositories.Contracts;
using ChristmasPastryShop.Utilities.Messages;

namespace ChristmasPastryShop.Models.Booths
{
    public class Booth : IBooth
    {
        private int boothId;
        private int capacity;
        private IRepository<IDelicacy> delicacyMenu;
        private IRepository<ICocktail> cocktailMenu;
        private double currentbill;
        private double turnover;
        private bool isReserved;

        public Booth(int boothId, int capacity)
        {
            BoothId = boothId;
            Capacity = capacity;
        }

        public int BoothId { get; private set; }

        public int Capacity
        {
            get { return capacity; }
            private set
            {
                if(value<=0)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.CapacityLessThanOne));
                }
                capacity = value;
            }
        }

        public IRepository<IDelicacy> DelicacyMenu { get; private set; }

        public IRepository<ICocktail> CocktailMenu { get; private set; }

        public double CurrentBill
        {
            get { return currentbill; }
            protected set
            {
                value = 0;
                currentbill = value;
            }
        }

        public double Turnover
        {
            get { return turnover; }
            protected set
            {
                value = 0;
                turnover = value;
            }
        }

        public bool IsReserved { get; protected set; }

        public void UpdateCurrentBill(double amount)
        {
            CurrentBill += amount;
        }

        public void Charge()
        {
            Turnover += CurrentBill;
            CurrentBill = 0;
        }

        public void ChangeStatus()
        {
            IsReserved = !IsReserved;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Booth: {BoothId}");
            sb.AppendLine($"Capacity: {Capacity}");
            sb.AppendLine($"Turnover: {Turnover:f2} lv");
            sb.AppendLine("- Cocktail menu:");
            foreach(var x in cocktailMenu.Models)
            {
                sb.AppendLine($"--{x.ToString()}");
            }
            sb.AppendLine("-Delicacy menu:");
            foreach(var x in delicacyMenu.Models)
            {
                sb.AppendLine($"--{x.ToString()}");
            }

            return sb.ToString().Trim();
        }
    }
}

