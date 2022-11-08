using System.Text;
using System.IO;

namespace Capin_Dread
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int i=0;
            List<string> list=new List<string>();
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
                if (File.ReferenceEquals(@"CapitalWordList.txt", @"WordList.txt".ToUpper()))
                    Console.WriteLine("Succesfull");
                else
                    Console.WriteLine("Unsuccesfull");
            }
            else
                Console.WriteLine("Files does not exist");
        }
        

    }
}