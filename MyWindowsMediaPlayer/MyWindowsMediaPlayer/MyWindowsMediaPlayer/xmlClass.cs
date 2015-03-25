using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Windows.Forms;

namespace MyWindowsMediaPlayer
{
    class xmlClass
    {
        public static bool CreateXml(string name, List<Media> it)
        {
            try
            {
                using (XmlTextWriter writer = new XmlTextWriter(@name, null))
                {
                    writer.WriteStartElement("Media");
                    foreach (Media data in it)
                    {
                        writer.WriteStartElement("Item");
                        writer.WriteElementString("uri", @data.getUri.ToString());
                        writer.WriteEndElement();
                    }
                    writer.WriteEndElement();
                    return true;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("An error occured: " + e.Message);
            }
            return false;
        }

        public static List<Media> ReadXml(string name)
        {
            List<Media> reader = new List<Media>();
            XmlDocument file = new XmlDocument();
            XmlNode uriNode;
            XmlNodeList node;

            string path;
            try
            {
                file.Load(@name);
                node = file.SelectNodes("/Media/Item");
                foreach (XmlNode actualNode in node)
                {
                    uriNode = actualNode.SelectSingleNode("uri");
                    path = uriNode.InnerText;
                    reader.Add(new Media(uriNode.InnerText));
                }
            }
            catch (XmlException e)
            {
                MessageBox.Show("An error occured in xml file: " + e.Message);
            }
            catch (Exception e)
            {
                MessageBox.Show("An error occured: " + e.Message);
            }
            return reader;
        }
    }
}
