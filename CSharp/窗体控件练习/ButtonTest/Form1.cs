using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ButtonTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            button1.ForeColor = Color.Red;
            button2.FlatStyle = FlatStyle.Flat;
            button3.ForeColor = Color.Blue;
            button4.ForeColor = DefaultForeColor;
            button4.FlatStyle = FlatStyle.Popup;
            button5.FlatStyle = FlatStyle.Standard;
            button6.FlatStyle = FlatStyle.System;
            button6.Font = new Font("隶书",12);
            button6.AutoSize = true;
            button6.Text = "这个按钮可自适应文本长度&A";
            ShowInTaskbar = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            MessageBox.Show("button6_alt+a");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("button1_esc");
        }

        private void button7_MouseEnter(object sender, EventArgs e)
        {
            button7.Font = new Font("隶书",18);
            button7.Width = 260;
            button7.Height = 80;
            button7.Location = new Point((Width-button7.Width)/2,(ClientRectangle.Height-button7.Height)/2);
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            //Button btn = new Button()
            //{
            //    Text = "新的按钮",
            //    ForeColor = Color.Green,
            //    //ForeColor = Color.FromArgb();
            //    AutoSize = true,
            //    Location = e.Location
            //};
            //Controls.Add(btn);

            TextBox txt = new TextBox()
            {
                Text = "new text",
                ForeColor = Color.Red,
                Width=200,
                Location = e.Location
            };
            Controls.Add(txt);
        }
    }
}
