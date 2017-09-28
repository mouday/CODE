using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace XmlTest
{
    class MyXml
    {
        public void CreateXmlTree(string xmlPath)
        {
            XElement xElement = new XElement(
                new XElement("BookAStore",
                    new XElement("Book",
                        new XElement("Name", "xmltest", new XAttribute("BookName", "xml")),
                        new XElement("Author", "java", new XAttribute("Name", "xml")),
                        new XElement("Adress", "上海"),
                        new XElement("Date", DateTime.Now.ToString("yyyy-mm-dd"))

                        ),
                    new XElement("Book",
                        new XElement("Name", "xmltest", new XAttribute("BookName", "xml")),
                        new XElement("Author", "java", new XAttribute("Name", "xml")),
                        new XElement("Adress", "上海"),
                        new XElement("Date", DateTime.Now.ToString("yyyy-mm-dd"))
                        )

)
                );

            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Encoding = new UTF8Encoding(false);
            settings.Indent = true;
            XmlWriter xw = XmlWriter.Create(xmlPath,settings);
            xElement.Save(xw);
            xw.Flush();
            xw.Close();
        }
    }
}
