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

            modelBuilder.Entity<Role>(b =>
            {
                b.HasMany(e => e.UserRoles)
                    .WithOne(e => e.Role)
                    .HasForeignKey(ur => ur.RoleId)
                    .IsRequired();
            });

            modelBuilder.Entity<User>(entity =>{
                entity.HasMany(e => e.UserRoles)
                    .WithOne(e => e.User)
                    .HasForeignKey(ur => ur.UserId)
                    .IsRequired();
                entity.HasMany(m => m.AddedFriends)
                    .WithOne(m => m.OutRequestUser)
                    .OnDelete(DeleteBehavior.Restrict);
                entity.HasMany(m => m.AcceptedFriends)
                    .WithOne(m => m.InRequestUser)
                    .OnDelete(DeleteBehavior.Restrict);
                entity.HasMany(m => m.PlayGamesPlayers)
                    .WithOne(m => m.Account)
                    .OnDelete(DeleteBehavior.Restrict);
                entity.HasMany(m => m.CreatedPlayers)
                    .WithOne(m => m.Creator)
                    .OnDelete(DeleteBehavior.Restrict);
                entity.HasMany(m => m.CreatedGames)
                    .WithOne(m => m.PartyCreator)
                    .OnDelete(DeleteBehavior.SetNull);
            }
            );

            modelBuilder.Entity<Game>()
               .HasMany(m => m.GameParties)
               .WithOne(m => m.Game)
               .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<GameRole>()
                .HasMany(m => m.GamePartyMembers)
                .WithOne(m => m.GameRole)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<UserGamePlace>()
               .HasMany(m => m.GameParties)
               .WithOne(m => m.UserGamePlace)
               .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<UserRole>().HasKey(x => new { x.UserId, x.RoleId });

            modelBuilder.Entity<Game>(entity =>
            {
                entity.Property(e => e.PlayersMinCount).IsRequired().HasMaxLength(255).IsUnicode(false);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(255);
                entity.Property(e => e.PlayersMinCount).IsRequired().HasMaxLength(255).IsUnicode(false);
                entity.Property(b => b.NameRu).HasMaxLength(100);
                entity.Property(b => b.NameEng).HasMaxLength(100);
                entity.Property(b => b.Name).HasMaxLength(100);
                entity.Property(b => b.GameInfo).HasMaxLength(5000);
                entity.Property(b => b.GameInfoShort).HasMaxLength(500);
                entity.Property(g => g.DateAdded).HasColumnType("date");
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
                Id = Guid.NewGuid(),
                Email = "admin@gmail.com",
                PasswordHash = "AQAAAAEAACcQAAAAEGPrM0+a2DPLt2IDXeNXCxwz6N4b+aTzO0qbm2ijrTLm0wZMouCaC+8Oan/u3yF+ZQ==",
                UserName = "admin",
                NormalizedEmail = "admin@gmail.com".Normalize(),
                NormalizedUserName = "admin".Normalize(),
                SecurityStamp = Guid.NewGuid().ToString()
            };
            var user = new User()
            {
                Id = Guid.NewGuid(),
                PasswordHash = "AQAAAAEAACcQAAAAEGPrM0+a2DPLt2IDXeNXCxwz6N4b+aTzO0qbm2ijrTLm0wZMouCaC+8Oan/u3yF+ZQ==",
                Email = "user@gmail.com",
                UserName = "user",
                NormalizedEmail = "user@gmail.com".Normalize(),
                NormalizedUserName = "user".Normalize(),
                SecurityStamp = Guid.NewGuid().ToString(),
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


            modelBuilder.Entity<Role>().HasData(new Role[] { adminRole, userRole });
            modelBuilder.Entity<User>().HasData(new User[] { userAdmin, user });
            modelBuilder.Entity<UserRole>().HasData(new UserRole[] { userRole1, userRole2 });
            modelBuilder.Entity<UserFriend>().HasData(userFried);
            modelBuilder.Entity<UserGamePlace>().HasData(new UserGamePlace[] { userGamePlaces1, userGamePlaces2 });
            modelBuilder.Entity<Player>().HasData(new Player[] { player1, player2 });

        }

    }

}
