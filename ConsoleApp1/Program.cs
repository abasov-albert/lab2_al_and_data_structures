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
            marks.Add("Lena", formB);
            marks.Add("Rita", formC);
            marks.Add("Valera", formD);
            marks.Add("Denis", formA);
            marks.Add("Abasov Albert", formA);
            marks.Add("Ivan Ivanov", formB);

            /*
            Console.WriteLine("Ivan Ivanov: " + marks.Get("Ivan Ivanov"));
            Console.WriteLine("Lena: " + marks.Get("Lena"));
            Console.WriteLine("Rita: " + marks.Get("Rita"));
            Console.WriteLine("Valera: " + marks.Get("Valera"));
            Console.WriteLine("Denis: " + marks.Get("Denis"));
            Console.WriteLine("Kolya: " + marks.Get("Kolya"));
            marks.Remove("Denis");
            Console.WriteLine("Denis: " + marks.Get("Denis"));
            */
         
            // tree
            var myBinaryTree = new MyBinaryTree<int, string>();
            myBinaryTree.Add(47, "Math");
            myBinaryTree.Add(40, "Physics");
            myBinaryTree.Add(22, "Biology");
            myBinaryTree.Add(61, "English");
            myBinaryTree.Add(9, "Geography");

            Console.WriteLine(myBinaryTree.Get(47));
            Console.WriteLine(myBinaryTree.Get(22));
            Console.WriteLine(myBinaryTree.Get(9));
            Console.WriteLine(myBinaryTree.Get(40));
            Console.WriteLine(myBinaryTree.Get(61));
            
            Console.WriteLine();

            Console.WriteLine($"Maximum value is {myBinaryTree.GetMax()}");
        }
        
        
    }
}
