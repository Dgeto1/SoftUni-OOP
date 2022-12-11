using System;
using System.Collections.Generic;
using System.Linq;
using ChristmasPastryShop.Models.Booths.Contracts;
using ChristmasPastryShop.Models.Cocktails.Contracts;
using ChristmasPastryShop.Repositories.Contracts;

namespace ChristmasPastryShop.Repositories
{
    public class BoothRepository : IRepository<IBooth>
    {
        public BoothRepository()
        {
            booths = new List<IBooth>();
        }

        private List<IBooth> booths;
        public IReadOnlyCollection<IBooth> Models => this.booths.AsReadOnly();

        public void AddModel(IBooth model)
        {
            booths.Add(model);
        }

        public IBooth FindById(int id)
           => this.booths.FirstOrDefault(v => v.BoothId == id);
    }
}

