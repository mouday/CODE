using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;
namespace UDPClient
{
    public partial class frmUdp : Form
    {
        private UdpClient sendUdpClient;
        private UdpClient receiveUpdClient;
        public frmUdp()
        {
            InitializeComponent();
            IPAddress[] ips = Dns.GetHostAddresses("");
            txtLocalIp.Text = ips[3].ToString();
            int port = 51883;
            txtLocalPort.Text = port.ToString();
            txtRemoteIp.Text = ips[3].ToString();
            txtRemotePort.Text = port.ToString();
        }

        // 接受消息    
        private void btnReceive_Click(object sender, EventArgs e)
        {
            // 创建接收套接字    
            IPAddress localIp = IPAddress.Parse(txtLocalIp.Text);
            IPEndPoint localIpEndPoint = new IPEndPoint(localIp, int.Parse(txtLocalPort.Text));
            receiveUpdClient = new UdpClient(localIpEndPoint);


            Thread receiveThread = new Thread(ReceiveMessage);
            receiveThread.Start();
        }

        // 接收消息方法    
        private void ReceiveMessage()
        {
            IPEndPoint remoteIpEndPoint = new IPEndPoint(IPAddress.Any, 0);
            while (true)
            {
                try
                {
                    // 关闭receiveUdpClient时此时会产生异常    
                    byte[] receiveBytes = receiveUpdClient.Receive(ref remoteIpEndPoint);

                    string message = Encoding.Unicode.GetString(receiveBytes);

                    // 显示消息内容    
                    ShowMessageforView(listBoxView, string.Format("{0}[{1}]", remoteIpEndPoint, message));
                }
                catch
                {
                    break;
                }
            }
        }

        // 利用委托回调机制实现界面上消息内容显示    
        delegate void ShowMessageforViewCallBack(ListBox listbox, string text);
        private void ShowMessageforView(ListBox listbox, string text)
        {
            if (listbox.InvokeRequired)
            {
                ShowMessageforViewCallBack showMessageforViewCallback = ShowMessageforView;
                listbox.Invoke(showMessageforViewCallback, new object[] { listbox, text });
            }
            else
            {
                listBoxView.Items.Add(text);
                listBoxView.SelectedIndex = listBoxView.Items.Count - 1;
                listBoxView.ClearSelected();
            }
        }
        private void btnSend_Click(object sender, EventArgs e)
        {
            if (txtMessage.Text == string.Empty)
            {
                MessageBox.Show("发送内容不能为空", "提示");
                return;
            }

            // 选择发送模式    
            if (checkBox1.Checked == true)
            {
                // 匿名模式(套接字绑定的端口由系统随机分配)    
                sendUdpClient = new UdpClient(0);
            }
            else
            {
                // 实名模式(套接字绑定到本地指定的端口)    
                IPAddress localIp = IPAddress.Parse(txtLocalIp.Text);
                IPEndPoint localIpEndPoint = new IPEndPoint(localIp, int.Parse(txtLocalPort.Text));
                sendUdpClient = new UdpClient(localIpEndPoint);
            }

            Thread sendThread = new Thread(SendMessage);
            sendThread.Start(txtMessage.Text);
        }

        // 发送消息方法    
        private void SendMessage(object obj)
        {
            string message = (string)obj;
            byte[] sendbytes = Encoding.Unicode.GetBytes(message);
            IPAddress remoteIp = IPAddress.Parse(txtRemoteIp.Text);
            IPEndPoint remoteIpEndPoint = new IPEndPoint(remoteIp, int.Parse(txtRemotePort.Text));
            sendUdpClient.Send(sendbytes, sendbytes.Length, remoteIpEndPoint);

            sendUdpClient.Close();

            // 清空发送消息框    
            ResetMessageText(txtMessage);
        }

        // 采用了回调机制    
        // 使用委托实现跨线程界面的操作方式    
        delegate void ResetMessageCallback(TextBox textbox);
        private void ResetMessageText(TextBox textbox)
        {
            // Control.InvokeRequired属性代表    
            // 如果控件的处理与调用线程在不同线程上创建的，则为true,否则为false    
            if (textbox.InvokeRequired)
            {
                ResetMessageCallback resetMessagecallback = ResetMessageText;
                textbox.Invoke(resetMessagecallback, new object[] { textbox });
            }
            else
            {
                textbox.Clear();
                textbox.Focus();
            }
        }

        // 停止接收    
        private void btnStop_Click(object sender, EventArgs e)
        {
            receiveUpdClient.Close();
        }

        // 清空接受消息框    
        private void btnClear_Click(object sender, EventArgs e)
        {
            this.listBoxView.Items.Clear();
        }

        private void frmUdp_Load(object sender, EventArgs e)
        {

        }

      
    }
}   
