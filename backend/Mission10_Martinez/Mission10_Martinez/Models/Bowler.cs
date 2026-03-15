using System;
using System.Collections.Generic;

namespace Mission10_Martinez.Models;

public partial class Bowler
{
    public int BowlerID { get; set; }

    public string? BowlerLastName { get; set; }

    public string? BowlerFirstName { get; set; }

    public string? BowlerMiddleInit { get; set; }

    public string? BowlerAddress { get; set; }

    public string? BowlerCity { get; set; }

    public string? BowlerState { get; set; }

    public string? BowlerZip { get; set; }

    public string? BowlerPhoneNumber { get; set; }

    public int? TeamID { get; set; }

    public virtual ICollection<Bowler_Score> Bowler_Scores { get; set; } = new List<Bowler_Score>();

    public virtual Team? Team { get; set; }
}
