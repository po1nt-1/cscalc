using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cscalc
{
    public partial class Form1 : Form
    {
        private double left_operand = 0.0;
        private string operation = "";
        private bool operation_completed = false;

        private double memory = 0.0;


        public Form1()
        {
            InitializeComponent();
        }

        private void button_number_click(object sender, EventArgs e)
        {
            string value = ((Button)sender).Text;
            
            if (operation_completed)
            {
                operation_completed = false;
                text_box.Text = "";
            }

            text_box.Text += value;
        }

        private double To_Double(string text)
        {
            try
            {
                return Convert.ToDouble(text_box.Text);
            }
            catch (System.FormatException)
            {
                return 0.0;
            }
        }

        private void button_invert_Click(object sender, EventArgs e)
        {
            double currentValue = To_Double(text_box.Text);

            currentValue = 0.0 - currentValue;
            text_box.Text = Convert.ToString(currentValue);
        }

        private void button_operation_click(object sender, EventArgs e)
        {
            if (operation == "")
            {
                left_operand = To_Double(text_box.Text);
                operation = ((Button)sender).Text;
                text_box.Text = "";
            }
        }

        private void button_equal_Click(object sender, EventArgs e)
        {
            if (operation == "+")
            {
                left_operand += To_Double(text_box.Text);
            }
            else if (operation == "-")
            {
                left_operand -= To_Double(text_box.Text);
            }
            else if (operation == "*")
            {
                left_operand *= To_Double(text_box.Text);
            }
            else if (operation == "/")
            {
                left_operand /= To_Double(text_box.Text);
            }
            else if (operation == "sqrt (x, y)")
            {
                left_operand = Math.Pow(left_operand, 1 / To_Double(text_box.Text));
            }
            else if (operation == "pow (x, y)")
            {
                left_operand = Math.Pow(left_operand, To_Double(text_box.Text));
            }

            if (operation != "")
            {
                text_box.Text = Convert.ToString(left_operand);
                operation = "";
                operation_completed = true;
            }
        }

        private void button_del_Click(object sender, EventArgs e)
        {
            text_box.Text = text_box.Text.Substring(0, text_box.Text.Length - 1);
        }

        private void button_c_Click(object sender, EventArgs e)
        {
            text_box.Text = "";
        }

        private void button_ce_Click(object sender, EventArgs e)
        {
            text_box.Text = "";
            left_operand = 0.0;
            operation = "";
            operation_completed = false;
        }

        private void button_ms_Click(object sender, EventArgs e)
        {
            memory = To_Double(text_box.Text);
        }

        private void button_mr_Click(object sender, EventArgs e)
        {
            text_box.Text = Convert.ToString(memory);
        }

        private void button_mc_Click(object sender, EventArgs e)
        {
            memory = 0.0;
        }
    }
}
