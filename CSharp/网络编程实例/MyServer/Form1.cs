using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
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
        TcpListener tcpLister;
        TcpClient tcpClient;
        NetworkStream networkStream;
        BinaryReader reader;
        BinaryWriter writer;

        private void btnListener_Click(object sender, EventArgs e)
        {
            IPAddress ipaddress = IPAddress.Parse("127.0.0.1");
            int  Port =51388;
              
           tcpLister = new TcpListener(ipaddress,Port);    
           tcpLister.Start();    
           // 启动一个线程来接受请求    
           Thread acceptThread =new Thread(acceptClientConnect);    
           acceptThread.Start();    
       }    
   
       // 接受请求    
       private void acceptClientConnect()    
       {    
           toolStripStatusLabel1.Text ="正在监听";    
           Thread.Sleep(1000);    
           try   
           {    
               toolStripStatusLabel1.Text ="等待连接";    
               tcpClient = tcpLister.AcceptTcpClient();    
               if (tcpLister != null)    
               {
                   toolStripStatusLabel1.Text = "接受到连接";    
                   networkStream = tcpClient.GetStream();    
                   reader = new BinaryReader(networkStream);    
                   writer = new BinaryWriter(networkStream);    
               }    
           }    
           catch   
           {    
               toolStripStatusLabel1.Text = "停止监听";    
               Thread.Sleep(1000);    
              toolStripStatusLabel1.Text = "就绪";    
           }    
       }

       private void button3_Click(object sender, EventArgs e)
       {
           string readerString;
           while (true)
           {
               txtView.Text = reader.ReadString();
               Thread.Sleep(1000);
           }
       }   
        
        
    }
}
