using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using WindowsFormsApplication1.Decorators;

namespace Lab1 {
    [XmlType("Car")]
    [XmlInclude(typeof(Petrol)), XmlInclude(typeof(Diesel)), XmlInclude(typeof(Electricity)), XmlInclude(typeof(BrandDecoratorBase))] 
    public class Car {
        private int numberOfWheels;
        private String carBrand;
        private String fuelType;
        private int maxSpeed;

        public int NumberOfWheels {
            get { return numberOfWheels; }
            set { numberOfWheels = value; }
        }

        public int MaxSpeed
        {
            get { return maxSpeed; }
            set { maxSpeed = value; }
        }

        public String CarBrand {
            get { return carBrand; }
            set { carBrand = value; }
        }

        public String FuelType {
            get { return fuelType; }
            set { fuelType = value; }
        }

        public Car() {
            this.numberOfWheels = 4;
            this.carBrand = "not determined";
            this.fuelType = "not determined";
            this.maxSpeed = 0;
        }

        public Car(int numberOfWheels, String carBrand, String fuelType, int maxSpeed) : this()
        {
            this.numberOfWheels = numberOfWheels;
            if (!carBrand.Equals(""))
                this.carBrand = carBrand;
            if (!fuelType.Equals(""))
                this.fuelType = fuelType;
            this.maxSpeed = maxSpeed;
        }

        public virtual double GetCost()
        {
            return 0;
        }
    }
}
