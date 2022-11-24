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
    [Migration("20221124080350_SetLinks")]
    partial class SetLinks
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
                            Id = new Guid("cdb63d90-a48f-4f49-98ae-ed6da9b0dfe0"),
                            GameId = new Guid("7df9f52c-31bb-493c-ad42-99b24ba6a539"),
                            Name = "Mafia"
                        },
                        new
                        {
                            Id = new Guid("28d54e59-c1ac-4054-bb11-aff6c8a3c93a"),
                            GameId = new Guid("7df9f52c-31bb-493c-ad42-99b24ba6a539"),
                            Name = "Player"
                        },
                        new
                        {
                            Id = new Guid("a17d0dbb-43bf-4d93-8c5c-1138bdde42f8"),
                            GameId = new Guid("7df9f52c-31bb-493c-ad42-99b24ba6a539"),
                            Name = "Doctor"
                        },
                        new
                        {
                            Id = new Guid("41945b37-f493-4976-b1e1-f925d845789d"),
                            GameId = new Guid("7df9f52c-31bb-493c-ad42-99b24ba6a539"),
                            Name = "Sheriff"
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
                            Id = new Guid("41b00840-ac57-44a9-ba17-c1a38feb4f66"),
                            ConcurrencyStamp = "9660f6f4-4ef2-4f9d-b5a4-aa512957aaa1",
                            Name = "Admin",
                            NormalizedName = "Admin"
                        },
                        new
                        {
                            Id = new Guid("b80a3cd3-f1b1-49bb-9792-2319b8949557"),
                            ConcurrencyStamp = "4437d247-9fcc-4e57-b7d9-84274f07c257",
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
                            UserId = new Guid("e1eef61a-d16a-439a-829b-426b8625cbbe"),
                            RoleId = new Guid("41b00840-ac57-44a9-ba17-c1a38feb4f66")
                        },
                        new
                        {
                            UserId = new Guid("fcae68f8-447e-43f8-8343-a44ad8d8288e"),
                            RoleId = new Guid("b80a3cd3-f1b1-49bb-9792-2319b8949557")
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
                            Id = new Guid("7df9f52c-31bb-493c-ad42-99b24ba6a539"),
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
                            Id = new Guid("4fd52939-3cae-471d-bb36-b66e8c8faab5"),
                            Date = new DateTime(2022, 11, 24, 14, 3, 50, 225, DateTimeKind.Local).AddTicks(8241),
                            GameId = new Guid("7df9f52c-31bb-493c-ad42-99b24ba6a539"),
                            PartyCreatorId = new Guid("e1eef61a-d16a-439a-829b-426b8625cbbe"),
                            UserGamePlaceId = new Guid("8d04ffc6-43fd-49e8-b63d-562cb826a9fe")
                        });
                });

            modelBuilder.Entity("DAL.Entities.GamePartyMember", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("GamePartyId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("GameRoleId")
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
                            Id = new Guid("aeddcba3-4211-44ec-8a43-d2e74e0c31d8"),
                            AccountId = new Guid("e1eef61a-d16a-439a-829b-426b8625cbbe"),
                            Name = "admin"
                        },
                        new
                        {
                            Id = new Guid("b3af6add-b12d-471c-9db0-f5bddd4e9a0c"),
                            AccountId = new Guid("fcae68f8-447e-43f8-8343-a44ad8d8288e"),
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
                            Id = new Guid("e1eef61a-d16a-439a-829b-426b8625cbbe"),
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "6f71d685-e9a2-418c-895b-a94750c81a0d",
                            Email = "admin@gmail.com",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedEmail = "admin@gmail.com",
                            NormalizedUserName = "admin",
                            PasswordHash = "AQAAAAEAACcQAAAAEGPrM0+a2DPLt2IDXeNXCxwz6N4b+aTzO0qbm2ijrTLm0wZMouCaC+8Oan/u3yF+ZQ==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "656f1900-24ba-4302-a496-8b27213bcba4",
                            TwoFactorEnabled = false,
                            UserName = "admin"
                        },
                        new
                        {
                            Id = new Guid("fcae68f8-447e-43f8-8343-a44ad8d8288e"),
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "356ca530-5983-4da3-8e13-36525ea3175c",
                            Email = "user@gmail.com",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedEmail = "user@gmail.com",
                            NormalizedUserName = "user",
                            PasswordHash = "AQAAAAEAACcQAAAAEGPrM0+a2DPLt2IDXeNXCxwz6N4b+aTzO0qbm2ijrTLm0wZMouCaC+8Oan/u3yF+ZQ==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "d93c02c8-60e1-4541-978d-b621463333ca",
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

                    b.HasIndex("UserId");

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
                        .IsRequired()
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId", "Name")
                        .IsUnique();

                    b.ToTable("UserGamePlaces");

                    b.HasData(
                        new
                        {
                            Id = new Guid("8d04ffc6-43fd-49e8-b63d-562cb826a9fe"),
                            Name = "MyHome",
                            UserId = new Guid("e1eef61a-d16a-439a-829b-426b8625cbbe")
                        },
                        new
                        {
                            Id = new Guid("3159f8e1-8dc6-4169-85e4-09f74a44e3c7"),
                            Name = "Work",
                            UserId = new Guid("e1eef61a-d16a-439a-829b-426b8625cbbe")
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
                            Id = new Guid("7c90d75d-ccf2-40d4-b171-5445e3e3668b"),
                            InRequestUserId = new Guid("e1eef61a-d16a-439a-829b-426b8625cbbe"),
                            OutRequestUserId = new Guid("fcae68f8-447e-43f8-8343-a44ad8d8288e"),
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
                        .HasForeignKey("PartyCreatorId");

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
#pragma warning restore 612, 618
        }
    }
}
