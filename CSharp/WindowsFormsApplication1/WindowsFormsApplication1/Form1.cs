﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 储存UI线程的标识符
            int curThreadID = Thread.CurrentThread.ManagedThreadId;
            //MessageBox.Show(curThreadID.ToString());
            new Thread((ThreadStart)delegate()
            {
                PrintThreadLog(curThreadID);
            }).Start();
        }

        private void PrintThreadLog(int mainThreadID)
        {
            // 当前线程的标识符
            // A代码块
            int asyncThreadID = Thread.CurrentThread.ManagedThreadId;

            // 输出当前线程的扼要信息，及与UI线程的引用比对结果
            // B代码块
            label1.BeginInvoke((MethodInvoker)delegate()
            {
                // 执行BeginInvoke内的方法的线程标识符
                //Thread.Sleep(3000);
                int curThreadID = Thread.CurrentThread.ManagedThreadId;
                label1.Text = String.Format("async thread id:{0},current thread id:{1};is ui thread:{2}",
                    asyncThreadID, curThreadID, curThreadID.Equals(mainThreadID));
            });
            // 挂起当前线程3秒，模拟耗时操作
            // C代码块
            Thread.Sleep(3000);
        }

        private readonly int maxcount = 10000;
        private void button2_Click(object sender, EventArgs e)
        {
            new Thread((ThreadStart)delegate()
                {
                    for (int i = 0; i < maxcount; i++)
                    {
                        // 此处警惕值类型装箱造成的"性能陷阱"
                        listView1.Invoke((MethodInvoker)delegate()
                        {
                            listView1.Items.Add(new ListViewItem(new string[]
                                {
                                    i.ToString(),String.Format("this is {0} item",i.ToString())
                                }));
                        });
                    }
                }
            ).Start();
        }
    }
}
