using System;
using System.Collections.Generic;

namespace grupparbete_Library_track.Models;

public partial class VwLoanReport
{
    public string FirstName { get; set; } = null!;

    public string Title { get; set; } = null!;

    public string? Status { get; set; }

    public DateOnly? LoanDate { get; set; }
}
