using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace net_ef_videogame
{
    public class Videogame
    {
        public long VideogameId { get; set; }
        public string Name { get; set; }
        public string Overview { get; set; }
        public DateTime Release_date { get; set; }
        
        public long SoftwareHouseId { get; set; }
        public SoftwareHouse SoftwareHouse { get; set; }
        

        public override string ToString()
        {
            return $"VIDEOGAME TROVATO -> id: {VideogameId} - nome: {Name} - overview: {Overview} - release date: {Release_date} - software house id: {SoftwareHouseId}";
        }
    }
}
