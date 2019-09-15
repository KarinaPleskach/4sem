using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Reflection;
using AboutInterface;


namespace SimplePluginApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            ShowAboutInfo();
            Console.Read();
        }
        /// <summary>
        /// Показываем строку About
        ///из библиотеки About
        /// </summary>
        private static void ShowAboutInfo()
        {
            ///Получаем полный путь к файлу AboutLibrary.dll.
            ///Предполагаем,что он находится в папке,где и 
            ///исполняемый файл
            String AboutLibName = Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), "AboutLibrary.dll");
            if (!File.Exists(AboutLibName)) { Console.Write("File not found"); return; }
            ///Загружаем сборку
            Assembly AboutAssembly = Assembly.LoadFrom(AboutLibName);

            ///в цикле проходим по всем public-типам сборки
            foreach (Type t in AboutAssembly.GetExportedTypes())
            {
                ///если это класс,который реализует интерфейс IAboutInt,
                ///то это то,что нам нужно :)
                if (t.IsClass && typeof(IAboutInt).IsAssignableFrom(t))
                {
                    ///создаем объект полученного класса
                    IAboutInt about=(IAboutInt)Activator.CreateInstance(t);
                    ///вызываем его метод GetAboutText
                    Console.WriteLine(about.GetAboutText());
                    break;
                }
            }
        }
    }
}
