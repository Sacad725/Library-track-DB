using System;
using System.Collections.Generic;

namespace grupparbete_Library_track.Models;

public partial class Reservation
{
    public int ReservationId { get; set; }

    public int MemberId { get; set; }

    public int BookId { get; set; }

    public DateOnly? ReservedAt { get; set; }

    public string? Status { get; set; }

    public virtual Book Book { get; set; } = null!;

    public virtual Member Member { get; set; } = null!;
}
