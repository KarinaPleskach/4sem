using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using WindowsFormsApplication1.Decorators;

namespace Lab1
{
    [XmlType("Audi")] 
    public class Audi: BrandDecoratorBase {

        private Car car;

        public Audi(Car car)
        {
            this.car = car;
            CarBrand = "Audi";
            FuelType = car.FuelType;
            MaxSpeed = car.MaxSpeed;
            NumberOfWheels = car.NumberOfWheels;
        }

        public Audi() { }

        public override double GetCost()
        {
            return car.GetCost() + 200;
        }

    }

}
