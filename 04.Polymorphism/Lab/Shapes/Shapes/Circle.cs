using System;
namespace Shapes
{
    public class Circle : Shape 
    {
        private int radius;

        public int Radius { get; set; }

        public Circle (int redius)
        {
            radius = Radius;
        }
        public override double CalculateArea()
        {
            return Math.PI * radius * radius;
        }

        public override double CalculatePerimeter()
        {
            return 2 * Math.PI * radius;
        }

        public override string Draw()
        {
            return base.Draw() + "circle";
        }
    }
}

