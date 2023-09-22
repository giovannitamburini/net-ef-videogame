using Microsoft.Data.SqlClient;

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
            //SoftwareHouse firstSoftwareHouse = new SoftwareHouse()
            //{
            //    Name = "Sony Interactive Entertainment",
            //    TaxId = "120338SKJDD192",
            //    City = "Tokyo",
            //    Country = "Japan",
            //    Videogames = new List<Videogame>()
            //};

            //SoftwareHouse secondSoftwareHouse = new SoftwareHouse()
            //{
            //    Name = "Activision Blizzard",
            //    TaxId = "AAA392840294223",
            //    City = "Santa Monica",
            //    Country = "Califoria",
            //    Videogames = new List<Videogame>()
            //};

            //SoftwareHouse thirdSoftwareHouse = new SoftwareHouse()
            //{
            //    Name = "Epic Games",
            //    TaxId = "BBB04790938402",
            //    City = "Cary",
            //    Country = "North Carolina",
            //    Videogames = new List<Videogame>()
            //};

            ////aggiungo le software house al databse
            //using (VideogameContext db = new VideogameContext())
            //{
            //    try
            //    {
            //        db.Add(firstSoftwareHouse);
            //        db.Add(secondSoftwareHouse);
            //        db.Add(thirdSoftwareHouse);

            //        db.SaveChanges();

            //        Console.WriteLine("Le Software House sono state aggiunte con successo");

            //    }
            //    catch (Exception ex)
            //    {
            //        Console.WriteLine(ex.Message);
            //    }


            //}


            bool repeatMenu = true;

            while (repeatMenu)
            {


                Console.WriteLine(@"
1 - inserire una nuova software house
2 - inserire un nuovo videogioco
3 - ricercare un videogioco per id
4 - ricercare tutti i videogiochi aventi il nome contenente una determinata stringa inserita in input
5 - cancellare un videogioco
6 - chiudere il programma
");

                Console.Write("Prego seleziona l'opzione che desideri effettuare: ");
                int selectedOption = int.Parse(Console.ReadLine());


                switch (selectedOption)
                {
                    case 1:

                        Console.WriteLine("Hai selezionato l'opzione 1: inserire una nuova software house");

                        Console.WriteLine("Inserisci i dati della software house");

                        Console.Write("Inserisci il nome della software house: ");
                        string name = Console.ReadLine();

                        Console.Write("Inserisci la taxId della software house: ");
                        string taxId = Console.ReadLine();

                        Console.Write("Inserisci la città della sede della sh: ");
                        string city = Console.ReadLine();

                        Console.Write("Inserisci il paese della sede della sh: ");
                        string country = Console.ReadLine();



                        SoftwareHouse newSoftwareHouse = new SoftwareHouse()
                        {
                            Name = name,
                            TaxId = taxId,
                            City = city,
                            Country = country,
                            Videogames = new List<Videogame>()
                        };


                        using (VideogameContext db = new VideogameContext())
                        {
                            try
                            {
                                db.Add(newSoftwareHouse);

                                db.SaveChanges();

                                Console.WriteLine("La Software House è stata aggiunta con successo");

                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }


                        }

                        break;

                    case 2:

                        Console.WriteLine("Hai selezionato l'opzione 2 - inserire un nuovo videogioco");

                        Console.WriteLine("Inserisci i dati del videogame");

                        Console.Write("Inserisci il nome del videogame: ");
                        string nameVg = Console.ReadLine();

                        Console.Write("Inserisci il riepilogo del videogame: ");
                        string overview = Console.ReadLine();

                        Console.Write("Inserisci la data di realizzazione del videogame (dd/MM/yyyy): ");
                        DateTime releaseDate = DateTime.Parse(Console.ReadLine());

                        Console.Write("Inserisci l'id della casa di produzione del videogame: ");
                        long softwareHouseId = long.Parse(Console.ReadLine());

                        Videogame newVideogame = new Videogame()
                        {
                            Name = nameVg,
                            Overview = overview,
                            Release_date = releaseDate,
                            SoftwareHouseId = softwareHouseId
                        };

                        using (VideogameContext db = new VideogameContext())
                        {
                            try
                            {
                                db.Add(newVideogame);

                                db.SaveChanges();

                                Console.WriteLine("Il videogame è stato aggiunto con successo");

                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                        }

                        break;

                    case 3:

                        Console.WriteLine("Hai selezionato l'opzione 2: ricercare un videogioco per id");

                        Console.Write("Inserisci l'id del videogame che vuoi cercare: ");
                        long idVideogame = long.Parse(Console.ReadLine());

                        using (VideogameContext db = new VideogameContext())
                        {
                            try
                            {
                                List<Videogame> videogames = db.Videogames.OrderBy(videogame => videogame.VideogameId).ToList();

                                Videogame videogameFounded = db.Videogames.Where(vg => vg.VideogameId == idVideogame).First();

                                Console.WriteLine(videogameFounded);
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                        }

                        break;


                    case 4:

                        Console.WriteLine("Hai selezionato l'opzione 3: ricercare tutti i videogiochi aventi il nome contenente una determinata stringa inserita in input");

                        break;

                    case 5:
                        Console.WriteLine("Hai selezionato l'opzione 4: cancellare un videogioco");

                        break;

                    case 6:

                        Console.WriteLine("Hai selezionato l'opzione 5: chiudere il programma");

                        repeatMenu = false;

                        break;

                    default:

                        Console.WriteLine("Non hai selezionato un opzione valida");

                        break;
                }
            }


        }
    }
}