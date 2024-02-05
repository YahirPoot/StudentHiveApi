using System;
using System.Collections.Generic;

namespace StudentHive.Domain.Entities;

public partial class TypesHouseRental
{
    public int IdTypeHouseRental { get; set; }

    public bool? OwnHouse { get; set; }

    public bool? SharedRoom { get; set; }

    public bool? SingleRoom { get; set; }

    public virtual ICollection<RentalHouse> RentalHouse { get; set; } = new List<RentalHouse>();
}
