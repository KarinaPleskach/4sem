using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AboutInterface
{
    /// <summary>
    /// Интерфейс,описывающий всего один метод-
    /// получение строки "О программе"
    /// </summary>
    public interface IAboutInt
    {
        String GetAboutText();
    }
}
