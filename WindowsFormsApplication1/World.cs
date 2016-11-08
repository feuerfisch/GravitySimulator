using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    class World
    {
        public double BESCHLEUNIGUNGSKONSTANTE = 0.00000001;
        public List<Entity> entityList { get; set; }
        public World()
        {
        }

        void calcv()
        {
            Parallel.ForEach(entityList, Element =>
           {
                Parallel.ForEach(entityList, Iterator =>
                {
                    if (Iterator != Element)
                    {
                        double dx = (Element.x - Iterator.x);
                        double dy = (Element.y - Iterator.y);
                        double dz = (Element.z - Iterator.z);
                        double dx3abs = Math.Round(System.Math.Abs((dx * dx * dx)), 5);
                        double dy3abs = Math.Round(System.Math.Abs((dy * dy * dy)), 5);
                        double dz3abs = Math.Round(System.Math.Abs((dz * dz * dz)), 5);
                        double ax = 0;
                        double ay = 0;
                        double az = 0;
                        double distanz = Math.Pow((dx3abs + dy3abs + dz3abs), 1.0 / 3.0);
                        if (distanz != 0) { ax = -BESCHLEUNIGUNGSKONSTANTE * Element.masse * dx / distanz; }
                        if (distanz != 0) { ay = -BESCHLEUNIGUNGSKONSTANTE * Element.masse * dy / distanz; }
                        if (distanz != 0) { az = -BESCHLEUNIGUNGSKONSTANTE * Element.masse * dz / distanz; }
                        Element.vx = Element.vx + ax;
                        Element.vy = Element.vy + ay;
                        Element.vz = Element.vz + az;
                    }
                });
           });
        }

        public void calcpos()
        {
            calcv();
            foreach (Entity Element in entityList)
            {
                Element.x = Element.x + Element.vx;
                Element.y = Element.y + Element.vy;
                Element.z = Element.z + Element.vz;
            }
        }
    }
}
