using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1 {
    class Program {
        static void Main(string[] args) {
            Car car = new Car();
            Console.WriteLine();
            car.toString();

            Petrol petrol = new Petrol();
            Console.WriteLine();
            petrol.toString();

            PeelP50 peel = new PeelP50();
            Console.WriteLine();
            peel.toString();

            car = new Diesel();
            Console.WriteLine();
            car.toString();
            car.characteristicOfWheels();
            car.characteristicOfFuel();
            car.characteristicOfBrand();
            car = new Nissan();
            Console.WriteLine();
            car.toString();
            car.characteristicOfWheels();
            car.characteristicOfFuel();
            car.characteristicOfBrand();

            car = new Electricity();
            Electricity electricity = (Electricity) car;
            Console.WriteLine();
            electricity.toString();
            electricity = new Tesla();
            Console.WriteLine();
            electricity.toString();
            
            Console.ReadLine();
        }
    }
}
