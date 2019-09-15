using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab1 {
    class Audi: Petrol {
        protected int maxSpeed;

        public Audi() : base("Audi") {
            this.maxSpeed = 350;
        }

        public override void toString() {
            Console.WriteLine("<---<---In the subclass: Audi!");
            base.toString();
            characteristicOfSpeed();
        }

        public void characteristicOfSpeed() {
            Console.WriteLine("     Max speed: " + maxSpeed + " km/h");
        }

        public override Image draw()
        {
            Bitmap img = new Bitmap(base.draw()); 
            Graphics g = Graphics.FromImage(img);
            g.DrawImage(Lab2.Properties.Resources.Audi, 100, 170);
            Pen myPen = new Pen(Color.Red, 2);
            g.DrawLine(myPen, 120, 150, 130, 170);
            return img;
        }
    }
}
