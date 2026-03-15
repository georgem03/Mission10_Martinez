using System;
using System.Collections.Generic;

namespace Mission10_Martinez.Models;

public partial class Match_Game
{
    public int MatchID { get; set; }

    public short GameNumber { get; set; }

    public int? WinningTeamID { get; set; }

    public virtual Tourney_Match Match { get; set; } = null!;
}
