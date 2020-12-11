using System;
using System.Collections;
using ConsoleApp1.Model;

namespace ConsoleApp1
{
    class Program
    {
        public static void Main(string[] args)
        {
            MyList<string> list = new MyList<string>();
            
            string text = System.IO.File.ReadAllText(@"/Users/oabasov/RiderProjects/ConsoleApp1/ConsoleApp1/Text.txt");
            text = text.Replace("\n", " ");
            var words = text.Split(" ");

            foreach (var word in words)
            {
                list.Add(word);
            }

            Console.WriteLine("Before the deletion of word \"or\"");
            Console.WriteLine(list.ToString());
            
            Console.WriteLine();
            
            list.Remove("or");
            Console.WriteLine("After the deletion of word \"or\"");
            Console.WriteLine(list.ToString());

            Console.WriteLine();

            Console.WriteLine("Add \"or\" between \"my\" and \"troubles\"");
            list.Add("or", 3);
            Console.WriteLine(list.ToString());

            Console.WriteLine();

            Console.WriteLine("Formatted text alligned right");
            list.PrintFormatted();
        }
    }
}
