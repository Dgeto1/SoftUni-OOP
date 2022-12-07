using System;
using System.Collections.Generic;
using System.Linq;
using Heroes.Models.Contracts;
using Heroes.Models.Heroes;

namespace Heroes.Models.Map
{
    public class Map : IMap
    {
        public string Fight(ICollection<IHero> players)
        {
            List<IHero> barbarians;
            List<IHero> knights;
            barbarians = players.Where(p => p.GetType().Name == "Barbarian").ToList();
            knights = players.Where(p => p.GetType().Name == "Knight").ToList();

            

        }
    }
}

