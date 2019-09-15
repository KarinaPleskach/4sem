using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1 {
    class PeelP50: Petrol {
        protected int numberOfDoors;

        public PeelP50() : base(3, "Peel P-50") {
            this.numberOfDoors = 1;
        }

        public override void toString() {
            Console.WriteLine("<---<---In the subclass: Peel P-50!");
            base.toString();
            characteristicOfDoors();
        }

        public void characteristicOfDoors() {
            Console.WriteLine("     Number of doors: " + numberOfDoors);
        }

        public override Image draw()
        {
            Bitmap img = new Bitmap(base.draw());
            Graphics g = Graphics.FromImage(img);
            g.DrawImage(Lab2.Properties.Resources.peel, 20, 170);
            Pen myPen = new Pen(Color.Red, 2);
            g.DrawLine(myPen, 100, 150, 80, 170);
            return img;
        }
    }
}
