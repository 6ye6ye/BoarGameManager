using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    public partial class AddGameInfoMaxLength : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("d44e1604-bd00-4f24-8697-8845c06a79e3"), new Guid("232c8238-74a6-40d1-8fa8-4bd595c57b70") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("052aa42e-dcd5-42ec-9371-49968f750cd0"), new Guid("32defc01-26c0-4ac1-b54c-fd99812ba043") });

            migrationBuilder.DeleteData(
                table: "GameParties",
                keyColumn: "Id",
                keyValue: new Guid("d28731d3-9861-4ba8-8d27-2ad0178ebaf2"));

            migrationBuilder.DeleteData(
                table: "GameRoles",
                keyColumn: "Id",
                keyValue: new Guid("0dd5bf03-cd7a-4661-a0c0-65970f79bc1f"));

            migrationBuilder.DeleteData(
                table: "GameRoles",
                keyColumn: "Id",
                keyValue: new Guid("186e9cf5-50ff-4416-8c73-28484cf416f1"));

            migrationBuilder.DeleteData(
                table: "GameRoles",
                keyColumn: "Id",
                keyValue: new Guid("220f20cf-4d2b-41e4-9bc9-54a6f34c1594"));

            migrationBuilder.DeleteData(
                table: "GameRoles",
                keyColumn: "Id",
                keyValue: new Guid("3ebb401e-8697-4956-9259-13e5d0e54c7a"));

            migrationBuilder.DeleteData(
                table: "GameRoles",
                keyColumn: "Id",
                keyValue: new Guid("552f8cde-5a5b-463a-9716-5a0d41e3e3ba"));

            migrationBuilder.DeleteData(
                table: "GameRoles",
                keyColumn: "Id",
                keyValue: new Guid("74adf251-6dd6-4348-a328-cc47ef9b50d3"));

            migrationBuilder.DeleteData(
                table: "GameRoles",
                keyColumn: "Id",
                keyValue: new Guid("8321a22d-ece5-49e3-bd4d-0f6367b55d9c"));

            migrationBuilder.DeleteData(
                table: "GameRoles",
                keyColumn: "Id",
                keyValue: new Guid("89bba2d1-2ac4-4a4c-bc6b-778101785c3b"));

            migrationBuilder.DeleteData(
                table: "GameRoles",
                keyColumn: "Id",
                keyValue: new Guid("9757c39c-55ea-472c-9c87-aab354edcf10"));

            migrationBuilder.DeleteData(
                table: "GameRoles",
                keyColumn: "Id",
                keyValue: new Guid("e979d263-befa-432d-874f-8ec2c1506e03"));

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: new Guid("6787ed8d-73c8-4540-ad02-d069fbafa964"));

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: new Guid("bc6dc3c2-5560-411a-b0f3-4eb3c8466765"));

            migrationBuilder.DeleteData(
                table: "UserFriends",
                keyColumn: "Id",
                keyValue: new Guid("24a8e07c-ce8a-4e9d-9c31-2fccd0af202a"));

            migrationBuilder.DeleteData(
                table: "UserGamePlaces",
                keyColumn: "Id",
                keyValue: new Guid("d20ac8bb-b8b1-4d5d-bcd2-558f746d8a2f"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("052aa42e-dcd5-42ec-9371-49968f750cd0"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("d44e1604-bd00-4f24-8697-8845c06a79e3"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("232c8238-74a6-40d1-8fa8-4bd595c57b70"));

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: new Guid("63cc2b4d-34f0-4240-879c-dd15a8104b55"));

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: new Guid("955fa3d0-0b2c-4251-8244-b8c09360a254"));

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: new Guid("9f07f524-eee0-468d-9e50-4c26c614d79c"));

            migrationBuilder.DeleteData(
                table: "UserGamePlaces",
                keyColumn: "Id",
                keyValue: new Guid("fc85bc3f-3475-4669-8cc9-3a98cbfcbcb4"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("32defc01-26c0-4ac1-b54c-fd99812ba043"));

            migrationBuilder.AlterColumn<string>(
                name: "NameRu",
                table: "Games",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NameEng",
                table: "Games",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "GameInfoShort",
                table: "Games",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<string>(
                name: "NameRu",
                table: "Games",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NameEng",
                table: "Games",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "GameInfoShort",
                table: "Games",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldNullable: true);

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
        }
    }
}
