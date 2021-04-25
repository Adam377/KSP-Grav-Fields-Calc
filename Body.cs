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
        private double solarDay;

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

        public double SolarDay
        {
            set { this.solarDay = value; }
            get { return this.solarDay; }
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

        public double calcGeoHeight()
        {
            // cube root is the same as power to 1/3
            // r = cube root(GMT2 / 4π2)

            if (name.CompareTo("Sun") == 0 || name.CompareTo("Gilly") == 0 || name.CompareTo("Mun") == 0 || name.CompareTo("Minmus") == 0 || name.CompareTo("Ike") == 0 || name.CompareTo("Laythe") == 0 || name.CompareTo("Vall") == 0 || name.CompareTo("Tylo") == 0 || name.CompareTo("Bop") == 0 || name.CompareTo("Pol") == 0)
            {
                // cannot calculate geostationary height on moon
                return 0;
            }
            else
            {
                double numerator = G * mass * (Math.Pow(SolarDay, 2));
                double denominator = 4 * Math.Pow(Math.PI, 2);
                double height = Math.Pow(numerator / denominator, (double)1 / 3);

                // height is distance above centre of planet/
                // KSP displays height above surface
                return height - radius;
            }
        }
    }
}
