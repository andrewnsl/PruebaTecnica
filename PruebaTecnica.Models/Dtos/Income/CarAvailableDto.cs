using PruebaTecnica.Models.Dtos.Generic;
using PruebaTecnica.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnica.Models.Dtos.Income
{
    public class CarAvailableDto
    {
        public int Id { get; set; }

        public int CarId { get; set; }

        public int CollectionLocationId { get; set; }

        public int ReturnLocationId { get; set; }

        public bool CarAvailableActive { get; set; }
        public CarDto Car { get; set; } = null!;

        public LocationDto CollectionLocation { get; set; } = null!;

        public LocationDto ReturnLocation { get; set; } = null!;
    }
}
