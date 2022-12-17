using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    public partial class AddAliasAndTesseraIdToGame : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("e1842a09-3159-48df-b92b-0469fd6bdc10"), new Guid("dc879d7a-6ace-4ac4-a97a-e118cc9693e1") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("81f88817-4432-4793-a5cd-1f4b382bc082"), new Guid("e49f0663-ac77-4240-8623-7b58b45ed997") });

            migrationBuilder.DeleteData(
                table: "GameParties",
                keyColumn: "Id",
                keyValue: new Guid("e2f5b10b-3598-44bf-be8f-9c3a5f29bb17"));

            migrationBuilder.DeleteData(
                table: "GameRoles",
                keyColumn: "Id",
                keyValue: new Guid("00482be0-b5a0-4dd6-b382-5b8fc3a2b005"));

            migrationBuilder.DeleteData(
                table: "GameRoles",
                keyColumn: "Id",
                keyValue: new Guid("0a37c203-5ee4-4ee5-a3a0-9a045384f925"));

            migrationBuilder.DeleteData(
                table: "GameRoles",
                keyColumn: "Id",
                keyValue: new Guid("0c205690-8ca7-4522-8ab9-9a674647a5d4"));

            migrationBuilder.DeleteData(
                table: "GameRoles",
                keyColumn: "Id",
                keyValue: new Guid("395adb4f-43ca-4452-bc7b-bcd5bcf6e1c0"));

            migrationBuilder.DeleteData(
                table: "GameRoles",
                keyColumn: "Id",
                keyValue: new Guid("519006af-6485-4835-b7af-ea7fdacaa099"));

            migrationBuilder.DeleteData(
                table: "GameRoles",
                keyColumn: "Id",
                keyValue: new Guid("68061ff3-a446-4927-a500-98ffd79736de"));

            migrationBuilder.DeleteData(
                table: "GameRoles",
                keyColumn: "Id",
                keyValue: new Guid("86094dc8-7753-44f4-807c-d91250de7245"));

            migrationBuilder.DeleteData(
                table: "GameRoles",
                keyColumn: "Id",
                keyValue: new Guid("a6dafb1d-1c3a-4459-bc18-44b2c3097244"));

            migrationBuilder.DeleteData(
                table: "GameRoles",
                keyColumn: "Id",
                keyValue: new Guid("ab68f0e0-2849-4e72-b12b-56f1ecb6dd15"));

            migrationBuilder.DeleteData(
                table: "GameRoles",
                keyColumn: "Id",
                keyValue: new Guid("de412b96-285c-4364-8afd-6d45c1160645"));

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: new Guid("0cffa9cd-73d6-4822-aca3-2280bafbee25"));

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: new Guid("e68df94c-83b9-4921-9e41-c31d0abfe7b6"));

            migrationBuilder.DeleteData(
                table: "UserFriends",
                keyColumn: "Id",
                keyValue: new Guid("831ba59e-05da-40b7-8c8d-6ce8f53a6d52"));

            migrationBuilder.DeleteData(
                table: "UserGamePlaces",
                keyColumn: "Id",
                keyValue: new Guid("5b18ef79-f5b8-47ea-8624-784ddef546a6"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("81f88817-4432-4793-a5cd-1f4b382bc082"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("e1842a09-3159-48df-b92b-0469fd6bdc10"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("dc879d7a-6ace-4ac4-a97a-e118cc9693e1"));

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: new Guid("100fafa0-fe38-4693-b876-335aa5138aa1"));

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: new Guid("42e59348-1525-4431-ae38-dc177d5be0d7"));

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: new Guid("49bb2951-207e-497b-b43c-711d287fa2c0"));

            migrationBuilder.DeleteData(
                table: "UserGamePlaces",
                keyColumn: "Id",
                keyValue: new Guid("4033511a-ac78-4cd3-a4b0-4d0cbb1b8a02"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e49f0663-ac77-4240-8623-7b58b45ed997"));

            migrationBuilder.AddColumn<string>(
                name: "Alias",
                table: "Games",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "TesseraId",
                table: "Games",
                type: "int",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("a15a448f-1efe-449a-968b-0b9d4ddb8ec7"), "7fde8ce8-cf35-4197-97d2-794686f7672c", "User", "User" },
                    { new Guid("de7ef132-723a-4dd8-ad50-7d80a5ee8e17"), "de0e16dc-6797-4f2c-b097-5e08ec5ab4ed", "Admin", "Admin" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("3fa4311c-95d8-4083-bb02-2e6be15c7bee"), 0, "4cb6cf9a-5c88-497d-8096-39b7dc5f31e0", "admin@gmail.com", false, false, null, "admin@gmail.com", "admin", "AQAAAAEAACcQAAAAEGPrM0+a2DPLt2IDXeNXCxwz6N4b+aTzO0qbm2ijrTLm0wZMouCaC+8Oan/u3yF+ZQ==", null, false, "10364dfe-d520-45be-9624-d23464ee5c00", false, "admin" },
                    { new Guid("7fe08019-9bba-4a70-8091-65796d61b1e5"), 0, "0b355f24-c5d4-4046-932e-f8c8129b22a7", "user@gmail.com", false, false, null, "user@gmail.com", "user", "AQAAAAEAACcQAAAAEGPrM0+a2DPLt2IDXeNXCxwz6N4b+aTzO0qbm2ijrTLm0wZMouCaC+8Oan/u3yF+ZQ==", null, false, "b91c3e91-b252-4e20-b8ad-9da9eac60177", false, "user" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("de7ef132-723a-4dd8-ad50-7d80a5ee8e17"), new Guid("3fa4311c-95d8-4083-bb02-2e6be15c7bee") },
                    { new Guid("a15a448f-1efe-449a-968b-0b9d4ddb8ec7"), new Guid("7fe08019-9bba-4a70-8091-65796d61b1e5") }
                });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "Id", "AccountId", "CreatorId", "Name" },
                values: new object[,]
                {
                    { new Guid("7ea4868f-b2ee-4373-b276-7d76f698d099"), new Guid("3fa4311c-95d8-4083-bb02-2e6be15c7bee"), null, "admin" },
                    { new Guid("e968c49c-3774-4dd6-adb1-34546745c2ad"), new Guid("7fe08019-9bba-4a70-8091-65796d61b1e5"), null, "user" }
                });

            migrationBuilder.InsertData(
                table: "UserFriends",
                columns: new[] { "Id", "InRequestUserId", "OutRequestUserId", "Status" },
                values: new object[] { new Guid("6b148b17-a7fd-4fb5-9010-b153ebb55b6d"), new Guid("3fa4311c-95d8-4083-bb02-2e6be15c7bee"), new Guid("7fe08019-9bba-4a70-8091-65796d61b1e5"), 1 });

            migrationBuilder.InsertData(
                table: "UserGamePlaces",
                columns: new[] { "Id", "Name", "UserId" },
                values: new object[,]
                {
                    { new Guid("bbbb626c-0f6d-4e55-bda3-6bbe92e67b10"), "Work", new Guid("3fa4311c-95d8-4083-bb02-2e6be15c7bee") },
                    { new Guid("d161eda9-5015-4feb-a931-5c178e89a15f"), "MyHome", new Guid("3fa4311c-95d8-4083-bb02-2e6be15c7bee") }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("de7ef132-723a-4dd8-ad50-7d80a5ee8e17"), new Guid("3fa4311c-95d8-4083-bb02-2e6be15c7bee") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("a15a448f-1efe-449a-968b-0b9d4ddb8ec7"), new Guid("7fe08019-9bba-4a70-8091-65796d61b1e5") });

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: new Guid("7ea4868f-b2ee-4373-b276-7d76f698d099"));

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: new Guid("e968c49c-3774-4dd6-adb1-34546745c2ad"));

            migrationBuilder.DeleteData(
                table: "UserFriends",
                keyColumn: "Id",
                keyValue: new Guid("6b148b17-a7fd-4fb5-9010-b153ebb55b6d"));

            migrationBuilder.DeleteData(
                table: "UserGamePlaces",
                keyColumn: "Id",
                keyValue: new Guid("bbbb626c-0f6d-4e55-bda3-6bbe92e67b10"));

            migrationBuilder.DeleteData(
                table: "UserGamePlaces",
                keyColumn: "Id",
                keyValue: new Guid("d161eda9-5015-4feb-a931-5c178e89a15f"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("a15a448f-1efe-449a-968b-0b9d4ddb8ec7"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("de7ef132-723a-4dd8-ad50-7d80a5ee8e17"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("3fa4311c-95d8-4083-bb02-2e6be15c7bee"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("7fe08019-9bba-4a70-8091-65796d61b1e5"));

            migrationBuilder.DropColumn(
                name: "Alias",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "TesseraId",
                table: "Games");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("81f88817-4432-4793-a5cd-1f4b382bc082"), "c358a68c-8147-4687-bbd6-7547f9ed7ce1", "Admin", "Admin" },
                    { new Guid("e1842a09-3159-48df-b92b-0469fd6bdc10"), "6df5739d-26d1-4fe1-a015-17a0f7a146da", "User", "User" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("dc879d7a-6ace-4ac4-a97a-e118cc9693e1"), 0, "a220fc2e-4c39-442c-be85-741955d82f8f", "user@gmail.com", false, false, null, "user@gmail.com", "user", "AQAAAAEAACcQAAAAEGPrM0+a2DPLt2IDXeNXCxwz6N4b+aTzO0qbm2ijrTLm0wZMouCaC+8Oan/u3yF+ZQ==", null, false, "8940dde6-a2d7-4a7b-83eb-e7988c973a21", false, "use" },
                    { new Guid("e49f0663-ac77-4240-8623-7b58b45ed997"), 0, "d02d687f-02da-4fe8-9a79-4b4cd11d084f", "admin@gmail.com", false, false, null, "admin@gmail.com", "admin", "AQAAAAEAACcQAAAAEGPrM0+a2DPLt2IDXeNXCxwz6N4b+aTzO0qbm2ijrTLm0wZMouCaC+8Oan/u3yF+ZQ==", null, false, "dcb753e6-109f-44f1-8130-afc40691a827", false, "admin" }
                });

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "Id", "GameInfo", "GameInfoShort", "Image", "MaxPartyTime", "MinAge", "MinPartyTime", "Name", "NameEng", "NameRu", "PlayersMaxCount", "PlayersMinCount", "Rating", "RatingCount", "ReleaseYear" },
                values: new object[,]
                {
                    { new Guid("100fafa0-fe38-4693-b876-335aa5138aa1"), null, "Вы любите детективы? Тогда эта увлекательная психологическая пошаговая ролевая игра с детективным\r\nсюжетом для вас. Она отлично подходит для игры в домашнем кругу,\r\nдля весёлой компании на различных вечеринках и даже в дороге поможет интересно \r\nпровести время.", "no-image-icon-6.png", 120, 10, 60, "Mafia Delux", "Mafia", "Мафия", 12, 4, 0.0, 0, 2021 },
                    { new Guid("42e59348-1525-4431-ae38-dc177d5be0d7"), "Игра Star Wars: Rebellion основана на классической кинотрилогии («Эпизод IV: Новая надежда», «Эпизод V: Империя наносит ответный удар», «Эпизод VI: Возвращение джедая»). Игрокам предлагают разыграть партию между Империей и повстанцами, силы и методы которых сильно разнятся. Карта, на которой разворачивается гражданская война, \r\n                огромна, поделена на регионы и насчитывает 32 звёздные системы.\\n\r\n                В распоряжении Империи два верных и мощных союзника — армия и флот, — и для победы \r\n                ей нужно обнаружить и уничтожить базу сопротивления. Повстанцы же вынуждены проводить\r\n                точечные удары из подполья, и чтобы выиграть гражданскую войну — им нужно, добиваясь\r\n                маленьких целей, привлечь на свою сторону как можно больше граждан и вдохновить их на \r\n                открытое восстание. При этом важную роль в конфликте играют лидеры: игроки начинают\r\n                партию с несколькими лидерами, во время партии получают новых и развивают их. ", "Звёздные Войны: Восстание (Star Wars: Rebellion) – игра, которая основана на классической кинотрилогии Звездных войн. Игрокам предлагают разыграть партию между Империей и повстанцами, \r\n                силы и методы которых сильно разнятся.", "StarWarsRebellion.jpg", 240, 14, 180, "Star Wars: Rebellion", "Star Wars: Rebellion", "Звездные войны: Восстание", 4, 2, 0.0, 0, 2016 },
                    { new Guid("49bb2951-207e-497b-b43c-711d287fa2c0"), "Forbidden Stars — стратегическая игра, события которой разворачиваются в мире \r\n                «Вархаммера 40 000». За контроль над игровым полем, составляемым каждый раз из квадратов \r\n                звёздных систем с планетами и космическим пространством, борются эльдары, орки, космодесант Хаоса и \r\n                космодесант, верный Императору.\r\n                Перед началом партии игроки по очереди добавляют по квадрату звёздной системы на стол, пока не будет сформировано игровое поле, \r\n                а затем расставляют свои стартовые войска и космические флоты, а также выкладывают жетоны целей. \r\n                Конфигурация игрового поля влияет на связи между системами. Сообщению между смежными системами может \r\n                мешать варп-шторм, который представлен жетоном-полоской. Во время партии варп-шторм движется: в конце \r\n                каждого раунда игроки перемещают полоску. Победа достаётся игроку, которому удалось первым установить \r\n                контроль над нужными системами и собрать все свои жетоны целей.\r\n                Каждый раунд игроки раздают приказы, выкладывая соответствующие жетоны рубашкой вверх \r\n                в системы. Жетоны могут накрывать друг друга и образовывать стопки. Приказы в каждой стопке применяются\r\n                от верхнего к нижнему. Всего в игре четыре вида приказов: мобилизация позволяет наращивать боевую мощь \r\n                за счёт новых войск и космических кораблей, а также возводить новые постройки для развития и защиты планет; \r\n                планирование — добирать карты, которыми можно влиять на исход боёв или увеличивать эффективность последующих\r\n                приказов, а также вредить противникам; администрирование — собирать ресурсы с подконтрольных планет и\r\n                использовать свойство своей фракции; передислокация — перемещать космические корабли и перебрасывать войска\r\n                с планеты на планету.\r\n                Во время боя игрок бросает некоторое количество кубиков за свои участвующие боевые единицы. \r\n                Выпавшие символы задают уровни нападения, обороны и боевого духа. Также противники могут удивить друг друга,\r\n                сыграв карты боя, которые не только усиливают эти параметры войск, но и позволяют применить особые эффекты, позволяющие уничтожить как можно больше сил противника, \r\n                уйти в глухую оборону и т.д. Листы боевых единиц и карты боя у каждой фракции свои.", "Forbidden Stars — стратегическая игра, события которой разворачиваются в\r\nмире «Вархаммера 40 000». За контроль над игровым полем, составляемым каждый раз из\r\nквадратов звёздных систем с планетами и космическим пространством, борются эльдары, орки, \r\nкосмодесант Хаоса и космодесант, верный Императору. ", "forbiddenStars.jpg", 120, 14, 60, "Forbidden Stars", "Forbidden Stars", "Запретные звезды", 4, 2, 0.0, 0, 2015 }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("e1842a09-3159-48df-b92b-0469fd6bdc10"), new Guid("dc879d7a-6ace-4ac4-a97a-e118cc9693e1") },
                    { new Guid("81f88817-4432-4793-a5cd-1f4b382bc082"), new Guid("e49f0663-ac77-4240-8623-7b58b45ed997") }
                });

            migrationBuilder.InsertData(
                table: "GameRoles",
                columns: new[] { "Id", "GameId", "Name" },
                values: new object[,]
                {
                    { new Guid("00482be0-b5a0-4dd6-b382-5b8fc3a2b005"), new Guid("49bb2951-207e-497b-b43c-711d287fa2c0"), "Ork" },
                    { new Guid("0a37c203-5ee4-4ee5-a3a0-9a045384f925"), new Guid("49bb2951-207e-497b-b43c-711d287fa2c0"), "Eldar" },
                    { new Guid("0c205690-8ca7-4522-8ab9-9a674647a5d4"), new Guid("42e59348-1525-4431-ae38-dc177d5be0d7"), "Empire" },
                    { new Guid("395adb4f-43ca-4452-bc7b-bcd5bcf6e1c0"), new Guid("49bb2951-207e-497b-b43c-711d287fa2c0"), "Chaos Space Marine" },
                    { new Guid("519006af-6485-4835-b7af-ea7fdacaa099"), new Guid("100fafa0-fe38-4693-b876-335aa5138aa1"), "Sheriff" },
                    { new Guid("68061ff3-a446-4927-a500-98ffd79736de"), new Guid("42e59348-1525-4431-ae38-dc177d5be0d7"), "Rebels" },
                    { new Guid("86094dc8-7753-44f4-807c-d91250de7245"), new Guid("100fafa0-fe38-4693-b876-335aa5138aa1"), "Mafia" },
                    { new Guid("a6dafb1d-1c3a-4459-bc18-44b2c3097244"), new Guid("100fafa0-fe38-4693-b876-335aa5138aa1"), "Doctor" },
                    { new Guid("ab68f0e0-2849-4e72-b12b-56f1ecb6dd15"), new Guid("49bb2951-207e-497b-b43c-711d287fa2c0"), "Emperor's Space Marine" },
                    { new Guid("de412b96-285c-4364-8afd-6d45c1160645"), new Guid("100fafa0-fe38-4693-b876-335aa5138aa1"), "Player" }
                });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "Id", "AccountId", "CreatorId", "Name" },
                values: new object[,]
                {
                    { new Guid("0cffa9cd-73d6-4822-aca3-2280bafbee25"), new Guid("e49f0663-ac77-4240-8623-7b58b45ed997"), null, "admin" },
                    { new Guid("e68df94c-83b9-4921-9e41-c31d0abfe7b6"), new Guid("dc879d7a-6ace-4ac4-a97a-e118cc9693e1"), null, "use" }
                });

            migrationBuilder.InsertData(
                table: "UserFriends",
                columns: new[] { "Id", "InRequestUserId", "OutRequestUserId", "Status" },
                values: new object[] { new Guid("831ba59e-05da-40b7-8c8d-6ce8f53a6d52"), new Guid("e49f0663-ac77-4240-8623-7b58b45ed997"), new Guid("dc879d7a-6ace-4ac4-a97a-e118cc9693e1"), 1 });

            migrationBuilder.InsertData(
                table: "UserGamePlaces",
                columns: new[] { "Id", "Name", "UserId" },
                values: new object[,]
                {
                    { new Guid("4033511a-ac78-4cd3-a4b0-4d0cbb1b8a02"), "MyHome", new Guid("e49f0663-ac77-4240-8623-7b58b45ed997") },
                    { new Guid("5b18ef79-f5b8-47ea-8624-784ddef546a6"), "Work", new Guid("e49f0663-ac77-4240-8623-7b58b45ed997") }
                });

            migrationBuilder.InsertData(
                table: "GameParties",
                columns: new[] { "Id", "Date", "GameId", "PartyCreatorId", "UserGamePlaceId" },
                values: new object[] { new Guid("e2f5b10b-3598-44bf-be8f-9c3a5f29bb17"), new DateTime(2022, 12, 9, 14, 52, 1, 885, DateTimeKind.Local).AddTicks(7172), new Guid("100fafa0-fe38-4693-b876-335aa5138aa1"), new Guid("e49f0663-ac77-4240-8623-7b58b45ed997"), new Guid("4033511a-ac78-4cd3-a4b0-4d0cbb1b8a02") });
        }
    }
}
