// KMP
/*
using System;
using System.Text.RegularExpressions;
namespace StringMatching
{
    class Regex
    {
        public static void RegexCheck(String input,String pattern)
        {
            Match m = Regex.Match(input, pattern, RegexOptions.IgnoreCase);
            if(m.Success)
            {
                Console.WriteLine("Found '{0}' at position {1}.", m.Value, m.Index);
            }
        }
        
    }

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
    }

    class Main
    {
    */
        /*
        ///////////////////////////////////////////////////////MAIN////////////////////////////////////////////////////////////////
        static void Main(String[] args)
        {
            char command;
            */
            /*if(args.Length != 2)
            {
                Console.WriteLine("Usage: java KmpSearch <text> <pattern>");
                Environment.Exit(0);
            }*/
            /*
            Console.WriteLine("Masukan Perintah");
            Console.ReadLine(command);
            String text = "Halo Apakabar semua kami Tipeh Cisco Lazu hehehe";


            Console.WriteLine("Text: " + text);
            switch (command)
            {
                case '1':
                    KMP test1 = new KMP();
                    String pattern = "Cisco";
                    Console.WriteLine("Pattern: " + pattern);
                    int posn = test1.kmpMatch(text, pattern);
                    if (posn == -1)
                    {
                        Console.WriteLine("Pattern not found");
                    }
                    else
                    {
                        Console.WriteLine("Pattern starts at posn " + posn);
                    }
                    end;
                case '2':
                    Regex test2 = new Regex();
                    String pattern = @"\bCisco\w*\b";
                    Console.WriteLine("Pattern: " + pattern);
                    test2.Regex(input, pattern);
                    end;
            }
            
            //////////////////////////////////////////////////////////////////////
            Console.WriteLine("Press Any Key to exit");
            Console.ReadLine();
        }
        
    }
        
    
}
*/