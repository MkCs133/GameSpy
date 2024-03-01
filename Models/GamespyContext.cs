using System;
using System.Collections.Generic;
using GameSpy.Data;
using Microsoft.EntityFrameworkCore;

namespace GameSpy.Models;

public partial class GamespyContext : IdentityContext

{

    public GamespyContext(DbContextOptions<GamespyContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Achievement> Achievements { get; set; }

    public virtual DbSet<Cpu> Cpus { get; set; }

    public virtual DbSet<Game> Games { get; set; }

    public virtual DbSet<Gpu> Gpus { get; set; }

    public virtual DbSet<Motherboard> Motherboards { get; set; }

    public virtual DbSet<Pc> Pcs { get; set; }

    public virtual DbSet<Ram> Rams { get; set; }

    public virtual DbSet<Storage> Storages { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-8LRAK3D\\SQLEXPRESS;Database=GAMESPY;Trusted_Connection=True;Encrypt=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
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

            entity.HasMany(d => d.Users).WithMany(p => p.Achievements)
                .UsingEntity<Dictionary<string, object>>(
                    "UserAchievement",
                    r => r.HasOne<User>().WithMany()
                        .HasForeignKey("Userid")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_USER_ACH_USER_ACHI_USER"),
                    l => l.HasOne<Achievement>().WithMany()
                        .HasForeignKey("Achievementsid")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_USER_ACH_USER_ACHI_ACHIEVEM"),
                    j =>
                    {
                        j.HasKey("Achievementsid", "Userid");
                        j.ToTable("USER_ACHIEVEMENTS");
                        j.HasIndex(new[] { "Userid" }, "USER_ACHIEVEMENTS2_FK");
                        j.HasIndex(new[] { "Achievementsid" }, "USER_ACHIEVEMENTS_FK");
                        j.IndexerProperty<int>("Achievementsid").HasColumnName("ACHIEVEMENTSID");
                        j.IndexerProperty<int>("Userid").HasColumnName("USERID");
                    });
        });

        modelBuilder.Entity<Cpu>(entity =>
        {
            entity.ToTable("CPU");

            entity.HasIndex(e => e.Pcid, "PC_CPU2_FK");

            entity.Property(e => e.Cpuid)
                .ValueGeneratedNever()
                .HasColumnName("CPUID");
            entity.Property(e => e.Manufacturer)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("MANUFACTURER");
            entity.Property(e => e.Name)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("NAME");
            entity.Property(e => e.Pcid).HasColumnName("PCID");
            entity.Property(e => e.Speed)
                .HasColumnType("decimal(3, 2)")
                .HasColumnName("SPEED");

            entity.HasOne(d => d.Pc).WithMany(p => p.Cpus)
                .HasForeignKey(d => d.Pcid)
                .HasConstraintName("FK_CPU_PC_CPU2_PC");
        });

        modelBuilder.Entity<Game>(entity =>
        {
            entity.ToTable("GAMES");

            entity.HasIndex(e => e.Pcid, "PC_GAMES_FK");

            entity.HasIndex(e => e.Userid, "USER_GAMES_FK");

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
            entity.Property(e => e.Name)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("NAME");
            entity.Property(e => e.Pcid).HasColumnName("PCID");
            entity.Property(e => e.Rating)
                .HasColumnType("numeric(2, 1)")
                .HasColumnName("RATING");
            entity.Property(e => e.Userid).HasColumnName("USERID");

            entity.HasOne(d => d.Pc).WithMany(p => p.Games)
                .HasForeignKey(d => d.Pcid)
                .HasConstraintName("FK_GAMES_PC_GAMES_PC");

            entity.HasOne(d => d.User).WithMany(p => p.Games)
                .HasForeignKey(d => d.Userid)
                .HasConstraintName("FK_GAMES_USER_GAME_USER");
        });

        modelBuilder.Entity<Gpu>(entity =>
        {
            entity.ToTable("GPU");

            entity.HasIndex(e => e.Pcid, "PC_GPU2_FK");

            entity.Property(e => e.Gpuid)
                .ValueGeneratedNever()
                .HasColumnName("GPUID");
            entity.Property(e => e.Capacity)
                .HasColumnType("decimal(3, 2)")
                .HasColumnName("CAPACITY");
            entity.Property(e => e.Manufacturer)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("MANUFACTURER");
            entity.Property(e => e.Model)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("MODEL");
            entity.Property(e => e.Name)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("NAME");
            entity.Property(e => e.Pcid).HasColumnName("PCID");

            entity.HasOne(d => d.Pc).WithMany(p => p.Gpus)
                .HasForeignKey(d => d.Pcid)
                .HasConstraintName("FK_GPU_PC_GPU2_PC");
        });

