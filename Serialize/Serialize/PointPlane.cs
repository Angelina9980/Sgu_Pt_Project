using System;

namespace Serialize
{
    [Serializable]
    public class PointPlane
    {
        public double x1_coordinate, y1_coordinate;
        public int id;
        public string type;
        public PointPlane(double x1, double y1)
        {
            x1_coordinate = x1;
            y1_coordinate = y1;
            type = "PointPlane";
        }

        public PointPlane() { }

        public virtual string GetInfo()
        {
            string info = "The figure: point\n" + "Point coordinates are:(" + x1_coordinate + ", " + y1_coordinate + ")";
            Console.WriteLine("Point coordinates are: ({0}, {1})", x1_coordinate, y1_coordinate);
            return info;
        }
    }
}
