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
            

            Console.WriteLine(formA.GetHashCode());
            Console.WriteLine(formB.GetHashCode());
            Console.WriteLine(formC.GetHashCode());
            Console.WriteLine(formD.GetHashCode());
            
            MyHashTable<int, Marks> markss = new MyHashTable<int, Marks>();
            markss.Add(44, formA);
            markss.Add(44, formA);
            markss.Add(44, formA);
            
            MyHashTable<string, Marks> marks = new MyHashTable<string, Marks>();
            marks.Add("Abasov Albert", formA);
            marks.Add("Abasov Albert", formA);
            marks.Add("Abasov Albert", formA);
            marks.Add("Abasov Albert", formA);
            marks.Add("Abasov Albert", formA);
            marks.Add("Ivan Ivanov", formB);

            Console.WriteLine(marks.Lookup("Ivan Ivanov"));
            
        }
    }
}
