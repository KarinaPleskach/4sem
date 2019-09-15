using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using WindowsFormsApplication1.Decorators;

namespace Lab1 {
    [XmlType("Tesla")]
    public class Tesla : BrandDecoratorBase
    {

        private Car car;

        public Tesla(Car car)
        {
            this.car = car;
            CarBrand = "Tesla";
            FuelType = car.FuelType;
            MaxSpeed = car.MaxSpeed;
            NumberOfWheels = car.NumberOfWheels;
        }

        public Tesla() { }

        public override double GetCost()
        {
            return car.GetCost() + 1000;
        }


    }
}
