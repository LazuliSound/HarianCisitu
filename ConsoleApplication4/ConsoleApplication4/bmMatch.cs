using System;

namespace WindowsFormsApplication1
{
    public class bmMatc
    {
        public static int bmMatch(String text, String pattern)
        {
            int []last = buildLast(pattern);
            for (int xd = 0; xd < 3; xd++)
            {
                Console.WriteLine(last[pattern[xd]]);
            }
            int n = text.Length;
            int m = pattern.Length;
            int i = m - 1;
            Console.WriteLine(text);
            Console.WriteLine(text.Length);
            Console.WriteLine(pattern);
            if (i > n - 1)
            {
                Console.WriteLine("1");
                return -1;
            } else
            {
                Console.WriteLine("2");
                int j = m - 1;
                do
                {
                    Console.Write("ahaha");
                    Console.Write(j);
                    Console.Write(pattern[j]);
                    Console.WriteLine(text[i]);
                    if (pattern[j] == text[i])
                    {
                        Console.WriteLine("a");
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
                        Console.Write("asfkashfkashfaskfjskajfhk");
                        Console.Write(last[text[i]]);
                        int lo = last[text[i]];
                        i = i + m - Math.Min(j, 1 + lo);
                        j = m - 1;

                    }
                    Console.Write("akhir");
                    Console.WriteLine(j);
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
                Console.Write("asdasfa");
                Console.Write(last[pattern[i]]);
                Console.WriteLine(pattern[i]);
                Console.WriteLine(i);
                last[pattern[i]] = i;
            }

            return last;
        }

        /*
        public static void Main(String [] args)
        {
            String l = "aku punya anjing kecil";
            String p = "pun";

            Console.WriteLine(l);
            Console.WriteLine(p);
            Console.WriteLine(l.Length);

            int posn = bmMatch(l,p);
            if (posn == -1)
            {
                Console.WriteLine("tidak ditemukan");
            } else
            {
                Console.Write("pada posisi ");
                Console.Write(posn);
            }
            Console.ReadKey();
        }
        */
    }
}