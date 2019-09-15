using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1 {
    class Car {
        protected int numberOfWheels;
        protected String carBrand;
        protected String fuelType;

        public Car() : this(4, "not determined", "not determined") { }
        
        public Car(String fuelType) : this(4, "not determined", fuelType) { }
       
        public Car(String carBand, String fuelType) : this(4, carBand, fuelType) { }

        public Car(int numberOfWheels, String carBrand, String fuelType) {
            this.numberOfWheels = numberOfWheels;
            this.carBrand = carBrand;
            this.fuelType = fuelType;
        }

        public virtual void toString() {
            Console.WriteLine("In the super class: Car!");
            characteristicOfWheels();
            characteristicOfBrand();
            characteristicOfFuel();
        }

        public void characteristicOfWheels() {
            Console.WriteLine("     Number of wheels: " + numberOfWheels);
        }

        public void characteristicOfBrand() {
            Console.WriteLine("     Car brand: " + carBrand);
        }

        public void characteristicOfFuel() {
            Console.WriteLine("     Fuel type: " + fuelType);
        }
    }
}
