using Lab1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace WindowsFormsApplication1.Decorators
{
    [XmlType("BrandDecoratorBase")]
    [XmlInclude(typeof(Audi)), XmlInclude(typeof(Nissan)), XmlInclude(typeof(PeelP50)), XmlInclude(typeof(Tesla))] 
    public abstract class BrandDecoratorBase : Car
    {
    }
}
