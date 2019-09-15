using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Lab1 {
    [XmlType("Petrol")]
    public class Petrol : Car {
        public Petrol(int countOfWheels, int maxSpeed)
            : base()
        {
            FuelType = "petrol";
            NumberOfWheels = countOfWheels;
            MaxSpeed = maxSpeed;

        }

        public Petrol(int numberOfWheels, String carBrand, String fuelType, int maxSpeed)
            : base(numberOfWheels, carBrand, fuelType, maxSpeed)
        {

        }

        public Petrol() { }

        public override double GetCost()
        {
            return 50;
        }
    }
}
