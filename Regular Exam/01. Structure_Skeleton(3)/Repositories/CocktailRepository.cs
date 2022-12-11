using System;
using System.Collections.Generic;
using System.Linq;
using ChristmasPastryShop.Models.Cocktails.Contracts;
using ChristmasPastryShop.Models.Delicacies.Contracts;
using ChristmasPastryShop.Repositories.Contracts;

namespace ChristmasPastryShop.Repositories
{
    public class CocktailRepository : IRepository<ICocktail>
    {
        public CocktailRepository()
        {
            cocktails = new List<ICocktail>();
        }

        private List<ICocktail> cocktails;
        public IReadOnlyCollection<ICocktail> Models => this.cocktails.AsReadOnly();

        public void AddModel(ICocktail model)
        {
            cocktails.Add(model);
        }

        public ICocktail FindByName(string name)
           => this.cocktails.FirstOrDefault(v => v.Name == name);
    }
}

