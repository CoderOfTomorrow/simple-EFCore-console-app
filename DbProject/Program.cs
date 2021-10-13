using DbProject.DatabaseComponents;
using DbProject.DatabaseComponents.Models;
using System;
using System.Threading.Tasks;

namespace DbProject
{
    class Program
    {
        static async Task Main()
        {
            using var database = new ApplicationDbContext();
            var repository = new DatabaseRepository<SimpleContent>(database);
            var command = "";

            while (command != "exit")
            {
                Console.Clear();
                Console.WriteLine("1) Get an element");
                Console.WriteLine("2) Get all elements");
                Console.WriteLine("3) Add a new element");
                Console.WriteLine("4) Delete an element");
                Console.WriteLine("5) Exit");
                Console.Write("Option -> ");
                command = Console.ReadLine();
                Console.Clear();

                try
                {
                    if (command == "1")
                    {
                        Console.Write("Inser element's id : ");
                        var stringId = Console.ReadLine();
                        Console.Clear();
                        var status = int.TryParse(stringId, out var result);
                        if (status)
                        {
                            var element = await repository.GetElement(result);
                            Console.WriteLine("The element is :");
                            Console.WriteLine($"Id - {element.Id} | Content - {element.Content}");
                        }
                        else
                        {
                            Console.WriteLine("The id is invalid . Try again");
                        }
                        Console.ReadKey();
                    }
                    if (command == "2")
                    {
                        var elements = await repository.GetElements();
                        Console.WriteLine("Elements are : ");
                        foreach (var obj in elements)
                        {
                            Console.WriteLine($"Id - {obj.Id} | Content - {obj.Content}");
                        }
                        Console.ReadKey();
                    }
                    if (command == "3")
                    {
                        Console.WriteLine("Add a new elemetn : ");
                        Console.Write("Element's content : ");
                        SimpleContent newElement = new();
                        newElement.Content = Console.ReadLine();
                        await repository.PostElement(newElement);
                        Console.WriteLine("The element was added");
                        Console.ReadKey();
                    }
                    if (command == "4")
                    {
                        Console.Write("Inser element's id : ");
                        var stringId = Console.ReadLine();
                        var status = int.TryParse(stringId, out var result);
                        if (status)
                        {
                            await repository.DeleteElement(result);
                            Console.WriteLine($"The element with id - {result} was deleted" );
                        }
                        else
                            Console.WriteLine("The id is invalid . Try again");
                        Console.ReadKey();
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.ReadKey();
                }
            }
        }
    }
}
