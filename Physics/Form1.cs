using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Physics
{
    public partial class Form1 : Form
    {
        Vector r0; double time; Vector a; Vector v0;
        double scale = 1;
        GraphicBall b, b1;

        Point[] pp = { new Point(0, 0), new Point(800, 100), new Point(800,600),new Point(20,550)};

        Graphics g;
        public Form1()
        {
            InitializeComponent();
            g = CreateGraphics();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            b = new GraphicBall(g, 10000, pictureBox1.Width , pictureBox1);
            v0 = (new Vector(3, -10)).E * 0;
            b.V = v0;
            r0 = (new Vector(pictureBox1.Location))/scale;
            b.RV = r0;
            b.A = new Vector(0, 0) ;
            time = 0;

            b1 = new GraphicBall(g, 10, pictureBox2.Width , pictureBox2);
            v0 = (new Vector(-20, -10)).E * 200;
            b1.V = v0;
            r0 = (new Vector(pictureBox2.Location)) / scale;
            b1.RV = r0;
            b1.A = new Vector(0, 0) ;

            
            g.DrawPolygon(Pens.Black, pp);

            timer1.Start();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            time = timer1.Interval/1000.0;

            //Vector r = r0 + v0 * time + a * time * time / 2;
            Vector r = b.RV - b1.RV;

            Vector F = b.M * b1.M / (r * r) * r.E *1000; //изменить потом
            b.A = -F / b.M;
            b1.A = F / b1.M;
            //b.A.Draw(g, Pens.Blue,pictureBox1.Location);
            //b1.A.Draw(g, Pens.Red, pictureBox2.Location);

            b.V += b.A * time;
            b.RV += b.V * time;
            b1.V += b1.A * time;
            b1.RV += b1.V * time;
            b.Draw(scale);
            b1.Draw(scale);

            b1.Bounce(pp);
            //pictureBox1.Location = (r0*scale).ToPoint();
        }

        private void Form1_Resize(object sender, EventArgs e)
        {

        }
    }
}
