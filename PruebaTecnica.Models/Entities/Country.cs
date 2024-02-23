using System;
using System.Collections.Generic;

namespace PruebaTecnica.Models.Entities;

public partial class Country
{
    public int Id { get; set; }

    public int CountryCode { get; set; }

    public string CountryName { get; set; } = null!;

    public bool CountryActive { get; set; }

    public virtual ICollection<Department> Departments { get; set; } = new List<Department>();
}
