using System;

namespace PointsRedo
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            
        }
    }

    class point2D
    {
        public int x;
        public int y;
        public point2D(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        public override string ToString()
        {
            return $"({this.x},{this.y})";
        }
        public bool Equals(point2D obj)
        {
            return (this.x == obj.x && this.y == obj.y);
        }
    }
    class point3D : point2D
    {
        int z;
        public point3D(int x, int y,int z) :base(x,y)
        {
            this.z = z;
            
        }
        public override string ToString()
        {
            return $"({this.x},{this.y},{this.z})";
        }
        public bool Equals(point3D o)
        {
            return (this.x == o.x && this.y == o.y && this.z == o.z);
        }
    }
}
