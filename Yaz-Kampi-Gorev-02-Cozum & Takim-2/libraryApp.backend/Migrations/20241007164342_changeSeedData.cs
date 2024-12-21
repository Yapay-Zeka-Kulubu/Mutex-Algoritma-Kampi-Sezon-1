using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace libraryApp.backend.Migrations
{
    /// <inheritdoc />
    public partial class changeSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "cezalar",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CezaBitisGunu", "CezaGunu" },
                values: new object[] { new DateTime(2024, 9, 17, 16, 43, 39, 641, DateTimeKind.Utc).AddTicks(5525), new DateTime(2024, 9, 7, 16, 43, 39, 641, DateTimeKind.Utc).AddTicks(5519) });

            migrationBuilder.UpdateData(
                table: "cezalar",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CezaBitisGunu", "CezaGunu" },
                values: new object[] { new DateTime(2024, 8, 18, 16, 43, 39, 641, DateTimeKind.Utc).AddTicks(5527), new DateTime(2024, 8, 8, 16, 43, 39, 641, DateTimeKind.Utc).AddTicks(5526) });

            migrationBuilder.UpdateData(
                table: "cezalar",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CezaBitisGunu", "CezaGunu" },
                values: new object[] { new DateTime(2024, 10, 2, 16, 43, 39, 641, DateTimeKind.Utc).AddTicks(5529), new DateTime(2024, 9, 27, 16, 43, 39, 641, DateTimeKind.Utc).AddTicks(5528) });

            migrationBuilder.UpdateData(
                table: "cezalar",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CezaBitisGunu", "CezaGunu" },
                values: new object[] { new DateTime(2024, 9, 22, 16, 43, 39, 641, DateTimeKind.Utc).AddTicks(5531), new DateTime(2024, 9, 12, 16, 43, 39, 641, DateTimeKind.Utc).AddTicks(5530) });

            migrationBuilder.UpdateData(
                table: "cezalar",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CezaBitisGunu", "CezaGunu" },
                values: new object[] { new DateTime(2024, 9, 7, 16, 43, 39, 641, DateTimeKind.Utc).AddTicks(5532), new DateTime(2024, 8, 28, 16, 43, 39, 641, DateTimeKind.Utc).AddTicks(5532) });

            migrationBuilder.UpdateData(
                table: "cezalar",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CezaBitisGunu", "CezaGunu" },
                values: new object[] { new DateTime(2024, 8, 8, 16, 43, 39, 641, DateTimeKind.Utc).AddTicks(5534), new DateTime(2024, 7, 29, 16, 43, 39, 641, DateTimeKind.Utc).AddTicks(5534) });

            migrationBuilder.UpdateData(
                table: "cezalar",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CezaBitisGunu", "CezaGunu" },
                values: new object[] { new DateTime(2024, 10, 12, 16, 43, 39, 641, DateTimeKind.Utc).AddTicks(5536), new DateTime(2024, 10, 2, 16, 43, 39, 641, DateTimeKind.Utc).AddTicks(5535) });

            migrationBuilder.UpdateData(
                table: "cezalar",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CezaBitisGunu", "CezaGunu" },
                values: new object[] { new DateTime(2024, 7, 9, 16, 43, 39, 641, DateTimeKind.Utc).AddTicks(5537), new DateTime(2024, 6, 29, 16, 43, 39, 641, DateTimeKind.Utc).AddTicks(5537) });

            migrationBuilder.UpdateData(
                table: "cezalar",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CezaBitisGunu", "CezaGunu" },
                values: new object[] { new DateTime(2024, 9, 27, 16, 43, 39, 641, DateTimeKind.Utc).AddTicks(5539), new DateTime(2024, 9, 17, 16, 43, 39, 641, DateTimeKind.Utc).AddTicks(5538) });

            migrationBuilder.UpdateData(
                table: "cezalar",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CezaBitisGunu", "CezaGunu" },
                values: new object[] { new DateTime(2024, 9, 12, 16, 43, 39, 641, DateTimeKind.Utc).AddTicks(5541), new DateTime(2024, 9, 2, 16, 43, 39, 641, DateTimeKind.Utc).AddTicks(5540) });

            migrationBuilder.UpdateData(
                table: "hesapAcmaTalepleri",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "TalepTarihi", "UserId" },
                values: new object[] { new DateTime(2024, 10, 2, 16, 43, 39, 641, DateTimeKind.Utc).AddTicks(5667), 1 });

            migrationBuilder.UpdateData(
                table: "hesapAcmaTalepleri",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "TalepTarihi", "UserId" },
                values: new object[] { new DateTime(2024, 10, 2, 16, 43, 39, 641, DateTimeKind.Utc).AddTicks(5669), 2 });

            migrationBuilder.UpdateData(
                table: "hesapAcmaTalepleri",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "BeklemedeMi", "OnaylandiMi", "TalepTarihi", "UserId" },
                values: new object[] { false, true, new DateTime(2024, 10, 2, 16, 43, 39, 641, DateTimeKind.Utc).AddTicks(5671), 3 });

            migrationBuilder.UpdateData(
                table: "hesapAcmaTalepleri",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "TalepTarihi", "UserId" },
                values: new object[] { new DateTime(2024, 10, 2, 16, 43, 39, 641, DateTimeKind.Utc).AddTicks(5672), 4 });

            migrationBuilder.UpdateData(
                table: "hesapAcmaTalepleri",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "BeklemedeMi", "OnaylandiMi", "TalepTarihi", "UserId" },
                values: new object[] { false, true, new DateTime(2024, 9, 27, 16, 43, 39, 641, DateTimeKind.Utc).AddTicks(5674), 5 });

            migrationBuilder.UpdateData(
                table: "hesapAcmaTalepleri",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "TalepTarihi", "UserId" },
                values: new object[] { new DateTime(2024, 9, 22, 16, 43, 39, 641, DateTimeKind.Utc).AddTicks(5675), 6 });

            migrationBuilder.UpdateData(
                table: "hesapAcmaTalepleri",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "BeklemedeMi", "OnaylandiMi", "TalepTarihi", "UserId" },
                values: new object[] { false, true, new DateTime(2024, 9, 17, 16, 43, 39, 641, DateTimeKind.Utc).AddTicks(5680), 7 });

            migrationBuilder.UpdateData(
                table: "hesapAcmaTalepleri",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "TalepTarihi", "UserId" },
                values: new object[] { new DateTime(2024, 9, 12, 16, 43, 39, 641, DateTimeKind.Utc).AddTicks(5681), 8 });

            migrationBuilder.UpdateData(
                table: "hesapAcmaTalepleri",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "BeklemedeMi", "OnaylandiMi", "TalepTarihi", "UserId" },
                values: new object[] { false, true, new DateTime(2024, 9, 7, 16, 43, 39, 641, DateTimeKind.Utc).AddTicks(5682), 9 });

            migrationBuilder.UpdateData(
                table: "hesapAcmaTalepleri",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "TalepTarihi", "UserId" },
                values: new object[] { new DateTime(2024, 9, 2, 16, 43, 39, 641, DateTimeKind.Utc).AddTicks(5683), 10 });

            migrationBuilder.InsertData(
                table: "hesapAcmaTalepleri",
                columns: new[] { "Id", "BeklemedeMi", "OnaylandiMi", "TalepTarihi", "UserId" },
                values: new object[,]
                {
                    { 11, false, true, new DateTime(2024, 8, 28, 16, 43, 39, 641, DateTimeKind.Utc).AddTicks(5690), 11 },
                    { 12, false, true, new DateTime(2024, 8, 23, 16, 43, 39, 641, DateTimeKind.Utc).AddTicks(5691), 12 },
                    { 13, false, true, new DateTime(2024, 8, 18, 16, 43, 39, 641, DateTimeKind.Utc).AddTicks(5692), 13 },
                    { 14, false, true, new DateTime(2024, 8, 18, 16, 43, 39, 641, DateTimeKind.Utc).AddTicks(5693), 14 }
                });

            migrationBuilder.UpdateData(
                table: "kitapOduncler",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DonusTarihi", "TalepTarihi" },
                values: new object[] { new DateTime(2024, 10, 14, 16, 43, 39, 641, DateTimeKind.Utc).AddTicks(5760), new DateTime(2024, 9, 30, 16, 43, 39, 641, DateTimeKind.Utc).AddTicks(5759) });

            migrationBuilder.UpdateData(
                table: "kitapOduncler",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DonusTarihi", "TalepTarihi" },
                values: new object[] { new DateTime(2024, 10, 13, 16, 43, 39, 641, DateTimeKind.Utc).AddTicks(5763), new DateTime(2024, 9, 29, 16, 43, 39, 641, DateTimeKind.Utc).AddTicks(5762) });

            migrationBuilder.UpdateData(
                table: "kitapOduncler",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DonusTarihi", "TalepTarihi" },
                values: new object[] { new DateTime(2024, 10, 12, 16, 43, 39, 641, DateTimeKind.Utc).AddTicks(5765), new DateTime(2024, 9, 28, 16, 43, 39, 641, DateTimeKind.Utc).AddTicks(5764) });

            migrationBuilder.UpdateData(
                table: "kitapOduncler",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DonusTarihi", "TalepTarihi" },
                values: new object[] { new DateTime(2024, 10, 11, 16, 43, 39, 641, DateTimeKind.Utc).AddTicks(5767), new DateTime(2024, 9, 27, 16, 43, 39, 641, DateTimeKind.Utc).AddTicks(5766) });

            migrationBuilder.UpdateData(
                table: "kitapOduncler",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DonusTarihi", "TalepTarihi" },
                values: new object[] { new DateTime(2024, 10, 10, 16, 43, 39, 641, DateTimeKind.Utc).AddTicks(5769), new DateTime(2024, 9, 26, 16, 43, 39, 641, DateTimeKind.Utc).AddTicks(5768) });

            migrationBuilder.UpdateData(
                table: "kitapOduncler",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DonusTarihi", "TalepTarihi" },
                values: new object[] { new DateTime(2024, 10, 9, 16, 43, 39, 641, DateTimeKind.Utc).AddTicks(5836), new DateTime(2024, 9, 25, 16, 43, 39, 641, DateTimeKind.Utc).AddTicks(5835) });

            migrationBuilder.UpdateData(
                table: "kitapOduncler",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "DonusTarihi", "TalepTarihi" },
                values: new object[] { new DateTime(2024, 10, 8, 16, 43, 39, 641, DateTimeKind.Utc).AddTicks(5838), new DateTime(2024, 9, 24, 16, 43, 39, 641, DateTimeKind.Utc).AddTicks(5837) });

            migrationBuilder.UpdateData(
                table: "kitapOduncler",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "DonusTarihi", "TalepTarihi" },
                values: new object[] { new DateTime(2024, 10, 6, 16, 43, 39, 641, DateTimeKind.Utc).AddTicks(5840), new DateTime(2024, 9, 23, 16, 43, 39, 641, DateTimeKind.Utc).AddTicks(5839) });

            migrationBuilder.UpdateData(
                table: "kitapOduncler",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "DonusTarihi", "TalepTarihi" },
                values: new object[] { new DateTime(2024, 10, 5, 16, 43, 39, 641, DateTimeKind.Utc).AddTicks(5842), new DateTime(2024, 9, 22, 16, 43, 39, 641, DateTimeKind.Utc).AddTicks(5841) });

            migrationBuilder.UpdateData(
                table: "kitapOduncler",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "DonusTarihi", "TalepTarihi" },
                values: new object[] { new DateTime(2024, 10, 4, 16, 43, 39, 641, DateTimeKind.Utc).AddTicks(5844), new DateTime(2024, 9, 21, 16, 43, 39, 641, DateTimeKind.Utc).AddTicks(5843) });

            migrationBuilder.UpdateData(
                table: "kitapYayinTalepleri",
                keyColumn: "Id",
                keyValue: 1,
                column: "TalepTarihi",
                value: new DateTime(2024, 10, 4, 16, 43, 39, 641, DateTimeKind.Utc).AddTicks(5872));

            migrationBuilder.UpdateData(
                table: "kitapYayinTalepleri",
                keyColumn: "Id",
                keyValue: 2,
                column: "TalepTarihi",
                value: new DateTime(2024, 9, 29, 16, 43, 39, 641, DateTimeKind.Utc).AddTicks(5876));

            migrationBuilder.UpdateData(
                table: "kitapYayinTalepleri",
                keyColumn: "Id",
                keyValue: 3,
                column: "TalepTarihi",
                value: new DateTime(2024, 9, 27, 16, 43, 39, 641, DateTimeKind.Utc).AddTicks(5877));

            migrationBuilder.UpdateData(
                table: "kitapYayinTalepleri",
                keyColumn: "Id",
                keyValue: 4,
                column: "TalepTarihi",
                value: new DateTime(2024, 9, 25, 16, 43, 39, 641, DateTimeKind.Utc).AddTicks(5879));

            migrationBuilder.UpdateData(
                table: "kitapYayinTalepleri",
                keyColumn: "Id",
                keyValue: 5,
                column: "TalepTarihi",
                value: new DateTime(2024, 9, 22, 16, 43, 39, 641, DateTimeKind.Utc).AddTicks(5880));

            migrationBuilder.UpdateData(
                table: "kitapYayinTalepleri",
                keyColumn: "Id",
                keyValue: 6,
                column: "TalepTarihi",
                value: new DateTime(2024, 9, 19, 16, 43, 39, 641, DateTimeKind.Utc).AddTicks(5881));

            migrationBuilder.UpdateData(
                table: "kitapYayinTalepleri",
                keyColumn: "Id",
                keyValue: 7,
                column: "TalepTarihi",
                value: new DateTime(2024, 9, 17, 16, 43, 39, 641, DateTimeKind.Utc).AddTicks(5883));

            migrationBuilder.UpdateData(
                table: "kitapYayinTalepleri",
                keyColumn: "Id",
                keyValue: 8,
                column: "TalepTarihi",
                value: new DateTime(2024, 9, 15, 16, 43, 39, 641, DateTimeKind.Utc).AddTicks(5884));

            migrationBuilder.UpdateData(
                table: "kitapYayinTalepleri",
                keyColumn: "Id",
                keyValue: 9,
                column: "TalepTarihi",
                value: new DateTime(2024, 9, 12, 16, 43, 39, 641, DateTimeKind.Utc).AddTicks(5885));

            migrationBuilder.UpdateData(
                table: "kitapYayinTalepleri",
                keyColumn: "Id",
                keyValue: 10,
                column: "TalepTarihi",
                value: new DateTime(2024, 9, 9, 16, 43, 39, 641, DateTimeKind.Utc).AddTicks(5886));

            migrationBuilder.UpdateData(
                table: "kitaplar",
                keyColumn: "Id",
                keyValue: 1,
                column: "YayinlanmaTarihi",
                value: new DateTime(2023, 10, 8, 16, 43, 39, 641, DateTimeKind.Utc).AddTicks(5724));

            migrationBuilder.UpdateData(
                table: "kitaplar",
                keyColumn: "Id",
                keyValue: 2,
                column: "YayinlanmaTarihi",
                value: new DateTime(2023, 9, 3, 16, 43, 39, 641, DateTimeKind.Utc).AddTicks(5726));

            migrationBuilder.UpdateData(
                table: "kitaplar",
                keyColumn: "Id",
                keyValue: 3,
                column: "YayinlanmaTarihi",
                value: new DateTime(2023, 5, 26, 16, 43, 39, 641, DateTimeKind.Utc).AddTicks(5727));

            migrationBuilder.UpdateData(
                table: "kitaplar",
                keyColumn: "Id",
                keyValue: 4,
                column: "YayinlanmaTarihi",
                value: new DateTime(2024, 3, 21, 16, 43, 39, 641, DateTimeKind.Utc).AddTicks(5728));

            migrationBuilder.UpdateData(
                table: "kitaplar",
                keyColumn: "Id",
                keyValue: 5,
                column: "YayinlanmaTarihi",
                value: new DateTime(2023, 12, 12, 16, 43, 39, 641, DateTimeKind.Utc).AddTicks(5729));

            migrationBuilder.UpdateData(
                table: "kitaplar",
                keyColumn: "Id",
                keyValue: 6,
                column: "YayinlanmaTarihi",
                value: new DateTime(2024, 5, 10, 16, 43, 39, 641, DateTimeKind.Utc).AddTicks(5730));

            migrationBuilder.UpdateData(
                table: "kitaplar",
                keyColumn: "Id",
                keyValue: 7,
                column: "YayinlanmaTarihi",
                value: new DateTime(2023, 2, 15, 16, 43, 39, 641, DateTimeKind.Utc).AddTicks(5731));

            migrationBuilder.UpdateData(
                table: "kitaplar",
                keyColumn: "Id",
                keyValue: 8,
                column: "YayinlanmaTarihi",
                value: new DateTime(2024, 6, 29, 16, 43, 39, 641, DateTimeKind.Utc).AddTicks(5732));

            migrationBuilder.UpdateData(
                table: "kitaplar",
                keyColumn: "Id",
                keyValue: 9,
                column: "YayinlanmaTarihi",
                value: new DateTime(2024, 1, 31, 16, 43, 39, 641, DateTimeKind.Utc).AddTicks(5734));

            migrationBuilder.UpdateData(
                table: "kitaplar",
                keyColumn: "Id",
                keyValue: 10,
                column: "YayinlanmaTarihi",
                value: new DateTime(2023, 11, 22, 16, 43, 39, 641, DateTimeKind.Utc).AddTicks(5735));

            migrationBuilder.UpdateData(
                table: "puanlar",
                keyColumn: "Id",
                keyValue: 1,
                column: "PuanGunu",
                value: new DateTime(2024, 10, 6, 16, 43, 39, 641, DateTimeKind.Utc).AddTicks(5976));

            migrationBuilder.UpdateData(
                table: "puanlar",
                keyColumn: "Id",
                keyValue: 2,
                column: "PuanGunu",
                value: new DateTime(2024, 10, 2, 16, 43, 39, 641, DateTimeKind.Utc).AddTicks(5978));

            migrationBuilder.UpdateData(
                table: "puanlar",
                keyColumn: "Id",
                keyValue: 3,
                column: "PuanGunu",
                value: new DateTime(2024, 9, 27, 16, 43, 39, 641, DateTimeKind.Utc).AddTicks(5979));

            migrationBuilder.UpdateData(
                table: "puanlar",
                keyColumn: "Id",
                keyValue: 4,
                column: "PuanGunu",
                value: new DateTime(2024, 9, 22, 16, 43, 39, 641, DateTimeKind.Utc).AddTicks(5980));

            migrationBuilder.UpdateData(
                table: "puanlar",
                keyColumn: "Id",
                keyValue: 5,
                column: "PuanGunu",
                value: new DateTime(2024, 9, 17, 16, 43, 39, 641, DateTimeKind.Utc).AddTicks(5981));

            migrationBuilder.UpdateData(
                table: "puanlar",
                keyColumn: "Id",
                keyValue: 6,
                column: "PuanGunu",
                value: new DateTime(2024, 9, 12, 16, 43, 39, 641, DateTimeKind.Utc).AddTicks(5983));

            migrationBuilder.UpdateData(
                table: "puanlar",
                keyColumn: "Id",
                keyValue: 7,
                column: "PuanGunu",
                value: new DateTime(2024, 9, 7, 16, 43, 39, 641, DateTimeKind.Utc).AddTicks(5984));

            migrationBuilder.UpdateData(
                table: "puanlar",
                keyColumn: "Id",
                keyValue: 8,
                column: "PuanGunu",
                value: new DateTime(2024, 9, 2, 16, 43, 39, 641, DateTimeKind.Utc).AddTicks(5985));

            migrationBuilder.UpdateData(
                table: "puanlar",
                keyColumn: "Id",
                keyValue: 9,
                column: "PuanGunu",
                value: new DateTime(2024, 8, 28, 16, 43, 39, 641, DateTimeKind.Utc).AddTicks(5986));

            migrationBuilder.UpdateData(
                table: "puanlar",
                keyColumn: "Id",
                keyValue: 10,
                column: "PuanGunu",
                value: new DateTime(2024, 8, 23, 16, 43, 39, 641, DateTimeKind.Utc).AddTicks(5987));

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$BWx8vIQSySBT7x26kwYRbu9zbn8N1xjleWOk1Rb0tGn9jJIolg8J6");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "$2a$11$cqBGhI9vhv1LVE56QQWtIu8arg4Z1tbShj2MDnDocwwSIUi1apDi2");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: 3,
                column: "Password",
                value: "$2a$11$k1GwuG4aew0k1vZPuLCpuexiZN/5cddWZJu6Px//h.zg8Gdub0NrK");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: 4,
                column: "Password",
                value: "$2a$11$j12HuRK5exgdi0NIEPSunu00j3OiUDh5QALFElZbzKJi9382FQgIe");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: 5,
                column: "Password",
                value: "$2a$11$c/odzOJHwNPsHdNp7a1BA.kmbaHVvvuzvSK.RbDLSrnf1bLiZy1eC");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: 6,
                column: "Password",
                value: "$2a$11$MHUGn/SrbZqKYVqD9.mVQednQ5Cl.vU0yGkGgJK3Xs2D3NuqLjzPe");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: 7,
                column: "Password",
                value: "$2a$11$VjCEkZNfE7tgthADJmZztengI3ZqhWd0I5N3kYpLxJZUOakeQfwV6");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: 8,
                column: "Password",
                value: "$2a$11$F9cIj.O3RSUrCDF.BZAt2e0G2x.QC15TtDkbvNUgCHYGzkSW0AV2.");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: 9,
                column: "Password",
                value: "$2a$11$3s93ifauQcyTRu3EHnuRXulTr/Cb22Ll4ive7zQhX2NROTIKSV8CC");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: 10,
                column: "Password",
                value: "$2a$11$gstZ70S5s/hIjjsTfbgMEuCIo47KhvajMGy0OeZuiExnszaqvCVu6");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: 11,
                column: "Password",
                value: "$2a$11$G9pcFopnCoOBq4WLTh057.6Gndd0i33s8cUrO3T4u4to7ck4ZQ9sm");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: 12,
                column: "Password",
                value: "$2a$11$10dryXGIVKN8bY6rWkGnEuZ00EfgHqbFfAZ9CPQ8AdeO5GtEsoiSe");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: 13,
                column: "Password",
                value: "$2a$11$GcxooHlxnEOsdD/0aYcDiOdGkOFEdGkDvIOwmqEZd9G.WfMTQpdCu");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: 14,
                column: "Password",
                value: "$2a$11$SEtujaji6yAe8kLycK03EuoU/THK0X7ttg4Me8qYlqRS8jVo.UTuO");

            migrationBuilder.CreateIndex(
                name: "IX_hesapAcmaTalepleri_UserId",
                table: "hesapAcmaTalepleri",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_cezalar_UserId",
                table: "cezalar",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_cezalar_users_UserId",
                table: "cezalar",
                column: "UserId",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_hesapAcmaTalepleri_users_UserId",
                table: "hesapAcmaTalepleri",
                column: "UserId",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_cezalar_users_UserId",
                table: "cezalar");

            migrationBuilder.DropForeignKey(
                name: "FK_hesapAcmaTalepleri_users_UserId",
                table: "hesapAcmaTalepleri");

            migrationBuilder.DropIndex(
                name: "IX_hesapAcmaTalepleri_UserId",
                table: "hesapAcmaTalepleri");

            migrationBuilder.DropIndex(
                name: "IX_cezalar_UserId",
                table: "cezalar");

            migrationBuilder.DeleteData(
                table: "hesapAcmaTalepleri",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "hesapAcmaTalepleri",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "hesapAcmaTalepleri",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "hesapAcmaTalepleri",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.UpdateData(
                table: "cezalar",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CezaBitisGunu", "CezaGunu" },
                values: new object[] { new DateTime(2024, 9, 12, 11, 17, 51, 392, DateTimeKind.Utc).AddTicks(9521), new DateTime(2024, 9, 2, 11, 17, 51, 392, DateTimeKind.Utc).AddTicks(9515) });

            migrationBuilder.UpdateData(
                table: "cezalar",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CezaBitisGunu", "CezaGunu" },
                values: new object[] { new DateTime(2024, 8, 13, 11, 17, 51, 392, DateTimeKind.Utc).AddTicks(9523), new DateTime(2024, 8, 3, 11, 17, 51, 392, DateTimeKind.Utc).AddTicks(9522) });

            migrationBuilder.UpdateData(
                table: "cezalar",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CezaBitisGunu", "CezaGunu" },
                values: new object[] { new DateTime(2024, 9, 27, 11, 17, 51, 392, DateTimeKind.Utc).AddTicks(9525), new DateTime(2024, 9, 22, 11, 17, 51, 392, DateTimeKind.Utc).AddTicks(9524) });

            migrationBuilder.UpdateData(
                table: "cezalar",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CezaBitisGunu", "CezaGunu" },
                values: new object[] { new DateTime(2024, 9, 17, 11, 17, 51, 392, DateTimeKind.Utc).AddTicks(9526), new DateTime(2024, 9, 7, 11, 17, 51, 392, DateTimeKind.Utc).AddTicks(9526) });

            migrationBuilder.UpdateData(
                table: "cezalar",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CezaBitisGunu", "CezaGunu" },
                values: new object[] { new DateTime(2024, 9, 2, 11, 17, 51, 392, DateTimeKind.Utc).AddTicks(9528), new DateTime(2024, 8, 23, 11, 17, 51, 392, DateTimeKind.Utc).AddTicks(9527) });

            migrationBuilder.UpdateData(
                table: "cezalar",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CezaBitisGunu", "CezaGunu" },
                values: new object[] { new DateTime(2024, 8, 3, 11, 17, 51, 392, DateTimeKind.Utc).AddTicks(9529), new DateTime(2024, 7, 24, 11, 17, 51, 392, DateTimeKind.Utc).AddTicks(9529) });

            migrationBuilder.UpdateData(
                table: "cezalar",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CezaBitisGunu", "CezaGunu" },
                values: new object[] { new DateTime(2024, 10, 7, 11, 17, 51, 392, DateTimeKind.Utc).AddTicks(9531), new DateTime(2024, 9, 27, 11, 17, 51, 392, DateTimeKind.Utc).AddTicks(9530) });

            migrationBuilder.UpdateData(
                table: "cezalar",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CezaBitisGunu", "CezaGunu" },
                values: new object[] { new DateTime(2024, 7, 4, 11, 17, 51, 392, DateTimeKind.Utc).AddTicks(9532), new DateTime(2024, 6, 24, 11, 17, 51, 392, DateTimeKind.Utc).AddTicks(9532) });

            migrationBuilder.UpdateData(
                table: "cezalar",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CezaBitisGunu", "CezaGunu" },
                values: new object[] { new DateTime(2024, 9, 22, 11, 17, 51, 392, DateTimeKind.Utc).AddTicks(9534), new DateTime(2024, 9, 12, 11, 17, 51, 392, DateTimeKind.Utc).AddTicks(9533) });

            migrationBuilder.UpdateData(
                table: "cezalar",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CezaBitisGunu", "CezaGunu" },
                values: new object[] { new DateTime(2024, 9, 7, 11, 17, 51, 392, DateTimeKind.Utc).AddTicks(9535), new DateTime(2024, 8, 28, 11, 17, 51, 392, DateTimeKind.Utc).AddTicks(9535) });

            migrationBuilder.UpdateData(
                table: "hesapAcmaTalepleri",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "TalepTarihi", "UserId" },
                values: new object[] { new DateTime(2024, 9, 27, 11, 17, 51, 392, DateTimeKind.Utc).AddTicks(9661), 4 });

            migrationBuilder.UpdateData(
                table: "hesapAcmaTalepleri",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "TalepTarihi", "UserId" },
                values: new object[] { new DateTime(2024, 9, 22, 11, 17, 51, 392, DateTimeKind.Utc).AddTicks(9662), 5 });

            migrationBuilder.UpdateData(
                table: "hesapAcmaTalepleri",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "BeklemedeMi", "OnaylandiMi", "TalepTarihi", "UserId" },
                values: new object[] { true, false, new DateTime(2024, 9, 17, 11, 17, 51, 392, DateTimeKind.Utc).AddTicks(9664), 6 });

            migrationBuilder.UpdateData(
                table: "hesapAcmaTalepleri",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "TalepTarihi", "UserId" },
                values: new object[] { new DateTime(2024, 9, 12, 11, 17, 51, 392, DateTimeKind.Utc).AddTicks(9665), 7 });

            migrationBuilder.UpdateData(
                table: "hesapAcmaTalepleri",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "BeklemedeMi", "OnaylandiMi", "TalepTarihi", "UserId" },
                values: new object[] { true, false, new DateTime(2024, 9, 7, 11, 17, 51, 392, DateTimeKind.Utc).AddTicks(9666), 8 });

            migrationBuilder.UpdateData(
                table: "hesapAcmaTalepleri",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "TalepTarihi", "UserId" },
                values: new object[] { new DateTime(2024, 9, 2, 11, 17, 51, 392, DateTimeKind.Utc).AddTicks(9667), 9 });

            migrationBuilder.UpdateData(
                table: "hesapAcmaTalepleri",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "BeklemedeMi", "OnaylandiMi", "TalepTarihi", "UserId" },
                values: new object[] { true, false, new DateTime(2024, 8, 28, 11, 17, 51, 392, DateTimeKind.Utc).AddTicks(9675), 10 });

            migrationBuilder.UpdateData(
                table: "hesapAcmaTalepleri",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "TalepTarihi", "UserId" },
                values: new object[] { new DateTime(2024, 8, 23, 11, 17, 51, 392, DateTimeKind.Utc).AddTicks(9676), 11 });

            migrationBuilder.UpdateData(
                table: "hesapAcmaTalepleri",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "BeklemedeMi", "OnaylandiMi", "TalepTarihi", "UserId" },
                values: new object[] { true, false, new DateTime(2024, 8, 18, 11, 17, 51, 392, DateTimeKind.Utc).AddTicks(9677), 12 });

            migrationBuilder.UpdateData(
                table: "hesapAcmaTalepleri",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "TalepTarihi", "UserId" },
                values: new object[] { new DateTime(2024, 8, 13, 11, 17, 51, 392, DateTimeKind.Utc).AddTicks(9678), 13 });

            migrationBuilder.UpdateData(
                table: "kitapOduncler",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DonusTarihi", "TalepTarihi" },
                values: new object[] { new DateTime(2024, 10, 9, 11, 17, 51, 392, DateTimeKind.Utc).AddTicks(9753), new DateTime(2024, 9, 25, 11, 17, 51, 392, DateTimeKind.Utc).AddTicks(9752) });

            migrationBuilder.UpdateData(
                table: "kitapOduncler",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DonusTarihi", "TalepTarihi" },
                values: new object[] { new DateTime(2024, 10, 8, 11, 17, 51, 392, DateTimeKind.Utc).AddTicks(9755), new DateTime(2024, 9, 24, 11, 17, 51, 392, DateTimeKind.Utc).AddTicks(9754) });

            migrationBuilder.UpdateData(
                table: "kitapOduncler",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DonusTarihi", "TalepTarihi" },
                values: new object[] { new DateTime(2024, 10, 7, 11, 17, 51, 392, DateTimeKind.Utc).AddTicks(9757), new DateTime(2024, 9, 23, 11, 17, 51, 392, DateTimeKind.Utc).AddTicks(9756) });

            migrationBuilder.UpdateData(
                table: "kitapOduncler",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DonusTarihi", "TalepTarihi" },
                values: new object[] { new DateTime(2024, 10, 6, 11, 17, 51, 392, DateTimeKind.Utc).AddTicks(9759), new DateTime(2024, 9, 22, 11, 17, 51, 392, DateTimeKind.Utc).AddTicks(9758) });

            migrationBuilder.UpdateData(
                table: "kitapOduncler",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DonusTarihi", "TalepTarihi" },
                values: new object[] { new DateTime(2024, 10, 5, 11, 17, 51, 392, DateTimeKind.Utc).AddTicks(9760), new DateTime(2024, 9, 21, 11, 17, 51, 392, DateTimeKind.Utc).AddTicks(9760) });

            migrationBuilder.UpdateData(
                table: "kitapOduncler",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DonusTarihi", "TalepTarihi" },
                values: new object[] { new DateTime(2024, 10, 4, 11, 17, 51, 392, DateTimeKind.Utc).AddTicks(9762), new DateTime(2024, 9, 20, 11, 17, 51, 392, DateTimeKind.Utc).AddTicks(9762) });

            migrationBuilder.UpdateData(
                table: "kitapOduncler",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "DonusTarihi", "TalepTarihi" },
                values: new object[] { new DateTime(2024, 10, 3, 11, 17, 51, 392, DateTimeKind.Utc).AddTicks(9764), new DateTime(2024, 9, 19, 11, 17, 51, 392, DateTimeKind.Utc).AddTicks(9764) });

            migrationBuilder.UpdateData(
                table: "kitapOduncler",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "DonusTarihi", "TalepTarihi" },
                values: new object[] { new DateTime(2024, 10, 1, 11, 17, 51, 392, DateTimeKind.Utc).AddTicks(9766), new DateTime(2024, 9, 18, 11, 17, 51, 392, DateTimeKind.Utc).AddTicks(9765) });

            migrationBuilder.UpdateData(
                table: "kitapOduncler",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "DonusTarihi", "TalepTarihi" },
                values: new object[] { new DateTime(2024, 9, 30, 11, 17, 51, 392, DateTimeKind.Utc).AddTicks(9767), new DateTime(2024, 9, 17, 11, 17, 51, 392, DateTimeKind.Utc).AddTicks(9767) });

            migrationBuilder.UpdateData(
                table: "kitapOduncler",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "DonusTarihi", "TalepTarihi" },
                values: new object[] { new DateTime(2024, 9, 29, 11, 17, 51, 392, DateTimeKind.Utc).AddTicks(9769), new DateTime(2024, 9, 16, 11, 17, 51, 392, DateTimeKind.Utc).AddTicks(9769) });

            migrationBuilder.UpdateData(
                table: "kitapYayinTalepleri",
                keyColumn: "Id",
                keyValue: 1,
                column: "TalepTarihi",
                value: new DateTime(2024, 9, 29, 11, 17, 51, 392, DateTimeKind.Utc).AddTicks(9796));

            migrationBuilder.UpdateData(
                table: "kitapYayinTalepleri",
                keyColumn: "Id",
                keyValue: 2,
                column: "TalepTarihi",
                value: new DateTime(2024, 9, 24, 11, 17, 51, 392, DateTimeKind.Utc).AddTicks(9798));

            migrationBuilder.UpdateData(
                table: "kitapYayinTalepleri",
                keyColumn: "Id",
                keyValue: 3,
                column: "TalepTarihi",
                value: new DateTime(2024, 9, 22, 11, 17, 51, 392, DateTimeKind.Utc).AddTicks(9799));

            migrationBuilder.UpdateData(
                table: "kitapYayinTalepleri",
                keyColumn: "Id",
                keyValue: 4,
                column: "TalepTarihi",
                value: new DateTime(2024, 9, 20, 11, 17, 51, 392, DateTimeKind.Utc).AddTicks(9801));

            migrationBuilder.UpdateData(
                table: "kitapYayinTalepleri",
                keyColumn: "Id",
                keyValue: 5,
                column: "TalepTarihi",
                value: new DateTime(2024, 9, 17, 11, 17, 51, 392, DateTimeKind.Utc).AddTicks(9802));

            migrationBuilder.UpdateData(
                table: "kitapYayinTalepleri",
                keyColumn: "Id",
                keyValue: 6,
                column: "TalepTarihi",
                value: new DateTime(2024, 9, 14, 11, 17, 51, 392, DateTimeKind.Utc).AddTicks(9803));

            migrationBuilder.UpdateData(
                table: "kitapYayinTalepleri",
                keyColumn: "Id",
                keyValue: 7,
                column: "TalepTarihi",
                value: new DateTime(2024, 9, 12, 11, 17, 51, 392, DateTimeKind.Utc).AddTicks(9804));

            migrationBuilder.UpdateData(
                table: "kitapYayinTalepleri",
                keyColumn: "Id",
                keyValue: 8,
                column: "TalepTarihi",
                value: new DateTime(2024, 9, 10, 11, 17, 51, 392, DateTimeKind.Utc).AddTicks(9805));

            migrationBuilder.UpdateData(
                table: "kitapYayinTalepleri",
                keyColumn: "Id",
                keyValue: 9,
                column: "TalepTarihi",
                value: new DateTime(2024, 9, 7, 11, 17, 51, 392, DateTimeKind.Utc).AddTicks(9806));

            migrationBuilder.UpdateData(
                table: "kitapYayinTalepleri",
                keyColumn: "Id",
                keyValue: 10,
                column: "TalepTarihi",
                value: new DateTime(2024, 9, 4, 11, 17, 51, 392, DateTimeKind.Utc).AddTicks(9807));

            migrationBuilder.UpdateData(
                table: "kitaplar",
                keyColumn: "Id",
                keyValue: 1,
                column: "YayinlanmaTarihi",
                value: new DateTime(2023, 10, 3, 11, 17, 51, 392, DateTimeKind.Utc).AddTicks(9721));

            migrationBuilder.UpdateData(
                table: "kitaplar",
                keyColumn: "Id",
                keyValue: 2,
                column: "YayinlanmaTarihi",
                value: new DateTime(2023, 8, 29, 11, 17, 51, 392, DateTimeKind.Utc).AddTicks(9722));

            migrationBuilder.UpdateData(
                table: "kitaplar",
                keyColumn: "Id",
                keyValue: 3,
                column: "YayinlanmaTarihi",
                value: new DateTime(2023, 5, 21, 11, 17, 51, 392, DateTimeKind.Utc).AddTicks(9723));

            migrationBuilder.UpdateData(
                table: "kitaplar",
                keyColumn: "Id",
                keyValue: 4,
                column: "YayinlanmaTarihi",
                value: new DateTime(2024, 3, 16, 11, 17, 51, 392, DateTimeKind.Utc).AddTicks(9724));

            migrationBuilder.UpdateData(
                table: "kitaplar",
                keyColumn: "Id",
                keyValue: 5,
                column: "YayinlanmaTarihi",
                value: new DateTime(2023, 12, 7, 11, 17, 51, 392, DateTimeKind.Utc).AddTicks(9725));

            migrationBuilder.UpdateData(
                table: "kitaplar",
                keyColumn: "Id",
                keyValue: 6,
                column: "YayinlanmaTarihi",
                value: new DateTime(2024, 5, 5, 11, 17, 51, 392, DateTimeKind.Utc).AddTicks(9726));

            migrationBuilder.UpdateData(
                table: "kitaplar",
                keyColumn: "Id",
                keyValue: 7,
                column: "YayinlanmaTarihi",
                value: new DateTime(2023, 2, 10, 11, 17, 51, 392, DateTimeKind.Utc).AddTicks(9727));

            migrationBuilder.UpdateData(
                table: "kitaplar",
                keyColumn: "Id",
                keyValue: 8,
                column: "YayinlanmaTarihi",
                value: new DateTime(2024, 6, 24, 11, 17, 51, 392, DateTimeKind.Utc).AddTicks(9728));

            migrationBuilder.UpdateData(
                table: "kitaplar",
                keyColumn: "Id",
                keyValue: 9,
                column: "YayinlanmaTarihi",
                value: new DateTime(2024, 1, 26, 11, 17, 51, 392, DateTimeKind.Utc).AddTicks(9729));

            migrationBuilder.UpdateData(
                table: "kitaplar",
                keyColumn: "Id",
                keyValue: 10,
                column: "YayinlanmaTarihi",
                value: new DateTime(2023, 11, 17, 11, 17, 51, 392, DateTimeKind.Utc).AddTicks(9730));

            migrationBuilder.UpdateData(
                table: "puanlar",
                keyColumn: "Id",
                keyValue: 1,
                column: "PuanGunu",
                value: new DateTime(2024, 10, 1, 11, 17, 51, 392, DateTimeKind.Utc).AddTicks(9917));

            migrationBuilder.UpdateData(
                table: "puanlar",
                keyColumn: "Id",
                keyValue: 2,
                column: "PuanGunu",
                value: new DateTime(2024, 9, 27, 11, 17, 51, 392, DateTimeKind.Utc).AddTicks(9918));

            migrationBuilder.UpdateData(
                table: "puanlar",
                keyColumn: "Id",
                keyValue: 3,
                column: "PuanGunu",
                value: new DateTime(2024, 9, 22, 11, 17, 51, 392, DateTimeKind.Utc).AddTicks(9920));

            migrationBuilder.UpdateData(
                table: "puanlar",
                keyColumn: "Id",
                keyValue: 4,
                column: "PuanGunu",
                value: new DateTime(2024, 9, 17, 11, 17, 51, 392, DateTimeKind.Utc).AddTicks(9921));

            migrationBuilder.UpdateData(
                table: "puanlar",
                keyColumn: "Id",
                keyValue: 5,
                column: "PuanGunu",
                value: new DateTime(2024, 9, 12, 11, 17, 51, 392, DateTimeKind.Utc).AddTicks(9922));

            migrationBuilder.UpdateData(
                table: "puanlar",
                keyColumn: "Id",
                keyValue: 6,
                column: "PuanGunu",
                value: new DateTime(2024, 9, 7, 11, 17, 51, 392, DateTimeKind.Utc).AddTicks(9923));

            migrationBuilder.UpdateData(
                table: "puanlar",
                keyColumn: "Id",
                keyValue: 7,
                column: "PuanGunu",
                value: new DateTime(2024, 9, 2, 11, 17, 51, 392, DateTimeKind.Utc).AddTicks(9924));

            migrationBuilder.UpdateData(
                table: "puanlar",
                keyColumn: "Id",
                keyValue: 8,
                column: "PuanGunu",
                value: new DateTime(2024, 8, 28, 11, 17, 51, 392, DateTimeKind.Utc).AddTicks(9925));

            migrationBuilder.UpdateData(
                table: "puanlar",
                keyColumn: "Id",
                keyValue: 9,
                column: "PuanGunu",
                value: new DateTime(2024, 8, 23, 11, 17, 51, 392, DateTimeKind.Utc).AddTicks(9926));

            migrationBuilder.UpdateData(
                table: "puanlar",
                keyColumn: "Id",
                keyValue: 10,
                column: "PuanGunu",
                value: new DateTime(2024, 8, 18, 11, 17, 51, 392, DateTimeKind.Utc).AddTicks(9927));

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$U2Pl6W.DuVQ9RiUoA.KTGuiWAHZpSFA/HpQFUpVi4dGwfnhMY.lnq");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "$2a$11$CYeDfDJOeLv5xUcD6LOmUef10VAGieYf8iUJayt9N72hCR6zeedke");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: 3,
                column: "Password",
                value: "$2a$11$hmVhgJtFjzx97oO4FrVdDu06LygBGu7n7LWs9XeQIBfHbqZBMxNGW");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: 4,
                column: "Password",
                value: "$2a$11$s/b74SPh6RVHD.vtozs/PeXtI2vCcoCGhmAyoUnhQMQtuBzdWOiQW");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: 5,
                column: "Password",
                value: "$2a$11$wJJoMYAq.2i8LnS8dBzzS.0MuExPmjs7re8XEseVWZthwE4kr15gK");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: 6,
                column: "Password",
                value: "$2a$11$3aps3qrqCCv8/gu9Zw0CiON2PJ5LsdeU3RTr7FJFrKsUa3unx/sAq");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: 7,
                column: "Password",
                value: "$2a$11$IJf1l9yOO5vBwDBkuEqR6.5tKU7.hL5jrFkLEWcEK/ZT4F54RL5hC");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: 8,
                column: "Password",
                value: "$2a$11$LB2Ux/aPyOQ86A3sTBob9OGTzrbSn41B4Se9hdl/eeBEmPAq4ELKK");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: 9,
                column: "Password",
                value: "$2a$11$Tz5AKBWqUuWTIJCPVc/cbuudN1DvnkfknbDYecrhy.vGgh9hJe.Qm");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: 10,
                column: "Password",
                value: "$2a$11$SMDAsqBLEF5wT0jyqRbGYukbR9363NPkyB.lZWD3BR2lCFxUWyGnS");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: 11,
                column: "Password",
                value: "$2a$11$/2Vs5n77zw3P/e5SML/Mo.eTGdQs5Gi6zLqCNTAD6PbEH6KoOTOh2");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: 12,
                column: "Password",
                value: "$2a$11$oPKVHnehv9qCCjFpws/MfefF56scQLjBzrWtC16l38A0wlHy81fV.");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: 13,
                column: "Password",
                value: "$2a$11$HylT7QzlgnevenX.p0eBpe2YLzoONE6VnE7PvaGvYAJqdZ5uysBKi");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: 14,
                column: "Password",
                value: "$2a$11$1F2RV6hIBwijyO1TI3YDXe5yNOADmPK4.JoWkiwO/Of2TlJuucI9S");
        }
    }
}
