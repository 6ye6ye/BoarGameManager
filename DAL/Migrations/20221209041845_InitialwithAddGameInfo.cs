using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    public partial class InitialwithAddGameInfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
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
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    NameRu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NameEng = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GameInfoShort = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GameInfo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rating = table.Column<double>(type: "float", nullable: false),
                    RatingCount = table.Column<int>(type: "int", nullable: false),
                    PlayersMinCount = table.Column<int>(type: "int", unicode: false, maxLength: 255, nullable: false),
                    PlayersMaxCount = table.Column<int>(type: "int", nullable: false),
                    MinAge = table.Column<int>(type: "int", nullable: false),
                    MinPartyTime = table.Column<int>(type: "int", nullable: false),
                    MaxPartyTime = table.Column<int>(type: "int", nullable: false),
                    ReleaseYear = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Players_AspNetUsers_AccountId",
                        column: x => x.AccountId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Players_AspNetUsers_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserFriends",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InRequestUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OutRequestUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserFriends", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserFriends_AspNetUsers_InRequestUserId",
                        column: x => x.InRequestUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserFriends_AspNetUsers_OutRequestUserId",
                        column: x => x.OutRequestUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserGamePlaces",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserGamePlaces", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserGamePlaces_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "GameRates",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Rate = table.Column<int>(type: "int", nullable: false),
                    GameId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameRates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GameRates_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GameRates_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GameRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GameId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameRoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GameRoles_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserGames",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GameId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserGames", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserGames_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserGames_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GameParties",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserGamePlaceId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PartyCreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    GameId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameParties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GameParties_AspNetUsers_PartyCreatorId",
                        column: x => x.PartyCreatorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_GameParties_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_GameParties_UserGamePlaces_UserGamePlaceId",
                        column: x => x.UserGamePlaceId,
                        principalTable: "UserGamePlaces",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "GamePartyMembers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GamePartyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PlayerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GameRoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Points = table.Column<int>(type: "int", nullable: false),
                    IsWinner = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GamePartyMembers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GamePartyMembers_GameParties_GamePartyId",
                        column: x => x.GamePartyId,
                        principalTable: "GameParties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GamePartyMembers_GameRoles_GameRoleId",
                        column: x => x.GameRoleId,
                        principalTable: "GameRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_GamePartyMembers_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("052aa42e-dcd5-42ec-9371-49968f750cd0"), "3a4685e5-3840-4b15-8fa2-0fdbf2479d4e", "Admin", "Admin" },
                    { new Guid("d44e1604-bd00-4f24-8697-8845c06a79e3"), "248d0688-99ab-483d-9367-2e066c1dd823", "User", "User" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("232c8238-74a6-40d1-8fa8-4bd595c57b70"), 0, "b2ceda99-398c-40cf-a81b-7d3c7045af5c", "user@gmail.com", false, false, null, "user@gmail.com", "user", "AQAAAAEAACcQAAAAEGPrM0+a2DPLt2IDXeNXCxwz6N4b+aTzO0qbm2ijrTLm0wZMouCaC+8Oan/u3yF+ZQ==", null, false, "795cee52-04d3-4163-9b93-f90eaf7ae631", false, "use" },
                    { new Guid("32defc01-26c0-4ac1-b54c-fd99812ba043"), 0, "3df7b6cb-2374-4b49-8965-9f2d36f1dc03", "admin@gmail.com", false, false, null, "admin@gmail.com", "admin", "AQAAAAEAACcQAAAAEGPrM0+a2DPLt2IDXeNXCxwz6N4b+aTzO0qbm2ijrTLm0wZMouCaC+8Oan/u3yF+ZQ==", null, false, "7eeb29b8-f159-4ac9-931d-cb11a30e4390", false, "admin" }
                });

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "Id", "GameInfo", "GameInfoShort", "Image", "MaxPartyTime", "MinAge", "MinPartyTime", "Name", "NameEng", "NameRu", "PlayersMaxCount", "PlayersMinCount", "Rating", "RatingCount", "ReleaseYear" },
                values: new object[,]
                {
                    { new Guid("63cc2b4d-34f0-4240-879c-dd15a8104b55"), null, "Вы любите детективы?\r\n                Тогда эта увлекательная психологическая пошаговая ролевая игра с детективным\r\n                сюжетом для вас.\\r\\n\\r\\nОна отлично подходит для игры в домашнем кругу,\r\n                для весёлой компании на различных вечеринках и даже в дороге поможет интересно \r\n                провести время.", "no-image-icon-6.png", 120, 10, 60, "Mafia Delux", "Mafia", "Мафия", 12, 4, 0.0, 0, 2021 },
                    { new Guid("955fa3d0-0b2c-4251-8244-b8c09360a254"), "Forbidden Stars — стратегическая игра, события которой разворачиваются в мире \r\n                «Вархаммера 40 000». За контроль над игровым полем, составляемым каждый раз из квадратов \r\n                звёздных систем с планетами и космическим пространством, борются эльдары, орки, космодесант Хаоса и \r\n                космодесант, верный Императору. \\n\r\n                    Перед началом партии игроки по очереди добавляют по квадрату звёздной системы на стол, пока не будет сформировано игровое поле, \r\n                а затем расставляют свои стартовые войска и космические флоты, а также выкладывают жетоны целей. \r\n                Конфигурация игрового поля влияет на связи между системами. Сообщению между смежными системами может \r\n                мешать варп-шторм, который представлен жетоном-полоской. Во время партии варп-шторм движется: в конце \r\n                каждого раунда игроки перемещают полоску. Победа достаётся игроку, которому удалось первым установить \r\n                контроль над нужными системами и собрать все свои жетоны целей.\\n\r\n                                Каждый раунд игроки раздают приказы, выкладывая соответствующие жетоны рубашкой вверх \r\n                в системы. Жетоны могут накрывать друг друга и образовывать стопки. Приказы в каждой стопке применяются\r\n                от верхнего к нижнему. Всего в игре четыре вида приказов: мобилизация позволяет наращивать боевую мощь \r\n                за счёт новых войск и космических кораблей, а также возводить новые постройки для развития и защиты планет; \r\n                планирование — добирать карты, которыми можно влиять на исход боёв или увеличивать эффективность последующих\r\n                приказов, а также вредить противникам; администрирование — собирать ресурсы с подконтрольных планет и\r\n                использовать свойство своей фракции; передислокация — перемещать космические корабли и перебрасывать войска\r\n                с планеты на планету.\\n\r\n                                Во время боя игрок бросает некоторое количество кубиков за свои участвующие боевые единицы. \r\n                Выпавшие символы задают уровни нападения, обороны и боевого духа. Также противники могут удивить друг друга, сыграв карты боя, которые не только усиливают эти параметры войск, но и позволяют применить особые эффекты, позволяющие уничтожить как можно больше сил противника, \r\n                уйти в глухую оборону и т.д. Листы боевых единиц и карты боя у каждой фракции свои.", "Forbidden Stars — стратегическая игра, события которой разворачиваются в\r\n                мире «Вархаммера 40 000». За контроль над игровым полем, составляемым каждый раз из\r\n                квадратов звёздных систем с планетами и космическим пространством, борются эльдары, орки, \r\n                космодесант Хаоса и космодесант, верный Императору. ", "forbiddenStars.jpg", 120, 14, 60, "Forbidden Stars", "Forbidden Stars", "Запретные звезды", 4, 2, 0.0, 0, 2015 },
                    { new Guid("9f07f524-eee0-468d-9e50-4c26c614d79c"), "Игра Star Wars: Rebellion основана на классической кинотрилогии («Эпизод IV: Новая надежда», «Эпизод V: Империя наносит ответный удар», «Эпизод VI: Возвращение джедая»). Игрокам предлагают разыграть партию между Империей и повстанцами, силы и методы которых сильно разнятся. Карта, на которой разворачивается гражданская война, \r\n                огромна, поделена на регионы и насчитывает 32 звёздные системы.\\n\r\n                В распоряжении Империи два верных и мощных союзника — армия и флот, — и для победы \r\n                ей нужно обнаружить и уничтожить базу сопротивления. Повстанцы же вынуждены проводить\r\n                точечные удары из подполья, и чтобы выиграть гражданскую войну — им нужно, добиваясь\r\n                маленьких целей, привлечь на свою сторону как можно больше граждан и вдохновить их на \r\n                открытое восстание. При этом важную роль в конфликте играют лидеры: игроки начинают\r\n                партию с несколькими лидерами, во время партии получают новых и развивают их. ", "Звёздные Войны: Восстание (Star Wars: Rebellion) – игра, которая основана на классической кинотрилогии Звездных войн. Игрокам предлагают разыграть партию между Империей и повстанцами, \r\n                силы и методы которых сильно разнятся.", "StarWarsRebellion.jpg", 240, 14, 180, "Star Wars: Rebellion", "Star Wars: Rebellion", "Звездные войны: Восстание", 4, 2, 0.0, 0, 2016 }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("d44e1604-bd00-4f24-8697-8845c06a79e3"), new Guid("232c8238-74a6-40d1-8fa8-4bd595c57b70") },
                    { new Guid("052aa42e-dcd5-42ec-9371-49968f750cd0"), new Guid("32defc01-26c0-4ac1-b54c-fd99812ba043") }
                });

            migrationBuilder.InsertData(
                table: "GameRoles",
                columns: new[] { "Id", "GameId", "Name" },
                values: new object[,]
                {
                    { new Guid("0dd5bf03-cd7a-4661-a0c0-65970f79bc1f"), new Guid("63cc2b4d-34f0-4240-879c-dd15a8104b55"), "Mafia" },
                    { new Guid("186e9cf5-50ff-4416-8c73-28484cf416f1"), new Guid("955fa3d0-0b2c-4251-8244-b8c09360a254"), "Emperor's Space Marine" },
                    { new Guid("220f20cf-4d2b-41e4-9bc9-54a6f34c1594"), new Guid("955fa3d0-0b2c-4251-8244-b8c09360a254"), "Chaos Space Marine" },
                    { new Guid("3ebb401e-8697-4956-9259-13e5d0e54c7a"), new Guid("63cc2b4d-34f0-4240-879c-dd15a8104b55"), "Sheriff" },
                    { new Guid("552f8cde-5a5b-463a-9716-5a0d41e3e3ba"), new Guid("9f07f524-eee0-468d-9e50-4c26c614d79c"), "Empire" },
                    { new Guid("74adf251-6dd6-4348-a328-cc47ef9b50d3"), new Guid("955fa3d0-0b2c-4251-8244-b8c09360a254"), "Ork" },
                    { new Guid("8321a22d-ece5-49e3-bd4d-0f6367b55d9c"), new Guid("9f07f524-eee0-468d-9e50-4c26c614d79c"), "Rebels" },
                    { new Guid("89bba2d1-2ac4-4a4c-bc6b-778101785c3b"), new Guid("63cc2b4d-34f0-4240-879c-dd15a8104b55"), "Doctor" },
                    { new Guid("9757c39c-55ea-472c-9c87-aab354edcf10"), new Guid("955fa3d0-0b2c-4251-8244-b8c09360a254"), "Eldar" },
                    { new Guid("e979d263-befa-432d-874f-8ec2c1506e03"), new Guid("63cc2b4d-34f0-4240-879c-dd15a8104b55"), "Player" }
                });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "Id", "AccountId", "CreatorId", "Name" },
                values: new object[,]
                {
                    { new Guid("6787ed8d-73c8-4540-ad02-d069fbafa964"), new Guid("32defc01-26c0-4ac1-b54c-fd99812ba043"), null, "admin" },
                    { new Guid("bc6dc3c2-5560-411a-b0f3-4eb3c8466765"), new Guid("232c8238-74a6-40d1-8fa8-4bd595c57b70"), null, "use" }
                });

            migrationBuilder.InsertData(
                table: "UserFriends",
                columns: new[] { "Id", "InRequestUserId", "OutRequestUserId", "Status" },
                values: new object[] { new Guid("24a8e07c-ce8a-4e9d-9c31-2fccd0af202a"), new Guid("32defc01-26c0-4ac1-b54c-fd99812ba043"), new Guid("232c8238-74a6-40d1-8fa8-4bd595c57b70"), 1 });

            migrationBuilder.InsertData(
                table: "UserGamePlaces",
                columns: new[] { "Id", "Name", "UserId" },
                values: new object[,]
                {
                    { new Guid("d20ac8bb-b8b1-4d5d-bcd2-558f746d8a2f"), "Work", new Guid("32defc01-26c0-4ac1-b54c-fd99812ba043") },
                    { new Guid("fc85bc3f-3475-4669-8cc9-3a98cbfcbcb4"), "MyHome", new Guid("32defc01-26c0-4ac1-b54c-fd99812ba043") }
                });

            migrationBuilder.InsertData(
                table: "GameParties",
                columns: new[] { "Id", "Date", "GameId", "PartyCreatorId", "UserGamePlaceId" },
                values: new object[] { new Guid("d28731d3-9861-4ba8-8d27-2ad0178ebaf2"), new DateTime(2022, 12, 9, 10, 18, 45, 708, DateTimeKind.Local).AddTicks(139), new Guid("63cc2b4d-34f0-4240-879c-dd15a8104b55"), new Guid("32defc01-26c0-4ac1-b54c-fd99812ba043"), new Guid("fc85bc3f-3475-4669-8cc9-3a98cbfcbcb4") });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_GameParties_GameId",
                table: "GameParties",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_GameParties_PartyCreatorId",
                table: "GameParties",
                column: "PartyCreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_GameParties_UserGamePlaceId",
                table: "GameParties",
                column: "UserGamePlaceId");

            migrationBuilder.CreateIndex(
                name: "IX_GamePartyMembers_GamePartyId",
                table: "GamePartyMembers",
                column: "GamePartyId");

            migrationBuilder.CreateIndex(
                name: "IX_GamePartyMembers_GameRoleId",
                table: "GamePartyMembers",
                column: "GameRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_GamePartyMembers_PlayerId",
                table: "GamePartyMembers",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_GameRates_GameId",
                table: "GameRates",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_GameRates_UserId",
                table: "GameRates",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_GameRoles_GameId",
                table: "GameRoles",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_Games_Name",
                table: "Games",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Players_AccountId",
                table: "Players",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Players_CreatorId",
                table: "Players",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_UserFriends_InRequestUserId",
                table: "UserFriends",
                column: "InRequestUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserFriends_OutRequestUserId",
                table: "UserFriends",
                column: "OutRequestUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserGamePlaces_UserId_Name",
                table: "UserGamePlaces",
                columns: new[] { "UserId", "Name" },
                unique: true,
                filter: "[UserId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_UserGames_GameId",
                table: "UserGames",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_UserGames_UserId_GameId",
                table: "UserGames",
                columns: new[] { "UserId", "GameId" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "GamePartyMembers");

            migrationBuilder.DropTable(
                name: "GameRates");

            migrationBuilder.DropTable(
                name: "UserFriends");

            migrationBuilder.DropTable(
                name: "UserGames");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "GameParties");

            migrationBuilder.DropTable(
                name: "GameRoles");

            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "UserGamePlaces");

            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
