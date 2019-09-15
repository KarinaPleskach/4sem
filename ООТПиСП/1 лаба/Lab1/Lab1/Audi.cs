using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
