using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSPGravFieldV2
{
    class Body : IComparable
    {
        //members
        readonly private double G = 6.67408 * Math.Pow(10, -11);
        private double mass;
        private double radius;
        private string name;

        //constructor
        public Body()
        {

        }

        //methods
        public int CompareTo(object obj)
        {
            Body b = (Body)obj;
            return name.CompareTo(b.name);
        }

        public double Mass
        {
            set { this.mass = value; }
            get { return this.mass; }
        }

        public double Radius
        {
            set { this.radius = value; }
            get { return this.radius; }
        }

        public string Name
        {
            set { this.name = value; }
            get { return this.name; }
        }

        public double calcGFS(Body b, double height)
        {
            //g = GM/r2
            double r = b.Radius + height;

            return (G * b.Mass) / (r * r); ;
        }

        public double calcSpeed(Body b, double height)
        {
            //v = root(GM/r)
            double r = b.Radius + height;

            return Math.Sqrt((G * b.Mass) / r);
        }
    }
}
