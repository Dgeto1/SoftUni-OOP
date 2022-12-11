using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using ChristmasPastryShop.Core.Contracts;
using ChristmasPastryShop.Models.Booths;
using ChristmasPastryShop.Models.Booths.Contracts;
using ChristmasPastryShop.Models.Cocktails;
using ChristmasPastryShop.Models.Cocktails.Contracts;
using ChristmasPastryShop.Models.Delicacies;
using ChristmasPastryShop.Models.Delicacies.Contracts;
using ChristmasPastryShop.Repositories;
using ChristmasPastryShop.Repositories.Contracts;
using ChristmasPastryShop.Utilities.Messages;

namespace ChristmasPastryShop.Core
{
    public class Controller : IController
    {
        private DelicacyRepository delicacyRepository;
        private CocktailRepository cocktailRepository;
        private BoothRepository boothRepository;

        public Controller()
        {
            delicacyRepository = new DelicacyRepository();
            cocktailRepository = new CocktailRepository();
            boothRepository = new BoothRepository();
        }

        public string AddBooth(int capacity)
        {
            int boothId = boothRepository.Models.Count + 1;
            IBooth booth = new Booth(boothId, capacity);
            boothRepository.AddModel(booth);

            return String.Format(OutputMessages.NewBoothAdded, boothId, capacity);
        }

        public string AddDelicacy(int boothId, string delicacyTypeName, string delicacyName)
        {
            if (delicacyRepository.FindByName(delicacyName) != null)
            {
                return String.Format(OutputMessages.DelicacyAlreadyAdded, delicacyName);
            }

            IDelicacy delicacy = null;
            if (delicacyTypeName == "Gingerbread")
            {
                delicacy = new Gingerbread(delicacyName);
            }
            else if (delicacyTypeName == "Stolen")
            {
                delicacy = new Stolen(delicacyTypeName);
            }
            else
            {
                return String.Format(OutputMessages.InvalidDelicacyType, delicacyTypeName);
            }
            //check here

            delicacyRepository.AddModel(delicacy);
            return String.Format(OutputMessages.NewDelicacyAdded, delicacyTypeName, delicacyName);
        }

        public string AddCocktail(int boothId, string cocktailTypeName, string cocktailName, string size)
        {
            if (cocktailRepository.FindByName(cocktailName) != null)
            {
                return String.Format(OutputMessages.CocktailAlreadyAdded, cocktailName);
            }

            ICocktail cocktail = null;
            if (cocktailTypeName == "Hibernation")
            {
                cocktail = new Hibernation(cocktailName, size);
            }
            else if (cocktailTypeName == "MulledWine")
            {
                cocktail = new MulledWine(cocktailName, size);
            }
            else
            {
                return String.Format(OutputMessages.InvalidCocktailType, cocktailTypeName);
            }
            //check here

            cocktailRepository.AddModel(cocktail);
            return String.Format(OutputMessages.NewCocktailAdded, cocktailTypeName, cocktailName, size);
        }

        public string ReserveBooth(int countOfPeople)
        {
            List<IBooth> booths = new List<IBooth>();
            foreach (IBooth booth in boothRepository.Models)
            {
                if (booth.IsReserved == false && booth.Capacity >= countOfPeople)
                {
                    booths.Add(booth);
                }
            }
            if (booths.Count == 0)
            {
                return String.Format(OutputMessages.NoAvailableBooth, countOfPeople);
            }
            booths = booths.OrderBy(c => c.Capacity).ThenByDescending(b => b.BoothId).ToList();
            booths[0].ChangeStatus();
            return String.Format(OutputMessages.BoothReservedSuccessfully, booths[0].BoothId, countOfPeople);
        }

        public string TryOrder(int boothId, string order)
        {
            IBooth booth = boothRepository.FindById(boothId);

            string[] segments = order.Split("/");
            string itemTypeName = segments[0];
            string itemName = segments[1];
            int countOrderedPieces = int.Parse(segments[2]);

            if(itemTypeName!= "Hibernation" || itemTypeName != "MulledWine" || itemTypeName != "GingerBread" || itemTypeName != "Stolen")
            {
                return String.Format(OutputMessages.NotRecognizedType, itemTypeName);
            }

            IDelicacy delicacy = null;
            ICocktail cocktail = null;

            if(itemTypeName== "Hibernation")
            {
                string size = segments[2];
                cocktail = new Hibernation(itemName, size);
                if(cocktailRepository.FindByName(itemName)==null)
                {
                    return String.Format(OutputMessages.NotRecognizedItemName, itemTypeName, itemName);
                }
                if (cocktail.Name != itemName || cocktail.Size != size)
                {
                    return String.Format(OutputMessages.NotRecognizedItemName, size, itemName);
                }
                booth.UpdateCurrentBill(cocktail.Price * countOrderedPieces);
                
            }
            else if (itemTypeName == "MulledWine")
            {
                string size = segments[2];
                cocktail = new MulledWine(itemName, size);
                if (cocktailRepository.FindByName(itemName) == null)
                {
                    return String.Format(OutputMessages.NotRecognizedItemName, itemTypeName, itemName);
                }
                if (cocktail.Name != itemName || cocktail.Size != size)
                {
                    return String.Format(OutputMessages.NotRecognizedItemName, size, itemName);
                }
                booth.UpdateCurrentBill(cocktail.Price * countOrderedPieces);
            }

            else if(itemTypeName=="Stolen")
            {
                delicacy = new Stolen(itemName);
                if(delicacyRepository.FindByName(itemName)==null)
                {
                    return String.Format(OutputMessages.NotRecognizedItemName, itemTypeName, itemName);
                }
                if (delicacy == null)
                {
                    return String.Format(OutputMessages.NotRecognizedItemName, itemTypeName, itemName);
                }
                booth.UpdateCurrentBill(delicacy.Price * countOrderedPieces);
            }
            else if (itemTypeName == "Gingerbread")
            {
                delicacy = new Gingerbread(itemName);
                if (delicacyRepository.FindByName(itemName) == null)
                {
                    return String.Format(OutputMessages.NotRecognizedItemName, itemTypeName, itemName);
                }
                if (delicacy == null)
                {
                    return String.Format(OutputMessages.NotRecognizedItemName, itemTypeName, itemName);
                }
                booth.UpdateCurrentBill(delicacy.Price * countOrderedPieces);
            }
            return String.Format(OutputMessages.SuccessfullyOrdered, boothId, countOrderedPieces, itemName);
        }

        public string LeaveBooth(int boothId)
        {
            IBooth booth = boothRepository.FindById(boothId);
            double currentBill = booth.CurrentBill;
            booth.Charge();
            booth.ChangeStatus();
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Bill {currentBill:f2} lv");
            sb.AppendLine($"Booth {booth.BoothId} is now available!");

            return sb.ToString().Trim();
        }

        public string BoothReport(int boothId)
        {
            IBooth booth = boothRepository.FindById(boothId);
            return booth.ToString();
        }
    }
}

