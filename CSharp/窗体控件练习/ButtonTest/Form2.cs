using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace ButtonTest
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            txtHost.Text = "192.168.3.42";
            
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                IPAddress[] ip = Dns.GetHostAddresses(Dns.GetHostName());
                string message = "hello world!";
                TcpClient client = new TcpClient(txtHost.Text,90);
                NetworkStream netStream = client.GetStream();
                StreamWriter writer = new StreamWriter(netStream, Encoding.Default);
                writer.Write(message);
                writer.Flush();
                writer.Close();
                client.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            StartListen();
        }

        private void StartListen()
        {
            TcpListener tcpListener=new TcpListener(90);
            tcpListener.Start();
            while(true)
            {
                TcpClient tcpClient=tcpListener.AcceptTcpClient();
                NetworkStream netStream = tcpClient.GetStream();
                byte[] mbyte=new byte[1024];
                int i = netStream.Read(mbyte,0,mbyte.Length);
                string message = Encoding.Default.GetString(mbyte,0,i);
                MessageBox.Show(message);
                Application.DoEvents();
            }
        }
    }
}
