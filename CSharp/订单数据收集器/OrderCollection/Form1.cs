using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrderCollection
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        delegate void TxtLogShow(string str);
        TxtLogShow txtLogShow;

        private void btnStart_Click(object sender, EventArgs e)
        {
            txtLogShow = new TxtLogShow(logShow);
            Thread t = new Thread(Monitor);
            t.Start();
        }

        private void logShow(string str)
        {
            
            txtLog.Text += DateTime.Now + "  新订单：" + str + "\n";
            txtLog.SelectionStart = txtLog.Text.Length;
        }

        private void Monitor()
        {
            string pathServer = @"\\192.168.2.55\合同执行传单\2017年合同执行传单\华虹\8月份";
            string pathTemp = "temp.txt";
            while (true)
            {
                //读取本地文件
                if (!File.Exists(pathTemp))
                {
                    FileStream fs = File.Create(pathTemp);
                    fs.Close();
                }
                string[] filesTemp = File.ReadAllLines(pathTemp,Encoding.Default);
                HashSet<string> hashSet = new HashSet<string>();
                foreach (string file in filesTemp)
                {
                    hashSet.Add(file);
                    //MessageBox.Show(file);
                }

                //获取远程文件目录
                List<string> fileList = new List<string>();
                string[] files = Directory.GetFiles(pathServer);
                foreach (string file in files)
                {
                    fileList.Add(Path.GetFileNameWithoutExtension(file));

                }
                StreamWriter writer = new StreamWriter(pathTemp,true,Encoding.Default);
                foreach (string file in fileList)
                {
                    if (hashSet.Add(file))
                    {
                        this.Invoke(txtLogShow, file);
                        writer.WriteLine(file);
                    }
                }
                writer.Close();
                Thread.Sleep(5000);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
