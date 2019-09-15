using Lab1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace WindowsFormsApplication1
{
    [XmlRoot("CarList")]
    [XmlInclude(typeof(Car))]
    public class CarList
    {
        [XmlArray("CarArray")]
        [XmlArrayItem("CarObject")]
        public List<Car> cars = new List<Car>();

        public List<Car> getList() { return cars;  }

        public void AddCar(Car car)
        {
            cars.Add(car);
        }
    }
}
