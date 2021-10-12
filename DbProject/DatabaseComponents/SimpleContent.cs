namespace DbProject.DatabaseComponents
{
    //creem o clasa simpla care o sa se mapeze automat cu ajutorul EntityFramework la elemente din tabelul cu aceasta schema din baza de date
    public class SimpleContent
    {
        public int Id { get; set; } //avem un camp Id care este obligatoriu si va reprezenta cheia noastra primara
        public string Content { get; set; } //un camp content de tip string 
    }
}
