using System;
using ConsoleApp1.Model;

namespace ConsoleApp1
{
    class Program
    {
        public static void Main(string[] args)
        {
            // TestLinkedList();
            
            TestHashTable();
            
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
            Grades grade1 = new Grades(72, "well", 63);
            Grades grade2 = new Grades(94, "not bad", 87);
            Grades grade3 = new Grades(72, "well", 63);
            Grades grade4 = new Grades(94, "not bad", 87);
            
            Student student1 = new Student("Vladislav", "Vladislavov", 1);
            Student student2 = new Student("Ivan", "Ivanov", 2);
            Student student3 = new Student("Petr", "Petrov", 3);
            Student student4 = new Student("Sydor", "Sydorov", 4);
            

            MyHashTable<Student, Grades> studentToGrades = new MyHashTable<Student, Grades>();
            studentToGrades.Add(student1, grade1);
            studentToGrades.Add(student2, grade2);
            studentToGrades.Add(student3, grade3);
            studentToGrades.Add(student4, grade4);

            Console.WriteLine("Ivan Ivanov: " + studentToGrades.Get(student2));
            Console.WriteLine("Vladislav Vladislavov: " + studentToGrades.Get(student1));
            Console.WriteLine("Petr Petrov: " + studentToGrades.Get(student3));
            Console.WriteLine("Sydor Sydorov: " + studentToGrades.Get(student4));
            
            studentToGrades.Remove(student3);
            Console.WriteLine();
            Console.WriteLine("Petr Petrov: " + studentToGrades.Get(student3));
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