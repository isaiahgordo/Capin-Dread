using System.Text;
using System.IO;
using System.Text.Json.Serialization;
using System.Runtime.CompilerServices;

namespace Capin_Dread
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int i=0,o,m=0,k=0;
            string? cath = @"CapitalWordList.txt",palin=@"PalinList.txt",sl=@"StudentList.txt";
            string insertNon = "Non",neverForget;
            bool b;
            bool l;
            List<string> list=new List<string>(),lastlist,stulist;
            if (File.Exists("WordList.txt")||File.Exists("CapitalWordList.txt"))
            {
                foreach (string line in File.ReadLines(@"WordList.txt", Encoding.UTF8))
                {
                    i++;
                    list.Add(line);
                }
                Console.WriteLine(i);
                foreach (string line in list)
                {
                    File.WriteAllText(line.ToUpper(), @"CapitalWordList.txt");
                }
                lastlist =list;
                list = Felper(cath);
                foreach (string line in File.ReadLines(cath, Encoding.UTF8))
                {
                    i++;
                    list.Add(line);
                }
                b = Listerbool(lastlist, list);
                if (b==true)
                    Console.WriteLine("Succesfull");
                else
                    Console.WriteLine("Unsuccesfull");
            }
            else
                Console.WriteLine("Files does not exist");
            StringBuilder sb;
            if (File.Exists("PwordList.txt")&&File.Exists("PalinList.txt")&&File.Exists("NonPalinList.txt"))
            {
                int r=0,v=0;
                list.Clear();
                List<string> s = new List<string>(), g =new List<string>();
                string? w;
                foreach (string line in File.ReadLines(@"PwordList.txt", Encoding.UTF8))
                {
                    sb = new StringBuilder(line);
                    o = sb.Length;                   
                    for (int t = 0; t < o; t++)
                        s.Add(sb[t].ToString());        
                    for (int t = s.Count-1; t >= 0; t--)
                        g.Add(sb[t].ToString());
                    for (int t = 0; t < o; t++)
                    {
                        l = Striulder(s[t], g[t]);
                        if (l == true) m++;
                        else k++;
                    }
                    list.Add(line);
                }
                Console.WriteLine(m.ToString()+" palindromes, "+k.ToString()+" non-palindrome");
                foreach(string line in list)
                {
                    if(line==line.Reverse())
                    {
                        File.WriteAllText(line, @"PalinList.txt");
                    }
                }
                list.Clear();
                foreach (string line in File.ReadLines(palin, Encoding.UTF8))
                {
                    sb = new StringBuilder(line);
                    o = sb.Length;                    
                    for(int t=0; t < s.Count; t++)                    
                        s[t] = sb[t].ToString();                                       
                    for (int t =0; t<g.Count;t++,o--)
                        g[t]=(sb[o].ToString());
                    for (int t = 0; t < o; t++)
                    {
                        l = Striulder(s[t], g[t]);
                        if (l == true) m++;
                        else k++;
                    }
                    list.Add(line);
                }
                w = palin.Insert(0, insertNon);
                foreach(string line in list)
                    if (line != line.Reverse())
                        File.WriteAllText(line, w);
                list = Felper(w);
                foreach(string line in File.ReadLines(w, Encoding.UTF8))
                {
                    sb = new StringBuilder(line);
                    o = sb.Length;                    
                    for (int t = 0; t < s.Count; t++)
                        s[t] = sb[t].ToString();                    
                    for (int t = 0; t < g.Count; t++, o--)
                        g.Add(sb[o].ToString());
                    for (int t = 0; t < o; t++)
                    {
                        l = Striulder(s[t], g[t]);
                        if (l == true) m++;
                        else k++;
                    }
                }
                if(r==m&&v==k)
                    Console.WriteLine("Succesful, Succesful");
                else if (r == m || v == k)
                {
                    if (r == m)
                        Console.Write("Succesful, ");
                    else
                        Console.Write("Unsuccesful, ");
                    if (v == k)
                        Console.WriteLine("Succesful");
                    else
                        Console.WriteLine("Unsuccesful");
                }
                else
                    Console.WriteLine("Unsuccesful");
            }
            else Console.WriteLine("Dose not exist");
            if (File.Exists("StudentList"))
            {
                list.Clear();
                int stunum, iosemcole;
                foreach (string line in File.ReadLines(sl, Encoding.UTF8))
                {
                    iosemcole = line.IndexOf(";");
                    b = int.TryParse(line.Substring(iosemcole + 1), out stunum);
                    if (b == true)
                    {
                        int v;
                        list = LestWeForget(line.Remove(iosemcole), stunum);
                        for (int r = 0; r < list.Count; r = r + 3)
                            for (v = 0; v < 3; v++)
                                Console.WriteLine(list[v]);
                    }
                    else Console.WriteLine("Unsuccesful");
                }
            }
            else Console.WriteLine("File does not exist");
            Console.ReadLine();
        }
        public static List<string> Felper(string? path)
        {
            List<string> s= new List<string>();
            foreach(string line in File.ReadAllLines(path))
                s.Add(line);
            return s;
        }
        public static bool Listerbool(List<string>s,List<string> S)
        {
            bool b=true;
            for (int i = 0; i < S.Count; i++)
                if (S[i] == s[i].ToLower())
                    b= true;
                else b= false;
            return b;
        }
        public static bool Striulder(string s,string g)
        {
            bool b=true;
            if (s == g)
                b = true;
            else b = false;
            return b;
        }
        public static List<string> LestWeForget(string line,int studentnum)
        {
            int wS = line.IndexOf(" "),rum;
            string s = line.Substring(0, wS), g = line.Replace(s, " ").Trim();
            List<string> l = new List<string>();
            Random r = new Random();
            rum = ((((r.Next(10)*10+r.Next(10))*10+r.Next(10))*10+r.Next(10))*10+r.Next(10))*10+r.Next(10);
            l.Add(rum.ToString());
            l.Add(g);
            l.Add(s);
            return l;
        }
    }
}