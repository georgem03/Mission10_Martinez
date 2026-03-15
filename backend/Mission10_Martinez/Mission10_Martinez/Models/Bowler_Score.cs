using System;
using System.Collections.Generic;

namespace Mission10_Martinez.Models;

public partial class Bowler_Score
{
    public int MatchID { get; set; }

    public short GameNumber { get; set; }

    public int BowlerID { get; set; }

    public short? RawScore { get; set; }

    public short? HandiCapScore { get; set; }

    public bool WonGame { get; set; }

    public virtual Bowler Bowler { get; set; } = null!;
}
