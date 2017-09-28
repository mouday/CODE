using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DownLoadFtpFile
{
    public partial class Download : Form
    {
        public Download()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void btnSavePath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                txtSavePath.Text = folderBrowserDialog.SelectedPath;
            }
        }

        private void DownloadFtpFile_Load(object sender, EventArgs e)
        {
            txtHost.Text = "10.10.3.11";
            txtUserId.Text = "001read";
            txtPassword.Text = "Read%211";
            txtSavePath.Text = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);//Environment.CurrentDirectory; //
            
            txtPassword.PasswordChar = '*';
        }

        private void btnInitialize_Click(object sender, EventArgs e)
        {
            FtpClient ftpClient = new FtpClient(txtHost.Text, txtUserId.Text, txtPassword.Text);
            List<string> list = new List<string>();

            list = DownLoadFile.GetFileList(ftpClient);
            
            string filePath = Path.Combine(txtSavePath.Text,"list.txt");
            foreach (string s in list)
            {
                StreamWriter writer = new StreamWriter(filePath,true,Encoding.Default);
                writer.WriteLine(s);
                writer.Close();

            }
            //MessageBox.Show(ftpClient.CurrentDirectory);
            listBoxHistory.Items.Add(DateTime.Now.ToString()+"ok");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string s = "/drw-rw-rw-   1 user     group           0 Jun 30 09:06 安徽电信";
            string s1=DownLoadFile.GetFolderName(s);
            MessageBox.Show("|"+s1+"|");
        }
    }
}
