using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Mission10_Martinez.Models;

public partial class BowlingLeagueContext : DbContext
{
    public BowlingLeagueContext()
    {
    }

    public BowlingLeagueContext(DbContextOptions<BowlingLeagueContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Bowler> Bowlers { get; set; }

    public virtual DbSet<Bowler_Score> Bowler_Scores { get; set; }

    public virtual DbSet<Match_Game> Match_Games { get; set; }

    public virtual DbSet<Team> Teams { get; set; }

    public virtual DbSet<Tournament> Tournaments { get; set; }

    public virtual DbSet<Tourney_Match> Tourney_Matches { get; set; }

    public virtual DbSet<ztblBowlerRating> ztblBowlerRatings { get; set; }

    public virtual DbSet<ztblSkipLabel> ztblSkipLabels { get; set; }

    public virtual DbSet<ztblWeek> ztblWeeks { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlite("Data Source=Data/BowlingLeague.sqlite");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Bowler>(entity =>
        {
            entity.HasIndex(e => e.BowlerLastName, "BowlerLastName");

            entity.HasIndex(e => e.TeamID, "BowlersTeamID");

            entity.Property(e => e.BowlerID).HasColumnType("INT");
            entity.Property(e => e.BowlerAddress).HasColumnType("nvarchar (50)");
            entity.Property(e => e.BowlerCity).HasColumnType("nvarchar (50)");
            entity.Property(e => e.BowlerFirstName).HasColumnType("nvarchar (50)");
            entity.Property(e => e.BowlerLastName).HasColumnType("nvarchar (50)");
            entity.Property(e => e.BowlerMiddleInit).HasColumnType("nvarchar (1)");
            entity.Property(e => e.BowlerPhoneNumber).HasColumnType("nvarchar (14)");
            entity.Property(e => e.BowlerState).HasColumnType("nvarchar (2)");
            entity.Property(e => e.BowlerZip).HasColumnType("nvarchar (10)");
            entity.Property(e => e.TeamID).HasColumnType("INT");

            entity.HasOne(d => d.Team).WithMany(p => p.Bowlers).HasForeignKey(d => d.TeamID);
        });

        modelBuilder.Entity<Bowler_Score>(entity =>
        {
            entity.HasKey(e => new { e.MatchID, e.GameNumber, e.BowlerID });

            entity.HasIndex(e => e.BowlerID, "BowlerID");

            entity.HasIndex(e => new { e.MatchID, e.GameNumber }, "MatchGamesBowlerScores");

            entity.Property(e => e.MatchID).HasColumnType("INT");
            entity.Property(e => e.GameNumber).HasColumnType("smallint");
            entity.Property(e => e.BowlerID).HasColumnType("INT");
            entity.Property(e => e.HandiCapScore)
                .HasDefaultValue((short)0)
                .HasColumnType("smallint");
            entity.Property(e => e.RawScore)
                .HasDefaultValue((short)0)
                .HasColumnType("smallint");
            entity.Property(e => e.WonGame).HasColumnType("bit");

            entity.HasOne(d => d.Bowler).WithMany(p => p.Bowler_Scores)
                .HasForeignKey(d => d.BowlerID)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Match_Game>(entity =>
        {
            entity.HasKey(e => new { e.MatchID, e.GameNumber });

            entity.HasIndex(e => e.WinningTeamID, "Team1ID");

            entity.HasIndex(e => e.MatchID, "TourneyMatchesMatchGames");

            entity.Property(e => e.MatchID).HasColumnType("INT");
            entity.Property(e => e.GameNumber).HasColumnType("smallint");
            entity.Property(e => e.WinningTeamID)
                .HasDefaultValue(0)
                .HasColumnType("INT");

            entity.HasOne(d => d.Match).WithMany(p => p.Match_Games)
                .HasForeignKey(d => d.MatchID)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Team>(entity =>
        {
            entity.HasIndex(e => e.TeamID, "TeamID").IsUnique();

            entity.Property(e => e.TeamID).HasColumnType("INT");
            entity.Property(e => e.CaptainID).HasColumnType("INT");
            entity.Property(e => e.TeamName).HasColumnType("nvarchar (50)");
        });

        modelBuilder.Entity<Tournament>(entity =>
        {
            entity.HasKey(e => e.TourneyID);

            entity.Property(e => e.TourneyID).HasColumnType("INT");
            entity.Property(e => e.TourneyDate).HasColumnType("date");
            entity.Property(e => e.TourneyLocation).HasColumnType("nvarchar (50)");
        });

        modelBuilder.Entity<Tourney_Match>(entity =>
        {
            entity.HasKey(e => e.MatchID);

            entity.HasIndex(e => e.OddLaneTeamID, "TourneyMatchesOdd");

            entity.HasIndex(e => e.TourneyID, "TourneyMatchesTourneyID");

            entity.HasIndex(e => e.EvenLaneTeamID, "Tourney_MatchesEven");

            entity.Property(e => e.MatchID).HasColumnType("INT");
            entity.Property(e => e.EvenLaneTeamID)
                .HasDefaultValue(0)
                .HasColumnType("INT");
            entity.Property(e => e.Lanes).HasColumnType("nvarchar (5)");
            entity.Property(e => e.OddLaneTeamID)
                .HasDefaultValue(0)
                .HasColumnType("INT");
            entity.Property(e => e.TourneyID)
                .HasDefaultValue(0)
                .HasColumnType("INT");

            entity.HasOne(d => d.EvenLaneTeam).WithMany(p => p.Tourney_MatchEvenLaneTeams).HasForeignKey(d => d.EvenLaneTeamID);

            entity.HasOne(d => d.OddLaneTeam).WithMany(p => p.Tourney_MatchOddLaneTeams).HasForeignKey(d => d.OddLaneTeamID);

            entity.HasOne(d => d.Tourney).WithMany(p => p.Tourney_Matches).HasForeignKey(d => d.TourneyID);
        });

        modelBuilder.Entity<ztblBowlerRating>(entity =>
        {
            entity.HasKey(e => e.BowlerRating);

            entity.Property(e => e.BowlerRating).HasColumnType("nvarchar (15)");
            entity.Property(e => e.BowlerHighAvg).HasColumnType("smallint");
            entity.Property(e => e.BowlerLowAvg).HasColumnType("smallint");
        });

        modelBuilder.Entity<ztblSkipLabel>(entity =>
        {
            entity.HasKey(e => e.LabelCount);

            entity.Property(e => e.LabelCount)
                .ValueGeneratedNever()
                .HasColumnType("INT");
        });

        modelBuilder.Entity<ztblWeek>(entity =>
        {
            entity.HasKey(e => e.WeekStart);

            entity.Property(e => e.WeekStart).HasColumnType("date");
            entity.Property(e => e.WeekEnd).HasColumnType("date");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
