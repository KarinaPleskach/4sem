using Lab1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    class CarCreator
    {
        private CarCreator() { }

        public static Car creator(int numberOfWheels, String carBrand, String fuelType, int maxSpeed)
        {
            Car car;

            switch (fuelType)
            {
                case "diesel": car = new Diesel(numberOfWheels, maxSpeed); break;
                case "petrol": car = new Petrol(numberOfWheels, maxSpeed); break;
                case "electricity": car = new Electricity(numberOfWheels, maxSpeed); break;
                default: car = new Car(numberOfWheels, carBrand, fuelType, maxSpeed); return car; 
            }

            switch (carBrand)
            {
                case "peel": car = new PeelP50(car); break;
                case "audi": car = new Audi(car); break;
                case "nissan": car = new Nissan(car); break;
                case "tesla": car = new Tesla(car); break;
                default: return car;
            }

            return car;
        }
    }
}
