using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FTPMonitor
{
    class Program
    {
        static void Main(string[] args)
        {
            //FtpClient ftpClient = new FtpClient("10.10.3.11", "001read", "Read%211");
            //List<string> list=ftpClient.GetFileDetails();
            //foreach (string s in list)
            //{
            //    Console.WriteLine(s);
            //}
            //Console.WriteLine();
            //Console.WriteLine("当前目录："+ftpClient.CurrentDirectory);
            //Console.WriteLine();
            ////List<string> fileList=ftpClient.GetFileList();
            ////foreach (string s in fileList)
            ////{
            ////    Console.WriteLine(s);
            ////}
            //ftpClient.RemotePath="预个人化脚本";
            //bool ret = ftpClient.Download("(更新)预个人化HHSR09-2016-030-52^030-53^030-54.zip.pgp", @"d:\(更新)预个人化HHSR09-2016-030-52^030-53^030-54.zip.pgp");
            //Console.WriteLine("下载状态："+ret);
            //Console.ReadKey();
            //1、遍历所有文件

            //2、保存所有文件

            //3、比对文件，不存在则下载，下载成功则保存到记录
            DownloadFtpFile fm = new DownloadFtpFile();
            fm.ShowDialog();

        }
    }
}
