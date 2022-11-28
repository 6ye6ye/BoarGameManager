﻿// <auto-generated />
using System;
using BoardGamesManager.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DAL.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20221128095943_AddSeeds")]
    partial class AddSeeds
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("BoardGameManager1.Entities.GameRate", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("GameId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Rate")
                        .HasColumnType("int");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("GameId");

                    b.HasIndex("UserId");

                    b.ToTable("GameRates");
                });

            modelBuilder.Entity("BoardGameManager1.Entities.GameRole", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("GameId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("GameId");

                    b.ToTable("GameRoles");

                    b.HasData(
                        new
                        {
                            Id = new Guid("dce5bf83-137a-4ba2-883a-00d0fb05219c"),
                            GameId = new Guid("5e92e4de-47cd-4ff6-8326-0d57fc560229"),
                            Name = "Mafia"
                        },
                        new
                        {
                            Id = new Guid("823c95c6-b1ce-4800-8afa-be5870eb1348"),
                            GameId = new Guid("5e92e4de-47cd-4ff6-8326-0d57fc560229"),
                            Name = "Player"
                        },
                        new
                        {
                            Id = new Guid("e7d99955-ed27-4034-8327-16bc93b1ec48"),
                            GameId = new Guid("5e92e4de-47cd-4ff6-8326-0d57fc560229"),
                            Name = "Doctor"
                        },
                        new
                        {
                            Id = new Guid("e27b2464-2d7e-4d29-98df-ff63be1becf2"),
                            GameId = new Guid("5e92e4de-47cd-4ff6-8326-0d57fc560229"),
                            Name = "Sheriff"
                        },
                        new
                        {
                            Id = new Guid("189405e5-d054-4117-ba80-9ad6c8fc41c5"),
                            GameId = new Guid("3cbf8290-33a5-4a0a-a222-ed8f1e881cb9"),
                            Name = "Ork"
                        },
                        new
                        {
                            Id = new Guid("9fb56489-e959-4cc8-9e17-a71d24f97ae4"),
                            GameId = new Guid("3cbf8290-33a5-4a0a-a222-ed8f1e881cb9"),
                            Name = "Eldar"
                        },
                        new
                        {
                            Id = new Guid("16088ed3-8e50-4832-89cc-926fcadb4307"),
                            GameId = new Guid("3cbf8290-33a5-4a0a-a222-ed8f1e881cb9"),
                            Name = "Chaos Space Marine"
                        },
                        new
                        {
                            Id = new Guid("8d58e1cc-758a-4b09-8116-4992a1f2a72b"),
                            GameId = new Guid("3cbf8290-33a5-4a0a-a222-ed8f1e881cb9"),
                            Name = "Emperor's Space Marine"
                        },
                        new
                        {
                            Id = new Guid("b0a0b795-d9dd-42eb-8e7c-0e69315b2805"),
                            GameId = new Guid("ea2b391a-7505-4ed9-a33b-88849ca33606"),
                            Name = "Empire"
                        },
                        new
                        {
                            Id = new Guid("1b6c842d-722b-4074-9ee6-3538cf04216d"),
                            GameId = new Guid("ea2b391a-7505-4ed9-a33b-88849ca33606"),
                            Name = "Rebels"
                        });
                });

            modelBuilder.Entity("BoardGameManager1.Entities.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

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
                            Id = new Guid("4dbfbf8b-3282-45b9-bb70-3ce505fe76ca"),
                            ConcurrencyStamp = "9fc38d83-e240-422b-bdc5-67ae492050b6",
                            Name = "Admin",
                            NormalizedName = "Admin"
                        },
                        new
                        {
                            Id = new Guid("04b8eff8-6e00-469b-890b-7b32a4283042"),
                            ConcurrencyStamp = "32ef12b6-5674-4af9-89e8-6e9333a6212a",
                            Name = "User",
                            NormalizedName = "User"
                        });
                });

            modelBuilder.Entity("BoardGameManager1.Entities.UserRole", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);

                    b.HasData(
                        new
                        {
                            UserId = new Guid("85fa4b0a-14c4-4014-9371-21dc6213d1df"),
                            RoleId = new Guid("4dbfbf8b-3282-45b9-bb70-3ce505fe76ca")
                        },
                        new
                        {
                            UserId = new Guid("c47af41b-3025-4680-926c-3285b1ad707d"),
                            RoleId = new Guid("04b8eff8-6e00-469b-890b-7b32a4283042")
                        });
                });

            modelBuilder.Entity("DAL.Entities.Game", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

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

                    b.Property<double>("Rating")
                        .HasColumnType("float");

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
                            Id = new Guid("5e92e4de-47cd-4ff6-8326-0d57fc560229"),
                            Image = "no-image-icon-6.png",
                            MaxPartyTime = 120,
                            MinAge = 10,
                            MinPartyTime = 60,
                            Name = "Mafia Delux",
                            NameEng = "Mafia",
                            NameRu = "Мафия",
                            PlayersMaxCount = 12,
                            PlayersMinCount = 4,
                            Rating = 0.0,
                            RatingCount = 0,
                            ReleaseYear = 2021
                        },
                        new
                        {
                            Id = new Guid("3cbf8290-33a5-4a0a-a222-ed8f1e881cb9"),
                            Image = "forbiddenStars.jpg",
                            MaxPartyTime = 120,
                            MinAge = 14,
                            MinPartyTime = 60,
                            Name = "Forbidden Stars",
                            NameEng = "Forbidden Stars",
                            NameRu = "Запретные звезды",
                            PlayersMaxCount = 4,
                            PlayersMinCount = 2,
                            Rating = 0.0,
                            RatingCount = 0,
                            ReleaseYear = 2015
                        },
                        new
                        {
                            Id = new Guid("ea2b391a-7505-4ed9-a33b-88849ca33606"),
                            Image = "StarWarsRebellion.jpg",
                            MaxPartyTime = 240,
                            MinAge = 14,
                            MinPartyTime = 180,
                            Name = "Star Wars: Rebellion",
                            NameEng = "Star Wars: Rebellion",
                            NameRu = "Звездные войны: Восстание",
                            PlayersMaxCount = 4,
                            PlayersMinCount = 2,
                            Rating = 0.0,
                            RatingCount = 0,
                            ReleaseYear = 2016
                        });
                });

            modelBuilder.Entity("DAL.Entities.GameParty", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("GameId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("PartyCreatorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("UserGamePlaceId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("GameId");

                    b.HasIndex("PartyCreatorId");

                    b.HasIndex("UserGamePlaceId");

                    b.ToTable("GameParties");

                    b.HasData(
                        new
                        {
                            Id = new Guid("376b4ee8-766a-4747-b40b-94f36f11b6e6"),
                            Date = new DateTime(2022, 11, 28, 15, 59, 43, 668, DateTimeKind.Local).AddTicks(5251),
                            GameId = new Guid("5e92e4de-47cd-4ff6-8326-0d57fc560229"),
                            PartyCreatorId = new Guid("85fa4b0a-14c4-4014-9371-21dc6213d1df"),
                            UserGamePlaceId = new Guid("fb17b5fe-971b-440f-8bc0-54bf4c8e2617")
                        });
                });

            modelBuilder.Entity("DAL.Entities.GamePartyMember", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("GamePartyId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("GameRoleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsWinner")
                        .HasColumnType("bit");

                    b.Property<Guid>("PlayerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Points")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GamePartyId");

                    b.HasIndex("GameRoleId");

                    b.HasIndex("PlayerId");

                    b.ToTable("GamePartyMembers");
                });

            modelBuilder.Entity("DAL.Entities.Player", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("AccountId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CreatorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.HasIndex("CreatorId");

                    b.ToTable("Players");

                    b.HasData(
                        new
                        {
                            Id = new Guid("93ad4030-c2fb-4f57-83e4-a729751fe6a4"),
                            AccountId = new Guid("85fa4b0a-14c4-4014-9371-21dc6213d1df"),
                            Name = "admin"
                        },
                        new
                        {
                            Id = new Guid("a8982c86-0c9c-43fd-9fc3-da344da52e55"),
                            AccountId = new Guid("c47af41b-3025-4680-926c-3285b1ad707d"),
                            Name = "use"
                        });
                });

            modelBuilder.Entity("DAL.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

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
                            Id = new Guid("85fa4b0a-14c4-4014-9371-21dc6213d1df"),
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "b08fe337-08fb-47cf-ad98-bedaca048ff5",
                            Email = "admin@gmail.com",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedEmail = "admin@gmail.com",
                            NormalizedUserName = "admin",
                            PasswordHash = "AQAAAAEAACcQAAAAEGPrM0+a2DPLt2IDXeNXCxwz6N4b+aTzO0qbm2ijrTLm0wZMouCaC+8Oan/u3yF+ZQ==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "b4fe4c8f-0df9-4d85-8a23-1797d324b707",
                            TwoFactorEnabled = false,
                            UserName = "admin"
                        },
                        new
                        {
                            Id = new Guid("c47af41b-3025-4680-926c-3285b1ad707d"),
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "21299ca4-c9e7-4f83-9299-e9213908c712",
                            Email = "user@gmail.com",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedEmail = "user@gmail.com",
                            NormalizedUserName = "user",
                            PasswordHash = "AQAAAAEAACcQAAAAEGPrM0+a2DPLt2IDXeNXCxwz6N4b+aTzO0qbm2ijrTLm0wZMouCaC+8Oan/u3yF+ZQ==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "bc25d6ab-cc8f-4dc3-9e52-dbeea91a0a8e",
                            TwoFactorEnabled = false,
                            UserName = "use"
                        });
                });

            modelBuilder.Entity("DAL.Entities.UserGame", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("GameId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("GameId");

                    b.HasIndex("UserId", "GameId")
                        .IsUnique();

                    b.ToTable("UserGames");
                });

            modelBuilder.Entity("DAL.Entities.UserGamePlace", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId", "Name")
                        .IsUnique()
                        .HasFilter("[UserId] IS NOT NULL");

                    b.ToTable("UserGamePlaces");

                    b.HasData(
                        new
                        {
                            Id = new Guid("fb17b5fe-971b-440f-8bc0-54bf4c8e2617"),
                            Name = "MyHome",
                            UserId = new Guid("85fa4b0a-14c4-4014-9371-21dc6213d1df")
                        },
                        new
                        {
                            Id = new Guid("37565d0e-05c9-44ee-8e28-966355d388e5"),
                            Name = "Work",
                            UserId = new Guid("85fa4b0a-14c4-4014-9371-21dc6213d1df")
                        });
                });

            modelBuilder.Entity("DAL.UserFriend", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("InRequestUserId")
                        .IsRequired()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("OutRequestUserId")
                        .IsRequired()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("InRequestUserId");

                    b.HasIndex("OutRequestUserId");

                    b.ToTable("UserFriends");

                    b.HasData(
                        new
                        {
                            Id = new Guid("74763513-a0ac-4551-b122-cf4e121d7ae0"),
                            InRequestUserId = new Guid("85fa4b0a-14c4-4014-9371-21dc6213d1df"),
                            OutRequestUserId = new Guid("c47af41b-3025-4680-926c-3285b1ad707d"),
                            Status = 1
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("BoardGameManager1.Entities.GameRate", b =>
                {
                    b.HasOne("DAL.Entities.Game", "Game")
                        .WithMany("GameRates")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DAL.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Game");

                    b.Navigation("User");
                });

            modelBuilder.Entity("BoardGameManager1.Entities.GameRole", b =>
                {
                    b.HasOne("DAL.Entities.Game", "Game")
                        .WithMany("GameRoles")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Game");
                });

            modelBuilder.Entity("BoardGameManager1.Entities.UserRole", b =>
                {
                    b.HasOne("BoardGameManager1.Entities.Role", "Role")
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DAL.Entities.User", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("DAL.Entities.GameParty", b =>
                {
                    b.HasOne("DAL.Entities.Game", "Game")
                        .WithMany("GameParties")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("DAL.Entities.User", "PartyCreator")
                        .WithMany("CreatedGames")
                        .HasForeignKey("PartyCreatorId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("DAL.Entities.UserGamePlace", "UserGamePlace")
                        .WithMany("GameParties")
                        .HasForeignKey("UserGamePlaceId")
                        .OnDelete(DeleteBehavior.SetNull);

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
                        .WithMany("GamePartyMembers")
                        .HasForeignKey("GameRoleId")
                        .OnDelete(DeleteBehavior.SetNull);

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
                        .WithMany("UserGames")
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
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("DAL.UserFriend", b =>
                {
                    b.HasOne("DAL.Entities.User", "InRequestUser")
                        .WithMany("AcceptedFriends")
                        .HasForeignKey("InRequestUserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("DAL.Entities.User", "OutRequestUser")
                        .WithMany("AddedFriends")
                        .HasForeignKey("OutRequestUserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("InRequestUser");

                    b.Navigation("OutRequestUser");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.HasOne("BoardGameManager1.Entities.Role", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.HasOne("DAL.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.HasOne("DAL.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.HasOne("DAL.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BoardGameManager1.Entities.GameRole", b =>
                {
                    b.Navigation("GamePartyMembers");
                });

            modelBuilder.Entity("BoardGameManager1.Entities.Role", b =>
                {
                    b.Navigation("UserRoles");
                });

            modelBuilder.Entity("DAL.Entities.Game", b =>
                {
                    b.Navigation("GameParties");

                    b.Navigation("GameRates");

                    b.Navigation("GameRoles");

                    b.Navigation("UserGames");
                });

            modelBuilder.Entity("DAL.Entities.GameParty", b =>
                {
                    b.Navigation("GamePartyMembers");
                });

            modelBuilder.Entity("DAL.Entities.Player", b =>
                {
                    b.Navigation("GamePartiesMember");
                });

            modelBuilder.Entity("DAL.Entities.User", b =>
                {
                    b.Navigation("AcceptedFriends");

                    b.Navigation("AddedFriends");

                    b.Navigation("CreatedGames");

                    b.Navigation("CreatedPlayers");

                    b.Navigation("Games");

                    b.Navigation("PlayGamesPlayers");

                    b.Navigation("UserRoles");
                });

            modelBuilder.Entity("DAL.Entities.UserGamePlace", b =>
                {
                    b.Navigation("GameParties");
                });
#pragma warning restore 612, 618
        }
    }
}