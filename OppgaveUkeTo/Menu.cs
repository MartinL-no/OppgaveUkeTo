using System;
using System.Threading;

namespace OppgaveUkeTo
{
    public class Menu
    {
        public static void Run()
        {
            var continueRunningProgram = true;

            while (continueRunningProgram)
            {
                Console.WriteLine(
                    "Please select one of the following options:\n\n" +
                    "1. Show all students\n" +
                    "2. Show students by course\n" +
                    "0. Exit program\n"
                );

                Console.Write("Your choice (eg 1, 2): ");
                string input = Console.ReadLine();

                continueRunningProgram = MainMenuInput(input);
            }
        }

        public static bool MainMenuInput(string input)
        {
            Console.Clear();
            switch (input)
            {
                case "1":
                    Students.ShowAllStudents();
                    ExitSubMenu();
                    return true;
                case "2":
                    CourseMenu();
                    return true;
                case "0":
                    return false;
                default:
                    ShowTemporaryMessage(1500, "Invalid input: please select another option");
                    return true;
            }
        }

        private static void CourseMenu()
        {
            bool validCourseName = false;

            while (!validCourseName)
            {
                Students.ShowAllCourses();
                var userInput = GetInput("Course you would like to select: ");
                validCourseName = Students.CourseNameExists(userInput);

                if (validCourseName)
                {
                    Students.ShowStudentsByCourse(userInput);
                    ExitSubMenu();
                }
                else
                {
                    ShowTemporaryMessage(1500, "Invalid input: please select another option");
                }
            }
        }

        public static string GetInput(string prompt)
        {
            Console.Write(prompt);
            var input = Console.ReadLine();
            Console.Clear();

            return input;
        }
        public static void ExitSubMenu()
        {
            Console.WriteLine("Press <Enter> to return to the main menu");

            while (Console.ReadKey().Key != ConsoleKey.Enter) { }

            Console.Clear();
        }
        public static void ShowTemporaryMessage(int millisecondsToShow, string message)
        {
            Console.Clear();
            Console.WriteLine(message);

            Thread.Sleep(millisecondsToShow);
            Console.Clear();
        }
    }
}