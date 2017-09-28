using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Text.RegularExpressions;
namespace NetTest
{
    class Html
    {
        private string _url;
        private string _pageHtml;

        public string PageHtml
        {
            get { return _pageHtml; }
            set { _pageHtml = value; }
        }
        public string Url
        {
            get { return _url; }
            set { _url = value; }
        }
        public Html(string url)
        {
            this.Url = url;
            WebClient webClient = new WebClient();
            byte[] pageData = webClient.DownloadData(Url);
            PageHtml = Encoding.UTF8.GetString(pageData);
        }
        public string GetHtml()
        {            
            return PageHtml;
        }
        public string GetTitle()
        {
            string pattern = @"<title>.*</title>";
            Regex reg = new Regex(pattern);
            Match match = reg.Match(PageHtml);
            return match.Groups[0].Value;
        }
        public void DownLoadFile(string address,string filename)
        {
            WebClient webClient=new WebClient();
            webClient.DownloadFile(address, filename);
        }
    }
}
