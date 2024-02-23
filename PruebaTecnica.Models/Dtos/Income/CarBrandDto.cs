using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnica.Models.Dtos.Income
{
    public class CarBrandDto
    {
        public int Id { get; set; }

        public string CarBrandName { get; set; } = null!;

        public bool CarBrandActive { get; set; }
    }
}
