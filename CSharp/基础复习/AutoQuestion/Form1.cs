using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AutoQuestion
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
        int a, b;
        string op;
        double result;
        private void btnNew_Click(object sender, EventArgs e)
        {
            Random r = new Random();
            a = r.Next(10) ;
            b = r.Next(10) ;
            int c = r.Next(4);
            switch (c)
            {
                case 0: op = "+"; result = a + b; break;
                case 1: op = "-"; result = a - b; break;
                case 2: op = "*"; result = a * b; break;
                case 3: op = "/"; if (b == 0) b = 1; result = a / b; break;              
            }
            label1.Text = a.ToString() + op + b.ToString() + "=";
        }

        private void btnJudge_Click(object sender, EventArgs e)
        {
            double d = double.Parse(txtResult.Text);
            string disp=label1.Text+d.ToString();
            if( Math.Abs(d-result)< 1e-3 )//0.001if (d == result)//
            {
                disp += "☆";
            }
            else
            {
                disp += "×";
            }
            disp += "  "+result;
            listBox1.Items.Add(disp);
        }
    }
}
