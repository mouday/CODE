using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FTPMonitor
{
    public partial class DownloadFtpFile : Form
    {
        public DownloadFtpFile()
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

        }
    }
}
