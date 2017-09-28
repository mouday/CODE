using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
namespace TcpWebserver
{
    class Program
    {
        static void Main(string[] args)
        {
            // 获得本机的Ip地址，即127.0.0.1    
            IPAddress localaddress = IPAddress.Loopback;
            // 创建可以访问的断点，49155表示端口号，如果这里设置为0，表示使用一个由系统分配的空闲的端口号    
            IPEndPoint endpoint = new IPEndPoint(localaddress, 49155);
            // 创建Tcp 监听器    
            TcpListener tcpListener = new TcpListener(endpoint);
            // 启动监听    
            tcpListener.Start();
            Console.WriteLine("Wait an connect Request...");
            while (true)
            {
                // 等待客户连接    
                TcpClient client = tcpListener.AcceptTcpClient();
                if (client.Connected == true)
                {
                    // 输出已经建立连接    
                    Console.WriteLine("Created connection");
                }
                // 获得一个网络流对象    
                // 该网络流对象封装了Socket的输入和输出操作    
                // 此时通过对网络流对象进行写入来返回响应消息    
                // 通过对网络流对象进行读取来获得请求消息    
                NetworkStream netstream = client.GetStream();
                // 把客户端的请求数据读入保存到一个数组中    
                byte[] buffer = new byte[2048];
                int receivelength = netstream.Read(buffer, 0, 2048);
                string requeststring = Encoding.UTF8.GetString(buffer, 0, receivelength);

                // 在服务器端输出请求的消息    
                Console.WriteLine(requeststring);

                // 服务器端做出相应内容    
                // 响应的状态行    
                string statusLine = "HTTP/1.1 200 OK\r\n";
                byte[] responseStatusLineBytes = Encoding.UTF8.GetBytes(statusLine);
                string responseBody = "<html><head><title>Default Page</title></head><body><p style='font:bold;font-size:24pt'>Welcome you</p></body></html>";
                string responseHeader =
                    string.Format(
                        "Content-Type: text/html; charset=UTf-8\r\nContent-Length: {0}\r\n", responseBody.Length);
                byte[] responseHeaderBytes = Encoding.UTF8.GetBytes(responseHeader);
                byte[] responseBodyBytes = Encoding.UTF8.GetBytes(responseBody);

                // 写入状态行信息    
                netstream.Write(responseStatusLineBytes, 0, responseStatusLineBytes.Length);
                // 写入回应的头部    
                netstream.Write(responseHeaderBytes, 0, responseHeaderBytes.Length);
                // 写入回应头部和内容之间的空行    
                netstream.Write(new byte[] { 13, 10 }, 0, 2);

                // 写入回应的内容    
                netstream.Write(responseBodyBytes, 0, responseBodyBytes.Length);

                // 关闭与客户端的连接    
                client.Close();
                Console.ReadKey();
                break;
            }
            // 关闭服务器    
            tcpListener.Stop();
        }
    }
}

