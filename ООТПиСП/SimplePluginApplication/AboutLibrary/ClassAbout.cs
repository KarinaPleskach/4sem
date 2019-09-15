using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AboutInterface;


namespace AboutLibrary
{
    /// <summary>
    /// Класс ,реализующий 
    ///IAboutInt интерфейс 
    /// </summary>
    public class ClassAbout:IAboutInt
    {       
        public String GetAboutText()
        {
            return "This is my first plugin";
        }
    }
}
