using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DecoratorSample.Beverage;

namespace DecoratorSample.Decorators
{
    class SugarCondiment : CondimentsDecoratorBase
    {
        private BeverageBase _beverage;

        public SugarCondiment(BeverageBase beverage)
        {
            _beverage = beverage;
            Desctiption = _beverage.GetDescription() + " +Sugar";
        }

        public override double GetCost()
        {
            return _beverage.GetCost() + 10;
        }
    }
}
