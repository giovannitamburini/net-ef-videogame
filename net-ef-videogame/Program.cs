namespace net_ef_videogame
{
    public class Program
    {
        static void Main(string[] args)
        {
            /*
            Vogliamo modificare l’esercizio di ieri rimuovendo le parti gestite con SqlClient e implementandole con Entity Framework.

            Devono essere presenti tutte le funzionalità dell’esercizio originale.

            Aggiungiamo anche un’altra voce al menu :
            1 - inserisci una nuova software house
            2 - inserire un nuovo videogioco
            3 - ricercare un videogioco per id
            4 - ricercare tutti i videogiochi aventi il nome contenente una determinata stringa inserita in input
            5 - cancellare un videogioco
            6 - chiudere il programma

            Fatto questo, ogni volta che creiamo un nuovo videogioco dobbiamo abbinargli la software house che l’ha prodotto (che dobbiamo aver precedentemente inserito in tabella), chiedendo all’utente l’id della software house e impostandolo nell’entity del videogame.

            Realizzare quindi tutte le entity e le migration necessarie per creare il database e implementare tutte le richieste dell’esercizio.
            -------------------------------------------------------------------------------------
             */

            //Videogame newVideogame = new Videogame()
            //{
            //    Name = "Call Of Duty",
            //    Overview = "Overview of Call Of Duty",
            //    Release_date = DateTime.Parse("21/12/2022"),
            //    SoftwareHouseId = 1
            //};

            // mi creo delle nuove Software House
            SoftwareHouse firstSoftwareHouse = new SoftwareHouse()
            {
                Name = "Sony Interactive Entertainment",
                TaxId = "120338SKJDD192",
                City = "Tokyo",
                Country = "Japan",
                Videogames = new List<Videogame>()
            };

            SoftwareHouse secondSoftwareHouse = new SoftwareHouse()
            {
                Name = "Activision Blizzard",
                TaxId = "AAA392840294223",
                City = "Santa Monica",
                Country = "Califoria",
                Videogames = new List<Videogame>()
            };

            SoftwareHouse thirdSoftwareHouse = new SoftwareHouse()
            {
                Name = "Epic Games",
                TaxId = "BBB04790938402",
                City = "Cary",
                Country = "North Carolina",
                Videogames = new List<Videogame>()
            };

            //aggiungo le software house al databse
            using (VideogameContext db = new VideogameContext())
            {
                try
                {
                    db.Add(firstSoftwareHouse);
                    db.Add(secondSoftwareHouse);
                    db.Add(thirdSoftwareHouse);

                    Console.WriteLine("Le Software House sono state aggiunte con successo");

                } catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                

                db.SaveChanges();
            }




        }
    }
}