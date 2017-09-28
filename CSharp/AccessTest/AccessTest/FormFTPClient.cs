using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AccessTest
{
    public partial class FormFTPClient : Form
    {
        public FormFTPClient()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int strRemotePort = 21;
            Boolean bConnected;
            string RemoteHost = "ftp://10.10.3.11";
            string RemotePass = "Read%211";
            string RemoteUser = "001read";
            string RemotePath = "";
            //FTPClient ftpClient = new FTPClient(strRemoteHost, strRemotePath, strRemoteUser, strRemotePass, strRemotePort);
            //string[] list = ftpClient.Dir("预个人化脚本");
            //FTPHelper ftp = new FTPHelper(RemoteHost,RemotePath,RemoteUser,RemotePass);

            FtpWeb ftp = new FtpWeb(RemoteHost, RemoteUser,RemotePass);
            string[] list = ftp.GetFileList("预个人化脚本");
            int i = 0;
            foreach (string s in list)
            {
                i++;
                listBox1.Items.Add(s);
            }
            //MessageBox.Show(list[0].Replace(" ","").ToString());
        }
    }
}
