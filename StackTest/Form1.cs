using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StackTest
{
    public partial class Form1 : Form
    {
        public String placa="";
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            
            label3.Visible = false;
            //for visual aspects we'll give the plate a format
            placa = textBox1.Text;
            String placaout = "";
            //checking if the user entered an old plate or a new one (based on digts)
            if (placa.Length == 7)
            {
                placaout = new StringBuilder().Append(placa.Substring(0, 3)).Append("-").Append(placa.Substring(3, 4)).ToString();
            }
            else if (placa.Length == 6)
            {
                placaout = new StringBuilder().Append(placa.Substring(0, 3)).Append("-").Append("0").Append(placa.Substring(3, 3)).ToString();
            }//instead of throwing an error well delete the text and show a label
            else {
                placaout = "";
                label3.Text = "Error Placa";
                label3.Visible = true;
            }
            textBox1.Text = placaout;
        }
    }
}
