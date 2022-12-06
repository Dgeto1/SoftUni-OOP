using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using NavalVessels.Models;
using NavalVessels.Repositories.Contracts;

namespace NavalVessels.Repositories
{
    public class VesselRepository : IRepository<Vessel>
    {
        private List<Vessel> models;
        public IReadOnlyCollection<Vessel> Models => models.AsReadOnly();


        public void Add(Vessel model)
        {
            models.Add(model);
        }

        public Vessel FindByName(string name)
        {
            return models.FirstOrDefault(m => m.Name == name);
        }

        public bool Remove(Vessel model)
        {
            return models.Remove(model);
        }
    }
}

