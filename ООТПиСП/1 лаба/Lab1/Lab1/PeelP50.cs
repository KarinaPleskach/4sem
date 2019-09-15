using System;
using System.Collections.Generic;
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
    }
}
