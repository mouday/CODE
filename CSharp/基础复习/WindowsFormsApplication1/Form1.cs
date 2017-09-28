using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            Application.Exit();
        }
        int x = 10;
        int y = 10;
        private void timer1_Tick(object sender, EventArgs e)
        {
            this.label1.Top += x;
            this.label1.Left += y;
            if (this.label1.Top < 0 || this.label1.Top + this.label1.Height > this.Height)
            {
                y = -y;
            }
            if (this.label1.Left < 0 || this.label1.Left + this.label1.Width > this.Width)
            {
                x = -x;
            }
            label2.Text = "Top:" + this.label1.Top + " Left:" + this.label1.Left + " x:" + x + " y:" + y
                + "\nTop+Height: " + (this.label1.Top + this.label1.Height)
                + " Left+Width: " + (this.label1.Left + this.label1.Width)
                + "\nHeight:" + this.Height + " Width:" + this.Width;
        }

        //********************************原始代码******************************
        //int deltX = 10;
        //int deltY = 8;

        //private void timer1_Tick(object sender, System.EventArgs e)
        //{
        //    this.label1.Left += deltX;
        //    this.label1.Top += deltY;
        //    if (this.label1.Top < 0 ||this.label1.Top + this.label1.Height > this.Height)
        //        deltY = -deltY;
        //    if (this.label1.Left < 0 ||this.label1.Left + this.label1.Width > this.Width)
        //        deltX = -deltX;
        //}

        //private void Form1_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        //{
        //    Application.Exit();
        //}
        //**************************************************************
    }
}
