using System;
using System.Collections.Generic;

namespace Mission10_Martinez.Models;

public partial class ztblWeek
{
    public DateOnly WeekStart { get; set; }

    public DateOnly? WeekEnd { get; set; }
}
