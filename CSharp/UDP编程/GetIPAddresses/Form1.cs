using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace GetIPAddresses
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            IPAddress[] ipAddresses = Dns.GetHostAddresses("");
            int i = 0;
            foreach (IPAddress ipAddress in ipAddresses)
            {
                
                listBox1.Items.Add("【"+i+"】"+ipAddress);
                i++;
            }
        }
    }
}
