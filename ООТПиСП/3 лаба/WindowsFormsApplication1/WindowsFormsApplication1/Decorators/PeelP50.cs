using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using WindowsFormsApplication1.Decorators;

namespace Lab1 {
    [XmlType("PeelP50")]
    public class PeelP50 : BrandDecoratorBase
    {

        private Car car;

        public PeelP50(Car car)
        {
            this.car = car;
            CarBrand = "Peel";
            FuelType = car.FuelType;
            MaxSpeed = car.MaxSpeed;
            NumberOfWheels = car.NumberOfWheels;
        }

        public PeelP50() { }

        public override double GetCost()
        {
            return car.GetCost() + 50;
        }


    }
}
