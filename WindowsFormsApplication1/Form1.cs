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
        System.Drawing.Pen myPen = new System.Drawing.Pen(System.Drawing.Color.Red);
        System.Drawing.Graphics formGraphics;

        public Form1()
        {
            this.Width = 1800;
            this.Height = 1000;
            Random rnd1 = new Random();
            world.entityList = new List<Entity>();
            formGraphics = this.CreateGraphics();
            InitializeComponent();
            label1.Text = world.BESCHLEUNIGUNGSKONSTANTE.ToString();
            label2.Text = timer1.Interval.ToString() + " ms per tick";
            world.entityList.Add(new Entity("Erde", rnd1.Next((this.Width / 2) - 50, (this.Width / 2) + 50), rnd1.Next((this.Height / 2) - 50, (this.Height / 2) + 50), 0, rnd1.Next(-1, 1), rnd1.Next(-1, 1), 0, 1000));
            world.entityList.Add(new Entity("Mond", rnd1.Next((this.Width / 2) - 50, (this.Width / 2) + 50), rnd1.Next((this.Height / 2) - 50, (this.Height / 2) + 50), 0, rnd1.Next(-1, 1), rnd1.Next(-1, 1), 0, 1000));
            world.entityList.Add(new Entity("Mars", rnd1.Next((this.Width / 2) - 50, (this.Width / 2) + 50), rnd1.Next((this.Height / 2) - 50, (this.Height / 2) + 50), 0, rnd1.Next(-1, 1), rnd1.Next(-1, 1), 0, 1000));
            world.entityList.Add(new Entity("Sonne", rnd1.Next((this.Width / 2), (this.Width / 2)), rnd1.Next((this.Height / 2), (this.Height / 2)), 0, 0, 0, 0, 10000000));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Random rnd1 = new Random();
            world.entityList.Clear();
            formGraphics.Clear(this.BackColor);
            world.entityList.Add(new Entity("Erde", rnd1.Next((this.Width / 2) - 50, (this.Width / 2) + 50), rnd1.Next((this.Height / 2) - 50, (this.Height / 2) + 50), 0, rnd1.Next(-1, 1), rnd1.Next(-1, 1), 0, 1000));
            world.entityList.Add(new Entity("Mond", rnd1.Next((this.Width / 2) - 50, (this.Width / 2) + 50), rnd1.Next((this.Height / 2) - 50, (this.Height / 2) + 50), 0, rnd1.Next(-1, 1), rnd1.Next(-1, 1), 0, 1000));
            world.entityList.Add(new Entity("Mars", rnd1.Next((this.Width / 2) - 50, (this.Width / 2) + 50), rnd1.Next((this.Height / 2) - 50, (this.Height / 2) + 50), 0, rnd1.Next(-1, 1), rnd1.Next(-1, 1), 0, 1000));
            world.entityList.Add(new Entity("Sonne", rnd1.Next((this.Width / 2), (this.Width / 2)), rnd1.Next((this.Height / 2), (this.Height / 2)), 0, 0, 0, 0, 10000000));
        }


        private void button2_Click(object sender, EventArgs e)
        {
            if (!timer1.Enabled) { timer1.Start(); } else timer1.Stop();
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            
            world.calcpos();
            foreach(Entity Element in world.entityList)
           {
               formGraphics.DrawEllipse(myPen, new Rectangle((int)Element.x, (int)Element.y, 1, 1));
           }
            
        }


        private void button4_Click(object sender, EventArgs e)
        {
            world.BESCHLEUNIGUNGSKONSTANTE =world.BESCHLEUNIGUNGSKONSTANTE * 10.0;
            label1.Text = world.BESCHLEUNIGUNGSKONSTANTE.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            world.BESCHLEUNIGUNGSKONSTANTE = world.BESCHLEUNIGUNGSKONSTANTE / 10.0;
            label1.Text = world.BESCHLEUNIGUNGSKONSTANTE.ToString();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if(timer1.Interval!=1)timer1.Interval /= 10;
            label2.Text =timer1.Interval.ToString() + " ms per tick";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            timer1.Interval *= 10;
            label2.Text = timer1.Interval.ToString() + " ms per tick";
        }
    }
}
