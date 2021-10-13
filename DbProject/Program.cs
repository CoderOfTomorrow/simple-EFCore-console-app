using DbProject.DatabaseComponents;
using System;
using System.Linq;

namespace DbProject
{
    class Program
    {
        static void Main()
        {
            string command = "";

            while (command != "exit")
            {
                Console.Clear();
                Console.WriteLine("-- Simple Database --\n");

                using var database = new ApplicationDbContext();
                int elementsCount = 0;

                if (database.TableOne.Any())
                    elementsCount = database.TableOne.Count();
                else
                    elementsCount = 0;

                Console.WriteLine($"There are {elementsCount} elements TableOne");

                if (elementsCount > 0)
                    foreach (var obj in database.TableOne)
                    {
                        Console.WriteLine("Id : " + obj.Id + " | Content : " + obj.Content);
                    }

                Console.WriteLine("\nPress 1 to add one more element or \"exit\" to end the program");
                command = Console.ReadLine();

                if (command == "1")
                {
                    Console.Clear();
                    Console.WriteLine("Content of the new element : ");
                    SimpleContent newElement = new();
                    newElement.Content = Console.ReadLine();
                    database.TableOne.Add(newElement);
                    database.SaveChanges();
                }
            }

        }
    }
}
