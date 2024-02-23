using System;
using System.Collections.Generic;

namespace PruebaTecnica.Models.Entities;

public partial class Location
{
    public int Id { get; set; }

    public int CityId { get; set; }

    public string LocationName { get; set; } = null!;

    public bool LocationActive { get; set; }

    public virtual ICollection<CarAvailable> CarAvailableCollectionLocations { get; set; } = new List<CarAvailable>();

    public virtual ICollection<CarAvailable> CarAvailableReturnLocations { get; set; } = new List<CarAvailable>();

    public virtual City City { get; set; } = null!;
}
