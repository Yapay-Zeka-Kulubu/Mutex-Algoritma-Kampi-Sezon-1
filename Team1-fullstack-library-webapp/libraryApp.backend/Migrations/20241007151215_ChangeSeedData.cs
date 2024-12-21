using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace libraryApp.backend.Migrations
{
    /// <inheritdoc />
    public partial class ChangeSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "BookPublishRequests",
                keyColumn: "id",
                keyValue: 1,
                column: "requestDate",
                value: new DateOnly(2024, 10, 7));

            migrationBuilder.UpdateData(
                table: "BookPublishRequests",
                keyColumn: "id",
                keyValue: 2,
                column: "requestDate",
                value: new DateOnly(2024, 10, 7));

            migrationBuilder.UpdateData(
                table: "BookPublishRequests",
                keyColumn: "id",
                keyValue: 3,
                column: "requestDate",
                value: new DateOnly(2024, 10, 7));

            migrationBuilder.UpdateData(
                table: "BookPublishRequests",
                keyColumn: "id",
                keyValue: 4,
                column: "requestDate",
                value: new DateOnly(2024, 10, 7));

            migrationBuilder.UpdateData(
                table: "BookPublishRequests",
                keyColumn: "id",
                keyValue: 5,
                column: "requestDate",
                value: new DateOnly(2024, 10, 7));

            migrationBuilder.UpdateData(
                table: "BookPublishRequests",
                keyColumn: "id",
                keyValue: 6,
                column: "requestDate",
                value: new DateOnly(2024, 10, 7));

            migrationBuilder.UpdateData(
                table: "BookPublishRequests",
                keyColumn: "id",
                keyValue: 7,
                column: "requestDate",
                value: new DateOnly(2024, 10, 7));

            migrationBuilder.UpdateData(
                table: "BookPublishRequests",
                keyColumn: "id",
                keyValue: 8,
                column: "requestDate",
                value: new DateOnly(2024, 10, 7));

            migrationBuilder.UpdateData(
                table: "BookPublishRequests",
                keyColumn: "id",
                keyValue: 9,
                column: "requestDate",
                value: new DateOnly(2024, 10, 7));

            migrationBuilder.UpdateData(
                table: "BookPublishRequests",
                keyColumn: "id",
                keyValue: 10,
                column: "requestDate",
                value: new DateOnly(2024, 10, 7));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "id",
                keyValue: 1,
                column: "status",
                value: false);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "id",
                keyValue: 2,
                column: "status",
                value: false);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "id",
                keyValue: 3,
                column: "status",
                value: false);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "id",
                keyValue: 4,
                column: "status",
                value: false);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "id",
                keyValue: 5,
                column: "status",
                value: false);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "id",
                keyValue: 6,
                column: "status",
                value: false);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "id",
                keyValue: 7,
                column: "status",
                value: false);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "id",
                keyValue: 8,
                column: "status",
                value: false);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "id",
                keyValue: 9,
                column: "status",
                value: false);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "id",
                keyValue: 10,
                column: "status",
                value: false);

            migrationBuilder.UpdateData(
                table: "LoanRequests",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "requestDate", "returnDate" },
                values: new object[] { new DateOnly(2024, 10, 7), new DateOnly(2024, 10, 14) });

            migrationBuilder.UpdateData(
                table: "LoanRequests",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "requestDate", "returnDate" },
                values: new object[] { new DateOnly(2024, 10, 7), new DateOnly(2024, 10, 21) });

            migrationBuilder.UpdateData(
                table: "LoanRequests",
                keyColumn: "id",
                keyValue: 3,
                columns: new[] { "requestDate", "returnDate" },
                values: new object[] { new DateOnly(2024, 10, 7), new DateOnly(2024, 10, 28) });

            migrationBuilder.UpdateData(
                table: "LoanRequests",
                keyColumn: "id",
                keyValue: 4,
                columns: new[] { "requestDate", "returnDate" },
                values: new object[] { new DateOnly(2024, 10, 7), new DateOnly(2024, 11, 4) });

            migrationBuilder.UpdateData(
                table: "LoanRequests",
                keyColumn: "id",
                keyValue: 5,
                columns: new[] { "requestDate", "returnDate" },
                values: new object[] { new DateOnly(2024, 10, 7), new DateOnly(2024, 11, 6) });

            migrationBuilder.UpdateData(
                table: "LoanRequests",
                keyColumn: "id",
                keyValue: 6,
                columns: new[] { "requestDate", "returnDate" },
                values: new object[] { new DateOnly(2024, 10, 7), new DateOnly(2024, 10, 21) });

            migrationBuilder.UpdateData(
                table: "LoanRequests",
                keyColumn: "id",
                keyValue: 7,
                columns: new[] { "requestDate", "returnDate" },
                values: new object[] { new DateOnly(2024, 10, 7), new DateOnly(2024, 10, 28) });

            migrationBuilder.UpdateData(
                table: "LoanRequests",
                keyColumn: "id",
                keyValue: 8,
                columns: new[] { "requestDate", "returnDate" },
                values: new object[] { new DateOnly(2024, 10, 7), new DateOnly(2024, 11, 4) });

            migrationBuilder.UpdateData(
                table: "LoanRequests",
                keyColumn: "id",
                keyValue: 9,
                columns: new[] { "requestDate", "returnDate" },
                values: new object[] { new DateOnly(2024, 10, 7), new DateOnly(2024, 11, 6) });

            migrationBuilder.UpdateData(
                table: "LoanRequests",
                keyColumn: "id",
                keyValue: 10,
                columns: new[] { "requestDate", "returnDate" },
                values: new object[] { new DateOnly(2024, 10, 7), new DateOnly(2024, 10, 21) });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "id",
                keyValue: 1,
                column: "sendingDate",
                value: new DateOnly(2024, 10, 7));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "id",
                keyValue: 2,
                column: "sendingDate",
                value: new DateOnly(2024, 10, 7));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "id",
                keyValue: 3,
                column: "sendingDate",
                value: new DateOnly(2024, 10, 7));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "id",
                keyValue: 4,
                column: "sendingDate",
                value: new DateOnly(2024, 10, 7));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "id",
                keyValue: 5,
                column: "sendingDate",
                value: new DateOnly(2024, 10, 7));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "id",
                keyValue: 6,
                column: "sendingDate",
                value: new DateOnly(2024, 10, 7));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "id",
                keyValue: 7,
                column: "sendingDate",
                value: new DateOnly(2024, 10, 7));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "id",
                keyValue: 8,
                column: "sendingDate",
                value: new DateOnly(2024, 10, 7));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "id",
                keyValue: 9,
                column: "sendingDate",
                value: new DateOnly(2024, 10, 7));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "id",
                keyValue: 10,
                column: "sendingDate",
                value: new DateOnly(2024, 10, 7));

            migrationBuilder.UpdateData(
                table: "Points",
                keyColumn: "id",
                keyValue: 1,
                column: "earnDate",
                value: new DateOnly(2024, 10, 7));

            migrationBuilder.UpdateData(
                table: "Points",
                keyColumn: "id",
                keyValue: 2,
                column: "earnDate",
                value: new DateOnly(2024, 10, 6));

            migrationBuilder.UpdateData(
                table: "Points",
                keyColumn: "id",
                keyValue: 3,
                column: "earnDate",
                value: new DateOnly(2024, 10, 5));

            migrationBuilder.UpdateData(
                table: "Points",
                keyColumn: "id",
                keyValue: 4,
                column: "earnDate",
                value: new DateOnly(2024, 10, 4));

            migrationBuilder.UpdateData(
                table: "Points",
                keyColumn: "id",
                keyValue: 5,
                column: "earnDate",
                value: new DateOnly(2024, 10, 3));

            migrationBuilder.UpdateData(
                table: "Points",
                keyColumn: "id",
                keyValue: 6,
                column: "earnDate",
                value: new DateOnly(2024, 10, 2));

            migrationBuilder.UpdateData(
                table: "Points",
                keyColumn: "id",
                keyValue: 7,
                column: "earnDate",
                value: new DateOnly(2024, 10, 1));

            migrationBuilder.UpdateData(
                table: "Points",
                keyColumn: "id",
                keyValue: 8,
                column: "earnDate",
                value: new DateOnly(2024, 9, 30));

            migrationBuilder.UpdateData(
                table: "Points",
                keyColumn: "id",
                keyValue: 9,
                column: "earnDate",
                value: new DateOnly(2024, 9, 29));

            migrationBuilder.UpdateData(
                table: "Points",
                keyColumn: "id",
                keyValue: 10,
                column: "earnDate",
                value: new DateOnly(2024, 9, 28));

            migrationBuilder.UpdateData(
                table: "Punishments",
                keyColumn: "id",
                keyValue: 1,
                column: "punishmentDate",
                value: new DateOnly(2024, 10, 7));

            migrationBuilder.UpdateData(
                table: "Punishments",
                keyColumn: "id",
                keyValue: 2,
                column: "punishmentDate",
                value: new DateOnly(2024, 10, 6));

            migrationBuilder.UpdateData(
                table: "Punishments",
                keyColumn: "id",
                keyValue: 3,
                column: "punishmentDate",
                value: new DateOnly(2024, 10, 5));

            migrationBuilder.UpdateData(
                table: "Punishments",
                keyColumn: "id",
                keyValue: 4,
                column: "punishmentDate",
                value: new DateOnly(2024, 10, 4));

            migrationBuilder.UpdateData(
                table: "Punishments",
                keyColumn: "id",
                keyValue: 5,
                column: "punishmentDate",
                value: new DateOnly(2024, 10, 3));

            migrationBuilder.UpdateData(
                table: "Punishments",
                keyColumn: "id",
                keyValue: 6,
                column: "punishmentDate",
                value: new DateOnly(2024, 10, 2));

            migrationBuilder.UpdateData(
                table: "Punishments",
                keyColumn: "id",
                keyValue: 7,
                column: "punishmentDate",
                value: new DateOnly(2024, 10, 1));

            migrationBuilder.UpdateData(
                table: "Punishments",
                keyColumn: "id",
                keyValue: 8,
                column: "punishmentDate",
                value: new DateOnly(2024, 9, 30));

            migrationBuilder.UpdateData(
                table: "Punishments",
                keyColumn: "id",
                keyValue: 9,
                column: "punishmentDate",
                value: new DateOnly(2024, 9, 29));

            migrationBuilder.UpdateData(
                table: "Punishments",
                keyColumn: "id",
                keyValue: 10,
                column: "punishmentDate",
                value: new DateOnly(2024, 9, 28));

            migrationBuilder.UpdateData(
                table: "RegisterRequests",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "confirmation", "pending", "requestDate" },
                values: new object[] { true, false, new DateOnly(2024, 10, 7) });

            migrationBuilder.UpdateData(
                table: "RegisterRequests",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "confirmation", "pending", "requestDate" },
                values: new object[] { true, false, new DateOnly(2024, 10, 6) });

            migrationBuilder.UpdateData(
                table: "RegisterRequests",
                keyColumn: "id",
                keyValue: 3,
                column: "requestDate",
                value: new DateOnly(2024, 10, 5));

            migrationBuilder.UpdateData(
                table: "RegisterRequests",
                keyColumn: "id",
                keyValue: 4,
                column: "requestDate",
                value: new DateOnly(2024, 10, 4));

            migrationBuilder.UpdateData(
                table: "RegisterRequests",
                keyColumn: "id",
                keyValue: 5,
                columns: new[] { "confirmation", "pending", "requestDate" },
                values: new object[] { true, false, new DateOnly(2024, 10, 3) });

            migrationBuilder.UpdateData(
                table: "RegisterRequests",
                keyColumn: "id",
                keyValue: 6,
                columns: new[] { "confirmation", "pending", "requestDate" },
                values: new object[] { true, false, new DateOnly(2024, 10, 2) });

            migrationBuilder.UpdateData(
                table: "RegisterRequests",
                keyColumn: "id",
                keyValue: 7,
                column: "requestDate",
                value: new DateOnly(2024, 10, 1));

            migrationBuilder.UpdateData(
                table: "RegisterRequests",
                keyColumn: "id",
                keyValue: 8,
                columns: new[] { "confirmation", "pending", "requestDate" },
                values: new object[] { true, false, new DateOnly(2024, 9, 30) });

            migrationBuilder.UpdateData(
                table: "RegisterRequests",
                keyColumn: "id",
                keyValue: 9,
                column: "requestDate",
                value: new DateOnly(2024, 9, 29));

            migrationBuilder.UpdateData(
                table: "RegisterRequests",
                keyColumn: "id",
                keyValue: 10,
                columns: new[] { "confirmation", "pending", "requestDate" },
                values: new object[] { true, false, new DateOnly(2024, 9, 28) });

            migrationBuilder.InsertData(
                table: "RegisterRequests",
                columns: new[] { "id", "confirmation", "pending", "requestDate", "userId" },
                values: new object[,]
                {
                    { 11, true, false, new DateOnly(2024, 9, 28), 11 },
                    { 12, true, false, new DateOnly(2024, 9, 28), 12 },
                    { 13, true, false, new DateOnly(2024, 9, 28), 13 },
                    { 14, true, false, new DateOnly(2024, 9, 28), 14 },
                    { 15, true, false, new DateOnly(2024, 9, 28), 15 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RegisterRequests",
                keyColumn: "id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "RegisterRequests",
                keyColumn: "id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "RegisterRequests",
                keyColumn: "id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "RegisterRequests",
                keyColumn: "id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "RegisterRequests",
                keyColumn: "id",
                keyValue: 15);

            migrationBuilder.UpdateData(
                table: "BookPublishRequests",
                keyColumn: "id",
                keyValue: 1,
                column: "requestDate",
                value: new DateOnly(2024, 10, 2));

            migrationBuilder.UpdateData(
                table: "BookPublishRequests",
                keyColumn: "id",
                keyValue: 2,
                column: "requestDate",
                value: new DateOnly(2024, 10, 2));

            migrationBuilder.UpdateData(
                table: "BookPublishRequests",
                keyColumn: "id",
                keyValue: 3,
                column: "requestDate",
                value: new DateOnly(2024, 10, 2));

            migrationBuilder.UpdateData(
                table: "BookPublishRequests",
                keyColumn: "id",
                keyValue: 4,
                column: "requestDate",
                value: new DateOnly(2024, 10, 2));

            migrationBuilder.UpdateData(
                table: "BookPublishRequests",
                keyColumn: "id",
                keyValue: 5,
                column: "requestDate",
                value: new DateOnly(2024, 10, 2));

            migrationBuilder.UpdateData(
                table: "BookPublishRequests",
                keyColumn: "id",
                keyValue: 6,
                column: "requestDate",
                value: new DateOnly(2024, 10, 2));

            migrationBuilder.UpdateData(
                table: "BookPublishRequests",
                keyColumn: "id",
                keyValue: 7,
                column: "requestDate",
                value: new DateOnly(2024, 10, 2));

            migrationBuilder.UpdateData(
                table: "BookPublishRequests",
                keyColumn: "id",
                keyValue: 8,
                column: "requestDate",
                value: new DateOnly(2024, 10, 2));

            migrationBuilder.UpdateData(
                table: "BookPublishRequests",
                keyColumn: "id",
                keyValue: 9,
                column: "requestDate",
                value: new DateOnly(2024, 10, 2));

            migrationBuilder.UpdateData(
                table: "BookPublishRequests",
                keyColumn: "id",
                keyValue: 10,
                column: "requestDate",
                value: new DateOnly(2024, 10, 2));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "id",
                keyValue: 1,
                column: "status",
                value: true);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "id",
                keyValue: 2,
                column: "status",
                value: true);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "id",
                keyValue: 3,
                column: "status",
                value: true);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "id",
                keyValue: 4,
                column: "status",
                value: true);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "id",
                keyValue: 5,
                column: "status",
                value: true);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "id",
                keyValue: 6,
                column: "status",
                value: true);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "id",
                keyValue: 7,
                column: "status",
                value: true);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "id",
                keyValue: 8,
                column: "status",
                value: true);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "id",
                keyValue: 9,
                column: "status",
                value: true);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "id",
                keyValue: 10,
                column: "status",
                value: true);

            migrationBuilder.UpdateData(
                table: "LoanRequests",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "requestDate", "returnDate" },
                values: new object[] { new DateOnly(2024, 10, 2), new DateOnly(2024, 10, 9) });

            migrationBuilder.UpdateData(
                table: "LoanRequests",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "requestDate", "returnDate" },
                values: new object[] { new DateOnly(2024, 10, 2), new DateOnly(2024, 10, 16) });

            migrationBuilder.UpdateData(
                table: "LoanRequests",
                keyColumn: "id",
                keyValue: 3,
                columns: new[] { "requestDate", "returnDate" },
                values: new object[] { new DateOnly(2024, 10, 2), new DateOnly(2024, 10, 23) });

            migrationBuilder.UpdateData(
                table: "LoanRequests",
                keyColumn: "id",
                keyValue: 4,
                columns: new[] { "requestDate", "returnDate" },
                values: new object[] { new DateOnly(2024, 10, 2), new DateOnly(2024, 10, 30) });

            migrationBuilder.UpdateData(
                table: "LoanRequests",
                keyColumn: "id",
                keyValue: 5,
                columns: new[] { "requestDate", "returnDate" },
                values: new object[] { new DateOnly(2024, 10, 2), new DateOnly(2024, 11, 1) });

            migrationBuilder.UpdateData(
                table: "LoanRequests",
                keyColumn: "id",
                keyValue: 6,
                columns: new[] { "requestDate", "returnDate" },
                values: new object[] { new DateOnly(2024, 10, 2), new DateOnly(2024, 10, 16) });

            migrationBuilder.UpdateData(
                table: "LoanRequests",
                keyColumn: "id",
                keyValue: 7,
                columns: new[] { "requestDate", "returnDate" },
                values: new object[] { new DateOnly(2024, 10, 2), new DateOnly(2024, 10, 23) });

            migrationBuilder.UpdateData(
                table: "LoanRequests",
                keyColumn: "id",
                keyValue: 8,
                columns: new[] { "requestDate", "returnDate" },
                values: new object[] { new DateOnly(2024, 10, 2), new DateOnly(2024, 10, 30) });

            migrationBuilder.UpdateData(
                table: "LoanRequests",
                keyColumn: "id",
                keyValue: 9,
                columns: new[] { "requestDate", "returnDate" },
                values: new object[] { new DateOnly(2024, 10, 2), new DateOnly(2024, 11, 1) });

            migrationBuilder.UpdateData(
                table: "LoanRequests",
                keyColumn: "id",
                keyValue: 10,
                columns: new[] { "requestDate", "returnDate" },
                values: new object[] { new DateOnly(2024, 10, 2), new DateOnly(2024, 10, 16) });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "id",
                keyValue: 1,
                column: "sendingDate",
                value: new DateOnly(2024, 10, 2));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "id",
                keyValue: 2,
                column: "sendingDate",
                value: new DateOnly(2024, 10, 2));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "id",
                keyValue: 3,
                column: "sendingDate",
                value: new DateOnly(2024, 10, 2));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "id",
                keyValue: 4,
                column: "sendingDate",
                value: new DateOnly(2024, 10, 2));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "id",
                keyValue: 5,
                column: "sendingDate",
                value: new DateOnly(2024, 10, 2));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "id",
                keyValue: 6,
                column: "sendingDate",
                value: new DateOnly(2024, 10, 2));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "id",
                keyValue: 7,
                column: "sendingDate",
                value: new DateOnly(2024, 10, 2));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "id",
                keyValue: 8,
                column: "sendingDate",
                value: new DateOnly(2024, 10, 2));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "id",
                keyValue: 9,
                column: "sendingDate",
                value: new DateOnly(2024, 10, 2));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "id",
                keyValue: 10,
                column: "sendingDate",
                value: new DateOnly(2024, 10, 2));

            migrationBuilder.UpdateData(
                table: "Points",
                keyColumn: "id",
                keyValue: 1,
                column: "earnDate",
                value: new DateOnly(2024, 10, 2));

            migrationBuilder.UpdateData(
                table: "Points",
                keyColumn: "id",
                keyValue: 2,
                column: "earnDate",
                value: new DateOnly(2024, 10, 1));

            migrationBuilder.UpdateData(
                table: "Points",
                keyColumn: "id",
                keyValue: 3,
                column: "earnDate",
                value: new DateOnly(2024, 9, 30));

            migrationBuilder.UpdateData(
                table: "Points",
                keyColumn: "id",
                keyValue: 4,
                column: "earnDate",
                value: new DateOnly(2024, 9, 29));

            migrationBuilder.UpdateData(
                table: "Points",
                keyColumn: "id",
                keyValue: 5,
                column: "earnDate",
                value: new DateOnly(2024, 9, 28));

            migrationBuilder.UpdateData(
                table: "Points",
                keyColumn: "id",
                keyValue: 6,
                column: "earnDate",
                value: new DateOnly(2024, 9, 27));

            migrationBuilder.UpdateData(
                table: "Points",
                keyColumn: "id",
                keyValue: 7,
                column: "earnDate",
                value: new DateOnly(2024, 9, 26));

            migrationBuilder.UpdateData(
                table: "Points",
                keyColumn: "id",
                keyValue: 8,
                column: "earnDate",
                value: new DateOnly(2024, 9, 25));

            migrationBuilder.UpdateData(
                table: "Points",
                keyColumn: "id",
                keyValue: 9,
                column: "earnDate",
                value: new DateOnly(2024, 9, 24));

            migrationBuilder.UpdateData(
                table: "Points",
                keyColumn: "id",
                keyValue: 10,
                column: "earnDate",
                value: new DateOnly(2024, 9, 23));

            migrationBuilder.UpdateData(
                table: "Punishments",
                keyColumn: "id",
                keyValue: 1,
                column: "punishmentDate",
                value: new DateOnly(2024, 10, 2));

            migrationBuilder.UpdateData(
                table: "Punishments",
                keyColumn: "id",
                keyValue: 2,
                column: "punishmentDate",
                value: new DateOnly(2024, 10, 1));

            migrationBuilder.UpdateData(
                table: "Punishments",
                keyColumn: "id",
                keyValue: 3,
                column: "punishmentDate",
                value: new DateOnly(2024, 9, 30));

            migrationBuilder.UpdateData(
                table: "Punishments",
                keyColumn: "id",
                keyValue: 4,
                column: "punishmentDate",
                value: new DateOnly(2024, 9, 29));

            migrationBuilder.UpdateData(
                table: "Punishments",
                keyColumn: "id",
                keyValue: 5,
                column: "punishmentDate",
                value: new DateOnly(2024, 9, 28));

            migrationBuilder.UpdateData(
                table: "Punishments",
                keyColumn: "id",
                keyValue: 6,
                column: "punishmentDate",
                value: new DateOnly(2024, 9, 27));

            migrationBuilder.UpdateData(
                table: "Punishments",
                keyColumn: "id",
                keyValue: 7,
                column: "punishmentDate",
                value: new DateOnly(2024, 9, 26));

            migrationBuilder.UpdateData(
                table: "Punishments",
                keyColumn: "id",
                keyValue: 8,
                column: "punishmentDate",
                value: new DateOnly(2024, 9, 25));

            migrationBuilder.UpdateData(
                table: "Punishments",
                keyColumn: "id",
                keyValue: 9,
                column: "punishmentDate",
                value: new DateOnly(2024, 9, 24));

            migrationBuilder.UpdateData(
                table: "Punishments",
                keyColumn: "id",
                keyValue: 10,
                column: "punishmentDate",
                value: new DateOnly(2024, 9, 23));

            migrationBuilder.UpdateData(
                table: "RegisterRequests",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "confirmation", "pending", "requestDate" },
                values: new object[] { false, true, new DateOnly(2024, 10, 2) });

            migrationBuilder.UpdateData(
                table: "RegisterRequests",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "confirmation", "pending", "requestDate" },
                values: new object[] { false, true, new DateOnly(2024, 10, 1) });

            migrationBuilder.UpdateData(
                table: "RegisterRequests",
                keyColumn: "id",
                keyValue: 3,
                column: "requestDate",
                value: new DateOnly(2024, 9, 30));

            migrationBuilder.UpdateData(
                table: "RegisterRequests",
                keyColumn: "id",
                keyValue: 4,
                column: "requestDate",
                value: new DateOnly(2024, 9, 29));

            migrationBuilder.UpdateData(
                table: "RegisterRequests",
                keyColumn: "id",
                keyValue: 5,
                columns: new[] { "confirmation", "pending", "requestDate" },
                values: new object[] { false, true, new DateOnly(2024, 9, 28) });

            migrationBuilder.UpdateData(
                table: "RegisterRequests",
                keyColumn: "id",
                keyValue: 6,
                columns: new[] { "confirmation", "pending", "requestDate" },
                values: new object[] { false, true, new DateOnly(2024, 9, 27) });

            migrationBuilder.UpdateData(
                table: "RegisterRequests",
                keyColumn: "id",
                keyValue: 7,
                column: "requestDate",
                value: new DateOnly(2024, 9, 26));

            migrationBuilder.UpdateData(
                table: "RegisterRequests",
                keyColumn: "id",
                keyValue: 8,
                columns: new[] { "confirmation", "pending", "requestDate" },
                values: new object[] { false, true, new DateOnly(2024, 9, 25) });

            migrationBuilder.UpdateData(
                table: "RegisterRequests",
                keyColumn: "id",
                keyValue: 9,
                column: "requestDate",
                value: new DateOnly(2024, 9, 24));

            migrationBuilder.UpdateData(
                table: "RegisterRequests",
                keyColumn: "id",
                keyValue: 10,
                columns: new[] { "confirmation", "pending", "requestDate" },
                values: new object[] { false, true, new DateOnly(2024, 9, 23) });
        }
    }
}
