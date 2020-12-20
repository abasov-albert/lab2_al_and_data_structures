using System;

namespace ConsoleApp1.Model
{
    public class Student : IComparable<Student>
    {
        public string name { get; set; }
        public string surname { get; set; }
        public int grade { get; set; }

        public int CompareTo(Student other)
        {
            int nameComparison = this.name.CompareTo(other.name);
            if (nameComparison != 0)
                return nameComparison;

            var surnameComparison = this.surname.CompareTo(other.surname);
            if (surnameComparison != 0)
                return surnameComparison;

            return this.grade.CompareTo(other.grade);
        }

        public override int GetHashCode()
        {
            int hash = 17;
            hash = 23 * hash + name == null ? 0 : name.GetHashCode();
            hash = 23 * hash + surname == null ? 0 : surname.GetHashCode();
            hash = 23 * hash + grade;

            return hash;
        }

        public Student(string name, string surname, int grade)
        {
            this.name = name;
            this.surname = surname;
            this.grade = grade;
        }
    }
}