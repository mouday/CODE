using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ExcelWinForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void 打开ExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Excel文件|*.xls";
            openFileDialog1.Title = "打开Excel文件";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                webBrowser1.Navigate(openFileDialog1.FileName);
            }
        }

        private void 打开百度ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            webBrowser1.Navigate("http://www.baidu.com");
        }
    }
}
