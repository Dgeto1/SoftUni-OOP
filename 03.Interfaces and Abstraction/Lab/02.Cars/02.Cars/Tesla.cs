using System;
using System.Text;
namespace Cars
{
    public class Tesla : ICar, IElectricCar
    {
        private int battery;
        private string model, color;

        public Tesla(string model, string color, int battery)
        {
            Model = model;
            Color = color;
            Battery = battery;
        }

        public int Battery { get; set; }
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

            sb.AppendLine($"{this.Color} Tesla {this.Model} with {this.Battery} Batteries");
            sb.AppendLine(Start());
            sb.AppendLine(Stop());
            return sb.ToString().Trim();
        }
    }
}

