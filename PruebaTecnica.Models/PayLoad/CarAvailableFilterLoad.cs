using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnica.Models.PayLoad
{
    public class CarAvailableFilterLoad
    {
        public int? DepartmentId { get; set; }
        public int? CityId { get; set; }
        public int? CollectionLocationId { get; set; }
        public int? ReturnLocationId { get; set; }
    }
}
