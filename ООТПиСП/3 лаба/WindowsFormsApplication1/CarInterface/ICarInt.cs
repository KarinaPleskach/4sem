using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarInterface
{
    public interface ICarInt
    {
        string PluginName { get; } 
        string PluginDescription { get; } 

        void Show();
    }
}
