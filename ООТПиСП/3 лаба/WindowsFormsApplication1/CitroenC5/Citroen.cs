using CarInterface;
using Lab1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CitroenC5
{
    [XmlType("Citroen")]
    public class Citroen : Diesel, ICarInt
    {

        public Citroen(int numberOfWheels, String carBrand, String fuelType, int maxSpeed)
            : base(numberOfWheels, carBrand, fuelType, maxSpeed)
        {
        }

        public Citroen() { }

        private string pluginName = "citroen";
        private string pluginDescription = "type sitroen ordinally is a diesel car";
        
        public string PluginName
        {
            get { return this.pluginName; }
        }

        public string PluginDescription
        {
            get { return this.pluginDescription; }
        }

        public void Show()
        {
            Form1 frm = new Form1(this);
            frm.ShowDialog();
        }
    }
}
