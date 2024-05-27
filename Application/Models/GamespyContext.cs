using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GameSpy.Models;

public partial class GameSpyContext : IdentityDbContext<AppUser>
{
    public GameSpyContext()
    {
    }

    public GameSpyContext(DbContextOptions<GameSpyContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Achievement> Achievements { get; set; }

    public virtual DbSet<Game> Games { get; set; }

    public virtual DbSet<AppUser> Users { get; set; }

    public virtual DbSet<UsersGames> UsersGames { get; set;}
    public virtual DbSet<UsersAchievements> UsersAchievements { get; set;}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Achievement>(entity =>
        {
            entity.HasKey(e => e.Achievementsid);

            entity.ToTable("ACHIEVEMENTS");

            entity.HasIndex(e => e.Gameid, "GAME_ACHIEVEMENTS_FK");

            entity.Property(e => e.Achievementsid)
                .ValueGeneratedNever()
                .HasColumnName("ACHIEVEMENTSID");
            entity.Property(e => e.Description)
                .HasMaxLength(2000)
                .IsUnicode(false)
                .HasColumnName("DESCRIPTION");
            entity.Property(e => e.Gameid).HasColumnName("GAMEID");
            entity.Property(e => e.Name)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("NAME");

            entity.HasOne(d => d.Game).WithMany(p => p.Achievements)
                .HasForeignKey(d => d.Gameid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ACHIEVEM_GAME_ACHI_GAMES");

        });


        modelBuilder.Entity<Game>(entity =>
        {
            entity.ToTable("GAMES");

            entity.Property(e => e.Gameid)
                .ValueGeneratedNever()
                .HasColumnName("GAMEID");
            entity.Property(e => e.Description)
                .HasMaxLength(2000)
                .IsUnicode(false)
                .HasColumnName("DESCRIPTION");
            entity.Property(e => e.Manufacturer)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("MANUFACTURER");
            entity.Property(e => e.Image)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("IMAGE");
            entity.Property(e => e.Name)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("NAME");
            entity.Property(e => e.Rating).HasColumnType("decimal(18, 2)");
        });

        modelBuilder.Entity<UsersGames>(entity => 
        {
            entity.HasKey(e => new { e.Gameid, e.Userid }).HasName("PK_USERS_GAMES");
            entity.ToTable("USER_GAME");
            entity.HasIndex(e => e.Userid).HasDatabaseName("USER_GAMES2_FK");
            entity.HasIndex(e => e.Gameid).HasDatabaseName("USER_GAMES_FK");
            entity.Property(e => e.Gameid).HasColumnName("GAMESID");
            entity.Property(e => e.Userid).HasColumnName("USERID");
            entity.Property(e => e.RecentTime).HasColumnName("RECENTTIME");
        });

        modelBuilder.Entity<UsersAchievements>(entity =>
        {
            entity.HasKey(e => new { e.Achievementid, e.Userid }).HasName("PK_USERS_ACHIEVEMENTS");
            entity.ToTable("USER_ACHIEVEMENTS");
            entity.HasIndex(e => e.Userid).HasDatabaseName("USER_ACHIEVEMENTS2_FK");
            entity.HasIndex(e => e.Achievementid).HasDatabaseName("USER_ACHIEVEMENTS_FK");
            entity.Property(e => e.Achievementid).HasColumnName("ACHIEVEMENTSID");
            entity.Property(e => e.Userid).HasColumnName("USERID");
        });

        modelBuilder.Entity<AppUser>(entity =>
        {
            entity.ToTable("USER");

            entity.HasIndex(e => e.NormalizedEmail, "EmailIndex");

            entity.HasIndex(e => e.NormalizedUserName, "UserNameIndex")
                .IsUnique()
                .HasFilter("([NormalizedUserName] IS NOT NULL)");

            entity.Property(e => e.Id).HasColumnName("USERID");
            entity.Property(e => e.Balance)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("BALANCE");
            entity.Property(e => e.Email).HasMaxLength(256);
            entity.Property(e => e.Firstname)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("FIRSTNAME");
            entity.Property(e => e.ProfilePicture)
            .HasMaxLength(200)
            .IsUnicode(false)
            .HasColumnName("PROFILEPICTURE");
            entity.Property(e => e.Lastname)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("LASTNAME");
            entity.Property(e => e.NormalizedEmail).HasMaxLength(256);
            entity.Property(e => e.NormalizedUserName).HasMaxLength(256);
            entity.Property(e => e.UserName).HasMaxLength(256);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
