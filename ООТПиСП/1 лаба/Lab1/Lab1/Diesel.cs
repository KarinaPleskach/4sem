using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1 {
    class Diesel: Car {
        public Diesel() : base("diesel") { }

        public Diesel(String carBrand) : base(carBrand, "diesel") { }

        public override void toString() {
            Console.WriteLine("<---In the subclass: Diesel!");
        }
    }
}
