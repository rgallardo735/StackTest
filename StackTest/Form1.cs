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
            
            lblError.Visible = false;
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
                lblError.Text = "Error Placa";
                lblError.Visible = true;
            }
            textBox1.Text = placaout;
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            lblError.Visible = false;
            //simple verification of the date based on lenght
            if (textBox2.Text.Length != 10)
            {
                lblError.Visible = true;
                lblError.Text = "errorfecha";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            lblError.Visible = false;
            //checking if some text is in blank
            if (textBox1.Text.Length==0 || textBox2.Text.Length == 0 || textBox1.Text.Length == 0)
            {
                lblError.Visible = true;                
                lblError.Text = "error datos";
            }
            else {
                //displaying result and his default value
                lblResult.Visible = true;
                lblResult.Text = "puede circular";
                //getting the date and converting it to datetime
                DateTime datein = Convert.ToDateTime(textBox2.Text);
                //storing the name of the day as string
                String dia = "";
                dia = datein.DayOfWeek.ToString();
                //storing the plate final number as int32
                int placaNum = Int32.Parse(textBox1.Text.Substring(7, 1));                
                //reading the hour inserted, remember that "no circula" law says 5am-20pm range
                int hora = Int32.Parse(textBox3.Text.Substring(0, 2));
                if (Enumerable.Range(5, 15).Contains(hora))
                {   
                    //switch case with the day of the weeek
                    switch (dia)
                    {
                        case "Monday":
                            //checking if the last digit is the correct
                            if (Enumerable.Range(1, 2).Contains(placaNum))
                            {
                                lblResult.Text = "no circula";
                            }
                            break;
                        case "Tuesday":
                            if (Enumerable.Range(3, 2).Contains(placaNum))
                            {
                                lblResult.Text = "no circula";
                            }
                            break;
                        case "Wednesday":
                            if (Enumerable.Range(5, 2).Contains(placaNum))
                            {
                                lblResult.Text = "no circula";
                            }
                            break;
                        case "Thursday":
                            if (Enumerable.Range(7, 2).Contains(placaNum))
                            {
                                lblResult.Text = "no circula";
                            }
                            break;
                        case "Friday":
                            if (placaNum==9||placaNum==0)
                            {
                                lblResult.Text = "no circula";
                            }
                            break;
                    }
                }
            }
        }
    }
}
