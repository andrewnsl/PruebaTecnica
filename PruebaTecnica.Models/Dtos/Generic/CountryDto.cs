using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnica.Models.Dtos.Generic
{
    public class CountryDto
    {
        public int Id { get; set; }

        public int CountryCode { get; set; }

        public string CountryName { get; set; } = null!;

        public bool CountryActive { get; set; }
    }
}
