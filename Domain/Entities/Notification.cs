using System;
using System.Collections.Generic;

namespace StudentHive.Domain.Entities;

public partial class Notification
{
    public int IdNotification { get; set; }

    public int? IdUser { get; set; }

    public int? IdRequest { get; set; }

    public string Message { get; set; } = null!;

    public bool IsRead { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual Request? IdRequestNavigation { get; set; }

    public virtual User? IdUserNavigation { get; set; }
}
