using DbProject.DatabaseComponents;
using Microsoft.EntityFrameworkCore;

namespace DbProject
{
    public class ApplicationDbContext : DbContext
    {
        private readonly string connectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=TestDatabse;Integrated Security=True";
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
            //ne conectam la o baza de date fie locala fie aflata pe un server strain fie pe cloud cu ajutorul unui connectionString
            //connection string este un sir de caractere care indica unde se afla baza de date si contine date cum ar fi denumirea
            //masinii , denumirea bazei de date , in unele cazuri numele si parola contului de admin ale acelei baze de date
            //pentru a putea efectua operatiuni de scriere si citire
        }

        //lista cu tabele din baza de date
        public DbSet<SimpleContent> TableOne { get; set; } //creem un tabel cu numele TableOne care o sa contina elemente de tipul SimpleContent
    }

    //prin intermediul acestei clase ne conectam la baza de date cu ajutorul unui ORM (Object–relational mapping) EntityFramework care ne permite sa
    //lucram cu o baza de date de tipul SqlServer direct din cod C#


    //daca dorim sa aducem modificari la structura bazei de date , sa adaugam sau stergem tabele sau sa le modificam , dupa ce facem schimbarile necesare
    //utilizam comanda add-migration "numele migratiei"
    //dupa update-database
}
