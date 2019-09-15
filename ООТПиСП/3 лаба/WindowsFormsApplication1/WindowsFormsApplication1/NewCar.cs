using CarInterface;
using Lab1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class NewCar : Form
    {
        public Car newCar = null;
        public Dictionary<String, Type> plugins = new Dictionary<String,Type>();
        public Dictionary<String, Assembly> asms = new Dictionary<String, Assembly>();
        Type type;
        private static Archive archive = Archive.getInstance();

        public NewCar()
        {
            InitializeComponent();
            CenterToScreen();

            plugins.Add("audi" ,typeof(Audi));
            plugins.Add("peel", typeof(PeelP50));
            plugins.Add("nissan", typeof(Nissan));
            plugins.Add("tesla", typeof(Tesla));

            asms["citroen"] = Assembly.Load(File.ReadAllBytes("CitroenC5.dll"));
            type = asms["citroen"].GetTypes().Where(t => (t.GetInterface("ICarInt") != null)).First();
            plugins.Add(type.Name.ToLower(), type);
            brand.Items.Add(type.Name.ToLower());
            //ICarInt plug = (ICarInt)Activator.CreateInstance(plugins["citroen"], 4, "citroen", "diesel", 120);
            //plug.Show();
            ICarInt plug1 = (ICarInt)Activator.CreateInstance(plugins["citroen"]);
            plug1.Show();

            asms["zotye"] = Assembly.Load(File.ReadAllBytes("ZotyeE200.dll"));
            type = asms["zotye"].GetTypes().Where(t => (t.GetInterface("ICarInt") != null)).First();
            plugins.Add(type.Name.ToLower(), type);
            brand.Items.Add(type.Name.ToLower());

            ICarInt plug2 = (ICarInt)Activator.CreateInstance(plugins["zotye"]);
            plug2.Show();
        }

        private void ok_Click(object sender, EventArgs e)
        {
            switch((String)brand.Text)
            {
                case "":
                case "peel":
                case "audi": 
                case "nissan": 
                case "tesla": 
                    this.newCar = CarCreator.creator((int)wheels.Value, (String)brand.Text, (String)fuel.Text, (int)speed.Value); break;
                default: 
                    newCar = (Car)Activator.CreateInstance(plugins[(String)brand.Text], (int)wheels.Value, (String)brand.Text, (String)fuel.Text, (int)speed.Value); break;
            }
        }

        private void canel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void plus_Click(object sender, EventArgs e)
        {
                openFileDialog1.InitialDirectory = "D:\\учеба\\4 семестр\\ООТПиСП\\3 лаба\\WindowsFormsApplication1\\WindowsFormApplication\\bin\\Debug";
                openFileDialog1.Filter = "ZIP files (*.zip)|*.zip";

                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    String compressedFile = openFileDialog1.FileName; // сжатый файл
                    String targetFile = compressedFile.Substring(0, compressedFile.LastIndexOf(".")) + ".dll"; // восстановленный файл

                    // чтение из сжатого файла
                    archive.Strategy = new UnzipOperation();
                    archive.operate(compressedFile, targetFile);

                    Assembly asm = Assembly.Load(File.ReadAllBytes(targetFile));
                    type = asm.GetTypes().Where(t => (t.GetInterface("ICarInt") != null)).First();
                    if (plugins.ContainsKey(type.Name.ToLower()))
                    {
                        MessageBox.Show("Plugin already exist");
                        return;
                    }
                    plugins.Add(type.Name.ToLower(), type);
                    brand.Items.Add(type.Name.ToLower());
                    asms[type.Name.ToLower()] = asm;

                    ICarInt plug = (ICarInt)Activator.CreateInstance(plugins[type.Name.ToLower()]);
                    plug.Show();
                }
        

        }

        private void minus_Click(object sender, EventArgs e)
        {
            if (((String)brand.Text).Equals("") || ((String)brand.Text).Equals("peel") || ((String)brand.Text).Equals("audi") || ((String)brand.Text).Equals("nissan") || ((String)brand.Text).Equals("tesla"))
            {
                MessageBox.Show("Select plugin");
            }
            else
            {
                type = asms[(String)brand.Text].GetTypes().Where(t => (t.GetInterface("ICarInt") != null)).First();
                String sourseFile = AppDomain.CurrentDomain.BaseDirectory + type.Namespace + ".dll";
                String compressedFile = sourseFile.Substring(0, sourseFile.LastIndexOf(".")) + ".zip";

                asms.Remove((String)brand.Text);
                plugins.Remove((String)brand.Text);
                brand.Items.Remove((String)brand.Text);

                archive.Strategy = new ZipOperation();
                archive.operate(sourseFile, compressedFile);
            }
        }
    }
}
