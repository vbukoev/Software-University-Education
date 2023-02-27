using Microsoft.EntityFrameworkCore;

using P02_FootballBetting.Data.Models;

namespace P02_FootballBetting.Data
{
    public class FootballBettingContext : DbContext
    {
        public FootballBettingContext()
        {
        }

        public FootballBettingContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Bet> Bets { get; set; } = null!;
        public DbSet<Color> Colors { get; set; } = null!;
        public DbSet<Country> Countries { get; set; } = null!;
        public DbSet<Game> Games { get; set; } = null!;
        public DbSet<Player> Players { get; set; } = null!;
        public DbSet<PlayerStatistic> PlayersStatistics { get; set; } = null!;
        public DbSet<Position> Positions { get; set; } = null!;
        public DbSet<Team> Teams { get; set; } = null!;
        public DbSet<Town> Towns { get; set; } = null!;
        public DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=FootballBetting;Integrated Security=True;TrustServerCertificate=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Team>(entity =>
            {
                entity.HasKey(e => e.TeamId);

                entity.HasOne(t => t.PrimaryKitColor)
                .WithMany(c => c.PrimaryKitTeams)
                .HasForeignKey(t => t.PrimaryKitColorId);

                entity.HasOne(t => t.SecondaryKitColor)
                .WithMany(c => c.SecondaryKitTeams)
                .HasForeignKey(t => t.SecondaryKitColorId);

                entity.HasOne(to => to.Town)
                .WithMany(t => t.Teams)
                .HasForeignKey(t => t.TownId);

                entity.HasMany(t => t.Players)
                .WithOne(p => p.Team)
                .HasForeignKey(t => t.TeamId);
            });

            modelBuilder.Entity<Color>(entity =>
            {
                entity.HasKey(c => c.ColorId);
            });

            modelBuilder.Entity<Town>(entity =>
            {
                entity.HasKey(t => t.TownId);

                entity.HasOne(t => t.Country)
                .WithMany(c => c.Towns)
                .HasForeignKey(c => c.TownId);
            });

            modelBuilder.Entity<Game>(entity =>
            {
                entity.HasKey(g => g.GameId);

                entity.HasOne(t => t.HomeTeam)
                .WithMany(g => g.HomeGames)
                .HasForeignKey(g => g.HomeTeamId);

                entity.HasOne(at => at.AwayTeam)
                .WithMany(g => g.AwayGames)
                .HasForeignKey(g => g.AwayTeamId);

                entity.HasOne(g => g.Bet)
                .WithMany(b => b.Games)
                .HasForeignKey(b => b.GameId);
            });

            modelBuilder.Entity<Bet>(entity =>
            {
                entity.HasKey(b => b.BetId);

                entity.Property(p => p.Prediction)
                .IsRequired();

                entity.HasOne(b => b.User)
                .WithMany(u => u.Bets)
                .HasForeignKey(u => u.UserId);
            });

            modelBuilder.Entity<Player>(entity =>
            {
                entity.HasKey(p => p.PlayerId);

                entity.HasOne(p => p.Position)
                .WithMany(pos => pos.Players)
                .HasForeignKey(pos => pos.PlayerId);
            });

            modelBuilder.Entity<PlayerStatistic>()
                .HasKey(ps => new { ps.PlayerId, ps.GameId });

            modelBuilder.Entity<PlayerStatistic>()
                .HasOne(ps => ps.Player)
                .WithMany(p => p.PlayersStatistics)
                .HasForeignKey(ps => ps.PlayerId);

            modelBuilder.Entity<PlayerStatistic>()
                .HasOne(ps => ps.Game)
                .WithMany(g => g.PlayersStatistics)
                .HasForeignKey(ps => ps.GameId);
        }
    }
}
