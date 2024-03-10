﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameSpy.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "USER",
                columns: table => new
                {
                    USERID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FIRSTNAME = table.Column<string>(type: "varchar(60)", unicode: false, maxLength: 60, nullable: false),
                    LASTNAME = table.Column<string>(type: "varchar(60)", unicode: false, maxLength: 60, nullable: false),
                    BALANCE = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USER", x => x.USERID);
                });

            migrationBuilder.CreateTable(
                name: "ACHIEVEMENTS",
                columns: table => new
                {
                    ACHIEVEMENTSID = table.Column<int>(type: "int", nullable: false),
                    GAMEID = table.Column<int>(type: "int", nullable: false),
                    NAME = table.Column<string>(type: "varchar(60)", unicode: false, maxLength: 60, nullable: false),
                    DESCRIPTION = table.Column<string>(type: "varchar(2000)", unicode: false, maxLength: 2000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ACHIEVEMENTS", x => x.ACHIEVEMENTSID);
                });

            migrationBuilder.CreateTable(
                name: "UserAchievement",
                columns: table => new
                {
                    Achievementsid = table.Column<int>(type: "int", nullable: false),
                    Userid = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAchievement", x => new { x.Achievementsid, x.Userid });
                    table.ForeignKey(
                        name: "FK_USER_ACH_USER_ACHI_ACHIEVEM",
                        column: x => x.Achievementsid,
                        principalTable: "ACHIEVEMENTS",
                        principalColumn: "ACHIEVEMENTSID");
                    table.ForeignKey(
                        name: "FK_USER_ACH_USER_ACHI_USER",
                        column: x => x.Userid,
                        principalTable: "USER",
                        principalColumn: "USERID");
                });

            migrationBuilder.CreateTable(
                name: "CPU",
                columns: table => new
                {
                    CPUID = table.Column<int>(type: "int", nullable: false),
                    PCID = table.Column<int>(type: "int", nullable: true),
                    NAME = table.Column<string>(type: "varchar(60)", unicode: false, maxLength: 60, nullable: false),
                    MANUFACTURER = table.Column<string>(type: "varchar(60)", unicode: false, maxLength: 60, nullable: false),
                    SPEED = table.Column<decimal>(type: "decimal(3,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CPU", x => x.CPUID);
                });

            migrationBuilder.CreateTable(
                name: "GAMES",
                columns: table => new
                {
                    GAMEID = table.Column<int>(type: "int", nullable: false),
                    USERID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    PCID = table.Column<int>(type: "int", nullable: true),
                    NAME = table.Column<string>(type: "varchar(60)", unicode: false, maxLength: 60, nullable: false),
                    DESCRIPTION = table.Column<string>(type: "varchar(2000)", unicode: false, maxLength: 2000, nullable: true),
                    RATING = table.Column<decimal>(type: "numeric(2,1)", nullable: false),
                    MANUFACTURER = table.Column<string>(type: "varchar(60)", unicode: false, maxLength: 60, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GAMES", x => x.GAMEID);
                    table.ForeignKey(
                        name: "FK_GAMES_USER_GAME_USER",
                        column: x => x.USERID,
                        principalTable: "USER",
                        principalColumn: "USERID");
                });

            migrationBuilder.CreateTable(
                name: "GPU",
                columns: table => new
                {
                    GPUID = table.Column<int>(type: "int", nullable: false),
                    NAME = table.Column<string>(type: "varchar(60)", unicode: false, maxLength: 60, nullable: false),
                    MODEL = table.Column<string>(type: "varchar(4)", unicode: false, maxLength: 4, nullable: false),
                    MANUFACTURER = table.Column<string>(type: "varchar(60)", unicode: false, maxLength: 60, nullable: false),
                    CAPACITY = table.Column<decimal>(type: "decimal(3,2)", nullable: false),
                    PCID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GPU", x => x.GPUID);
                });

            migrationBuilder.CreateTable(
                name: "MOTHERBOARD",
                columns: table => new
                {
                    MOTHERBOARDID = table.Column<int>(type: "int", nullable: false),
                    PCID = table.Column<int>(type: "int", nullable: true),
                    NAME = table.Column<string>(type: "varchar(60)", unicode: false, maxLength: 60, nullable: false),
                    MANUFACTURER = table.Column<string>(type: "varchar(60)", unicode: false, maxLength: 60, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MOTHERBOARD", x => x.MOTHERBOARDID);
                });

            migrationBuilder.CreateTable(
                name: "PC",
                columns: table => new
                {
                    PCID = table.Column<int>(type: "int", nullable: false),
                    CPUID = table.Column<int>(type: "int", nullable: false),
                    GPUID = table.Column<int>(type: "int", nullable: false),
                    STORAGEID = table.Column<int>(type: "int", nullable: false),
                    RAMID = table.Column<int>(type: "int", nullable: false),
                    MOTHERBOARDID = table.Column<int>(type: "int", nullable: false),
                    USERID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NAME = table.Column<string>(type: "varchar(60)", unicode: false, maxLength: 60, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PC", x => x.PCID);
                    table.ForeignKey(
                        name: "FK_PC_PC_CPU_CPU",
                        column: x => x.CPUID,
                        principalTable: "CPU",
                        principalColumn: "CPUID");
                    table.ForeignKey(
                        name: "FK_PC_PC_GPU_GPU",
                        column: x => x.GPUID,
                        principalTable: "GPU",
                        principalColumn: "GPUID");
                    table.ForeignKey(
                        name: "FK_PC_PC_MOTHER_MOTHERBO",
                        column: x => x.MOTHERBOARDID,
                        principalTable: "MOTHERBOARD",
                        principalColumn: "MOTHERBOARDID");
                    table.ForeignKey(
                        name: "FK_PC_PC_OWNER_USER",
                        column: x => x.USERID,
                        principalTable: "USER",
                        principalColumn: "USERID");
                });

            migrationBuilder.CreateTable(
                name: "RAM",
                columns: table => new
                {
                    RAMID = table.Column<int>(type: "int", nullable: false),
                    PCID = table.Column<int>(type: "int", nullable: true),
                    NAME = table.Column<string>(type: "varchar(60)", unicode: false, maxLength: 60, nullable: false),
                    MODEL = table.Column<string>(type: "varchar(4)", unicode: false, maxLength: 4, nullable: false),
                    CAPACITY = table.Column<decimal>(type: "decimal(3,2)", nullable: false),
                    SPEED = table.Column<decimal>(type: "decimal(3,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RAM", x => x.RAMID);
                    table.ForeignKey(
                        name: "FK_RAM_PC_RAM2_PC",
                        column: x => x.PCID,
                        principalTable: "PC",
                        principalColumn: "PCID");
                });

            migrationBuilder.CreateTable(
                name: "STORAGE",
                columns: table => new
                {
                    STORAGEID = table.Column<int>(type: "int", nullable: false),
                    TYPE = table.Column<string>(type: "varchar(5)", unicode: false, maxLength: 5, nullable: false),
                    NAME = table.Column<string>(type: "varchar(60)", unicode: false, maxLength: 60, nullable: false),
                    CAPACITY = table.Column<decimal>(type: "decimal(3,2)", nullable: false),
                    PCID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_STORAGE", x => x.STORAGEID);
                    table.ForeignKey(
                        name: "FK_STORAGE_PC_STORAG_PC",
                        column: x => x.PCID,
                        principalTable: "PC",
                        principalColumn: "PCID");
                });

            migrationBuilder.CreateIndex(
                name: "GAME_ACHIEVEMENTS_FK",
                table: "ACHIEVEMENTS",
                column: "GAMEID");

            migrationBuilder.CreateIndex(
                name: "PC_CPU2_FK",
                table: "CPU",
                column: "PCID");

            migrationBuilder.CreateIndex(
                name: "PC_GAMES_FK",
                table: "GAMES",
                column: "PCID");

            migrationBuilder.CreateIndex(
                name: "USER_GAMES_FK",
                table: "GAMES",
                column: "USERID");

            migrationBuilder.CreateIndex(
                name: "PC_GPU2_FK",
                table: "GPU",
                column: "PCID");

            migrationBuilder.CreateIndex(
                name: "PC_MOTHERBOARD2_FK",
                table: "MOTHERBOARD",
                column: "PCID");

            migrationBuilder.CreateIndex(
                name: "PC_CPU_FK",
                table: "PC",
                column: "CPUID");

            migrationBuilder.CreateIndex(
                name: "PC_GPU_FK",
                table: "PC",
                column: "GPUID");

            migrationBuilder.CreateIndex(
                name: "PC_MOTHERBOARD_FK",
                table: "PC",
                column: "MOTHERBOARDID");

            migrationBuilder.CreateIndex(
                name: "PC_OWNER_FK",
                table: "PC",
                column: "USERID");

            migrationBuilder.CreateIndex(
                name: "PC_RAM_FK",
                table: "PC",
                column: "RAMID");

            migrationBuilder.CreateIndex(
                name: "PC_STORAGE_FK",
                table: "PC",
                column: "STORAGEID");

            migrationBuilder.CreateIndex(
                name: "PC_RAM2_FK",
                table: "RAM",
                column: "PCID");

            migrationBuilder.CreateIndex(
                name: "PC_STORAGE2_FK",
                table: "STORAGE",
                column: "PCID");

            migrationBuilder.CreateIndex(
                name: "IX_UserAchievement_Userid",
                table: "UserAchievement",
                column: "Userid");

            migrationBuilder.AddForeignKey(
                name: "FK_ACHIEVEM_GAME_ACHI_GAMES",
                table: "ACHIEVEMENTS",
                column: "GAMEID",
                principalTable: "GAMES",
                principalColumn: "GAMEID");

            migrationBuilder.AddForeignKey(
                name: "FK_CPU_PC_CPU2_PC",
                table: "CPU",
                column: "PCID",
                principalTable: "PC",
                principalColumn: "PCID");

            migrationBuilder.AddForeignKey(
                name: "FK_GAMES_PC_GAMES_PC",
                table: "GAMES",
                column: "PCID",
                principalTable: "PC",
                principalColumn: "PCID");

            migrationBuilder.AddForeignKey(
                name: "FK_GPU_PC_GPU2_PC",
                table: "GPU",
                column: "PCID",
                principalTable: "PC",
                principalColumn: "PCID");

            migrationBuilder.AddForeignKey(
                name: "FK_MOTHERBO_PC_MOTHER_PC",
                table: "MOTHERBOARD",
                column: "PCID",
                principalTable: "PC",
                principalColumn: "PCID");

            migrationBuilder.AddForeignKey(
                name: "FK_PC_PC_RAM_RAM",
                table: "PC",
                column: "RAMID",
                principalTable: "RAM",
                principalColumn: "RAMID");

            migrationBuilder.AddForeignKey(
                name: "FK_PC_PC_STORAG_STORAGE",
                table: "PC",
                column: "STORAGEID",
                principalTable: "STORAGE",
                principalColumn: "STORAGEID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CPU_PC_CPU2_PC",
                table: "CPU");

            migrationBuilder.DropForeignKey(
                name: "FK_GPU_PC_GPU2_PC",
                table: "GPU");

            migrationBuilder.DropForeignKey(
                name: "FK_MOTHERBO_PC_MOTHER_PC",
                table: "MOTHERBOARD");

            migrationBuilder.DropForeignKey(
                name: "FK_RAM_PC_RAM2_PC",
                table: "RAM");

            migrationBuilder.DropForeignKey(
                name: "FK_STORAGE_PC_STORAG_PC",
                table: "STORAGE");

            migrationBuilder.DropTable(
                name: "UserAchievement");

            migrationBuilder.DropTable(
                name: "ACHIEVEMENTS");

            migrationBuilder.DropTable(
                name: "GAMES");

            migrationBuilder.DropTable(
                name: "PC");

            migrationBuilder.DropTable(
                name: "CPU");

            migrationBuilder.DropTable(
                name: "GPU");

            migrationBuilder.DropTable(
                name: "MOTHERBOARD");

            migrationBuilder.DropTable(
                name: "USER");

            migrationBuilder.DropTable(
                name: "RAM");

            migrationBuilder.DropTable(
                name: "STORAGE");
        }
    }
}