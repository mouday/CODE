using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DrawEllipseTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Random random = new Random();

        private Color GetRandomColor()
        {
            return Color.FromArgb(
                 random.Next(256),
                 random.Next(256),
                 random.Next(256));
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            Graphics g = this.CreateGraphics();

            int x0 = this.Width / 2;
            int y0 = this.Height / 2;

            for (int r = 0; r < this.Height / 2; r++)
            {
                g.DrawEllipse(
                    new Pen(GetRandomColor(), 1),
                    x0 - r, y0 - r, r * 2, r * 2
                    );
            }
            g.Dispose();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Graphics g = this.CreateGraphics();
            g.DrawRectangle(new Pen(GetRandomColor(),1),10,50,50,100);
            g.DrawEllipse(new Pen(Color.Red,2),100,200,50,100);
            g.Dispose();
        }
    }
}
