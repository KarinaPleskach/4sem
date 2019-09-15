using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Lab1 {
    [XmlType("Electricity")]
    public class Electricity: Car {

        public Electricity(int countOfWheels, int maxSpeed) : base()
        {
            FuelType = "electricity";
            NumberOfWheels = countOfWheels;
            MaxSpeed = maxSpeed;

        }

        public Electricity(int numberOfWheels, String carBrand, String fuelType, int maxSpeed)
            : base(numberOfWheels, carBrand, fuelType, maxSpeed)
        {

        }
        
        public Electricity() { }

         public override double GetCost()
         {
             return 1000;
         }
    }
}
