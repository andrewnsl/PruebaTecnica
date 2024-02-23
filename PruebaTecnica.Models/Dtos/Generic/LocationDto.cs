using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnica.Models.Dtos.Generic
{
    public class LocationDto
    {
        public int Id { get; set; }

        public int CityId { get; set; }

        public string LocationName { get; set; } = null!;

        public bool LocationActive { get; set; }
    }
}
