using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Text.RegularExpressions;
using SearchAlgorithm;

namespace HarianCisitu
{
    class NewsList
    {
        private News[] list;
        private const int DEF_SIZE = 500;
        private int trueSize;

        public News NewsIdx(int idx)
        {
            return list[idx];
        }
        public News[] List
        {
            get
            {
                return this.list;
            }
        }

        public int Size
        {
            get
            {
                return this.trueSize;
            }
        }

        static void Main(string[] args)
        {
            Debug.WriteLine("tralalala");
            NewsList program = new HarianCisitu.NewsList();
            string l = program.ParseRssFile("http://rss.vivanews.com/get/all");
            
            for (int k = 0; k < program.trueSize; k++)
            {
                Console.WriteLine(program.list[k].Title);
                Console.WriteLine(program.list[k].Link);
                Console.WriteLine(program.list[k].Desc);
                Console.WriteLine(program.list[k].Date);
                Console.WriteLine("");
            }
            Console.WriteLine("");
            BM kmp = new SearchAlgorithm.BM();
            News[] found = kmp.SearchBM("kan", program);
            int i = 0;
            while (found[i] != null)
            {
                Console.WriteLine(found[i].Title);
                Console.WriteLine(found[i].Desc);
                Console.WriteLine("");
                i++;
            }
            Console.ReadKey();

        }
        private string ParseRssFile(string path)
        {
            list = new News[DEF_SIZE];
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
