using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System;
using System.Text.RegularExpressions;

namespace HarianCisitu
{
    class NewsList
    {

        static void Main(string[] args)
        {
            Debug.WriteLine("tralalala");
            NewsList program = new HarianCisitu.NewsList();
            string l = program.ParseRssFile();
            Console.WriteLine(l);
            Console.ReadKey();

        }
        private string ParseRssFile()
        {
            XmlDocument rssXmlDoc = new XmlDocument();

            // Load the RSS file from the RSS URL
            rssXmlDoc.Load("http://feeds.feedburner.com/techulator/articles");

            // Parse the Items in the RSS file
            XmlNodeList rssNodes = rssXmlDoc.SelectNodes("rss/channel/item");

            StringBuilder rssContent = new StringBuilder();

            // Iterate through the items in the RSS file
            foreach (XmlNode rssNode in rssNodes)
            {
                Debug.WriteLine("");
                XmlNode rssSubNode = rssNode.SelectSingleNode("title");
                string title = rssSubNode != null ? rssSubNode.InnerText : "";
                Debug.WriteLine(title);

                rssSubNode = rssNode.SelectSingleNode("link");
                string link = rssSubNode != null ? rssSubNode.InnerText : "";
                Debug.WriteLine(link);

                rssSubNode = rssNode.SelectSingleNode("description");
                string description = rssSubNode != null ? rssSubNode.InnerText : "";
                Debug.WriteLine(description);
                

                rssContent.Append("&lt;a href='" + link + "'>" + title + "&lt;/a>&lt;br>" + description);
            }

            // Return the string that contain the RSS items
            return rssContent.ToString();
        }

    }
    class News
    {
        private string title;
        private string link;
        private string description;
        public News()
        {
            title = "";
            link = "";
            description = "";
        }
        public string Title
        {
            get
            {
                return this.title;
            }
            set
            {
                this.title = value;
            }
        }
        public string Link
        {
            get
            {
                return this.link;
            }
            set
            {
                this.link = value;
            }
        }
    }
}
