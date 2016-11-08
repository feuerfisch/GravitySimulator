using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        World world = new World();
        Random rnd1 = new Random();
        Pen blackPen = new Pen(Color.Black, 3);
        System.Drawing.Pen myPen = new System.Drawing.Pen(System.Drawing.Color.Red);
        System.Drawing.Graphics formGraphics;

        public Form1()
        {
            this.Width = 1800;
            this.Height = 1000;
            Random rnd1 = new Random();
            world.entityList = new List<Entity>();
            world.entityList.Add(new Entity("Erde", rnd1.Next((this.Width / 2) - 10, (this.Width / 2) + 11), rnd1.Next((this.Height / 2) - 10, (this.Height / 2) + 11), 0, rnd1.Next(-1, 1), rnd1.Next(-1, 1), 0, 1000000));
            world.entityList.Add(new Entity("Mond", rnd1.Next((this.Width / 2) - 10, (this.Width / 2) + 11), rnd1.Next((this.Height / 2) - 10, (this.Height / 2) + 11), 0, rnd1.Next(-1, 1), rnd1.Next(-1, 1), 0, 1000000));
            world.entityList.Add(new Entity("Mars", rnd1.Next((this.Width / 2) - 10, (this.Width / 2) + 11), rnd1.Next((this.Height / 2) - 10, (this.Height / 2) + 11), 0, rnd1.Next(-1, 1), rnd1.Next(-1, 1), 0, 1000000));
            formGraphics = this.CreateGraphics();
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Random rnd1 = new Random();
            world.entityList.Clear();
            formGraphics.Clear(this.BackColor);
            //world.entityList.Add(new Entity("Erde", rnd1.Next((this.Width / 2) - 10, (this.Width / 2) + 11), rnd1.Next((this.Height / 2) - 10, (this.Height / 2) + 11), 0, rnd1.Next(-1, 1), rnd1.Next(-1, 1), 0, 1000000));
            //world.entityList.Add(new Entity("Mond", rnd1.Next((this.Width / 2) - 10, (this.Width / 2) + 11), rnd1.Next((this.Height / 2) - 10, (this.Height / 2) + 11), 0, rnd1.Next(-1, 1), rnd1.Next(-1, 1), 0, 1000000));
            //world.entityList.Add(new Entity("Mars", rnd1.Next((this.Width / 2) - 10, (this.Width / 2) + 11), rnd1.Next((this.Height / 2) - 10, (this.Height / 2) + 11), 0, rnd1.Next(-1, 1), rnd1.Next(-1, 1), 0, 1000000));
            world.entityList.Add(new Entity("Erde", rnd1.Next((this.Width / 2) - 10, (this.Width / 2) + 11), rnd1.Next((this.Height / 2) - 10, (this.Height / 2) + 11), 0, 0, 0, 0, 1000000));
            world.entityList.Add(new Entity("Mond", rnd1.Next((this.Width / 2) - 10, (this.Width / 2) + 11), rnd1.Next((this.Height / 2) - 10, (this.Height / 2) + 11), 0, 0, 0, 0, 1000000));
            //world.entityList.Add(new Entity("Mars", rnd1.Next((this.Width / 2) - 10, (this.Width / 2) + 11), rnd1.Next((this.Height / 2) - 10, (this.Height / 2) + 11), 0, 0, 0, 0, 1000000));
        }


        private void button2_Click(object sender, EventArgs e)
        {
            if (!timer1.Enabled) { timer1.Start(); } else timer1.Stop();
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            
            world.calcpos();
            foreach (Entity Element in world.entityList)
            {
                formGraphics.DrawEllipse(myPen, new Rectangle((int) Element.x, (int) Element.y, 1, 1));
            }
            
        }
    }
}
