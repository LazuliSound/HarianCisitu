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
        public News[] list;
        private int size;
        public int trueSize;

        static void Main(string[] args)
        {
            Debug.WriteLine("tralalala");
            NewsList program = new HarianCisitu.NewsList();
            string l = program.ParseRssFile();
            
            for (int i = 0; i < program.trueSize; i++)
            {
                Console.WriteLine(program.list[i].Title);
                Console.WriteLine(program.list[i].Link);
                Console.WriteLine(program.list[i].Desc);
                Console.WriteLine("");
            }
            Console.ReadKey();

        }
        private string ParseRssFile()
        {
            size = 100;
            list = new News[100];
            int i = 0;
            XmlDocument rssXmlDoc = new XmlDocument();

            // Load the RSS file from the RSS URL
            rssXmlDoc.Load("http://rss.detik.com/index.php/detikcom");

            // Parse the Items in the RSS file
            XmlNodeList rssNodes = rssXmlDoc.SelectNodes("rss/channel/item");

            StringBuilder rssContent = new StringBuilder();

            // Iterate through the items in the RSS file
            foreach (XmlNode rssNode in rssNodes)
            {
                Debug.WriteLine("");
                XmlNode rssSubNode = rssNode.SelectSingleNode("title");
                string title = rssSubNode != null ? rssSubNode.InnerText : "";

                rssSubNode = rssNode.SelectSingleNode("link");
                string link = rssSubNode != null ? rssSubNode.InnerText : "";

                rssSubNode = rssNode.SelectSingleNode("description");
                string description = rssSubNode != null ? rssSubNode.InnerText : "";
                list[i] = new HarianCisitu.News(title, link, description);
                i++;
                rssContent.Append("&lt;a href='" + link + "'>" + title + "&lt;/a>&lt;br>" + description);
            }
            trueSize = i;

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
        public News(string title, string link, string desc)
        {
            this.title = title;
            this.link = link;
            this.description = desc;
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
        public string Desc
        {
            get
            {
                return this.description;
            }
            set
            {
                this.description = value;
            }
        }
    }
}
