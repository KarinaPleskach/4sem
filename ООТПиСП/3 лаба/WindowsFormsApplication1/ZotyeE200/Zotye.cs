using CarInterface;
using Lab1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ZotyeE200
{
    [XmlType("Zotye")]
    public class Zotye : Electricity, ICarInt
    {


        public Zotye(int numberOfWheels, String carBrand, String fuelType, int maxSpeed)
            : base(numberOfWheels, carBrand, fuelType, maxSpeed)
        {
        }
        public Zotye() { }


        private string pluginName = "zotye";
        private string pluginDescription = "type zotye ordinally is a electricity car";

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
