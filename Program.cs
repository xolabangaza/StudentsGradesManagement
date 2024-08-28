using System;
using System.Drawing;

class StudentGrades
{
    // Arrays to store the students data
    static int[] studentIDs = new int[5];
    static string[] names = new string[5];
    static int[] grades = new int[5];
    
    static void Main()
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("\n" + "---------------------------------Student Grades Management System---------------------------------");
        Menu();
    }

    // Method to display the menu and handle user input
    static void Menu()
    {
        while (true)
        {
            Console.WriteLine( "\n"+ "1. Add a new student"+"\n"+ "2. View all students"+"\n"+ "3. Delete a student by StudentID"+"\n"+ "4. Exit"+"\n");
            Console.Write("Choose from the above menu (1-4): ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddStudent();
                    break;
                case "2":
                    ViewStudents();
                    break;
                case "3":
                    Console.Write("Enter StudentID to delete: ");
                    int studentId;
                    if (int.TryParse(Console.ReadLine(), out studentId))
                    {
                        DeleteStudent(studentId);
                    }
                    else
                    {
                        Console.WriteLine("Invalid StudentID.");
                    }
                    break;
                case "4":
                    return;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }

    //Method to add student
    static void AddStudent()
    {
        for (int i = 0; i < studentIDs.Length; i++)
        {
            if (studentIDs[i] == 0) // Empty spot found
            {
                Console.Write("Enter StudentID: ");
                if (int.TryParse(Console.ReadLine(), out studentIDs[i]))
                {
                    Console.Write("Enter Name: ");
                    names[i] = Console.ReadLine();
                    Console.Write("Enter Grade: ");
                    if (int.TryParse(Console.ReadLine(), out grades[i]))
                    {
                        Console.WriteLine("Student added successfully.");
                    }
                    else
                    {
                        Console.WriteLine("Invalid Grade. Student not added.");
                        studentIDs[i] = 0; // Reset entry
                        names[i] = string.Empty;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid StudentID. Student not added.");
                }
                return;
            }
        }
        Console.WriteLine("No more space to add new students.");
    }
    //Method to view student data
    static void ViewStudents()
    {
        Console.WriteLine("List of Students:");
        for (int i = 0; i < studentIDs.Length; i++)
        {
            if (studentIDs[i] != 0)
            {
                Console.WriteLine($"StudentID: {studentIDs[i]}, Name: {names[i]}, Grade: {grades[i]}");
            }
           else if (studentIDs[i] == 0)
            {
                Console.WriteLine("No student found");
            }
        }
    }
    //Method to delete a students by their ID
    static void DeleteStudent(int studentId)
    {
        for (int i = 0; i < studentIDs.Length; i++)
        {
            if (studentIDs[i] == studentId)
            {
                studentIDs[i] = 0;
                names[i] = string.Empty;
                grades[i] = 0;
                Console.WriteLine("Student deleted successfully.");
                return;
            }
        }
        Console.WriteLine("StudentID not found.");
    }
}
