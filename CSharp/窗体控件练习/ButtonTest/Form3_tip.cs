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
    public partial class Form3_tip : Form
    {
        public Form3_tip()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.ShowBalloonTip(1000,"当前时间",DateTime.Now.ToLocalTime().ToString(),ToolTipIcon.Info);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.notifyIcon1.Visible = false;
        }
    }
}
