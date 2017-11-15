using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calc
{
    public partial class Form1 : Form
    {
        private string calculation;
        private bool finished = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (finished) {
                textBox1.Text = "";
                finished = false;
            }
            appendText(1);
        }

        private void buttonPlus_Click(object sender, EventArgs e)
        {
            calculation = calculation + textBox1.Text + "+";
            textBox1.Text = "";
        }

        private void appendText(int number)
        {
            textBox1.Text = textBox1.Text + number.ToString();
        }

        private void buttonEquals_Click(object sender, EventArgs e)
        {
            calculation = calculation + textBox1.Text;
            textBox1.Text = new DataTable().Compute(calculation, null).ToString();
            calculation = "";
            finished = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (finished)
            {
                textBox1.Text = "";
                finished = false;
            }
            appendText(2);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (finished)
            {
                textBox1.Text = "";
                finished = false;
            }
            appendText(3);
        }

        private void buttonMin_Click(object sender, EventArgs e)
        {
            calculation = calculation + textBox1.Text + "-";
            textBox1.Text = "";
        }
    }
}
