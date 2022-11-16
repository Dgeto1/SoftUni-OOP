using System;
using System.Collections.Generic;

namespace _03.Raiding
{
    class StartUp
    {
        static void Main(string[] args)
        {
            List<BaseHero> heroes = new List<BaseHero>();
            int n = int.Parse(Console.ReadLine());
            for(int i=0; i<n; i++)
            {
                string heroName = Console.ReadLine();
                string heroType = Console.ReadLine();
                if(heroType == "Druid")
                {
                    Druid druid = new Druid(heroType, heroName);
                    heroes.Add(druid);
                }
                else if(heroType == "Paladin")
                {
                    Paladin paladin = new Paladin(heroType, heroName);
                    heroes.Add(paladin);
                }
                else if(heroType=="Rogue")
                {
                    Rogue rogue = new Rogue(heroType, heroName);
                    heroes.Add(rogue);
                }
                else if(heroType=="Warrior")
                {
                    Warrior warrior = new Warrior(heroType, heroName);
                    heroes.Add(warrior);
                }
                else
                {
                    Console.WriteLine("Invalid hero!");
                    i--;
                }
            }
            int bossPower = int.Parse(Console.ReadLine());
            int sumPower = 0;
            foreach(var x in heroes)
            {
                sumPower += x.Power;
                
                Console.WriteLine(x.CastAbility());
            }
            if(bossPower<=sumPower)
            {
                Console.WriteLine("Victory!");
            }
            else
            {
                Console.WriteLine("Defeat...");
            }
        }
    }
}

