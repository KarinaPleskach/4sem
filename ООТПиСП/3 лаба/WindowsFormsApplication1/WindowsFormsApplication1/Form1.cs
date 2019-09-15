using Lab1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        CarList carList = new CarList();
        NewCar newCar = new NewCar();

        public Form1()
        {
            InitializeComponent();
            CenterToScreen();

            carList.AddCar(new PeelP50(new Petrol(4, 120)));
            carList.AddCar(new Tesla(new Electricity(4, 300)));

            newGrid();
        }

        private void newGrid()
        {
            if (carList.getList() != null)
            {
                DataTable table = new DataTable();

                DataColumn numberOfWheels = new DataColumn("numberOfWheels");
                DataColumn carBrand = new DataColumn("carBrand");
                DataColumn fuelType = new DataColumn("fuelType");
                DataColumn maxSpeed = new DataColumn("maxSpeed");

                table.Columns.Add(numberOfWheels);
                table.Columns.Add(carBrand);
                table.Columns.Add(fuelType);
                table.Columns.Add(maxSpeed);

                foreach (Car car in carList.getList())
                {
                    DataRow row = table.NewRow();
                    row["numberOfWheels"] = car.NumberOfWheels;
                    row["carBrand"] = car.CarBrand;
                    row["fuelType"] = car.FuelType;
                    row["maxSpeed"] = car.MaxSpeed;
                    table.Rows.Add(row);
                }

                DataGrid.DataSource = table;
            }
        }

        private void addNewCarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            

            if (newCar.ShowDialog() == DialogResult.OK)
            {
                carList.AddCar(newCar.newCar);
                newGrid();
            }
        }

        private void deleteCarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(DataGrid.CurrentRow.Index >= 0) {
                carList.getList().RemoveAt(DataGrid.CurrentRow.Index);
                newGrid();
            }
        }

        private void clearAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            carList.getList().Clear();
            newGrid();
        }

        private void openFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = "D:\\учеба\\4 семестр\\ООТПиСП\\3 лаба";
            openFileDialog1.Filter = "Xml files (*.xml)|*.xml";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                carList.getList().Clear();

                Stream stream = openFileDialog1.OpenFile();

                //Type[] carTypes = { typeof(PeelP50), typeof(Audi), typeof(Nissan), typeof(Tesla) };

                //XmlSerializer serializer = new XmlSerializer(typeof(CarList), carTypes);
               
                XmlSerializer serializer = new XmlSerializer(typeof(CarList), newCar.plugins.Values.ToArray());
                carList = (CarList)serializer.Deserialize(stream);

                stream.Close();
                newGrid();
            }
        }

        private void saveFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.InitialDirectory = "D:\\учеба\\4 семестр\\ООТПиСП\\3 лаба";
            saveFileDialog1.FileName = "newcars";
            saveFileDialog1.Filter = "Xml files (*.xml)|*.xml";

            if(saveFileDialog1.ShowDialog() == DialogResult.OK) {
                Stream stream = saveFileDialog1.OpenFile();

                //Type[] carTypes = { typeof(PeelP50), typeof(Audi), typeof(Nissan), typeof(Tesla) };

                //XmlSerializer serializer = new XmlSerializer(typeof(CarList), carTypes);

                XmlSerializer serializer = new XmlSerializer(typeof(CarList), newCar.plugins.Values.ToArray());
                serializer.Serialize(stream, carList);

                stream.Close();
            }
        }

    }
}
