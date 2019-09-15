using CarInterface;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CitroenC5
{
    public partial class Form1 : Form
    {
        private readonly ICarInt plugin;

        public Form1(ICarInt plugin)
        {
            InitializeComponent();
            this.plugin = plugin;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.textBox1.AppendText("Type: " + plugin.PluginName + "\r\n");
            this.textBox1.AppendText("Description: " + plugin.PluginDescription + "\r\n");
        }
    }
}

