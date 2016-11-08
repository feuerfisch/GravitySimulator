using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    class Entity
    {
        public const double BESCHLEUNIGUNGSKONSTANTE = 0.00000010;
        string name { get; set; }
        public double x { get; set; }
        public double y { get; set; }
        public double z { get; set; }
        double vx { get; set; }
        double vy { get; set; }
        double vz { get; set; }
        double masse { get; set; }
        public Entity(string _name, double _x, double _y, double _z, double _vx, double _vy, double _vz, double _masse)
        {
            name = _name;
            x = _x;
            y = _y;
            z = _z;
            vx = _vx;
            vy = _vy;
            vz = _vz;
            masse = _masse;
        }
        public void calcv(List<Entity> entityList)
        {
            foreach (Entity Element in entityList)
            {
                if (Element != this)
                {
                    double dx = (this.x - Element.x);
                    double dy = (this.y - Element.y);
                    double dz = (this.z - Element.z);
                    double dx3abs = Math.Round(System.Math.Abs((dx * dx)), 5);
                    double dy3abs = Math.Round(System.Math.Abs((dy * dy)), 5);
                    double dz3abs = Math.Round(System.Math.Abs((dz * dz)), 5);
                    double ax = 0;
                    double ay = 0;
                    double az = 0;
                    if (dx3abs != 0) { ax = -BESCHLEUNIGUNGSKONSTANTE * Element.masse * dx / dx3abs; }
                    if (dy3abs != 0) { ay = -BESCHLEUNIGUNGSKONSTANTE * Element.masse * dy / dy3abs; }
                    if (dz3abs != 0) { az = -BESCHLEUNIGUNGSKONSTANTE * Element.masse * dz / dz3abs; }
                    vx = vx + ax;
                    vy = vy + ay;
                    vz = vz + az;
                }
            }
        }
        public void calcpos()
        {
            x = x + vx;
            y = y + vy;
            z = z + vz;
        }
    }
}
