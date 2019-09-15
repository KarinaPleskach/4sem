using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1 {
    class Nissan: Diesel {
        public Nissan() : base("Nissan") { }

        public override void toString() {
            Console.WriteLine("<---<---In the subclass: Nissan!");
        }
        public override Image draw()
        {
            Bitmap img = new Bitmap(base.draw());
            Graphics g = Graphics.FromImage(img);
            g.DrawImage(Lab2.Properties.Resources.Nissan, 155, 180);
            Pen myPen = new Pen(Color.Red, 2);
            g.DrawLine(myPen,200, 150, 200, 170);
            return img;
        }
    }
}
