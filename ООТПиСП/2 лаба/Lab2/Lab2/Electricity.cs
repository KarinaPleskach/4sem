using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1 {
    class Electricity: Car {
        public Electricity() : base("electricity") { }

        public Electricity(String carBrand) : base(carBrand, "electricity") { }

        public override void toString() {
            Console.WriteLine("<---In the subclass: Electricity!");
        }
        public override Image draw()
        {
            Bitmap img = new Bitmap(base.draw());
            Graphics g = Graphics.FromImage(img);
            g.DrawImage(Lab2.Properties.Resources.electricity, 250, 90);
            Pen myPen = new Pen(Color.Red, 2);
            g.DrawLine(myPen, 200, 60, 250, 110);
            return img;
        }
    }
}
