using System;
using System.Collections.Generic;

namespace Mission10_Martinez.Models;

public partial class Team
{
    public int TeamID { get; set; }

    public string TeamName { get; set; } = null!;

    public int? CaptainID { get; set; }

    public virtual ICollection<Bowler> Bowlers { get; set; } = new List<Bowler>();

    public virtual ICollection<Tourney_Match> Tourney_MatchEvenLaneTeams { get; set; } = new List<Tourney_Match>();

    public virtual ICollection<Tourney_Match> Tourney_MatchOddLaneTeams { get; set; } = new List<Tourney_Match>();
}
