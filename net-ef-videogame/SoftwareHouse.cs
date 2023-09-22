using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace net_ef_videogame
{
    public class SoftwareHouse
    {
        public long SoftwareHouseId { get; set; }
        public string Name { get; set; }
        public string TaxId { get; set; }
        public string City { get; set; }
        public string Country { get; set; }

        public List<Videogame> Videogames { get; set; }

        public override string ToString()
        {
            return $"Software House id: {SoftwareHouseId}, Software Name {Name}";
        }
    }
}
