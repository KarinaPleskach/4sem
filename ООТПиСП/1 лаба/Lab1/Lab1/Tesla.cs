using System;
using System.Collections.Generic;
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
            base.toString();
            this.characteristicOfCost();
        }

        public void characteristicOfCost() {
            Console.WriteLine("     Cost: " + cost + " $");
        }
    }
}
