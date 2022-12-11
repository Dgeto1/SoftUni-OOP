using System;
using System.Collections.Generic;
using System.Linq;
using ChristmasPastryShop.Models.Delicacies;
using ChristmasPastryShop.Models.Delicacies.Contracts;
using ChristmasPastryShop.Repositories.Contracts;

namespace ChristmasPastryShop.Repositories
{
    public class DelicacyRepository : IRepository<IDelicacy>
    {
        public DelicacyRepository()
        {
            delicacies = new List<IDelicacy>();
        }

        private List<IDelicacy> delicacies;
        public IReadOnlyCollection<IDelicacy> Models => this.delicacies.AsReadOnly();

        public void AddModel(IDelicacy model)
        {
            delicacies.Add(model);
        }

        public IDelicacy FindByName(string name)
            => this.delicacies.FirstOrDefault(v => v.Name == name);
    }
}

