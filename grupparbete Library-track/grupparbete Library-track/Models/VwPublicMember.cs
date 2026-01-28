using System;
using System.Collections.Generic;

namespace grupparbete_Library_track.Models;

public partial class VwPublicMember
{
    public int MemberId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;
}
