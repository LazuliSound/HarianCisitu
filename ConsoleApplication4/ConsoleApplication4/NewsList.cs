using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Text.RegularExpressions;
using SearchAlgorithm;
using mshtml;
//using System.Windows.Forms;
using HtmlAgilityPack;
using System.Net;

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

        public static String parseDetikKMP(string url)
        {
            WebClient W = new WebClient();
            string page = W.DownloadString(url);
            int idx = KMP.kmpMatch(page, "detikdetailtext");
            if (idx < 0)
            {
                idx = KMP.kmpMatch(page, "p-artikel");
                if(idx < 0)
                {
                    Console.WriteLine("isi berita tidak ditemukan1");
                }
                else
                {
                    page = page.Substring(idx);
                }
            }
            else
                page = page.Substring(idx);
            idx = KMP.kmpMatch(page, "<!-- POLONG");
            if (idx < 0) Console.WriteLine("isi berita tidak ditemukan2");
            else
                page = page.Substring(0, idx);
            idx = KMP.kmpMatch(page, "</p>") + 4;
            if (idx < 0) Console.WriteLine("isi berita tidak ditemukan3");
            else
                page = page.Substring(idx);
            idx = KMP.kmpMatch(page, "<br />");
            while (idx != -1)
            {
                string front, end;
                front = page.Substring(0, idx);
                end = page.Substring(idx + 6);
                page = front + end;
                idx = KMP.kmpMatch(page, "<br />");
            }
            idx = KMP.kmpMatch(page, "<br/>");
            if (idx < 0) Console.WriteLine("isi berita tidak ditemukan4");
            else
                page = page.Substring(0, idx);
            
            //isx = KMP.kmpMatch(page, )

            return page;
        }

        public static String parseDetikBM(string url)
        {
            WebClient W = new WebClient();
            string page = W.DownloadString(url);
            int idx = BM.bmMatch(page, "detikdetailtext");
            if (idx < 0)
            {
                idx = BM.bmMatch(page, "p-artikel");
                if (idx < 0)
                {
                    Console.WriteLine("isi berita tidak ditemukan");
                }
                else
                {
                    page = page.Substring(idx);
                }
            }
            else
                page = page.Substring(idx);
            idx = BM.bmMatch(page, "<!-- POLONG");
            if (idx < 0) Console.WriteLine("isi berita tidak ditemukan");
            else
                page = page.Substring(0, idx);
            idx = BM.bmMatch(page, "</p>") + 4;
            if (idx < 0) Console.WriteLine("isi berita tidak ditemukan");
            else
                page = page.Substring(idx);
            idx = BM.bmMatch(page, "<br />");
            while (idx != -1)
            {
                string front, end;
                front = page.Substring(0, idx);
                end = page.Substring(idx + 6);
                page = front + end;
                idx = BM.bmMatch(page, "<br />");
            }
            idx = BM.bmMatch(page, "<br/>");
            if (idx < 0) Console.WriteLine("isi berita tidak ditemukan");
            else
                page = page.Substring(0, idx);

            return page;
        }

        public static String parseDetikRegex(string url)
        {
            WebClient W = new WebClient();
            string page = W.DownloadString(url);
            int idx = RegexC.regexMatch(page, "detikdetailtext");
            if (idx < 0)
            {
                idx = RegexC.regexMatch(page, "p-artikel");
                if (idx < 0)
                {
                    Console.WriteLine("isi berita tidak ditemukan1");
                }
                else
                {
                    page = page.Substring(idx);
                }
            }
            else
                page = page.Substring(idx);
            idx = RegexC.regexMatch(page, "<!-- POLONG");
            if (idx < 0) Console.WriteLine("isi berita tidak ditemukan2");
            else
                page = page.Substring(0, idx);
            idx = RegexC.regexMatch(page, "</p>") + 4;
            if (idx < 0) Console.WriteLine("isi berita tidak ditemukan3");
            else
                page = page.Substring(idx);
            idx = RegexC.regexMatch(page, "<br />");
            while (idx != -1)
            {
                string front, end;
                front = page.Substring(0, idx);
                end = page.Substring(idx + 6);
                page = front + end;
                idx = RegexC.regexMatch(page, "<br />");
            }
            idx = RegexC.regexMatch(page, "<br/>");
            if (idx < 0) Console.WriteLine("isi berita tidak ditemukan4");
            else
                page = page.Substring(0, idx);

            return page;
        }

        public static String parseTempoKMP(string url)
        {
            WebClient W = new WebClient();
            string page = W.DownloadString(url);
            int idx = KMP.kmpMatch(page, "666666") + 6;
            if (idx < 0)
            {
                idx = KMP.kmpMatch(page, "p-artikel");
                if(idx >= 0){
                    page = page.Substring(idx);
                }
                else
                Console.WriteLine("isi berita tidak ditemukan1");
            }
            else
            {
                page = page.Substring(idx);
                idx = KMP.kmpMatch(page, "666666") + 6;
                if (idx < 0) Console.WriteLine("isi berita tidak ditemukan2");
                else
                    page = page.Substring(idx);
            }
            idx = KMP.kmpMatch(page, "</span>") + 10;
            if (idx < 0) Console.WriteLine("isi berita tidak ditemukan3");
            else
                page = page.Substring(idx);
            idx = KMP.kmpMatch(page, "<!-- end artikel");
            if (idx < 0) Console.WriteLine("isi berita tidak ditemukan4");
            else
                page = page.Substring(0, idx);
            idx = KMP.kmpMatch(page, "<br />");
            while(idx != -1)
            {
                string front = page.Substring(0, idx);
                string end = page.Substring(idx+6);
                page = front + end;
                idx = KMP.kmpMatch(page, "<br />");
            }
            idx = KMP.kmpMatch(page, "<em>");
            while (idx != -1)
            {
                string front = page.Substring(0, idx);
                string end = page.Substring(idx + 4);
                page = front + end;
                idx = KMP.kmpMatch(page, "<em>");
            }
            idx = KMP.kmpMatch(page, "</em>");
            while (idx != -1)
            {
                string front = page.Substring(0, idx);
                string end = page.Substring(idx + 5);
                page = front + end;
                idx = KMP.kmpMatch(page, "</em>");
            }
            idx = KMP.kmpMatch(page, "</a>");
            while (idx != -1)
            {
                string front = page.Substring(0, idx);
                string end = page.Substring(idx + 4);
                page = front + end;
                idx = KMP.kmpMatch(page, "</a>");
            }
            idx = KMP.kmpMatch(page, "</p>");
            while (idx != -1)
            {
                string front = page.Substring(0, idx);
                string end = page.Substring(idx + 4);
                page = front + end;
                idx = KMP.kmpMatch(page, "</p>");
            }


            return page;
        }

        public static String parseTempoBM(string url)
        {
            WebClient W = new WebClient();
            string page = W.DownloadString(url);
            int idx = BM.bmMatch(page, "666666") + 6;
            if (idx < 0)
            {
                idx = BM.bmMatch(page, "p-artikel");
                if (idx >= 0)
                {
                    page = page.Substring(idx);
                }
                else
                Console.WriteLine("isi berita tidak ditemukan");
            }
            else
            {
                page = page.Substring(idx);
                idx = BM.bmMatch(page, "666666") + 6;
                if (idx < 0) Console.WriteLine("isi berita tidak ditemukan");
                else
                    page = page.Substring(idx);
            }
            idx = BM.bmMatch(page, "</span>") + 10;
            if (idx < 0) Console.WriteLine("isi berita tidak ditemukan");
            else
                page = page.Substring(idx);
            idx = BM.bmMatch(page, "<!-- end artikel");
            if (idx < 0) Console.WriteLine("isi berita tidak ditemukan");
            else
                page = page.Substring(0, idx);
            idx = BM.bmMatch(page, "<br />");
            while (idx != -1)
            {
                string front = page.Substring(0, idx);
                string end = page.Substring(idx + 6);
                page = front + end;
                idx = BM.bmMatch(page, "<br />");
            }
            idx = BM.bmMatch(page, "<em>");
            while (idx != -1)
            {
                string front = page.Substring(0, idx);
                string end = page.Substring(idx + 4);
                page = front + end;
                idx = BM.bmMatch(page, "<em>");
            }
            idx = BM.bmMatch(page, "</em>");
            while (idx != -1)
            {
                string front = page.Substring(0, idx);
                string end = page.Substring(idx + 5);
                page = front + end;
                idx = BM.bmMatch(page, "</em>");
            }
            idx = BM.bmMatch(page, "</a>");
            while (idx != -1)
            {
                string front = page.Substring(0, idx);
                string end = page.Substring(idx + 4);
                page = front + end;
                idx = BM.bmMatch(page, "</a>");
            }
            idx = BM.bmMatch(page, "</p>");
            while (idx != -1)
            {
                string front = page.Substring(0, idx);
                string end = page.Substring(idx + 4);
                page = front + end;
                idx = BM.bmMatch(page, "</p>");
            }

            return page;
        }

        public static String parseTempoRegex(string url)
        {
            WebClient W = new WebClient();
            string page = W.DownloadString(url);
            int idx = RegexC.regexMatch(page, "666666") + 6;
            if (idx < 0)
            {
                idx = RegexC.regexMatch(page, "p-artikel");
                if (idx >= 0)
                {
                    page = page.Substring(idx);
                }
                else
                Console.WriteLine("isi berita tidak ditemukan1");
            }
            else
            {
                page = page.Substring(idx);
                idx = RegexC.regexMatch(page, "666666") + 6;
                if (idx < 0) Console.WriteLine("isi berita tidak ditemukan2");
                else
                    page = page.Substring(idx);
            }
            idx = RegexC.regexMatch(page, "</span>") + 10;
            if (idx < 0) Console.WriteLine("isi berita tidak ditemukan");
            else
                page = page.Substring(idx);
            idx = RegexC.regexMatch(page, "<!-- end artikel");
            if (idx < 0) Console.WriteLine("isi berita tidak ditemukan");
            else
                page = page.Substring(0, idx);
            idx = RegexC.regexMatch(page, "<br />");
            while (idx != -1)
            {
                string front = page.Substring(0, idx);
                string end = page.Substring(idx + 6);
                page = front + end;
                idx = RegexC.regexMatch(page, "<br />");
            }
            idx = RegexC.regexMatch(page, "<em>");
            while (idx != -1)
            {
                string front = page.Substring(0, idx);
                string end = page.Substring(idx + 4);
                page = front + end;
                idx = RegexC.regexMatch(page, "<em>");
            }
            idx = RegexC.regexMatch(page, "</em>");
            while (idx != -1)
            {
                string front = page.Substring(0, idx);
                string end = page.Substring(idx + 5);
                page = front + end;
                idx = RegexC.regexMatch(page, "</em>");
            }
            idx = RegexC.regexMatch(page, "</a>");
            while (idx != -1)
            {
                string front = page.Substring(0, idx);
                string end = page.Substring(idx + 4);
                page = front + end;
                idx = RegexC.regexMatch(page, "</a>");
            }
            idx = RegexC.regexMatch(page, "</p>");
            while (idx != -1)
            {
                string front = page.Substring(0, idx);
                string end = page.Substring(idx + 4);
                page = front + end;
                idx = RegexC.regexMatch(page, "</p>");
            }

            return page;
        }

        public static string parseAntaraKMP(string url)
        {
            WebClient W = new WebClient();
            string page = W.DownloadString(url);
            int idx = KMP.kmpMatch(page, "content_news") + 20;
            if (idx < 0) Console.WriteLine("isi berita tidak ditemukan");
            else
                page = page.Substring(idx);
            idx = KMP.kmpMatch(page, "mt10") - 10;
            if (idx < 0) Console.WriteLine("isi berita tidak ditemukan");
            else
                page = page.Substring(0,idx);
            idx = KMP.kmpMatch(page, "<br>");
            while (idx != -1)
            {
                string front = page.Substring(0, idx);
                string end = page.Substring(idx + 4);
                page = front + end;
                idx = KMP.kmpMatch(page, "<br>");
            }
            return page;
        }

        public static string parseAntaraBM(string url)
        {
            WebClient W = new WebClient();
            string page = W.DownloadString(url);
            int idx = BM.bmMatch(page, "content_news") + 20;
            if (idx < 0) Console.WriteLine("isi berita tidak ditemukan");
            else
                page = page.Substring(idx);
            idx = BM.bmMatch(page, "mt10") - 10;
            if (idx < 0) Console.WriteLine("isi berita tidak ditemukan");
            else
                page = page.Substring(0, idx);
            idx = BM.bmMatch(page, "<br>");
            while (idx != -1)
            {
                string front = page.Substring(0, idx);
                string end = page.Substring(idx + 4);
                page = front + end;
                idx = BM.bmMatch(page, "<br>");
            }
            return page;
        }

        public static string parseAntaraRegex(string url)
        {
            WebClient W = new WebClient();
            string page = W.DownloadString(url);
            int idx = RegexC.regexMatch(page, "content_news") + 20;
            if (idx < 0) Console.WriteLine("isi berita tidak ditemukan");
            else
                page = page.Substring(idx);
            idx = RegexC.regexMatch(page, "mt10") - 10;
            if (idx < 0) Console.WriteLine("isi berita tidak ditemukan");
            else
                page = page.Substring(0, idx);
            idx = RegexC.regexMatch(page, "<br>");
            while (idx != -1)
            {
                string front = page.Substring(0, idx);
                string end = page.Substring(idx + 4);
                page = front + end;
                idx = RegexC.regexMatch(page, "<br>");
            }
            return page;
        }

        public static string parseVivaKMP(string url)
        {
            WebClient W = new WebClient();
            string page = W.DownloadString(url);
            int idx = KMP.kmpMatch(page, "article-content");
            if (idx < 0) Console.WriteLine("isi berita tidak ditemukan");
            else
                page = page.Substring(idx);
            idx = KMP.kmpMatch(page, "description");
            if (idx < 0) Console.WriteLine("isi berita tidak ditemukan");
            else
                page = page.Substring(idx);
            idx = KMP.kmpMatch(page, "<p>")+3;
            if (idx < 0) Console.WriteLine("isi berita tidak ditemukan");
            else
                page = page.Substring(idx);
            idx = KMP.kmpMatch(page, "</span>");
            if (idx < 0) Console.WriteLine("isi berita tidak ditemukan");
            else
                page = page.Substring(0,idx);
            idx = KMP.kmpMatch(page, "<p>");
            while (idx != -1)
            {
                string front = page.Substring(0, idx);
                string end = page.Substring(idx + 3);
                page = front + end;
                idx = KMP.kmpMatch(page, "<p>");
            }
            idx = KMP.kmpMatch(page, "</p>");
            while (idx != -1)
            {
                string front = page.Substring(0, idx);
                string end = page.Substring(idx + 4);
                page = front + end;
                idx = KMP.kmpMatch(page, "</p>");
            }
            idx = KMP.kmpMatch(page, "<em>");
            while (idx != -1)
            {
                string front = page.Substring(0, idx);
                string end = page.Substring(idx + 4);
                page = front + end;
                idx = KMP.kmpMatch(page, "<em>");
            }
            idx = KMP.kmpMatch(page, "</em>");
            while (idx != -1)
            {
                string front = page.Substring(0, idx);
                string end = page.Substring(idx + 5);
                page = front + end;
                idx = KMP.kmpMatch(page, "</em>");
            }

            return page;
        }

        public static string parseVivaBM(string url)
        {
            WebClient W = new WebClient();
            string page = W.DownloadString(url);
            int idx = BM.bmMatch(page, "article-content");
            if (idx < 0) Console.WriteLine("isi berita tidak ditemukan");
            else
                page = page.Substring(idx);
            idx = BM.bmMatch(page, "description");
            if (idx < 0) Console.WriteLine("isi berita tidak ditemukan");
            else
                page = page.Substring(idx);
            idx = BM.bmMatch(page, "<p>") + 3;
            if (idx < 0) Console.WriteLine("isi berita tidak ditemukan");
            else
                page = page.Substring(idx);
            idx = BM.bmMatch(page, "</span>");
            if (idx < 0) Console.WriteLine("isi berita tidak ditemukan");
            else
                page = page.Substring(0, idx);
            idx = BM.bmMatch(page, "<p>");
            while (idx != -1)
            {
                string front = page.Substring(0, idx);
                string end = page.Substring(idx + 3);
                page = front + end;
                idx = BM.bmMatch(page, "<p>");
            }
            idx = BM.bmMatch(page, "</p>");
            while (idx != -1)
            {
                string front = page.Substring(0, idx);
                string end = page.Substring(idx + 4);
                page = front + end;
                idx = BM.bmMatch(page, "</p>");
            }
            idx = BM.bmMatch(page, "<em>");
            while (idx != -1)
            {
                string front = page.Substring(0, idx);
                string end = page.Substring(idx + 4);
                page = front + end;
                idx = BM.bmMatch(page, "<em>");
            }
            idx = BM.bmMatch(page, "</em>");
            while (idx != -1)
            {
                string front = page.Substring(0, idx);
                string end = page.Substring(idx + 5);
                page = front + end;
                idx = BM.bmMatch(page, "</em>");
            }

            return page;
        }

        public static string parseVivaRegex(string url)
        {
            WebClient W = new WebClient();
            string page = W.DownloadString(url);
            int idx = RegexC.regexMatch(page, "article-content");
            if (idx < 0) Console.WriteLine("isi berita tidak ditemukan");
            else
                page = page.Substring(idx);
            idx = RegexC.regexMatch(page, "description");
            if (idx < 0) Console.WriteLine("isi berita tidak ditemukan");
            else
                page = page.Substring(idx);
            idx = RegexC.regexMatch(page, "<p>") + 3;
            if (idx < 0) Console.WriteLine("isi berita tidak ditemukan");
            else
                page = page.Substring(idx);
            idx = RegexC.regexMatch(page, "</span>");
            if (idx < 0) Console.WriteLine("isi berita tidak ditemukan");
            else
                page = page.Substring(0, idx);
            idx = RegexC.regexMatch(page, "<p>");
            while (idx != -1)
            {
                string front = page.Substring(0, idx);
                string end = page.Substring(idx + 3);
                page = front + end;
                idx = RegexC.regexMatch(page, "<p>");
            }
            idx = RegexC.regexMatch(page, "</p>");
            while (idx != -1)
            {
                string front = page.Substring(0, idx);
                string end = page.Substring(idx + 4);
                page = front + end;
                idx = RegexC.regexMatch(page, "</p>");
            }
            idx = RegexC.regexMatch(page, "<em>");
            while (idx != -1)
            {
                string front = page.Substring(0, idx);
                string end = page.Substring(idx + 4);
                page = front + end;
                idx = RegexC.regexMatch(page, "<em>");
            }
            idx = RegexC.regexMatch(page, "</em>");
            while (idx != -1)
            {
                string front = page.Substring(0, idx);
                string end = page.Substring(idx + 5);
                page = front + end;
                idx = RegexC.regexMatch(page, "</em>");
            }

            return page;
        }

        public static string parseHTML(string url, int method)
        {
            switch (method)
            {
                case 0:
                    if (KMP.kmpMatch(url, "detik.com") != -1)
                    {
                        return parseDetikKMP(url);
                    }
                    else if (KMP.kmpMatch(url, "tempo.co") != -1)
                    {
                        return parseTempoKMP(url);
                    }
                    else if (KMP.kmpMatch(url, "viva") != -1)
                    {
                        return parseVivaKMP(url);
                    }
                    else if (KMP.kmpMatch(url, "antara") != -1)
                    {
                        return parseAntaraKMP(url);
                    }
                    break;
                case 1:
                    if (BM.bmMatch(url, "detik.com") != -1)
                    {
                        return parseDetikBM(url);
                    }
                    else if (BM.bmMatch(url, "tempo.co") != -1)
                    {
                        return parseTempoBM(url);
                    }
                    else if (BM.bmMatch(url, "viva") != -1)
                    {
                        return parseVivaBM(url);
                    }
                    else if (BM.bmMatch(url, "antara") != -1)
                    {
                        return parseAntaraBM(url);
                    }
                    break;
                case 2:
                    if (RegexC.regexMatch(url, "detik.com") != -1)
                    {
                        return parseDetikRegex(url);
                    }
                    else if (RegexC.regexMatch(url, "tempo.co") != -1)
                    {
                        return parseTempoRegex(url);
                    }
                    else if (RegexC.regexMatch(url, "viva") != -1)
                    {
                        return parseVivaRegex(url);
                    }
                    else if (RegexC.regexMatch(url, "antara") != -1)
                    {
                        return parseAntaraRegex(url);
                    }
                    break;
            }
            return "Salah URL";
        }

        static void Main(string[] args)
        {

            Console.WriteLine(parseHTML("http://www.tempo.co/read/news/2017/04/28/348870276/Lawan-Ahok-Warga-Pasar-Ikan-Kembali-Dirikan-Bangunan-Liar",0));

            Console.ReadLine();

            Debug.WriteLine("tralalala");
            NewsList program = new HarianCisitu.NewsList();
            Console.WriteLine("Ping1");
           // string l = program.ParseRssFile("http://rss.vivanews.com/get/all");
            Console.WriteLine("Ping2");
            string l = program.ParseRssFile("http://rss.detik.com/index.php/detikcom");
            Console.WriteLine("Ping3");
            //l = program.ParseRssFile("http://tempo.co/rss/terkini");
            Console.WriteLine("Ping4");
            //l = program.ParseRssFile("http://www.antaranews.com/rss/terkini");
            Console.WriteLine("Ping5");

            for (int k = 0; k < program.trueSize; k++)
            {
                Console.WriteLine(program.list[k].Title);
                Console.WriteLine(program.list[k].Link);
                Console.WriteLine(program.list[k].Desc);
                Console.WriteLine(program.list[k].Date);
                Console.WriteLine("");
            }
            Console.WriteLine("");
            RegexC kmp = new SearchAlgorithm.RegexC();
            News[] found = kmp.SearchRegex("Gubernur", program);
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
                Console.WriteLine("Node");

                Debug.WriteLine("");
                XmlNode rssSubNode = rssNode.SelectSingleNode("title");
                string title = rssSubNode != null ? rssSubNode.InnerText : "";
                Debug.WriteLine(title);

                rssSubNode = rssNode.SelectSingleNode("link");
                string link = rssSubNode != null ? rssSubNode.InnerText : "";
                Debug.WriteLine(link);

                // rssSubNode = rssNode.SelectSingleNode("description");
                //string description = rssSubNode != null ? rssSubNode.InnerText : "";
                //Debug.WriteLine(description);
                string description = parseHTML(link, 0);

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
