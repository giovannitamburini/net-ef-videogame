using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace net_ef_videogame
{
    public static class ManagerDBEFVideogame
    {
        public static void ShowSoftwareHouses()
        {
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
        }

        public static bool AddSoftwareHouse(SoftwareHouse softwareHouseToAdd)
        {
            using (VideogameContext db = new VideogameContext())
            {
                try
                {
                    db.Add(softwareHouseToAdd);

                    db.SaveChanges();

                    Console.WriteLine("La Software House è stata aggiunta con successo");

                    return true;

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                return false;
            }
        }

        public static bool AddVideogame(Videogame videogameToAdd)
        {
            using (VideogameContext db = new VideogameContext())
            {
                try
                {
                    db.Add(videogameToAdd);

                    db.SaveChanges();

                    return true;

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                return false;
            }
        }

        public static Videogame SearchVideogameById(long idVg)
        {
            using (VideogameContext db = new VideogameContext())
            {
                try
                {
                    List<Videogame> videogames = db.Videogames.OrderBy(videogame => videogame.VideogameId).ToList();

                    Videogame videogameFounded = db.Videogames.Where(vg => vg.VideogameId == idVg).First();

                    return videogameFounded;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                return new Videogame();
            }
        }

        public static List<Videogame> GetVideogameByString(string str)
        {
            using (VideogameContext db = new VideogameContext())
            {
                try
                {
                    List<Videogame> videogames = db.Videogames.OrderBy(videogame => videogame.VideogameId).ToList();

                    List<Videogame> videogamesFoundedByString = db.Videogames.Where(vg => vg.Name.Contains(str)).ToList();

                    return videogamesFoundedByString;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                return new List<Videogame>();
            }
        }

        public static bool DeleteVideogame(long idVg)
        {
            using (VideogameContext db = new VideogameContext())
            {
                try
                {
                    Videogame videogameToDelete = db.Videogames.SingleOrDefault(vg => vg.VideogameId == idVg);

                    db.Videogames.Remove(videogameToDelete);

                    db.SaveChanges();

                    Console.WriteLine($"Il videogame con id '{videogameToDelete.VideogameId}' e nome '{videogameToDelete.Name}' è stato eliminato");

                    return true;

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                return false;
            }
        }

        public static List<Videogame> getVideogamesListBySoftwareHouseId(long idSH)
        {
            using (VideogameContext db = new VideogameContext())
            {
                try
                {
                    List<Videogame> videogames = db.Videogames.OrderBy(videogame => videogame.VideogameId).ToList();

                    List<Videogame> videogamesBySoftwareHouseId = db.Videogames.Where(vg => vg.SoftwareHouseId == idSH).ToList();

                    return videogamesBySoftwareHouseId;

                    //foreach (Videogame vg in videogamesBySoftwareHouseId)
                    //{
                    //    Console.WriteLine(vg);
                    //}

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                return new List<Videogame>();
            }
        }
    }
}
