using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1 {
    class Nissan: Diesel {
        public Nissan() : base("Nissan") { }

        public override void toString() {
            Console.WriteLine("<---<---In the subclass: Nissan!");
        }
    }
}
