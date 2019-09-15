using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1 {
    class Diesel: Car {
        public Diesel() : base("diesel") { }

        public Diesel(String carBrand) : base(carBrand, "petrol") { }

        public override void toString() {
            Console.WriteLine("<---In the subclass: Diesel!");
        }
        public override Image draw()
        {
            Bitmap img = new Bitmap(base.draw());
            Graphics g = Graphics.FromImage(img);
            g.DrawImage(Lab2.Properties.Resources.diesel, 170, 90);
            Pen myPen = new Pen(Color.Red, 2);
            g.DrawLine(myPen, 200, 60, 200, 90);
            return img;
        }
    }
}
