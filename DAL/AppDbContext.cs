using BoardGameManager1.Entities;
using BoardGameManager1.Enums;
using DAL;
using DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BoardGamesManager.Data
{
    public class AppDbContext : IdentityDbContext<User, Role, Guid, IdentityUserClaim<Guid>, UserRole, IdentityUserLogin<Guid>, IdentityRoleClaim<Guid>, IdentityUserToken<Guid>>
    {
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

            modelBuilder.Entity<User>(b => {
                b.HasMany(e => e.UserRoles)
                    .WithOne(e => e.User)
                    .HasForeignKey(ur => ur.UserId)
                    .IsRequired(); });

            modelBuilder.Entity<Role>(b => {
                b.HasMany(e => e.UserRoles)
                    .WithOne(e => e.Role)
                    .HasForeignKey(ur => ur.RoleId)
                    .IsRequired();
            });

            modelBuilder.Entity<User>()
               .HasMany(m => m.PlayGamesPlayers)
               .WithOne(m => m.Account)
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
               .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<UserRole>().HasKey(x => new { x.UserId, x.RoleId });

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
                Id = Guid.NewGuid(),
                Name = UserRoleEnum.Admin.ToString(),
                NormalizedName = UserRoleEnum.Admin.ToString().Normalize()
            };
            var userRole = new Role()
            {
                // Id = Guid.NewGuid().ToString(),
                Id = Guid.NewGuid(),
                Name = UserRoleEnum.User.ToString(),
                NormalizedName = UserRoleEnum.User.ToString().Normalize()
            };

            var userAdmin = new User()
            {
                //Id = Guid.NewGuid().ToString(),
                Id = Guid.NewGuid(),
                Email = "admin@gmail.com",
                PasswordHash = "AQAAAAEAACcQAAAAEGPrM0+a2DPLt2IDXeNXCxwz6N4b+aTzO0qbm2ijrTLm0wZMouCaC+8Oan/u3yF+ZQ==",
                UserName = "admin",
                NormalizedEmail = "admin@gmail.com".Normalize(),
                NormalizedUserName = "admin".Normalize(),
                SecurityStamp = Guid.NewGuid().ToString()
                // RoleId = adminRole.Id
            };
            var user = new User()
            {
                //Id = Guid.NewGuid().ToString(),
                Id = Guid.NewGuid(),
                PasswordHash = "AQAAAAEAACcQAAAAEGPrM0+a2DPLt2IDXeNXCxwz6N4b+aTzO0qbm2ijrTLm0wZMouCaC+8Oan/u3yF+ZQ==",
                Email = "user@gmail.com",
                UserName = "use",
                NormalizedEmail = "user@gmail.com".Normalize(),
                NormalizedUserName = "user".Normalize(),
                SecurityStamp = Guid.NewGuid().ToString()
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
                Id = Guid.NewGuid(),
                Image = "no-image-icon-6.png",
                MaxPartyTime = 120,
                MinPartyTime = 60,
                MinAge = 10,
                Name = "Mafia Delux",
                NameEng = "Mafia",
                NameRu = "Мафия",
                PlayersMaxCount = 12,
                PlayersMinCount = 4,
                ReleaseYear = 2021,
                Rating = 0,
                RatingCount = 0
            };


            var gameRole1 = new GameRole()
            {
                Id = Guid.NewGuid(),
                GameId = game.Id,
                Name = "Mafia"
            };
            var gameRole2 = new GameRole()
            {
                Id = Guid.NewGuid(),
                GameId = game.Id,
                Name = "Player"
            };
            var gameRole3 = new GameRole()
            {
                Id = Guid.NewGuid(),
                GameId = game.Id,
                Name = "Doctor"
            };
            var gameRole4 = new GameRole()
            {
                Id = Guid.NewGuid(),
                GameId = game.Id,
                Name = "Sheriff"
            };

            var userFried = new UserFriend()
            {
                Id = Guid.NewGuid(),
                InRequestUserId = userAdmin.Id,
                OutRequestUserId = user.Id,
                Status = FriendStatus.Added
            };

            var userGamePlaces1 = new UserGamePlace()
            {
                Id = Guid.NewGuid(),
                UserId = userAdmin.Id,
                Name = "MyHome"
            };
            var userGamePlaces2 = new UserGamePlace()
            {
                Id = Guid.NewGuid(),
                UserId = userAdmin.Id,
                Name = "Work"
            };

            var gameParty = new GameParty()
            {
                Id = Guid.NewGuid(),
                Date = DateTime.Now,
                PartyCreatorId = userAdmin.Id,
                UserGamePlaceId = userGamePlaces1.Id,
                GameId = game.Id
            };
            var player1 = new Player()
            {
                Id = Guid.NewGuid(),
                AccountId = userAdmin.Id,
                CreatorId = null,
                Name = userAdmin.UserName
            };
            var player2 = new Player()
            {
                Id = Guid.NewGuid(),
                AccountId = user.Id,
                CreatorId = null,
                Name = user.UserName
            };
            //var gamePartyMember1 = new GamePartyMember()
            //{
            //    Id = Guid.NewGuid(),
            //    GamePartyId = 1,
            //    GameRoleId = 1,
            //    IsWinner = true,
            //    Points = 0,
            //    PlayerId = 1
            //};
            //var gamePartyMember2 = new GamePartyMember()
            //{
            //    Id = Guid.NewGuid(),
            //    GamePartyId = 1,
            //    GameRoleId = 2,
            //    IsWinner = false,
            //    Points = 0,
            //    PlayerId = 2
            //};

            modelBuilder.Entity<Role>().HasData(new Role[] { adminRole, userRole });
            modelBuilder.Entity<User>().HasData(new User[] { userAdmin, user });
            modelBuilder.Entity<UserRole>().HasData(new UserRole[] { userRole1, userRole2 });
            modelBuilder.Entity<Game>().HasData(game);
            modelBuilder.Entity<GameRole>().HasData(new GameRole[] { gameRole1, gameRole2, gameRole3, gameRole4 });
            modelBuilder.Entity<UserFriend>().HasData(userFried);
            modelBuilder.Entity<UserGamePlace>().HasData(new UserGamePlace[] { userGamePlaces1, userGamePlaces2 });
            modelBuilder.Entity<GameParty>().HasData(gameParty);
            modelBuilder.Entity<Player>().HasData(new Player[] { player1, player2 });
            //modelBuilder.Entity<GamePartyMember>().HasData(new GamePartyMember[] { gamePartyMember1, gamePartyMember2 });

        }

    }

}
