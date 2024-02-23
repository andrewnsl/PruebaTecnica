using PruebaTecnica.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnica.Models.Dtos.Generic
{
    public class CityDto
    {
        public int Id { get; set; }

        public int DepartmentId { get; set; }

        public int CityCode { get; set; }

        public string CityName { get; set; } = null!;

        public bool CityActive { get; set; }
    }
}
