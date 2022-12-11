﻿using System;
namespace ChristmasPastryShop.Models.Delicacies
{
    public class Stolen : Delicacy
    {
        private const double stolenPrice = 3.50;
        public Stolen(string name) : base(name, stolenPrice)
        {
        }
    }
}

