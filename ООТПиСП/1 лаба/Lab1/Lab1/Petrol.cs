using System;
using System.Collections.Generic;
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
    }
}
