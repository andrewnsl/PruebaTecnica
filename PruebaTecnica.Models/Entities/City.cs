using System;
using System.Collections.Generic;

namespace PruebaTecnica.Models.Entities;

public partial class City
{
    public int Id { get; set; }

    public int DepartmentId { get; set; }

    public int CityCode { get; set; }

    public string CityName { get; set; } = null!;

    public bool CityActive { get; set; }

    public virtual Department Department { get; set; } = null!;

    public virtual ICollection<Location> Locations { get; set; } = new List<Location>();
}
