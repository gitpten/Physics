using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Physics
{
    class GraphicBall: Ball
    {
        public GraphicBall(Graphics g, double m, double d, PictureBox pb) : base(g, m, d)
        {
            Pb = pb;
        }

        public PictureBox Pb { get; set; }

        public void Draw(double scale)
        {
            Pb.Location = (RV * scale).ToPoint();
        }
    }
}
