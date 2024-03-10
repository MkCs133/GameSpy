﻿// <auto-generated />
using System;
using GameSpy.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GameSpy.Migrations
{
    [DbContext(typeof(GameSpyContext))]
    [Migration("20240305230431_Migration2")]
    partial class Migration2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("GameSpy.Models.Achievement", b =>
                {
                    b.Property<int>("Achievementsid")
                        .HasColumnType("int")
                        .HasColumnName("ACHIEVEMENTSID");

                    b.Property<string>("Description")
                        .HasMaxLength(2000)
                        .IsUnicode(false)
                        .HasColumnType("varchar(2000)")
                        .HasColumnName("DESCRIPTION");

                    b.Property<int>("Gameid")
                        .HasColumnType("int")
                        .HasColumnName("GAMEID");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(60)
                        .IsUnicode(false)
                        .HasColumnType("varchar(60)")
                        .HasColumnName("NAME");

                    b.HasKey("Achievementsid");

                    b.HasIndex(new[] { "Gameid" }, "GAME_ACHIEVEMENTS_FK");

                    b.ToTable("ACHIEVEMENTS", (string)null);
                });

            modelBuilder.Entity("GameSpy.Models.Cpu", b =>
                {
                    b.Property<int>("Cpuid")
                        .HasColumnType("int")
                        .HasColumnName("CPUID");

                    b.Property<string>("Manufacturer")
                        .IsRequired()
                        .HasMaxLength(60)
                        .IsUnicode(false)
                        .HasColumnType("varchar(60)")
                        .HasColumnName("MANUFACTURER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(60)
                        .IsUnicode(false)
                        .HasColumnType("varchar(60)")
                        .HasColumnName("NAME");

                    b.Property<int?>("Pcid")
                        .HasColumnType("int")
                        .HasColumnName("PCID");

                    b.Property<decimal>("Speed")
                        .HasColumnType("decimal(3, 2)")
                        .HasColumnName("SPEED");

                    b.HasKey("Cpuid");

                    b.HasIndex(new[] { "Pcid" }, "PC_CPU2_FK");

                    b.ToTable("CPU", (string)null);
                });

            modelBuilder.Entity("GameSpy.Models.Game", b =>
                {
                    b.Property<int>("Gameid")
                        .HasColumnType("int")
                        .HasColumnName("GAMEID");

                    b.Property<string>("Description")
                        .HasMaxLength(2000)
                        .IsUnicode(false)
                        .HasColumnType("varchar(2000)")
                        .HasColumnName("DESCRIPTION");

                    b.Property<string>("Manufacturer")
                        .IsRequired()
                        .HasMaxLength(60)
                        .IsUnicode(false)
                        .HasColumnType("varchar(60)")
                        .HasColumnName("MANUFACTURER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(60)
                        .IsUnicode(false)
                        .HasColumnType("varchar(60)")
                        .HasColumnName("NAME");

                    b.Property<int?>("Pcid")
                        .HasColumnType("int")
                        .HasColumnName("PCID");

                    b.Property<decimal>("Rating")
                        .HasColumnType("numeric(2, 1)")
                        .HasColumnName("RATING");

                    b.Property<string>("Userid")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("USERID");

                    b.HasKey("Gameid");

                    b.HasIndex(new[] { "Pcid" }, "PC_GAMES_FK");

                    b.HasIndex(new[] { "Userid" }, "USER_GAMES_FK");

                    b.ToTable("GAMES", (string)null);
                });

            modelBuilder.Entity("GameSpy.Models.Gpu", b =>
                {
                    b.Property<int>("Gpuid")
                        .HasColumnType("int")
                        .HasColumnName("GPUID");

                    b.Property<decimal>("Capacity")
                        .HasColumnType("decimal(3, 2)")
                        .HasColumnName("CAPACITY");

                    b.Property<string>("Manufacturer")
                        .IsRequired()
                        .HasMaxLength(60)
                        .IsUnicode(false)
                        .HasColumnType("varchar(60)")
                        .HasColumnName("MANUFACTURER");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasMaxLength(4)
                        .IsUnicode(false)
                        .HasColumnType("varchar(4)")
                        .HasColumnName("MODEL");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(60)
                        .IsUnicode(false)
                        .HasColumnType("varchar(60)")
                        .HasColumnName("NAME");

                    b.Property<int?>("Pcid")
                        .HasColumnType("int")
                        .HasColumnName("PCID");

                    b.HasKey("Gpuid");

                    b.HasIndex(new[] { "Pcid" }, "PC_GPU2_FK");

                    b.ToTable("GPU", (string)null);
                });

            modelBuilder.Entity("GameSpy.Models.Motherboard", b =>
                {
                    b.Property<int>("Motherboardid")
                        .HasColumnType("int")
                        .HasColumnName("MOTHERBOARDID");

                    b.Property<string>("Manufacturer")
                        .IsRequired()
                        .HasMaxLength(60)
                        .IsUnicode(false)
                        .HasColumnType("varchar(60)")
                        .HasColumnName("MANUFACTURER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(60)
                        .IsUnicode(false)
                        .HasColumnType("varchar(60)")
                        .HasColumnName("NAME");

                    b.Property<int?>("Pcid")
                        .HasColumnType("int")
                        .HasColumnName("PCID");

                    b.HasKey("Motherboardid");

                    b.HasIndex(new[] { "Pcid" }, "PC_MOTHERBOARD2_FK");

                    b.ToTable("MOTHERBOARD", (string)null);
                });

            modelBuilder.Entity("GameSpy.Models.Pc", b =>
                {
                    b.Property<int>("Pcid")
                        .HasColumnType("int")
                        .HasColumnName("PCID");

                    b.Property<int>("Cpuid")
                        .HasColumnType("int")
                        .HasColumnName("CPUID");

                    b.Property<int>("Gpuid")
                        .HasColumnType("int")
                        .HasColumnName("GPUID");

                    b.Property<int>("Motherboardid")
                        .HasColumnType("int")
                        .HasColumnName("MOTHERBOARDID");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(60)
                        .IsUnicode(false)
                        .HasColumnType("varchar(60)")
                        .HasColumnName("NAME");

                    b.Property<int>("Ramid")
                        .HasColumnType("int")
                        .HasColumnName("RAMID");

                    b.Property<int>("Storageid")
                        .HasColumnType("int")
                        .HasColumnName("STORAGEID");

                    b.Property<string>("Userid")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("USERID");

                    b.HasKey("Pcid");

                    b.HasIndex(new[] { "Cpuid" }, "PC_CPU_FK");

                    b.HasIndex(new[] { "Gpuid" }, "PC_GPU_FK");

                    b.HasIndex(new[] { "Motherboardid" }, "PC_MOTHERBOARD_FK");

                    b.HasIndex(new[] { "Userid" }, "PC_OWNER_FK");

                    b.HasIndex(new[] { "Ramid" }, "PC_RAM_FK");

                    b.HasIndex(new[] { "Storageid" }, "PC_STORAGE_FK");

                    b.ToTable("PC", (string)null);
                });

            modelBuilder.Entity("GameSpy.Models.Ram", b =>
                {
                    b.Property<int>("Ramid")
                        .HasColumnType("int")
                        .HasColumnName("RAMID");

                    b.Property<decimal>("Capacity")
                        .HasColumnType("decimal(3, 2)")
                        .HasColumnName("CAPACITY");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasMaxLength(4)
                        .IsUnicode(false)
                        .HasColumnType("varchar(4)")
                        .HasColumnName("MODEL");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(60)
                        .IsUnicode(false)
                        .HasColumnType("varchar(60)")
                        .HasColumnName("NAME");

                    b.Property<int?>("Pcid")
                        .HasColumnType("int")
                        .HasColumnName("PCID");

                    b.Property<decimal>("Speed")
                        .HasColumnType("decimal(3, 2)")
                        .HasColumnName("SPEED");

                    b.HasKey("Ramid");

                    b.HasIndex(new[] { "Pcid" }, "PC_RAM2_FK");

                    b.ToTable("RAM", (string)null);
                });

            modelBuilder.Entity("GameSpy.Models.Storage", b =>
                {
                    b.Property<int>("Storageid")
                        .HasColumnType("int")
                        .HasColumnName("STORAGEID");

                    b.Property<decimal>("Capacity")
                        .HasColumnType("decimal(3, 2)")
                        .HasColumnName("CAPACITY");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(60)
                        .IsUnicode(false)
                        .HasColumnType("varchar(60)")
                        .HasColumnName("NAME");

                    b.Property<int?>("Pcid")
                        .HasColumnType("int")
                        .HasColumnName("PCID");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(5)
                        .IsUnicode(false)
                        .HasColumnType("varchar(5)")
                        .HasColumnName("TYPE");

                    b.HasKey("Storageid");

                    b.HasIndex(new[] { "Pcid" }, "PC_STORAGE2_FK");

                    b.ToTable("STORAGE", (string)null);
                });

            modelBuilder.Entity("GameSpy.Models.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("USERID");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<decimal>("Balance")
                        .HasColumnType("decimal(5, 2)")
                        .HasColumnName("BALANCE");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("Firstname")
                        .IsRequired()
                        .HasMaxLength(60)
                        .IsUnicode(false)
                        .HasColumnType("varchar(60)")
                        .HasColumnName("FIRSTNAME");

                    b.Property<string>("Lastname")
                        .IsRequired()
                        .HasMaxLength(60)
                        .IsUnicode(false)
                        .HasColumnType("varchar(60)")
                        .HasColumnName("LASTNAME");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("USER", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("IdentityUserClaims");
                });

            modelBuilder.Entity("UserAchievement", b =>
                {
                    b.Property<int>("Achievementsid")
                        .HasColumnType("int");

                    b.Property<string>("Userid")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Achievementsid", "Userid");

                    b.HasIndex("Userid");

                    b.ToTable("UserAchievement");
                });

            modelBuilder.Entity("GameSpy.Models.Achievement", b =>
                {
                    b.HasOne("GameSpy.Models.Game", "Game")
                        .WithMany("Achievements")
                        .HasForeignKey("Gameid")
                        .IsRequired()
                        .HasConstraintName("FK_ACHIEVEM_GAME_ACHI_GAMES");

                    b.Navigation("Game");
                });

            modelBuilder.Entity("GameSpy.Models.Cpu", b =>
                {
                    b.HasOne("GameSpy.Models.Pc", "Pc")
                        .WithMany("Cpus")
                        .HasForeignKey("Pcid")
                        .HasConstraintName("FK_CPU_PC_CPU2_PC");

                    b.Navigation("Pc");
                });

            modelBuilder.Entity("GameSpy.Models.Game", b =>
                {
                    b.HasOne("GameSpy.Models.Pc", "Pc")
                        .WithMany("Games")
                        .HasForeignKey("Pcid")
                        .HasConstraintName("FK_GAMES_PC_GAMES_PC");

                    b.HasOne("GameSpy.Models.User", "User")
                        .WithMany("Games")
                        .HasForeignKey("Userid")
                        .HasConstraintName("FK_GAMES_USER_GAME_USER");

                    b.Navigation("Pc");

                    b.Navigation("User");
                });

            modelBuilder.Entity("GameSpy.Models.Gpu", b =>
                {
                    b.HasOne("GameSpy.Models.Pc", "Pc")
                        .WithMany("Gpus")
                        .HasForeignKey("Pcid")
                        .HasConstraintName("FK_GPU_PC_GPU2_PC");

                    b.Navigation("Pc");
                });

            modelBuilder.Entity("GameSpy.Models.Motherboard", b =>
                {
                    b.HasOne("GameSpy.Models.Pc", "Pc")
                        .WithMany("Motherboards")
                        .HasForeignKey("Pcid")
                        .HasConstraintName("FK_MOTHERBO_PC_MOTHER_PC");

                    b.Navigation("Pc");
                });

            modelBuilder.Entity("GameSpy.Models.Pc", b =>
                {
                    b.HasOne("GameSpy.Models.Cpu", "Cpu")
                        .WithMany("Pcs")
                        .HasForeignKey("Cpuid")
                        .IsRequired()
                        .HasConstraintName("FK_PC_PC_CPU_CPU");

                    b.HasOne("GameSpy.Models.Gpu", "Gpu")
                        .WithMany("Pcs")
                        .HasForeignKey("Gpuid")
                        .IsRequired()
                        .HasConstraintName("FK_PC_PC_GPU_GPU");

                    b.HasOne("GameSpy.Models.Motherboard", "Motherboard")
                        .WithMany("Pcs")
                        .HasForeignKey("Motherboardid")
                        .IsRequired()
                        .HasConstraintName("FK_PC_PC_MOTHER_MOTHERBO");

                    b.HasOne("GameSpy.Models.Ram", "Ram")
                        .WithMany("Pcs")
                        .HasForeignKey("Ramid")
                        .IsRequired()
                        .HasConstraintName("FK_PC_PC_RAM_RAM");

                    b.HasOne("GameSpy.Models.Storage", "Storage")
                        .WithMany("Pcs")
                        .HasForeignKey("Storageid")
                        .IsRequired()
                        .HasConstraintName("FK_PC_PC_STORAG_STORAGE");

                    b.HasOne("GameSpy.Models.User", "User")
                        .WithMany("Pcs")
                        .HasForeignKey("Userid")
                        .IsRequired()
                        .HasConstraintName("FK_PC_PC_OWNER_USER");

                    b.Navigation("Cpu");

                    b.Navigation("Gpu");

                    b.Navigation("Motherboard");

                    b.Navigation("Ram");

                    b.Navigation("Storage");

                    b.Navigation("User");
                });

            modelBuilder.Entity("GameSpy.Models.Ram", b =>
                {
                    b.HasOne("GameSpy.Models.Pc", "Pc")
                        .WithMany("Rams")
                        .HasForeignKey("Pcid")
                        .HasConstraintName("FK_RAM_PC_RAM2_PC");

                    b.Navigation("Pc");
                });

            modelBuilder.Entity("GameSpy.Models.Storage", b =>
                {
                    b.HasOne("GameSpy.Models.Pc", "Pc")
                        .WithMany("Storages")
                        .HasForeignKey("Pcid")
                        .HasConstraintName("FK_STORAGE_PC_STORAG_PC");

                    b.Navigation("Pc");
                });

            modelBuilder.Entity("UserAchievement", b =>
                {
                    b.HasOne("GameSpy.Models.Achievement", null)
                        .WithMany()
                        .HasForeignKey("Achievementsid")
                        .IsRequired()
                        .HasConstraintName("FK_USER_ACH_USER_ACHI_ACHIEVEM");

                    b.HasOne("GameSpy.Models.User", null)
                        .WithMany()
                        .HasForeignKey("Userid")
                        .IsRequired()
                        .HasConstraintName("FK_USER_ACH_USER_ACHI_USER");
                });

            modelBuilder.Entity("GameSpy.Models.Cpu", b =>
                {
                    b.Navigation("Pcs");
                });

            modelBuilder.Entity("GameSpy.Models.Game", b =>
                {
                    b.Navigation("Achievements");
                });

            modelBuilder.Entity("GameSpy.Models.Gpu", b =>
                {
                    b.Navigation("Pcs");
                });

            modelBuilder.Entity("GameSpy.Models.Motherboard", b =>
                {
                    b.Navigation("Pcs");
                });

            modelBuilder.Entity("GameSpy.Models.Pc", b =>
                {
                    b.Navigation("Cpus");

                    b.Navigation("Games");

                    b.Navigation("Gpus");

                    b.Navigation("Motherboards");

                    b.Navigation("Rams");

                    b.Navigation("Storages");
                });

            modelBuilder.Entity("GameSpy.Models.Ram", b =>
                {
                    b.Navigation("Pcs");
                });

            modelBuilder.Entity("GameSpy.Models.Storage", b =>
                {
                    b.Navigation("Pcs");
                });

            modelBuilder.Entity("GameSpy.Models.User", b =>
                {
                    b.Navigation("Games");

                    b.Navigation("Pcs");
                });
#pragma warning restore 612, 618
        }
    }
}