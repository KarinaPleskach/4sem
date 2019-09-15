using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Lab1 {
    [XmlType("Diesel")]
    public class Diesel: Car {

        public Diesel(int countOfWheels, int maxSpeed) : base()
        {
            FuelType = "diesel";
            NumberOfWheels = countOfWheels;
            MaxSpeed = maxSpeed;

        }

        public Diesel(int numberOfWheels, String carBrand, String fuelType, int maxSpeed)
            : base(numberOfWheels, carBrand, fuelType, maxSpeed)
        {

        }

        public Diesel() { }

         public override double GetCost()
         {
             return 25;
         }
    }
}
