using PruebaTecnica.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnica.Models.Dtos.Generic
{
    public class DepartmentDto
    {
        public int Id { get; set; }

        public int CountryId { get; set; }

        public int DepartmentCode { get; set; }

        public string DepartmentName { get; set; } = null!;

        public bool DepartmentActive { get; set; }
    }
}
