// <auto-generated />
using System;
using BoardGamesManager.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DAL.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

                    b.ToTable("GameRates", (string)null);
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

                    b.ToTable("GameRoles", (string)null);
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
                            Id = new Guid("5bfca672-bf0f-47de-8a87-8e12dda03fea"),
                            ConcurrencyStamp = "61f7d472-a065-431e-8166-185209da101a",
                            Name = "Admin",
                            NormalizedName = "Admin"
                        },
                        new
                        {
                            Id = new Guid("466398d3-0ba9-4845-a9d4-e2323e8c439f"),
                            ConcurrencyStamp = "f754335b-0827-46eb-8aff-d7b7cbb06016",
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
                            UserId = new Guid("f5a299b5-20f4-43d3-afaa-af09d0b22359"),
                            RoleId = new Guid("5bfca672-bf0f-47de-8a87-8e12dda03fea")
                        },
                        new
                        {
                            UserId = new Guid("7403ec36-15f8-444b-bd30-02438aa9a1dc"),
                            RoleId = new Guid("466398d3-0ba9-4845-a9d4-e2323e8c439f")
                        });
                });

            modelBuilder.Entity("DAL.Entities.Game", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Alias")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateAdded")
                        .HasColumnType("date");

                    b.Property<string>("GameInfo")
                        .HasMaxLength(5000)
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GameInfoShort")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

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
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("NameEng")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("NameRu")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

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

                    b.Property<int?>("TeseraId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Games", (string)null);
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

                    b.ToTable("GameParties", (string)null);
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

                    b.ToTable("GamePartyMembers", (string)null);
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

                    b.ToTable("Players", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("c2773453-6d6f-4c50-ab47-40b563f4075a"),
                            AccountId = new Guid("f5a299b5-20f4-43d3-afaa-af09d0b22359"),
                            Name = "admin"
                        },
                        new
                        {
                            Id = new Guid("d742dc30-c8b1-4415-9829-3acffc19ce7b"),
                            AccountId = new Guid("7403ec36-15f8-444b-bd30-02438aa9a1dc"),
                            Name = "user"
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
                            Id = new Guid("f5a299b5-20f4-43d3-afaa-af09d0b22359"),
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "52fb6e47-730d-4e59-b5de-de1c7aa09f8c",
                            Email = "admin@gmail.com",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedEmail = "admin@gmail.com",
                            NormalizedUserName = "admin",
                            PasswordHash = "AQAAAAEAACcQAAAAEGPrM0+a2DPLt2IDXeNXCxwz6N4b+aTzO0qbm2ijrTLm0wZMouCaC+8Oan/u3yF+ZQ==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "caa6feeb-906e-4cc7-a3db-5f554dc8c46c",
                            TwoFactorEnabled = false,
                            UserName = "admin"
                        },
                        new
                        {
                            Id = new Guid("7403ec36-15f8-444b-bd30-02438aa9a1dc"),
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "4f1ea01d-26bf-4e2d-8089-12a8f5c1fd5d",
                            Email = "user@gmail.com",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedEmail = "user@gmail.com",
                            NormalizedUserName = "user",
                            PasswordHash = "AQAAAAEAACcQAAAAEGPrM0+a2DPLt2IDXeNXCxwz6N4b+aTzO0qbm2ijrTLm0wZMouCaC+8Oan/u3yF+ZQ==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "16abf1ee-4d4d-4e91-a3fc-7a476b263dc1",
                            TwoFactorEnabled = false,
                            UserName = "user"
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

                    b.ToTable("UserGames", (string)null);
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

                    b.ToTable("UserGamePlaces", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("63baca01-7381-4943-a0d3-b962ac5467f8"),
                            Name = "MyHome",
                            UserId = new Guid("f5a299b5-20f4-43d3-afaa-af09d0b22359")
                        },
                        new
                        {
                            Id = new Guid("1f871d0f-b7be-4918-9b90-646b6034a5fe"),
                            Name = "Work",
                            UserId = new Guid("f5a299b5-20f4-43d3-afaa-af09d0b22359")
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

                    b.ToTable("UserFriends", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("16380b66-1636-4a50-9bb5-341d869e3780"),
                            InRequestUserId = new Guid("f5a299b5-20f4-43d3-afaa-af09d0b22359"),
                            OutRequestUserId = new Guid("7403ec36-15f8-444b-bd30-02438aa9a1dc"),
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
