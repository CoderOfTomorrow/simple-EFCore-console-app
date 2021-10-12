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

            //introducem un while pentru a crea ceva de genul la un meniu care va functiona pana tastam "exit"
            while (command != "exit")
            {
                //curatam consola
                Console.Clear();
                Console.WriteLine("-- Baza de date --\n");

                using var database = new ApplicationDbContext();   //creem o conectiun la baza de date
                int elementsCount = 0;  //intitializam un contor sa vedem cate elemente sunt in baza de date

                if (database.TableOne.Any()) // verificam daca sunt elemente si daca sunt atribuim contorului nr de elemente
                    elementsCount = database.TableOne.Count();
                else
                    elementsCount = 0;

                Console.WriteLine($"Baza de date contine {elementsCount} elemente"); //afisam numarul de elemente

                if (elementsCount > 0) //daca exista elemente afisam elementele din baza de date din tabelul TableOne
                    foreach (var obj in database.TableOne)
                    {
                        Console.WriteLine("Id : " + obj.Id + " | Continut : " + obj.Content);
                    }

                Console.WriteLine("\nTastati 1 pentru a introduce un elemnt nou sau \"exit\" pentru a iesi");
                command = Console.ReadLine();

                if (command == "1") //daca dorim sa introducem un element tastam 1
                {
                    Console.Clear();
                    Console.WriteLine("Introduceti continutul noului elemnt : ");
                    SimpleContent newElement = new(); //creem un element nou de tipul SimpleContent , acest tip de element se accepta in tabelul TableOne din baza de date
                    newElement.Content = Console.ReadLine(); //initializam campul Content cu continut citit de la tastatura
                    database.TableOne.Add(newElement); //introducem elementul nou in tabelul TableOne
                    database.SaveChanges(); //salvam modificarile aduse la baza de date
                }
            }

        }
    }
}
