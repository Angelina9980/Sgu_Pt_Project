using System;

namespace Serialize
{
    [Serializable]
    class Circle : PointPlane
    {
        public double radius, length;
        public Circle(double x1, double y1, double radius) : base(x1, y1)
        {
            this.radius = radius;
            if (radius == 0)
            {
                type = "PointPlane";
            }
            else
            {
                type = "Circle";
            }
        }

        public Circle()
        {

        }
        public double Length
        {
            get
            {
                return length;
            }
        }
        public double Radius
        {
            get
            {
                return radius;
            }
            set
            {
                if (value >= 0)
                    radius = value;
                else
                {
                    Console.WriteLine("Incorrect value of radius");
                    Console.WriteLine("Default value: radius = 1");
                    radius = 1;
                }
            }
        }

        public virtual double GetLength()
        {
            return length = 2 * Math.PI * radius;
        }

        public override string GetInfo()
        {
            if (radius == 0)
            {
                string pointInfo = "The figure: point\n" + "Point coordinates are:(" + x1_coordinate + ", " + y1_coordinate + ")";
                return pointInfo;
            }
            else
            {
                Console.WriteLine("Figure: Circle");
                Console.WriteLine("Сicle coordinates are: ({0},{1})", x1_coordinate, y1_coordinate);
                Console.WriteLine("Circle radius is: {0}", radius);
                Console.WriteLine("Circle length is {0}", GetLength());
                string circleInfo = "The figure: circle\n" + "Сircle coordinates are: (" + x1_coordinate + ", " + y1_coordinate + ")"
                    + "\nCircle radius is: " + radius + "\nCircle length is " + GetLength();
                return circleInfo;
            }
        }

    }
}