        modelBuilder.Entity<Motherboard>(entity =>
        {
            entity.ToTable("MOTHERBOARD");

            entity.HasIndex(e => e.Pcid, "PC_MOTHERBOARD2_FK");

            entity.Property(e => e.Motherboardid)
                .ValueGeneratedNever()
                .HasColumnName("MOTHERBOARDID");
            entity.Property(e => e.Manufacturer)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("MANUFACTURER");
            entity.Property(e => e.Name)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("NAME");
            entity.Property(e => e.Pcid).HasColumnName("PCID");

            entity.HasOne(d => d.Pc).WithMany(p => p.Motherboards)
                .HasForeignKey(d => d.Pcid)
                .HasConstraintName("FK_MOTHERBO_PC_MOTHER_PC");
        });

        modelBuilder.Entity<Pc>(entity =>
        {
            entity.ToTable("PC");

            entity.HasIndex(e => e.Cpuid, "PC_CPU_FK");

            entity.HasIndex(e => e.Gpuid, "PC_GPU_FK");

            entity.HasIndex(e => e.Motherboardid, "PC_MOTHERBOARD_FK");

            entity.HasIndex(e => e.Userid, "PC_OWNER_FK");

            entity.HasIndex(e => e.Ramid, "PC_RAM_FK");

            entity.HasIndex(e => e.Storageid, "PC_STORAGE_FK");

            entity.Property(e => e.Pcid)
                .ValueGeneratedNever()
                .HasColumnName("PCID");
            entity.Property(e => e.Cpuid).HasColumnName("CPUID");
            entity.Property(e => e.Gpuid).HasColumnName("GPUID");
            entity.Property(e => e.Motherboardid).HasColumnName("MOTHERBOARDID");
            entity.Property(e => e.Name)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("NAME");
            entity.Property(e => e.Ramid).HasColumnName("RAMID");
            entity.Property(e => e.Storageid).HasColumnName("STORAGEID");
            entity.Property(e => e.Userid).HasColumnName("USERID");

            entity.HasOne(d => d.Cpu).WithMany(p => p.Pcs)
                .HasForeignKey(d => d.Cpuid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PC_PC_CPU_CPU");

            entity.HasOne(d => d.Gpu).WithMany(p => p.Pcs)
                .HasForeignKey(d => d.Gpuid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PC_PC_GPU_GPU");

            entity.HasOne(d => d.Motherboard).WithMany(p => p.Pcs)
                .HasForeignKey(d => d.Motherboardid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PC_PC_MOTHER_MOTHERBO");

            entity.HasOne(d => d.Ram).WithMany(p => p.Pcs)
                .HasForeignKey(d => d.Ramid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PC_PC_RAM_RAM");

            entity.HasOne(d => d.Storage).WithMany(p => p.Pcs)
                .HasForeignKey(d => d.Storageid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PC_PC_STORAG_STORAGE");

            entity.HasOne(d => d.User).WithMany(p => p.Pcs)
                .HasForeignKey(d => d.Userid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PC_PC_OWNER_USER");
        });

        modelBuilder.Entity<Ram>(entity =>
        {
            entity.ToTable("RAM");

            entity.HasIndex(e => e.Pcid, "PC_RAM2_FK");

            entity.Property(e => e.Ramid)
                .ValueGeneratedNever()
                .HasColumnName("RAMID");
            entity.Property(e => e.Capacity)
                .HasColumnType("decimal(3, 2)")
                .HasColumnName("CAPACITY");
            entity.Property(e => e.Model)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("MODEL");
            entity.Property(e => e.Name)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("NAME");
            entity.Property(e => e.Pcid).HasColumnName("PCID");
            entity.Property(e => e.Speed)
                .HasColumnType("decimal(3, 2)")
                .HasColumnName("SPEED");

            entity.HasOne(d => d.Pc).WithMany(p => p.Rams)
                .HasForeignKey(d => d.Pcid)
                .HasConstraintName("FK_RAM_PC_RAM2_PC");
        });

        modelBuilder.Entity<Storage>(entity =>
        {
            entity.ToTable("STORAGE");

            entity.HasIndex(e => e.Pcid, "PC_STORAGE2_FK");

            entity.Property(e => e.Storageid)
                .ValueGeneratedNever()
                .HasColumnName("STORAGEID");
            entity.Property(e => e.Capacity)
                .HasColumnType("decimal(3, 2)")
                .HasColumnName("CAPACITY");
            entity.Property(e => e.Name)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("NAME");
            entity.Property(e => e.Pcid).HasColumnName("PCID");
            entity.Property(e => e.Type)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("TYPE");

            entity.HasOne(d => d.Pc).WithMany(p => p.Storages)
                .HasForeignKey(d => d.Pcid)
                .HasConstraintName("FK_STORAGE_PC_STORAG_PC");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("USER");

            entity.Property(e => e.Userid)
                .ValueGeneratedNever()
                .HasColumnName("USERID");
            entity.Property(e => e.Balence)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("BALENCE");
            entity.Property(e => e.Firstname)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("FIRSTNAME");
            entity.Property(e => e.Lastname)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("LASTNAME");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
