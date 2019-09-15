using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1 {
    class Petrol : Car {
        public Petrol() : base("petrol") { }

        public Petrol(int numberOfWheels, String carBrand) : base(numberOfWheels, carBrand, "petrol") { }

        public Petrol(String carBrand) : base(carBrand, "petrol") { }

        public override void toString() {
            Console.WriteLine("<---In the subclass: Petrol!");
            base.toString();
        }

        public override Image draw()
        {
            Bitmap img = new Bitmap(base.draw()); 
            Graphics g = Graphics.FromImage(img);
            g.DrawImage(Lab2.Properties.Resources.Petrol, 70, 90);
            Pen myPen = new Pen(Color.Red, 2);
            g.DrawLine(myPen, 200, 60, 120, 90);
            return img;
        }
    }
}
