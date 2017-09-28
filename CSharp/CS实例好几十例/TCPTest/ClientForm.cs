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
    public partial class ClientForm : Form
    {
        private BinaryReader reader = null;
        private BinaryWriter writer = null;
        private TcpClient tcpClient = null;
        public ClientForm()
        {
            InitializeComponent();
        }
        Random random = new Random();
        private void ClientForm_Load(object sender, EventArgs e)
        {
            IPAddress[] ipAddresses = Dns.GetHostAddresses(Dns.GetHostName());                     
            //listBoxShow.Items.AddRange(ipAddresses);
            txtIPAddress.Text=ipAddresses[3].ToString();
            txtPort.Text = random.Next(1024,65536).ToString();

        }

        private void btnRequest_Click(object sender, EventArgs e)
        {
            Thread t = new Thread(Connect);
            t.Start();
            listBoxShow.Items.Add("正在连接。。。");
        }

       
        private void Connect()
        {
            IPAddress ip = IPAddress.Parse(this.txtIPAddress.Text);
            int port = int.Parse(this.txtPort.Text);
            
            tcpClient = new TcpClient();
            tcpClient.Connect(ip.ToString(), port);
            

            NetworkStream netWorkStream = tcpClient.GetStream();
            reader = new BinaryReader(netWorkStream);
            writer = new BinaryWriter(netWorkStream);
            //listBoxShow.Items.Add("已连接客户端。。。");
        }
        private void Send()
        {
            writer.Write(txtSend.Text);
            writer.Flush();
        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            listBoxShow.Items.Add(reader.ReadString());
        }

        private void btnSend_Click(object sender, EventArgs e)
        {

        }

       

    }
}
