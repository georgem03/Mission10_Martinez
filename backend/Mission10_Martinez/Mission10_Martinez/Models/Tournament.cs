using System;
using System.Collections.Generic;

namespace Mission10_Martinez.Models;

public partial class Tournament
{
    public int TourneyID { get; set; }

    public DateOnly? TourneyDate { get; set; }

    public string? TourneyLocation { get; set; }

    public virtual ICollection<Tourney_Match> Tourney_Matches { get; set; } = new List<Tourney_Match>();
}
