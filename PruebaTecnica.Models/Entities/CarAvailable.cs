using System;
using System.Collections.Generic;

namespace PruebaTecnica.Models.Entities;

public partial class CarAvailable
{
    public int Id { get; set; }

    public int CarId { get; set; }

    public int CollectionLocationId { get; set; }

    public int ReturnLocationId { get; set; }

    public bool CarAvailableActive { get; set; }

    public virtual Car Car { get; set; } = null!;

    public virtual Location CollectionLocation { get; set; } = null!;

    public virtual Location ReturnLocation { get; set; } = null!;
}
