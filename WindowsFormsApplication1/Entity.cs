using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    class Entity
    {
        public string name { get; set; }
        public double x { get; set; }
        public double y { get; set; }
        public double z { get; set; }
        public double vx { get; set; }
        public double vy { get; set; }
        public double vz { get; set; }
        public double masse { get; set; }

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
    }
}
