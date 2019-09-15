using System;
using DecoratorSample.Beverage;
using DecoratorSample.Decorators;

namespace DecoratorSample
{
    public partial class Program
    {
        static void Main(string[] args)
        {
            BeverageBase espresso = new Espresso();
            BeverageBase blackTea = new BlackTea();
            BeverageBase greenTea = new GreenTea();

            //PrintBeverage(espresso);
            //PrintBeverage(blackTea);
            //PrintBeverage(greenTea);

            Console.WriteLine("-----------");

            BeverageBase capuccino = new SugarCondiment(new MilkCondiment(new Espresso()));
            //PrintBeverage(capuccino);

            BeverageBase greenTeaWithSugar = new SugarCondiment(new SugarCondiment( new GreenTea()));
            PrintBeverage(greenTeaWithSugar);

            Console.ReadLine();
        }

        static partial void PrintBeverage(BeverageBase beverage);
    }

    public partial class Program
    {
        static partial void PrintBeverage(BeverageBase beverage)
        {
            Console.WriteLine("Beverage: {0}; Price: {1}",
                beverage.GetDescription(), beverage.GetCost());
        }
    }
}
