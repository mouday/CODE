using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace MyServer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
           
        }
        NetworkStream networkStream;
        BinaryReader reader;
        BinaryWriter writer;
        TcpClient tcpClient;

        private void ConnectToServer()
        {
            try
            {
                // 调用委托    
                toolStripStatusLabel1.Text = "正在连接...";
                if (txtServerIp.Text == string.Empty || txtPort.Text == string.Empty)
                {
                    MessageBox.Show("请先输入服务器的IP地址和端口号");
                }

                IPAddress ipaddress = IPAddress.Parse(txtServerIp.Text);
                 tcpClient = new TcpClient();
                tcpClient.Connect(ipaddress, int.Parse(txtPort.Text));

                // 延时操作    
                Thread.Sleep(1000);
                if (tcpClient != null)
                {
                    toolStripStatusLabel1.Text = "连接成功";
                     networkStream = tcpClient.GetStream();
                     reader = new BinaryReader(networkStream);
                     writer = new BinaryWriter(networkStream);
                }
            }
            catch
            {
                toolStripStatusLabel1.Text = "连接失败";
                Thread.Sleep(1000);
                toolStripStatusLabel1.Text = "就绪";
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtServerIp.Text = "127.0.0.1";
            txtPort.Text = "51388";
        }


        private void btnSend_Click(object sender, EventArgs e)
        {
            Thread sendThread = new Thread(SendMessage);
            sendThread.Start(txtMessage.Text);
        }
        private void SendMessage(object state)
        {
            toolStripStatusLabel1.Text = "正在发送...";
            try
            {

                writer.Write(state.ToString());
                Thread.Sleep(5000);
                writer.Flush();
               toolStripStatusLabel1.Text = "完毕";

                txtMessage.Text= null;
                //lstbxMessageView.Invoke(showMessageCallback, state.ToString());
            }
            catch
            {
                if (reader != null)
                {
                    reader.Close();
                }
                if (writer != null)
                {
                    writer.Close();
                }
                if (tcpClient != null)
                {
                    tcpClient.Close();
                }
                toolStripStatusLabel1.Text = "断开了连接";
            }
        }

        private void btnConnect_Click_1(object sender, EventArgs e)
        {

        }

        private void btnConnect_Click_2(object sender, EventArgs e)
        {
            Thread connectThread = new Thread(ConnectToServer);
            connectThread.Start();
        }

    }
}
