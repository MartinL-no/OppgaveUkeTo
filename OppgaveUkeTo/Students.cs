using System;
using System.Collections.Generic;
using System.Linq;

namespace OppgaveUkeTo
{
    internal class Students
    {
        static List<Student> RegisteredStudents = new List<Student>();

        public static void AddStudent(Student student)
        {
            RegisteredStudents.Add(student);
        }

        public static void ShowAllStudents()
        {
            Console.WriteLine("All students:\n");

            foreach (var student in RegisteredStudents)
            {
                Console.WriteLine(
                    $"Name: {student.Name}\n" +
                    $"Age: {student.Age}\n" +
                    $"Course: {student.Course}\n"
                );
            }
        }

        public static void ShowAllCourses()
        {
            var courses = RegisteredStudents.Select(s => s.Course).Distinct();

            Console.WriteLine("Course options:\n");
            foreach (var course in courses)
            {
                Console.WriteLine(course);
            }
            Console.WriteLine();
        }

        public static void ShowStudentsByCourse(string courseName)
        {
            if (CourseNameExists(courseName))
            {
                var studentsOnCourse =
                    RegisteredStudents.FindAll(s => s.Course.ToLowerInvariant() == courseName.ToLowerInvariant());
                var courseNameWithCorrectFormatting = studentsOnCourse[0].Course;
                Console.WriteLine($"Student on {courseNameWithCorrectFormatting} course:\n");

                foreach (var student in studentsOnCourse)
                {
                    Console.WriteLine(student.Name);
                }

                Console.WriteLine();

            }
        }

        public static bool CourseNameExists(string courseName)
        {
            return RegisteredStudents.Exists(s => s.Course.ToLowerInvariant() == courseName.ToLowerInvariant());
        }
    }
}