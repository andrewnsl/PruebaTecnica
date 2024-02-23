using PruebaTecnica.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnica.Models.Dtos.Income
{
    public class CarDto
    {
        public int Id { get; set; }

        public int CarBrand { get; set; }

        public int CarModel { get; set; }

        public int CarCylinder { get; set; }

        public bool CarActive { get; set; }

        public CarBrandDto CarBrandNavigation { get; set; } = null!;
    }
}
