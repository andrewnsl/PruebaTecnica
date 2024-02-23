using System;
using System.Collections.Generic;

namespace PruebaTecnica.Models.Entities;

public partial class Car
{
    public int Id { get; set; }

    public int CarBrand { get; set; }

    public int CarModel { get; set; }

    public int CarCylinder { get; set; }

    public bool CarActive { get; set; }

    public virtual ICollection<CarAvailable> CarAvailables { get; set; } = new List<CarAvailable>();

    public virtual CarBrand CarBrandNavigation { get; set; } = null!;
}
