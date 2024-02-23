using System;
using System.Collections.Generic;

namespace PruebaTecnica.Models.Entities;

public partial class Department
{
    public int Id { get; set; }

    public int CountryId { get; set; }

    public int DepartmentCode { get; set; }

    public string DepartmentName { get; set; } = null!;

    public bool DepartmentActive { get; set; }

    public virtual ICollection<City> Cities { get; set; } = new List<City>();

    public virtual Country Country { get; set; } = null!;
}
