﻿// <auto-generated />
using System;
using BoardGamesManager.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BoardGameManager1.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20221110045835_AddGameToGameParty")]
    partial class AddGameToGameParty
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("BoardGameManager1.Entities.GameRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("GameId")
                        .HasColumnType("int");

                    b.Property<int>("RoleForGameId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GameId");

                    b.HasIndex("RoleForGameId")
                        .IsUnique();

                    b.ToTable("GameRoles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            GameId = 1,
                            RoleForGameId = 1
                        },
                        new
                        {
                            Id = 2,
                            GameId = 1,
                            RoleForGameId = 2
                        },
                        new
                        {
                            Id = 3,
                            GameId = 1,
                            RoleForGameId = 3
                        },
                        new
                        {
                            Id = 4,
                            GameId = 1,
                            RoleForGameId = 4
                        });
                });

            modelBuilder.Entity("BoardGameManager1.Entities.Role", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "d2914c25-2fc2-49f1-bb96-788252594fda",
                            ConcurrencyStamp = "4499dfac-1c3f-4ef4-a515-b30c415cd2d4",
                            Name = "Admin",
                            NormalizedName = "Admin"
                        },
                        new
                        {
                            Id = "efbb345e-44ab-435a-a018-4e698cf50bc6",
                            ConcurrencyStamp = "53a66dda-22a1-41a1-af01-b6426c63dbfa",
                            Name = "User",
                            NormalizedName = "User"
                        });
                });

            modelBuilder.Entity("BoardGameManager1.Entities.UserRole", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);

                    b.HasData(
                        new
                        {
                            UserId = "ad3ee538-1452-45c9-8bc1-5332356b8576",
                            RoleId = "d2914c25-2fc2-49f1-bb96-788252594fda"
                        },
                        new
                        {
                            UserId = "04963b95-e838-4648-a0fd-92ecb4e5883c",
                            RoleId = "efbb345e-44ab-435a-a018-4e698cf50bc6"
                        });
                });

            modelBuilder.Entity("DAL.Entities.Game", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MaxPartyTime")
                        .HasColumnType("int");

                    b.Property<int>("MinAge")
                        .HasColumnType("int");

                    b.Property<int>("MinPartyTime")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("NameEng")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NameRu")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PlayersMaxCount")
                        .HasColumnType("int");

                    b.Property<int>("PlayersMinCount")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("int");

                    b.Property<float?>("Rating")
                        .HasColumnType("real");

                    b.Property<int>("RatingCount")
                        .HasColumnType("int");

                    b.Property<int>("ReleaseYear")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Games");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Image = "",
                            MaxPartyTime = 120,
                            MinAge = 10,
                            MinPartyTime = 60,
                            Name = "Mafia Delux",
                            NameEng = "Mafia",
                            NameRu = "Мафия",
                            PlayersMaxCount = 12,
                            PlayersMinCount = 4,
                            RatingCount = 0,
                            ReleaseYear = 2021
                        });
                });

            modelBuilder.Entity("DAL.Entities.GameParty", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int?>("GameId")
                        .HasColumnType("int");

                    b.Property<string>("PartyCreatorId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("UserGamePlaceId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GameId");

                    b.HasIndex("PartyCreatorId");

                    b.HasIndex("UserGamePlaceId");

                    b.ToTable("GameParties");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Date = new DateTime(2022, 11, 10, 10, 58, 35, 162, DateTimeKind.Local).AddTicks(1646),
                            PartyCreatorId = "ad3ee538-1452-45c9-8bc1-5332356b8576",
                            UserGamePlaceId = 1
                        });
                });

            modelBuilder.Entity("DAL.Entities.GamePartyMember", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("GamePartyId")
                        .HasColumnType("int");

                    b.Property<int>("GameRoleId")
                        .HasColumnType("int");

                    b.Property<bool>("IsWinner")
                        .HasColumnType("bit");

                    b.Property<int>("PlayerId")
                        .HasColumnType("int");

                    b.Property<int>("Points")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GamePartyId");

                    b.HasIndex("GameRoleId");

                    b.HasIndex("PlayerId");

                    b.ToTable("GamePartyMembers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            GamePartyId = 1,
                            GameRoleId = 1,
                            IsWinner = true,
                            PlayerId = 1,
                            Points = 0
                        },
                        new
                        {
                            Id = 2,
                            GamePartyId = 1,
                            GameRoleId = 2,
                            IsWinner = false,
                            PlayerId = 2,
                            Points = 0
                        });
                });

            modelBuilder.Entity("DAL.Entities.Player", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("AccountId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CreatorId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AccountId")
                        .IsUnique()
                        .HasFilter("[AccountId] IS NOT NULL");

                    b.HasIndex("CreatorId");

                    b.ToTable("Players");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AccountId = "ad3ee538-1452-45c9-8bc1-5332356b8576",
                            Name = "admin@gmail.com"
                        },
                        new
                        {
                            Id = 2,
                            AccountId = "04963b95-e838-4648-a0fd-92ecb4e5883c",
                            Name = "user@gmail.com"
                        });
                });

            modelBuilder.Entity("DAL.Entities.RoleForGame", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("RolesForGame");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Mafia"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Player"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Doctor"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Sheriff"
                        });
                });

            modelBuilder.Entity("DAL.Entities.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

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
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "ad3ee538-1452-45c9-8bc1-5332356b8576",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "a09a3042-e6b9-4a09-b0ae-ffa117d3d2cc",
                            Email = "admin@gmail.com",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedEmail = "admin@gmail.com",
                            NormalizedUserName = "admin@gmail.com",
                            PasswordHash = "AQAAAAEAACcQAAAAEGPrM0+a2DPLt2IDXeNXCxwz6N4b+aTzO0qbm2ijrTLm0wZMouCaC+8Oan/u3yF+ZQ==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "28c63c33-2fbd-4127-84ec-f788c4ead232",
                            TwoFactorEnabled = false,
                            UserName = "admin@gmail.com"
                        },
                        new
                        {
                            Id = "04963b95-e838-4648-a0fd-92ecb4e5883c",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "416c11df-02c0-407a-a02b-1d17c6388ca4",
                            Email = "user@gmail.com",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedEmail = "user@gmail.com",
                            NormalizedUserName = "user@gmail.com",
                            PasswordHash = "AQAAAAEAACcQAAAAEGPrM0+a2DPLt2IDXeNXCxwz6N4b+aTzO0qbm2ijrTLm0wZMouCaC+8Oan/u3yF+ZQ==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "766e900e-6b89-4f79-a994-03890d8cce5f",
                            TwoFactorEnabled = false,
                            UserName = "user@gmail.com"
                        });
                });

            modelBuilder.Entity("DAL.Entities.UserGame", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("GameId")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("GameId");

                    b.HasIndex("UserId", "GameId")
                        .IsUnique();

                    b.ToTable("UserGames");
                });

            modelBuilder.Entity("DAL.Entities.UserGamePlace", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId", "Name")
                        .IsUnique();

                    b.ToTable("UserGamePlaces");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "MyHome",
                            UserId = "ad3ee538-1452-45c9-8bc1-5332356b8576"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Work",
                            UserId = "ad3ee538-1452-45c9-8bc1-5332356b8576"
                        });
                });

            modelBuilder.Entity("DAL.UserFriend", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("InRequestUserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("OutRequestUserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OutRequestUserId");

                    b.HasIndex("InRequestUserId", "OutRequestUserId")
                        .IsUnique()
                        .HasFilter("[InRequestUserId] IS NOT NULL AND [OutRequestUserId] IS NOT NULL");

                    b.ToTable("UserFriends");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            InRequestUserId = "ad3ee538-1452-45c9-8bc1-5332356b8576",
                            OutRequestUserId = "04963b95-e838-4648-a0fd-92ecb4e5883c",
                            Status = 1
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("BoardGameManager1.Entities.GameRole", b =>
                {
                    b.HasOne("DAL.Entities.Game", null)
                        .WithMany("GameRoles")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DAL.Entities.RoleForGame", "RoleForGame")
                        .WithOne("GameRole")
                        .HasForeignKey("BoardGameManager1.Entities.GameRole", "RoleForGameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("RoleForGame");
                });

            modelBuilder.Entity("BoardGameManager1.Entities.UserRole", b =>
                {
                    b.HasOne("BoardGameManager1.Entities.Role", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DAL.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DAL.Entities.GameParty", b =>
                {
                    b.HasOne("DAL.Entities.Game", "Game")
                        .WithMany("GameParties")
                        .HasForeignKey("GameId");

                    b.HasOne("DAL.Entities.User", "PartyCreator")
                        .WithMany("CreatedGames")
                        .HasForeignKey("PartyCreatorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DAL.Entities.UserGamePlace", "UserGamePlace")
                        .WithMany()
                        .HasForeignKey("UserGamePlaceId");

                    b.Navigation("Game");

                    b.Navigation("PartyCreator");

                    b.Navigation("UserGamePlace");
                });

            modelBuilder.Entity("DAL.Entities.GamePartyMember", b =>
                {
                    b.HasOne("DAL.Entities.GameParty", "GameParty")
                        .WithMany("GamePartyMembers")
                        .HasForeignKey("GamePartyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BoardGameManager1.Entities.GameRole", "GameRole")
                        .WithMany()
                        .HasForeignKey("GameRoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DAL.Entities.Player", "Player")
                        .WithMany("GamePartiesMember")
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("GameParty");

                    b.Navigation("GameRole");

                    b.Navigation("Player");
                });

            modelBuilder.Entity("DAL.Entities.Player", b =>
                {
                    b.HasOne("DAL.Entities.User", "Account")
                        .WithMany("PlayGamesPlayers")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("DAL.Entities.User", "Creator")
                        .WithMany("CreatedPlayers")
                        .HasForeignKey("CreatorId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Account");

                    b.Navigation("Creator");
                });

            modelBuilder.Entity("DAL.Entities.UserGame", b =>
                {
                    b.HasOne("DAL.Entities.Game", "Game")
                        .WithMany()
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DAL.Entities.User", "User")
                        .WithMany("Games")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Game");

                    b.Navigation("User");
                });

            modelBuilder.Entity("DAL.Entities.UserGamePlace", b =>
                {
                    b.HasOne("DAL.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("DAL.UserFriend", b =>
                {
                    b.HasOne("DAL.Entities.User", "InRequestUser")
                        .WithMany("AcceptedFriends")
                        .HasForeignKey("InRequestUserId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("DAL.Entities.User", "OutRequestUser")
                        .WithMany("AddedFriends")
                        .HasForeignKey("OutRequestUserId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("InRequestUser");

                    b.Navigation("OutRequestUser");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("BoardGameManager1.Entities.Role", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("DAL.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("DAL.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("DAL.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DAL.Entities.Game", b =>
                {
                    b.Navigation("GameParties");

                    b.Navigation("GameRoles");
                });

            modelBuilder.Entity("DAL.Entities.GameParty", b =>
                {
                    b.Navigation("GamePartyMembers");
                });

            modelBuilder.Entity("DAL.Entities.Player", b =>
                {
                    b.Navigation("GamePartiesMember");
                });

            modelBuilder.Entity("DAL.Entities.RoleForGame", b =>
                {
                    b.Navigation("GameRole")
                        .IsRequired();
                });

            modelBuilder.Entity("DAL.Entities.User", b =>
                {
                    b.Navigation("AcceptedFriends");

                    b.Navigation("AddedFriends");

                    b.Navigation("CreatedGames");

                    b.Navigation("CreatedPlayers");

                    b.Navigation("Games");

                    b.Navigation("PlayGamesPlayers");
                });
#pragma warning restore 612, 618
        }
    }
}