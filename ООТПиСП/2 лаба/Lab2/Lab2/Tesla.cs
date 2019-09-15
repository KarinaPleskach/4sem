using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1 {
    class Tesla: Electricity {
        protected int cost;

        public Tesla() : base("Tesla") {
            this.cost = 400000;
        }

        public override void toString() {
            Console.WriteLine("<---<---In the subclass: Tesla!");
        }

        public void characteristicOfCost() {
            Console.WriteLine("     Cost: " + cost + " $");
        }
        public override Image draw()
        {
            Bitmap img = new Bitmap(base.draw());
            Graphics g = Graphics.FromImage(img);
            g.DrawImage(Lab2.Properties.Resources.tesla, 310, 180);
            Pen myPen = new Pen(Color.Red, 2);
            g.DrawLine(myPen, 350, 180, 300, 170);
            return img;
        }
    }
}
