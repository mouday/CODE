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

namespace TCPTest
{
    public partial class ServerForm : Form
    {
        private BinaryReader reader = null;
        private BinaryWriter writer = null;
        private TcpListener tcpListener = null;
        public ServerForm()
        {
            InitializeComponent();
        }
        Random random = new Random();
        private void ServerForm_Load(object sender, EventArgs e)
        {
            IPAddress[] ipAddresses = Dns.GetHostAddresses(Dns.GetHostName());                     
            //listBoxShow.Items.AddRange(ipAddresses);
            txtIPAddress.Text=ipAddresses[3].ToString();
            txtPort.Text = random.Next(1024,65536).ToString();

        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            this.Server();
        }

       
        private void Server()
        {
            IPAddress ip = IPAddress.Parse(txtIPAddress.Text);
            int port = int.Parse(txtPort.Text);
            
            tcpListener = new TcpListener(ip,port);
            tcpListener.Start();
            listBoxShow.Items.Add("监听启动。。。");
            
        }
        private void AcceptClient()
        {
            if (tcpListener == null) return;
            TcpClient tcpClient = tcpListener.AcceptTcpClient();
            NetworkStream netWorkStream = tcpClient.GetStream();
            reader = new BinaryReader(netWorkStream);
            writer = new BinaryWriter(netWorkStream);
            //listBoxShow.Items.Add("已连接客户端。。。");
        }
       

        private void btnRead_Click(object sender, EventArgs e)
        {
            listBoxShow.Items.Add(reader.ReadString());
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            this.AcceptClient();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Server();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Thread t = new Thread(AcceptClient);
           t.Start();
           listBoxShow.Items.Add("已连接客户端。。。");
        }

    }
}
