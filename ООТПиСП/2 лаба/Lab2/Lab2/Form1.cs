using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab2
{
    public partial class Form1 : Form
    {
        Lab1.Car car;
        public Form1()
        {
            InitializeComponent();
        }

        public PictureBox getBox()
        {
            return box;
        }

        private void button2_Click(object sender, EventArgs e)
        {   
            car = new Lab1.Audi();
            box.Image = car.draw();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            car = new Lab1.Nissan();
            box.Image = car.draw();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            car = new Lab1.PeelP50();
            box.Image = car.draw();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            car = new Lab1.Tesla();
            box.Image = car.draw();
        }

    }
}
