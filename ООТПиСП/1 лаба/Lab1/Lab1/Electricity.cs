using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1 {
    class Electricity: Car {
        public Electricity() : base("electricity") { }

        public Electricity(String carBrand) : base(carBrand, "electricity") { }

        public override void toString() {
            Console.WriteLine("<---In the subclass: Electricity!");
            base.toString();
        }
    }
}
