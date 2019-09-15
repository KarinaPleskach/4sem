namespace DecoratorSample.Beverage
{
    class GreenTea : BeverageBase
    {
        public GreenTea()
        {
            Desctiption = "Green leaf tea";
        }

        public override double GetCost()
        {
            return 125;
        }
    }
}
