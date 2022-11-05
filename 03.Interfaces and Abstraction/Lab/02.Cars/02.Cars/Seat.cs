﻿using System;
using System.Text;
namespace Cars
{
    public class Seat : ICar
    {
        private string color;
        private string model;

        public Seat(string model, string color)
        {
            this.Model = model;
            this.Color = color;
        }

        public string Model { get; set; }
        public string Color { get; set; }

        public string Start()
        {
            return "Engine start";
        }

        public string Stop()
        {
            return "Break!";
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{this.Color} Seat {this.Model}");
            sb.AppendLine(Start());
            sb.AppendLine(Stop());
            return sb.ToString().Trim();

        }
    }
}

