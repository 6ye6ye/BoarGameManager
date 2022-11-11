using BoardGameManager1.Entities;
using BoardGameManager1.Enums;
using DAL;
using DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BoardGamesManager.Data
{
    public class AppDbContext : IdentityDbContext<User, Role,string, IdentityUserClaim<string>, UserRole, IdentityUserLogin<string>,   IdentityRoleClaim<string>, IdentityUserToken<string>>
    {
       // public DbSet<UserRole> UserRoles { get; set; } = default!;
        public DbSet<Game> Games { get; set; } = default!;
        public DbSet<GameRate> GameRates { get; set; } = default!;
        public DbSet<GameParty> GameParties { get; set; } = default!;
        public DbSet<GamePartyMember> GamePartyMembers { get; set; } = default!;
        public DbSet<GameRole> GameRoles { get; set; } = default!;
        public DbSet<UserFriend> UserFriends { get; set; } = default!;
        public DbSet<UserGame> UserGames { get; set; } = default!;
        public DbSet<UserGamePlace> UserGamePlaces { get; set; } = default!;
        public DbSet<Player> Players { get; set; } = default!;

        public AppDbContext(DbContextOptions<AppDbContext> options)
           : base(options)
        {
         //   Database.EnsureCreated();
        }

     
 

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
               .HasMany(m => m.PlayGamesPlayers)
               .WithOne(m=>m.Account)
              .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<User>()
               .HasMany(m => m.CreatedPlayers)
               .WithOne(m => m.Creator)
              .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<User>()
                .HasMany(m => m.AddedFriends)
                .WithOne(m => m.OutRequestUser)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<User>()
                .HasMany(m => m.AcceptedFriends)
                .WithOne(m => m.InRequestUser)
                .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<Game>()
               .HasMany(m => m.GameParties)
               .WithOne(m => m.Game)
               .OnDelete(DeleteBehavior.Restrict);

            //modelBuilder.Entity<UserFriend>()
            //    .HasOne(m => m.InRequestUser)
            //    .WithMany(t => t.AcceptedFriends)
            // .OnDelete(DeleteBehavior.SetNull);
            //modelBuilder.Entity<UserFriend>()
            //    .HasOne(m => m.OutRequestUser)
            //    .WithMany(t => t.AddedFriends)
            // .OnDelete(DeleteBehavior.SetNull);

            //modelBuilder.Entity<Player>()
            //   .HasOne(m => m.Creator)
            //   .WithMany(t => t.CreatedPlayers)
            //   .HasForeignKey(m => m.CreatorId)
            //   .OnDelete(DeleteBehavior.SetNull);
            //modelBuilder.Entity<Player>()
            //   .HasOne(m => m.Account)
            //   .WithMany(t => t.PlayGamesPlayers)
            //   .HasForeignKey(m => m.AccountId)
            //.OnDelete(DeleteBehavior.SetNull);


            modelBuilder.Entity<UserRole>().HasKey(x => new { x.UserId, x.RoleId });
         

            modelBuilder.Entity<Game>()
                    .HasIndex(p => new { p.Name })
                    .IsUnique();

            modelBuilder.Entity<Game>(entity =>
            {
                entity.Property(e => e.PlayersMinCount)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.PlayersMinCount)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            Seed(modelBuilder);
        }
        private void Seed(ModelBuilder modelBuilder)
        {
            var adminRole = new Role()
            {

                Id = Guid.NewGuid().ToString(),
                Name = UserRoleEnum.Admin.ToString(),
                NormalizedName = UserRoleEnum.Admin.ToString().Normalize()
            };
            var userRole = new Role()
            {
                Id = Guid.NewGuid().ToString(),
                Name = UserRoleEnum.User.ToString(),
                NormalizedName = UserRoleEnum.User.ToString().Normalize()
            };

            var userAdmin = new User()
            {
                Id = Guid.NewGuid().ToString(),
                Email = "admin@gmail.com",
                PasswordHash = "AQAAAAEAACcQAAAAEGPrM0+a2DPLt2IDXeNXCxwz6N4b+aTzO0qbm2ijrTLm0wZMouCaC+8Oan/u3yF+ZQ==",
                UserName = "admin@gmail.com",
                NormalizedEmail = "admin@gmail.com".Normalize(),
                NormalizedUserName = "admin@gmail.com".Normalize(),

                // RoleId = adminRole.Id
            };
            var user = new User()
            {
                Id = Guid.NewGuid().ToString(),
                PasswordHash = "AQAAAAEAACcQAAAAEGPrM0+a2DPLt2IDXeNXCxwz6N4b+aTzO0qbm2ijrTLm0wZMouCaC+8Oan/u3yF+ZQ==",
                Email = "user@gmail.com",
                UserName = "user@gmail.com",
                NormalizedEmail = "user@gmail.com".Normalize(),
                NormalizedUserName = "user@gmail.com".Normalize(),
                //   RoleId = userRole.Id

            };
          
            var userRole1 = new UserRole()
            {
                RoleId = adminRole.Id,
                UserId = userAdmin.Id
            };
            var userRole2 = new UserRole()
            {
                RoleId = userRole.Id,
                UserId = user.Id
            };


            var game = new Game()
            {
                Id = 1,
                Image = "",
                MaxPartyTime = 120,
                MinPartyTime = 60,
                MinAge = 10,
                Name = "Mafia Delux",
                NameEng = "Mafia",
                NameRu = "Мафия",
                PlayersMaxCount = 12,
                PlayersMinCount = 4,
                ReleaseYear = 2021,
                Rating=0,
                RatingCount=0
            };


            var gameRole1 = new GameRole()
            {
                Id = 1,
                GameId = 1,
                Name = "Mafia"
            };
            var gameRole2 = new GameRole()
            {
                Id = 2,
                GameId = 1,
                Name = "Player"
            };
            var gameRole3 = new GameRole()
            {
                Id = 3,
                GameId = 1,
                Name = "Doctor"
            };
            var gameRole4 = new GameRole()
            {
                Id = 4,
                GameId = 1,
                Name = "Sheriff"
            };

            var userFried = new UserFriend()
            {
                Id = 1,
                InRequestUserId = userAdmin.Id,
                OutRequestUserId = user.Id,
                Status = FriendStatus.Added
            };

            var userGamePlaces1 = new UserGamePlace()
            {
                Id = 1,
                UserId = userAdmin.Id,
                Name = "MyHome"
            };
            var userGamePlaces2 = new UserGamePlace()
            {
                Id = 2,
                UserId = userAdmin.Id,
                Name = "Work"
            };

            var gameParty = new GameParty()
            {
                Id = 1,
                Date = DateTime.Now,
                PartyCreatorId = userAdmin.Id,
                UserGamePlaceId = 1,
            };
            var player1 = new Player()
            {
                Id = 1,
                AccountId = userAdmin.Id,
                CreatorId = null,
                Name = userAdmin.UserName
            };
            var player2 = new Player()
            {
                Id = 2,
                AccountId = user.Id,
                CreatorId = null,
                Name = user.UserName
            };
            var gamePartyMember1 = new GamePartyMember()
            {
                Id = 1,
                GamePartyId = 1,
                GameRoleId = 1,
                IsWinner = true,
                Points = 0,
                PlayerId = 1
            };
            var gamePartyMember2 = new GamePartyMember()
            {
                Id = 2,
                GamePartyId = 1,
                GameRoleId = 2,
                IsWinner = false,
                Points = 0,
                PlayerId = 2
            };

            modelBuilder.Entity<Role>().HasData(new Role[] { adminRole, userRole });
            modelBuilder.Entity<User>().HasData(new User[] { userAdmin, user });
            modelBuilder.Entity<UserRole>().HasData(new UserRole[] { userRole1, userRole2 });
            modelBuilder.Entity<Game>().HasData(game);
            modelBuilder.Entity<GameRole>().HasData(new GameRole[] { gameRole1, gameRole2, gameRole3, gameRole4 });
            modelBuilder.Entity<UserFriend>().HasData(userFried);
            modelBuilder.Entity<UserGamePlace>().HasData(new UserGamePlace[] { userGamePlaces1, userGamePlaces2 });
            modelBuilder.Entity<GameParty>().HasData(gameParty);
            modelBuilder.Entity<Player>().HasData(new Player[] { player1, player2 });
            modelBuilder.Entity<GamePartyMember>().HasData(new GamePartyMember[] { gamePartyMember1, gamePartyMember2 });

        }

    }

}
