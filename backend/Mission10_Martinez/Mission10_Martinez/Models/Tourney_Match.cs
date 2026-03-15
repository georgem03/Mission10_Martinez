using System;
using System.Collections.Generic;

namespace Mission10_Martinez.Models;

public partial class Tourney_Match
{
    public int MatchID { get; set; }

    public int? TourneyID { get; set; }

    public string? Lanes { get; set; }

    public int? OddLaneTeamID { get; set; }

    public int? EvenLaneTeamID { get; set; }

    public virtual Team? EvenLaneTeam { get; set; }

    public virtual ICollection<Match_Game> Match_Games { get; set; } = new List<Match_Game>();

    public virtual Team? OddLaneTeam { get; set; }

    public virtual Tournament? Tourney { get; set; }
}
