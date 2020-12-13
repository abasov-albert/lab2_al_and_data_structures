﻿using System;
using System.Collections;
using System.Collections.Generic;
using ConsoleApp1.Model;

namespace ConsoleApp1
{
    class Program
    {
        public static void Main(string[] args)
        {
            /*
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
            */
            
            
            Marks formA = new Marks(72, "well", 63);
            Marks formB = new Marks(94, "not bad", 87);
            Marks formC = new Marks(72, "well", 63);
            Marks formD = new Marks(94, "not bad", 87);
            
            MyHashTable<string, Marks> marks = new MyHashTable<string, Marks>();
            marks.Add("Abasov Albert", formA);
            marks.Add("Lena", formB);
            marks.Add("Rita", formC);
            marks.Add("Valera", formD);
            marks.Add("Denis", formA);
            marks.Add("Ivan Ivanov", formB);

            Console.WriteLine("Ivan Ivanov: " + marks.Lookup("Ivan Ivanov"));
            Console.WriteLine("Lena: " + marks.Lookup("Lena"));
            Console.WriteLine("Rita: " + marks.Lookup("Rita"));
            Console.WriteLine("Valera: " + marks.Lookup("Valera"));
            Console.WriteLine("Denis: " + marks.Lookup("Denis"));
            Console.WriteLine("Kolya: " + marks.Lookup("Kolya"));
            marks.Delete("Denis");
            Console.WriteLine("Denis: " + marks.Lookup("Denis"));
            
        }
    }
}
