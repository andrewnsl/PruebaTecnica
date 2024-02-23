using System;
using System.Collections.Generic;

namespace PruebaTecnica.Models.Entities;

public partial class CarBrand
{
    public int Id { get; set; }

    public string CarBrandName { get; set; } = null!;

    public bool CarBrandActive { get; set; }

    public virtual ICollection<Car> Cars { get; set; } = new List<Car>();
}
