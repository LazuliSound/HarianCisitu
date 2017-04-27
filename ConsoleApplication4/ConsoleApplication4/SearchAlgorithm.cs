using System;
using System.Text.RegularExpressions;
using HarianCisitu;


namespace SearchAlgorithm
{
    #region Regex
    class RegexC
    {
        public News[] SearchRegex(String pattern, NewsList newslist)
        {
            News[] foundNews = new News[newslist.Size];
            int j = 0;
            for (int i = 0; i < newslist.Size; i++)
            {
                bool titleFound = Regex.IsMatch(newslist.NewsIdx(i).Title, pattern);
                Match descFounded = Regex.Match(newslist.NewsIdx(i).Desc, pattern);
                int descFound = descFounded.Index;
                if (titleFound || descFound != 0)
                {
                    foundNews[j] = newslist.NewsIdx(i);
                    foundNews[j].Desc = newslist.NewsIdx(i).Desc;
                    if (descFound != -1)
                    {
                        char[] temp = new char[200];
                        int idx = descFound;
                        while (idx > 0 && foundNews[j].Desc[idx] != '.' && foundNews[j].Desc[idx] != '>')
                        {
                            idx--;
                        }
                        idx++;
                        int p = 0;
                        while (idx < newslist.NewsIdx(i).Desc.Length && (foundNews[j].Desc[idx] != '.'
                            || foundNews[j].Desc[idx] != '<') && p < 200)
                        {
                            temp[p] = foundNews[j].Desc[idx];
                            p++;
                            idx++;
                        }
                        string temp1 = new string(temp, 0, p);
                        foundNews[j].Desc = temp1;
                    }
                    j++;
                }
            }
            return foundNews;
        }

        public static int regexMatch(String text, String pattern)
        {
            Match match = Regex.Match(text, pattern);
            if (match.Success)
            {
                return match.Index;
            }
            else
            {
                return -1;
            }
        }

    }
    #endregion
    #region KMP
    class KMP
    {
        public static int[] computerFail(String pattern)
        {
            int[] fail = new int[pattern.Length];
            fail[0] = 0;

            int m = pattern.Length;
            int j = 0;
            int i = 1;

            while (i < m)
            {
                if (pattern[j] == pattern[i])
                {
                    fail[i] = j + 1;
                    i++;
                    j++;
                }
                else
                {
                    if (j > 0)
                    {
                        j = fail[j - 1];
                    }
                    else
                    {
                        fail[i] = 0;
                        i++;
                    }
                }
            }
            return fail;
        }

        public static int kmpMatch(String text, String pattern)
        {
            int n = text.Length;
            int m = pattern.Length;

            int[] fail = computerFail(pattern);

            int i = 0;
            int j = 0;

            while (i < n)
            {
                if (pattern[j] == text[i])
                {
                    if (j == m - 1)
                    {
                        return i - m + 1;
                    }
                    i++;
                    j++;
                }
                else
                {
                    if (j > 0)
                    {
                        j = fail[j - 1];
                    }
                    else
                    {
                        i++;
                    }
                }
            }
            return -1;
        }
        public News[] SearchKMP(string pattern, NewsList newslist)
        {
            News[] foundNews = new News[newslist.Size];
            int j = 0;
            for (int i = 0; i < newslist.Size; i++)
            {
                int titleFound = kmpMatch(newslist.NewsIdx(i).Title, pattern);
                int descFound = kmpMatch(newslist.NewsIdx(i).Desc, pattern);
                if (titleFound != -1 || descFound != -1)
                {
                    foundNews[j] = newslist.NewsIdx(i);
                    if (descFound != -1)
                    {
                        char[] temp = new char[200];
                        int idx = descFound;
                        while (idx > 0 && foundNews[j].Desc[idx] != '.' && foundNews[j].Desc[idx] != '>')
                        {
                            idx--;
                        }
                        idx++;
                        int p = 0;
                        while (idx < newslist.NewsIdx(i).Desc.Length && (foundNews[j].Desc[idx] != '.'
                            || foundNews[j].Desc[idx] != '<') && p < 200)
                        {
                            temp[p] = foundNews[j].Desc[idx];
                            p++;
                            idx++;
                        }
                        string temp1 = new string(temp, 0, p);
                        foundNews[j].Desc = temp1;
                    }
                    j++;
                }
            }
            return foundNews;
        }
    }
    #endregion
    #region BM
    class BM
    {
        public News[] SearchBM(String S, NewsList newslist)
        {
            int contain = 0;
            News[] newsout = new News[newslist.Size];
            for (int i = 0; i < newslist.Size; i++)
            {
                Boolean included = false;
                int idx = bmMatch(newslist.NewsIdx(i).Desc, S);
                if (bmMatch(newslist.NewsIdx(i).Title, S) != -1)
                {
                    included = true;
                }
                else if (idx != -1)
                {
                    included = true;
                }
                if (included)
                {
                    newsout[contain] = newslist.NewsIdx(i);
                    if (idx != -1)
                    {
                        char[] temp = new char[200];
                        while (idx > 0 && newsout[contain].Desc[idx] != '.' && newsout[contain].Desc[idx] != '>')
                        {
                            idx--;
                        }
                        idx++;
                        int p = 0;
                        while (idx < newslist.NewsIdx(i).Desc.Length && (newsout[contain].Desc[idx] != '.'
                            || newsout[contain].Desc[idx] != '<') && p < 200)
                        {
                            temp[p] = newsout[contain].Desc[idx];
                            p++;
                            idx++;
                        }
                        newsout[contain].Desc = new string(temp, 0, p);
                    }
                    contain++;
                }
            }
            return newsout;
        }

        public static int bmMatch(String text, String pattern)
        {
            int[] last = buildLast(pattern);
            int n = text.Length;
            int m = pattern.Length;
            int i = m - 1;
            if (i > n - 1)
            {
                return -1;
            }
            else
            {
                int j = m - 1;
                do
                {
                    if (pattern[j] == text[i])
                    {
                        if (j == 0)
                        {
                            return i;
                        }
                        else
                        {
                            i--;
                            j--;
                        }
                    }
                    else
                    {
                        int lo = last[text[i]];
                        i = i + m - Math.Min(j, 1 + lo);
                        j = m - 1;

                    }
                } while (i <= n - 1);
                return -1;
            }
        }

        public static int[] buildLast(String pattern)
        {
            int[] last = new int[128];

            for (int i = 0; i < 128; i++)
                last[i] = -1;

            for (int i = 0; i < pattern.Length; i++)
            {
                last[pattern[i]] = i;
            }

            return last;
        }
    }
    #endregion
}
