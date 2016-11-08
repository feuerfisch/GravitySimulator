using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    class World
    {
        public List<Entity> entityList { get; set; }
        public World()
        {
        }
        public void calcpos()
        {
            calcv();
            foreach (Entity Element in entityList)
            {
                Element.calcpos();
            }
        }

        void calcv()
        {
            foreach (Entity Element in entityList)
            {
                Element.calcv(entityList);
            }
        }
    }
}
