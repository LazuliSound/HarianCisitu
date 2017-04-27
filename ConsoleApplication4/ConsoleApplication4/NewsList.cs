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
            string l = program.ParseRssFile("http://www.antaranews.com/rss/terkini");
            
            for (int i = 0; i < program.trueSize; i++)
            {
                Console.WriteLine(program.list[i].Title);
                Console.WriteLine(program.list[i].Link);
                Console.WriteLine(program.list[i].Desc);
                Console.WriteLine(program.list[i].Date);
                Console.WriteLine("");
            }
            Console.ReadKey();

        }
        private string ParseRssFile(string path)
        {
            size = 500;
            list = new News[500];
            int i = 0;
            XmlDocument rssXmlDoc = new XmlDocument();

            // Load the RSS file from the RSS URL
            rssXmlDoc.Load(path);

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

                rssSubNode = rssNode.SelectSingleNode("pubDate");
                string date = rssSubNode != null ? rssSubNode.InnerText : "";
                Debug.WriteLine(date);

                list[i] = new HarianCisitu.News(title, link, description, date);
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
        private string date;
        public News()
        {
            title = "";
            link = "";
            description = "";
        }
        public News(string title, string link, string desc, string date)
        {
            this.title = title;
            this.link = link;
            this.description = desc;
            this.date = date;
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
        public string Date
        {
            get
            {
                return this.date;
            }
            set
            {
                this.date = value;
            }
        }
    }
}
