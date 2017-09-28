using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace NetTest
{
    class MyRequest
    {
        public static string DownloadString(string url)
        {
            HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
            request.Credentials = CredentialCache.DefaultCredentials;
            HttpWebResponse response = request.GetResponse() as HttpWebResponse;

            Stream responseStream = response.GetResponseStream();
            Encoding encoding = Encoding.UTF8; //Encoding.Default;
            StreamReader reader = new StreamReader(responseStream, encoding);
            string str = reader.ReadToEnd();
            reader.Close();
            responseStream.Close();
            response.Close();
            return str;
        }
    }
}
