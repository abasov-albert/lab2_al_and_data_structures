using System;
using ConsoleApp1.Model;

namespace ConsoleApp1
{
    class Program
    {
        public static void Main(string[] args)
        {
            // TestLinkedList();
            
            // TestHashTable();
            
            // TestTree();
        }
        
        private static void TestLinkedList()
        {
            MyList<string> list = new MyList<string>();

            string text =
                System.IO.File.ReadAllText(@"C:\Users\abaso\RiderProjects\lab2_al_and_data_structures\ConsoleApp1\Text.txt");
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

            Console.WriteLine("Add \"or\" between \"was\" and \"5\"");
            list.Add("or", 3);
            Console.WriteLine(list.ToString());

            Console.WriteLine();

            Console.WriteLine("Formatted text alligned right");
            list.PrintFormatted();
        }
        
        private static void TestHashTable()
        {
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

            Console.WriteLine("Ivan Ivanov: " + marks.Get("Ivan Ivanov"));
            Console.WriteLine("Lena: " + marks.Get("Lena"));
            Console.WriteLine("Rita: " + marks.Get("Rita"));
            Console.WriteLine("Valera: " + marks.Get("Valera"));
            Console.WriteLine("Denis: " + marks.Get("Denis"));
            Console.WriteLine("Kolya: " + marks.Get("Kolya"));
            marks.Remove("Denis");
            Console.WriteLine("Denis: " + marks.Get("Denis"));
        }
        
        private static void TestTree()
        {
            //  tree

            var myBinaryTree = new MyBinaryTree<int, string>();
            myBinaryTree.Add(47, "Math");
            myBinaryTree.Add(40, "Physics");
            myBinaryTree.Add(22, "Biology");
            myBinaryTree.Add(61, "English");
            myBinaryTree.Add(95, "Geography");
            myBinaryTree.Add(9, "Science");
            myBinaryTree.Add(93, "Social Studies");
            myBinaryTree.Add(39, "Literature");
            myBinaryTree.Add(43, "Statistics");
            myBinaryTree.Add(38, "Chemistry");
            myBinaryTree.Add(59, "Economics");
            myBinaryTree.Add(25, "History");
            myBinaryTree.Add(60, "Law");
            myBinaryTree.Add(71, "French");
            myBinaryTree.Add(32, "Psychology");


            myBinaryTree.Remove(47);
            myBinaryTree.Remove(22);
            myBinaryTree.Remove(61);

            Console.WriteLine(myBinaryTree.Get(38));
            Console.WriteLine(myBinaryTree.Get(60));
            Console.WriteLine(myBinaryTree.Get(32));

            Console.WriteLine();

            Console.WriteLine($"Maximum value is {myBinaryTree.GetMax()}");
        }
    }
}