using System;

namespace OppgaveUkeTo
{
    class Program
    {
        static void Main(string[] args)
        {
            Students.AddStudent(new Student("Heibert", 42, "Radio car driving"));
            Students.AddStudent(new Student("Terje", 38, "Programming"));
            Students.AddStudent(new Student("Bjorn", 38, "Bear Taming"));

            Console.WriteLine("Welcome to GET University\n");

            Menu.Run();
        }
    }
}