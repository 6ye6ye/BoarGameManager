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

            modelBuilder.Entity<GameRole>()
                .HasMany(m => m.GamePartyMembers)
                .WithOne(m => m.GameRole)
                .OnDelete(DeleteBehavior.SetNull);
            modelBuilder.Entity<UserGamePlace>()
               .HasMany(m => m.GameParties)
               .WithOne(m => m.UserGamePlace)
               .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<User>()
              .HasMany(m => m.CreatedGames)
              .WithOne(m => m.PartyCreator)
              .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<UserRole>().HasKey(x => new { x.UserId, x.RoleId });
            modelBuilder.Entity<Game>()
                .Property(b => b.GameInfoShort).HasMaxLength(500);
            modelBuilder.Entity<Game>()
                .Property(b => b.GameInfo).HasMaxLength(5000);
            modelBuilder.Entity<Game>()
               .Property(b => b.Name).HasMaxLength(100);
            modelBuilder.Entity<Game>()
               .Property(b => b.NameEng).HasMaxLength(100);
            modelBuilder.Entity<Game>()
              .Property(b => b.NameRu).HasMaxLength(100);
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
                UserName = "use",
                NormalizedEmail = "user@gmail.com".Normalize(),
                NormalizedUserName = "user".Normalize(),
                SecurityStamp = Guid.NewGuid().ToString()
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

            var game1 = new Game()
            {
                Id = Guid.NewGuid(),
                Image = "no-image-icon-6.png",
                MaxPartyTime = 120,
                MinPartyTime = 60,
                MinAge = 10,
                Name = "Mafia Delux",
                NameEng = "Mafia",
                NameRu = "Мафия",
                GameInfoShort= @"Вы любите детективы? Тогда эта увлекательная психологическая пошаговая ролевая игра с детективным
сюжетом для вас. Она отлично подходит для игры в домашнем кругу,
для весёлой компании на различных вечеринках и даже в дороге поможет интересно 
провести время.",
                PlayersMaxCount = 12,
                PlayersMinCount = 4,
                ReleaseYear = 2021,
                Rating = 0,
                RatingCount = 0
            };
            var game2 = new Game()
            {
                Id = Guid.NewGuid(),
                Image = "forbiddenStars.jpg",
                MaxPartyTime = 120,
                MinPartyTime = 60,
                MinAge = 14,
                Name = "Forbidden Stars",
                NameEng = "Forbidden Stars",
                NameRu = "Запретные звезды",
                GameInfoShort= @"Forbidden Stars — стратегическая игра, события которой разворачиваются в
мире «Вархаммера 40 000». За контроль над игровым полем, составляемым каждый раз из
квадратов звёздных систем с планетами и космическим пространством, борются эльдары, орки, 
космодесант Хаоса и космодесант, верный Императору. ",
                GameInfo= @"Forbidden Stars — стратегическая игра, события которой разворачиваются в мире 
                «Вархаммера 40 000». За контроль над игровым полем, составляемым каждый раз из квадратов 
                звёздных систем с планетами и космическим пространством, борются эльдары, орки, космодесант Хаоса и 
                космодесант, верный Императору.
                Перед началом партии игроки по очереди добавляют по квадрату звёздной системы на стол, пока не будет сформировано игровое поле, 
                а затем расставляют свои стартовые войска и космические флоты, а также выкладывают жетоны целей. 
                Конфигурация игрового поля влияет на связи между системами. Сообщению между смежными системами может 
                мешать варп-шторм, который представлен жетоном-полоской. Во время партии варп-шторм движется: в конце 
                каждого раунда игроки перемещают полоску. Победа достаётся игроку, которому удалось первым установить 
                контроль над нужными системами и собрать все свои жетоны целей.
                Каждый раунд игроки раздают приказы, выкладывая соответствующие жетоны рубашкой вверх 
                в системы. Жетоны могут накрывать друг друга и образовывать стопки. Приказы в каждой стопке применяются
                от верхнего к нижнему. Всего в игре четыре вида приказов: мобилизация позволяет наращивать боевую мощь 
                за счёт новых войск и космических кораблей, а также возводить новые постройки для развития и защиты планет; 
                планирование — добирать карты, которыми можно влиять на исход боёв или увеличивать эффективность последующих
                приказов, а также вредить противникам; администрирование — собирать ресурсы с подконтрольных планет и
                использовать свойство своей фракции; передислокация — перемещать космические корабли и перебрасывать войска
                с планеты на планету.
                Во время боя игрок бросает некоторое количество кубиков за свои участвующие боевые единицы. 
                Выпавшие символы задают уровни нападения, обороны и боевого духа. Также противники могут удивить друг друга,
                сыграв карты боя, которые не только усиливают эти параметры войск, но и позволяют применить особые эффекты, позволяющие уничтожить как можно больше сил противника, 
                уйти в глухую оборону и т.д. Листы боевых единиц и карты боя у каждой фракции свои.",
                PlayersMaxCount = 4,
                PlayersMinCount = 2,
                ReleaseYear = 2015,
                Rating = 0,
                RatingCount = 0
            };
            var game3 = new Game()
            {
                Id = Guid.NewGuid(),
                Image = "StarWarsRebellion.jpg",
                MaxPartyTime = 240,
                MinPartyTime = 180,
                MinAge = 14,
                Name = "Star Wars: Rebellion",
                NameEng = "Star Wars: Rebellion",
                NameRu = "Звездные войны: Восстание",
                GameInfoShort= @"Звёздные Войны: Восстание (Star Wars: Rebellion) – игра, которая основана на классической кинотрилогии Звездных войн. Игрокам предлагают разыграть партию между Империей и повстанцами, 
                силы и методы которых сильно разнятся.",
                GameInfo= @"Игра Star Wars: Rebellion основана на классической кинотрилогии («Эпизод IV: Новая надежда», «Эпизод V: Империя наносит ответный удар», «Эпизод VI: Возвращение джедая»). Игрокам предлагают разыграть партию между Империей и повстанцами, силы и методы которых сильно разнятся. Карта, на которой разворачивается гражданская война, 
                огромна, поделена на регионы и насчитывает 32 звёздные системы.\n
                В распоряжении Империи два верных и мощных союзника — армия и флот, — и для победы 
                ей нужно обнаружить и уничтожить базу сопротивления. Повстанцы же вынуждены проводить
                точечные удары из подполья, и чтобы выиграть гражданскую войну — им нужно, добиваясь
                маленьких целей, привлечь на свою сторону как можно больше граждан и вдохновить их на 
                открытое восстание. При этом важную роль в конфликте играют лидеры: игроки начинают
                партию с несколькими лидерами, во время партии получают новых и развивают их. ",
                PlayersMaxCount = 4,
                PlayersMinCount = 2,
                ReleaseYear = 2016,
                Rating = 0,
                RatingCount = 0
            };


            var gameRole1 = new GameRole()
            {
                Id = Guid.NewGuid(),
                GameId = game1.Id,
                Name = "Mafia"
            };
            var gameRole2 = new GameRole()
            {
                Id = Guid.NewGuid(),
                GameId = game1.Id,
                Name = "Player"
            };
            var gameRole3 = new GameRole()
            {
                Id = Guid.NewGuid(),
                GameId = game1.Id,
                Name = "Doctor"
            };
            var gameRole4 = new GameRole()
            {
                Id = Guid.NewGuid(),
                GameId = game1.Id,
                Name = "Sheriff"
            };


            var gameRole2_1 = new GameRole()
            {
                Id = Guid.NewGuid(),
                GameId = game2.Id,
                Name = "Ork"
            };
            var gameRole2_2 = new GameRole()
            {
                Id = Guid.NewGuid(),
                GameId = game2.Id,
                Name = "Eldar"
            };
            var gameRole2_3 = new GameRole()
            {
                Id = Guid.NewGuid(),
                GameId = game2.Id,
                Name = "Chaos Space Marine"
            };
            var gameRole2_4 = new GameRole()
            {
                Id = Guid.NewGuid(),
                GameId = game2.Id,
                Name = "Emperor's Space Marine"
            };

            var gameRole3_1 = new GameRole()
            {
                Id = Guid.NewGuid(),
                GameId = game3.Id,
                Name = "Empire"
            };
            var gameRole3_2 = new GameRole()
            {
                Id = Guid.NewGuid(),
                GameId = game3.Id,
                Name = "Rebels"
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
                GameId = game1.Id
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
            modelBuilder.Entity<Game>().HasData(game1,game2,game3);
            modelBuilder.Entity<GameRole>().HasData(new GameRole[] { 
                gameRole1, gameRole2, gameRole3, gameRole4,
                gameRole2_1,gameRole2_2,gameRole2_3,gameRole2_4,
                gameRole3_1,gameRole3_2
            });
            modelBuilder.Entity<UserFriend>().HasData(userFried);
            modelBuilder.Entity<UserGamePlace>().HasData(new UserGamePlace[] { userGamePlaces1, userGamePlaces2 });
            modelBuilder.Entity<GameParty>().HasData(gameParty);
            modelBuilder.Entity<Player>().HasData(new Player[] { player1, player2 });
            //modelBuilder.Entity<GamePartyMember>().HasData(new GamePartyMember[] { gamePartyMember1, gamePartyMember2 });

        }

    }

}
