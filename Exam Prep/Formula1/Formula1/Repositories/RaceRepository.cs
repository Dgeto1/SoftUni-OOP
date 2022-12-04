using System;
using Formula1.Models.Contracts;
using System.Collections.Generic;
using Formula1.Repositories.Contracts;
using System.Linq;

namespace Formula1.Repositories
{
	public class RaceRepository : IRepository<IRace>
	{
        private List<IRace> models;

        public IReadOnlyCollection<IRace> Models => models.AsReadOnly();

        public void Add(IRace model)
        {
            models.Add(model);
        }

        public IRace FindByName(string name)
        {
            return models.FirstOrDefault(x => x.RaceName == name);
        }

        public bool Remove(IRace model)
        {
            return models.Remove(model);
        }
    }
}

