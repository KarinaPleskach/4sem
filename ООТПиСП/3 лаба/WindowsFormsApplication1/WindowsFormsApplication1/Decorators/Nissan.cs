using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using WindowsFormsApplication1.Decorators;

namespace Lab1 {
    [XmlType("Nissan")]
    public class Nissan : BrandDecoratorBase{
        private Car car;

        public Nissan(Car car)
        {
            this.car = car;
            CarBrand = "Naissan";
            FuelType = car.FuelType;
            MaxSpeed = car.MaxSpeed;
            NumberOfWheels = car.NumberOfWheels;
        }

        public Nissan() { }

        public override double GetCost()
        {
            return car.GetCost() + 100;
        }

    }
}
