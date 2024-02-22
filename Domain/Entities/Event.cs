using System;
using System.Collections.Generic;

namespace StudentHive.Domain.Entities;

public partial class Event
{
    public int IdEvent { get; set; }

    public string EventType { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public virtual ICollection<Request> Requests { get; set; } = new List<Request>();
}
