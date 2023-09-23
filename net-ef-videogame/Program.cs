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

            BONUS : aggiungere un’altra voce di menu
            stampa tutti i videogiochi prodotti da una software house (all’utente verrà chiesto l’id della software house della quale mostrare i videogame)
            -------------------------------------------------------------------------------------
             */

            bool repeatMenu = true;

            while (repeatMenu)
            {
                Console.WriteLine(@"
1 - inserire una nuova software house
2 - inserire un nuovo videogioco
3 - ricercare un videogioco per id
4 - ricercare tutti i videogiochi aventi il nome contenente una determinata stringa inserita in input
5 - cancellare un videogioco
6 - stampa tutti i videogiochi prodotti da una software house
7 - chiudere il programma
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

                        bool insertedSH = ManagerDBEFVideogame.AddSoftwareHouse(newSoftwareHouse);

                        if (insertedSH)
                        {
                            Console.WriteLine("Software House inserita con successo");
                        }
                        else
                        {
                            Console.WriteLine("Inserimento non riuscito");
                        }

                        break;

                    case 2:

                        Console.WriteLine("Hai selezionato l'opzione 2: inserire un nuovo videogioco");

                        Console.WriteLine("Inserisci i dati del videogame");

                        Console.Write("Inserisci il nome del videogame: ");
                        string nameVg = Console.ReadLine();

                        Console.Write("Inserisci il riepilogo del videogame: ");
                        string overview = Console.ReadLine();

                        Console.Write("Inserisci la data di realizzazione del videogame (dd/MM/yyyy): ");
                        DateTime releaseDate = DateTime.Parse(Console.ReadLine());

                        ManagerDBEFVideogame.ShowSoftwareHouses();

                        Console.Write("Inserisci l'id della softwarehouse tra l'elenco fornito per associare il vg alla sh: ");
                        long softwareHouseId = long.Parse(Console.ReadLine());

                        Videogame newVideogame = new Videogame()
                        {
                            Name = nameVg,
                            Overview = overview,
                            Release_date = releaseDate,
                            SoftwareHouseId = softwareHouseId
                        };

                        bool insertedVg = ManagerDBEFVideogame.AddVideogame(newVideogame);

                        if (insertedVg)
                        {
                            Console.WriteLine("Videogame inserito con successo");
                        }
                        else
                        {
                            Console.WriteLine("Inserimento non riuscito");
                        }

                        break;

                    case 3:

                        Console.WriteLine("Hai selezionato l'opzione 3: ricercare un videogioco per id");

                        Console.Write("Inserisci l'id del videogame che vuoi cercare: ");
                        long idVideogame = long.Parse(Console.ReadLine());

                        Videogame vgFounded = ManagerDBEFVideogame.SearchVideogameById(idVideogame);

                        Console.WriteLine($"Videogame trovato: {vgFounded}");

                        break;

                    case 4:

                        Console.WriteLine("Hai selezionato l'opzione 4: ricercare tutti i videogiochi aventi il nome contenente una determinata stringa inserita in input");

                        Console.Write("Inserisci una stringa per ricercare uno o più videogames che contengono nel nome la stringa da te inserita: ");
                        string stringtoSearch = Console.ReadLine();

                        List<Videogame> listObteined = ManagerDBEFVideogame.GetVideogameByString(stringtoSearch);

                        foreach (Videogame vg in listObteined)
                        {
                            Console.WriteLine(vg);
                        }

                        break;

                    case 5:

                        Console.WriteLine("Hai selezionato l'opzione 5: cancellare un videogioco");

                        Console.Write("Inserisci l'id del videogame che vuoi eliminare: ");
                        long idVideogameToBeDeleted = long.Parse(Console.ReadLine());

                        bool obtained = ManagerDBEFVideogame.DeleteVideogame(idVideogameToBeDeleted);

                        if (obtained)
                        {
                            Console.WriteLine("Videogame eliminato con successo");
                        }
                        else
                        {
                            Console.WriteLine("Qualcosa è andato storto,il videogame non è stato eliminato");
                        }

                        break;

                    case 6:

                        Console.WriteLine("Hai selezionato l'opzione 6: stampa tutti i videogiochi prodotti da una software house");

                        using (VideogameContext db = new VideogameContext())
                        {
                            try
                            {
                                List<SoftwareHouse> softwareHouses = db.SoftwareHouses.ToList<SoftwareHouse>();

                                foreach (SoftwareHouse sh in softwareHouses)
                                {
                                    Console.WriteLine(sh);
                                }
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                        }

                        Console.Write("Inseirisci l'id della software house, tra le opzioni elencate, per ottenere i suoi videogames: ");
                        long softwareHouseIdToSearch = long.Parse(Console.ReadLine());

                        List<Videogame> listVgObteined = ManagerDBEFVideogame.getVideogamesListBySoftwareHouseId(softwareHouseIdToSearch);

                        foreach (Videogame vg in listVgObteined)
                        {
                            Console.WriteLine(vg);
                        }

                        break;

                    case 7:

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