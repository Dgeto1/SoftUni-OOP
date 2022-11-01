using System;
namespace _01.ClassBoxData
{
	public class Box
	{
        private double length, width, height;
        public Box(double length, double width, double height)
        {
            Length = length;
            Width = width;
            Height = height;
        }

        public double Length
		{
			get { return this.length; }
			private set
			{
                if (value <= 0) throw new ArgumentException($"Lenght cannot be zero or negative.");
                this.length = value;
			}
		}

        public double Width
        {
            get { return this.width; }
            private set
            {
                if (value <= 0) throw new ArgumentException($"Width cannot be zero or negative.");
                this.width = value;
            }
        }

        public double Height
        {
            get { return this.height; }
            private set
            {
                if (value <= 0) throw new ArgumentException($"Height cannot be zero or negative.");
                this.height = value;
            }
        }

        public double SurfaceArea()
        {
            return 2 * (Length * Height + Length * Width + Height * Width);
        }

        public double LateralSurfaceArea()
        {
            return 2 * (Length * Height + Width * Height);
        }

        public double Volume()
        {
            return Length * Width * Height;
        }

        public override string ToString()
        {
            return $"Surface Area - {this.SurfaceArea():f2}" + Environment.NewLine+
                $"Lateral Surface Area - {this.LateralSurfaceArea():f2}" + Environment.NewLine +
                $"Volume - {this.Volume():f2}";
        }
    }
}

