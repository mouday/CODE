using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DownLoadFtpFile
{
    class DownLoadFile
    {
        public static List<string> GetFileList(FtpClient ftpClient)
        {
            HashSet<string> hashSet = new HashSet<string>();

            List<string> listDrictory = new List<string>();
            List<string> listFile = new List<string>();
            List<string> listDetails = new List<string>();
            List<string> list = new List<string>();
            ftpClient.RemotePath = "/微工厂/个人化";
            //listDetails = ftpClient.GetFileDetails();
           
             listFile = ftpClient.GetFileList();
               
          
            //筛选出目录
            //保存当前目录下的文件列表
            foreach (string file in listFile)
            {

                list.Add(ftpClient.RemotePath + file);
            }

            foreach (string Details in listDetails)
            {
                if (!listFile.Contains(Details)) listDrictory.Add(Details);
            }

            foreach (string drictory in listDrictory)
            {
                ftpClient.RemotePath = "/" + drictory;
                //GetFileList(ftpClient);
            }
            return list;

        }
        public static string GetFolderName(string str)
        {
            string folderName = str.Substring(str.LastIndexOf(' ')+1);
            return folderName;
        }



    }
}
