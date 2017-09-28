using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;


namespace NetTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Html html = new Html(txtNetAddress.Text);
            //richTextBox1.Text = html.GetHtml();
            //string path = Path.Combine(txtSave.Text, "html.txt");
            //File.WriteAllText(path, richTextBox1.Text);
            //richTextBox1.Text = html.GetTitle();
            //richTextBox1.Text = MyRequest.DownloadString(txtNetAddress.Text);
            html.DownLoadFile(@"http://www.ppt123.net/beijing/UploadFiles_8374/201201/2012011410364885.gif", @"D:\Code\网络编程实例\1.gif");
            MessageBox.Show("ok!");
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                txtSave.Text = folderBrowserDialog.SelectedPath;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //txtSave.Text = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            txtSave.Text = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            txtNetAddress.Text = "https://www.baidu.com/";
        }
    }
}
