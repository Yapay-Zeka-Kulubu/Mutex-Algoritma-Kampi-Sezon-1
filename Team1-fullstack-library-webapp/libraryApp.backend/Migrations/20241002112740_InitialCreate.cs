using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace libraryApp.backend.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    title = table.Column<string>(type: "text", nullable: false),
                    type = table.Column<string>(type: "text", nullable: false),
                    status = table.Column<bool>(type: "boolean", nullable: false),
                    number_of_pages = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Pages",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    bookId = table.Column<int>(type: "integer", nullable: false),
                    pageNumber = table.Column<int>(type: "integer", nullable: false),
                    content = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pages", x => x.id);
                    table.ForeignKey(
                        name: "FK_Pages_Books_bookId",
                        column: x => x.bookId,
                        principalTable: "Books",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    roleId = table.Column<int>(type: "integer", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    surname = table.Column<string>(type: "text", nullable: false),
                    email = table.Column<string>(type: "text", nullable: false),
                    username = table.Column<string>(type: "text", nullable: false),
                    password = table.Column<string>(type: "text", nullable: false),
                    userStatus = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.id);
                    table.ForeignKey(
                        name: "FK_Users_Roles_roleId",
                        column: x => x.roleId,
                        principalTable: "Roles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookAuthors",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    userId = table.Column<int>(type: "integer", nullable: false),
                    bookId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookAuthors", x => x.id);
                    table.ForeignKey(
                        name: "FK_BookAuthors_Books_bookId",
                        column: x => x.bookId,
                        principalTable: "Books",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookAuthors_Users_userId",
                        column: x => x.userId,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookPublishRequests",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    userId = table.Column<int>(type: "integer", nullable: false),
                    bookId = table.Column<int>(type: "integer", nullable: false),
                    requestDate = table.Column<DateOnly>(type: "date", nullable: false),
                    confirmation = table.Column<bool>(type: "boolean", nullable: false),
                    pending = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookPublishRequests", x => x.id);
                    table.ForeignKey(
                        name: "FK_BookPublishRequests_Books_bookId",
                        column: x => x.bookId,
                        principalTable: "Books",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookPublishRequests_Users_userId",
                        column: x => x.userId,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LoanRequests",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    userId = table.Column<int>(type: "integer", nullable: false),
                    bookId = table.Column<int>(type: "integer", nullable: false),
                    requestDate = table.Column<DateOnly>(type: "date", nullable: false),
                    returnDate = table.Column<DateOnly>(type: "date", nullable: false),
                    isReturned = table.Column<bool>(type: "boolean", nullable: false),
                    confirmation = table.Column<bool>(type: "boolean", nullable: false),
                    pending = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoanRequests", x => x.id);
                    table.ForeignKey(
                        name: "FK_LoanRequests_Books_bookId",
                        column: x => x.bookId,
                        principalTable: "Books",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LoanRequests_Users_userId",
                        column: x => x.userId,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    senderId = table.Column<int>(type: "integer", nullable: false),
                    recieverId = table.Column<int>(type: "integer", nullable: false),
                    title = table.Column<string>(type: "text", nullable: false),
                    content = table.Column<string>(type: "text", nullable: false),
                    sendingDate = table.Column<DateOnly>(type: "date", nullable: false),
                    isRead = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.id);
                    table.ForeignKey(
                        name: "FK_Messages_Users_senderId",
                        column: x => x.senderId,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Points",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    userId = table.Column<int>(type: "integer", nullable: false),
                    point = table.Column<int>(type: "integer", nullable: false),
                    earnDate = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Points", x => x.id);
                    table.ForeignKey(
                        name: "FK_Points_Users_userId",
                        column: x => x.userId,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Punishments",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    userId = table.Column<int>(type: "integer", nullable: false),
                    punishmentDate = table.Column<DateOnly>(type: "date", nullable: false),
                    isActive = table.Column<bool>(type: "boolean", nullable: false),
                    fineAmount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Punishments", x => x.id);
                    table.ForeignKey(
                        name: "FK_Punishments_Users_userId",
                        column: x => x.userId,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RegisterRequests",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    userId = table.Column<int>(type: "integer", nullable: false),
                    requestDate = table.Column<DateOnly>(type: "date", nullable: false),
                    confirmation = table.Column<bool>(type: "boolean", nullable: false),
                    pending = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegisterRequests", x => x.id);
                    table.ForeignKey(
                        name: "FK_RegisterRequests_Users_userId",
                        column: x => x.userId,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "id", "number_of_pages", "status", "title", "type" },
                values: new object[,]
                {
                    { 1, 250, true, "The Psychology of Money", "psychology" },
                    { 2, 368, true, "The Silent Patient", "thriller" },
                    { 3, 334, true, "Educated", "memoir" },
                    { 4, 448, true, "Becoming", "memoir" },
                    { 5, 208, true, "The Alchemist", "fiction" },
                    { 6, 464, true, "Sapiens: A Brief History of Humankind", "history" },
                    { 7, 371, true, "The Power of Habit", "self-help" },
                    { 8, 277, true, "The Catcher in the Rye", "fiction" },
                    { 9, 328, true, "1984", "dystopian" },
                    { 10, 281, true, "To Kill a Mockingbird", "fiction" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { 1, "member" },
                    { 2, "manager" },
                    { 3, "staff" },
                    { 4, "author" }
                });

            migrationBuilder.InsertData(
                table: "Pages",
                columns: new[] { "id", "bookId", "content", "pageNumber" },
                values: new object[,]
                {
                    { 1, 1, "Understanding how money works is essential in today's economy. This chapter explores the psychology behind financial decisions.", 1 },
                    { 2, 1, "The concept of saving and investing is examined, highlighting the impact of time and compound interest.", 2 },
                    { 3, 1, "We delve into common financial myths and the reality behind them, debunking misconceptions that can hinder financial growth.", 3 },
                    { 4, 1, "Emotional aspects of money management are discussed, emphasizing the need for awareness and discipline.", 4 },
                    { 5, 1, "The final chapter provides actionable steps to improve financial literacy and well-being.", 5 },
                    { 6, 2, "The Silent Patient begins with a shocking incident, setting the stage for a psychological thriller filled with twists and turns.", 1 },
                    { 7, 2, "We explore the protagonist's motivations and the dark secrets that unfold throughout the narrative.", 2 },
                    { 8, 2, "Themes of love, betrayal, and forgiveness are intricately woven into the story, making it a gripping read.", 3 },
                    { 9, 2, "The unreliable narrator challenges readers to question the truth behind the events.", 4 },
                    { 10, 2, "The climax leaves readers breathless, leading to a shocking revelation that ties all elements together.", 5 },
                    { 11, 3, "Educated recounts the author's journey from a strict upbringing in Idaho to pursuing higher education against all odds.", 1 },
                    { 12, 3, "The struggle for knowledge and identity forms the core of this compelling memoir.", 2 },
                    { 13, 3, "Key events in the author's life are portrayed with raw honesty and vulnerability.", 3 },
                    { 14, 3, "The challenges faced by the author serve as a powerful reminder of the importance of education.", 4 },
                    { 15, 3, "The memoir concludes with a reflection on personal growth and the value of resilience.", 5 },
                    { 16, 4, "Becoming tells the inspiring story of Michelle Obama, chronicling her life from childhood to the White House.", 1 },
                    { 17, 4, "The author shares personal anecdotes that resonate with themes of identity and self-discovery.", 2 },
                    { 18, 4, "The journey through her career and marriage showcases the challenges faced in the public eye.", 3 },
                    { 19, 4, "Advocacy for education and health issues becomes a focal point in her story.", 4 },
                    { 20, 4, "The memoir ends with a powerful message of hope and empowerment for future generations.", 5 },
                    { 21, 5, "The Alchemist is a magical tale about following one’s dreams and listening to one’s heart.", 1 },
                    { 22, 5, "The journey of Santiago, a young shepherd, serves as a metaphor for the quest for personal legend.", 2 },
                    { 23, 5, "The book emphasizes the significance of dreams and the courage to pursue them.", 3 },
                    { 24, 5, "Wisdom and the interconnectedness of the universe play key roles in the narrative.", 4 },
                    { 25, 5, "The conclusion inspires readers to realize their own dreams and take action.", 5 },
                    { 26, 6, "Sapiens provides a thought-provoking overview of human history and evolution.", 1 },
                    { 27, 6, "The author examines how Homo sapiens came to dominate the Earth and the implications of this power.", 2 },
                    { 28, 6, "Major events, such as the Agricultural Revolution, are analyzed in detail.", 3 },
                    { 29, 6, "The narrative challenges readers to think critically about humanity's future.", 4 },
                    { 30, 6, "The concluding chapter reflects on our place in the world and our responsibilities as a species.", 5 },
                    { 31, 7, "The Power of Habit explores the science behind why habits exist and how they can be changed.", 1 },
                    { 32, 7, "The author breaks down the habit loop: cue, routine, and reward.", 2 },
                    { 33, 7, "Real-life examples illustrate the power of habits in personal and professional life.", 3 },
                    { 34, 7, "Strategies for creating positive habits and breaking negative ones are presented.", 4 },
                    { 35, 7, "The final chapter emphasizes the importance of belief in changing habits.", 5 },
                    { 36, 8, "The Catcher in the Rye narrates the story of Holden Caulfield, a disenchanted teenager.", 1 },
                    { 37, 8, "Themes of alienation and rebellion permeate the narrative, reflecting teenage angst.", 2 },
                    { 38, 8, "Holden's perspective provides a critique of adult hypocrisy and societal expectations.", 3 },
                    { 39, 8, "Key moments highlight the struggle for identity and connection.", 4 },
                    { 40, 8, "The ending leaves readers contemplating the complexities of growing up.", 5 },
                    { 41, 9, "1984 depicts a dystopian future under totalitarian rule, exploring themes of surveillance and oppression.", 1 },
                    { 42, 9, "The protagonist, Winston Smith, grapples with the loss of individuality in a conformist society.", 2 },
                    { 43, 9, "The narrative challenges readers to reflect on the nature of freedom and truth.", 3 },
                    { 44, 9, "The struggle against oppressive regimes is a central theme that resonates in contemporary society.", 4 },
                    { 45, 9, "The conclusion leaves a lasting impact, urging readers to remain vigilant in preserving their freedoms.", 5 },
                    { 46, 10, "To Kill a Mockingbird presents a poignant exploration of racism and injustice in the American South.", 1 },
                    { 47, 10, "The story unfolds through the eyes of young Scout Finch, offering a unique perspective on moral growth.", 2 },
                    { 48, 10, "Key characters highlight the complexities of human behavior and social norms.", 3 },
                    { 49, 10, "The narrative emphasizes empathy and understanding as vital to combating prejudice.", 4 },
                    { 50, 10, "The conclusion underscores the importance of standing up for what is right, even in the face of adversity.", 5 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "id", "email", "name", "password", "roleId", "surname", "userStatus", "username" },
                values: new object[,]
                {
                    { 1, "test1@example.com", "Alice", "pass123", 1, "Smith", true, "alice_smith" },
                    { 2, "test2@example.com", "Bob", "pass234", 1, "Brown", true, "bob_brown" },
                    { 3, "test3@example.com", "Charlie", "pass345", 1, "Davis", true, "charlie_davis" },
                    { 4, "test4@example.com", "Diana", "pass456", 1, "Evans", true, "diana_evans" },
                    { 5, "test5@example.com", "Evan", "pass567", 1, "Foster", true, "evan_foster" },
                    { 6, "test6@example.com", "Fiona", "pass678", 1, "Gates", true, "fiona_gates" },
                    { 7, "test7@example.com", "George", "pass789", 1, "Harris", true, "george_harris" },
                    { 8, "test8@example.com", "Hannah", "pass890", 1, "Irwin", true, "hannah_irwin" },
                    { 9, "test9@example.com", "Isaac", "pass901", 1, "Jones", true, "isaac_jones" },
                    { 10, "test10@example.com", "Jack", "pass012", 1, "King", true, "jack_king" },
                    { 11, "test11@example.com", "Feyza", "123", 1, "Beyaztaş", true, "member" },
                    { 12, "test12@example.com", "Türker", "123", 2, "Kıvılcım", true, "manager" },
                    { 13, "test13@example.com", "Fatih", "123", 3, "Çağdaş", true, "staff" },
                    { 14, "test14@example.com", "Zehra", "123", 4, "Ülker", true, "author" },
                    { 15, "test14@example.com", "Özge", "123", 4, "Nur", true, "author2" }
                });

            migrationBuilder.InsertData(
                table: "BookAuthors",
                columns: new[] { "id", "bookId", "userId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 2 },
                    { 3, 3, 3 },
                    { 4, 4, 4 },
                    { 5, 5, 5 },
                    { 6, 6, 6 },
                    { 7, 7, 7 },
                    { 8, 8, 8 },
                    { 9, 9, 9 },
                    { 10, 10, 10 }
                });

            migrationBuilder.InsertData(
                table: "BookPublishRequests",
                columns: new[] { "id", "bookId", "confirmation", "pending", "requestDate", "userId" },
                values: new object[,]
                {
                    { 1, 1, false, true, new DateOnly(2024, 10, 2), 1 },
                    { 2, 2, false, true, new DateOnly(2024, 10, 2), 2 },
                    { 3, 3, false, true, new DateOnly(2024, 10, 2), 3 },
                    { 4, 4, false, true, new DateOnly(2024, 10, 2), 4 },
                    { 5, 5, false, true, new DateOnly(2024, 10, 2), 5 },
                    { 6, 6, false, true, new DateOnly(2024, 10, 2), 6 },
                    { 7, 7, false, true, new DateOnly(2024, 10, 2), 7 },
                    { 8, 8, false, true, new DateOnly(2024, 10, 2), 8 },
                    { 9, 9, false, true, new DateOnly(2024, 10, 2), 9 },
                    { 10, 10, false, true, new DateOnly(2024, 10, 2), 10 }
                });

            migrationBuilder.InsertData(
                table: "LoanRequests",
                columns: new[] { "id", "bookId", "confirmation", "isReturned", "pending", "requestDate", "returnDate", "userId" },
                values: new object[,]
                {
                    { 1, 1, false, false, true, new DateOnly(2024, 10, 2), new DateOnly(2024, 10, 9), 1 },
                    { 2, 2, false, false, true, new DateOnly(2024, 10, 2), new DateOnly(2024, 10, 16), 2 },
                    { 3, 3, false, false, true, new DateOnly(2024, 10, 2), new DateOnly(2024, 10, 23), 3 },
                    { 4, 4, false, false, true, new DateOnly(2024, 10, 2), new DateOnly(2024, 10, 30), 4 },
                    { 5, 5, false, false, true, new DateOnly(2024, 10, 2), new DateOnly(2024, 11, 1), 5 },
                    { 6, 6, false, false, true, new DateOnly(2024, 10, 2), new DateOnly(2024, 10, 16), 6 },
                    { 7, 7, false, false, true, new DateOnly(2024, 10, 2), new DateOnly(2024, 10, 23), 7 },
                    { 8, 8, false, false, true, new DateOnly(2024, 10, 2), new DateOnly(2024, 10, 30), 8 },
                    { 9, 9, false, false, true, new DateOnly(2024, 10, 2), new DateOnly(2024, 11, 1), 9 },
                    { 10, 10, false, false, true, new DateOnly(2024, 10, 2), new DateOnly(2024, 10, 16), 10 }
                });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "id", "content", "isRead", "recieverId", "senderId", "sendingDate", "title" },
                values: new object[,]
                {
                    { 1, "Hello! Looking forward to reading this book.", false, 2, 1, new DateOnly(2024, 10, 2), "Greetings" },
                    { 2, "Did you finish the last chapter?", false, 1, 2, new DateOnly(2024, 10, 2), "Question" },
                    { 3, "I found a great article related to our reading.", false, 3, 1, new DateOnly(2024, 10, 2), "Resource Sharing" },
                    { 4, "Let's discuss this book in our next meeting.", false, 4, 1, new DateOnly(2024, 10, 2), "Discussion" },
                    { 5, "What do you think about the protagonist's choices?", false, 5, 1, new DateOnly(2024, 10, 2), "Character Analysis" },
                    { 6, "I can't wait to start the next book!", false, 6, 1, new DateOnly(2024, 10, 2), "Excitement" },
                    { 7, "Have you read the latest chapter?", false, 7, 1, new DateOnly(2024, 10, 2), "Update" },
                    { 8, "This book changed my perspective on many things.", false, 8, 1, new DateOnly(2024, 10, 2), "Thoughts" },
                    { 9, "I'm glad we chose this book for our group.", false, 9, 1, new DateOnly(2024, 10, 2), "Group Decision" },
                    { 10, "What are your favorite quotes from the book?", false, 10, 1, new DateOnly(2024, 10, 2), "Quotes" }
                });

            migrationBuilder.InsertData(
                table: "Points",
                columns: new[] { "id", "earnDate", "point", "userId" },
                values: new object[,]
                {
                    { 1, new DateOnly(2024, 10, 2), 10, 1 },
                    { 2, new DateOnly(2024, 10, 1), 20, 1 },
                    { 3, new DateOnly(2024, 9, 30), 15, 2 },
                    { 4, new DateOnly(2024, 9, 29), 25, 2 },
                    { 5, new DateOnly(2024, 9, 28), 30, 3 },
                    { 6, new DateOnly(2024, 9, 27), 40, 4 },
                    { 7, new DateOnly(2024, 9, 26), 50, 5 },
                    { 8, new DateOnly(2024, 9, 25), 60, 6 },
                    { 9, new DateOnly(2024, 9, 24), 70, 7 },
                    { 10, new DateOnly(2024, 9, 23), 80, 8 }
                });

            migrationBuilder.InsertData(
                table: "Punishments",
                columns: new[] { "id", "fineAmount", "isActive", "punishmentDate", "userId" },
                values: new object[,]
                {
                    { 1, 5, true, new DateOnly(2024, 10, 2), 1 },
                    { 2, 10, true, new DateOnly(2024, 10, 1), 2 },
                    { 3, 15, false, new DateOnly(2024, 9, 30), 3 },
                    { 4, 20, true, new DateOnly(2024, 9, 29), 4 },
                    { 5, 25, false, new DateOnly(2024, 9, 28), 5 },
                    { 6, 30, true, new DateOnly(2024, 9, 27), 6 },
                    { 7, 35, true, new DateOnly(2024, 9, 26), 7 },
                    { 8, 40, false, new DateOnly(2024, 9, 25), 8 },
                    { 9, 45, true, new DateOnly(2024, 9, 24), 9 },
                    { 10, 50, false, new DateOnly(2024, 9, 23), 10 }
                });

            migrationBuilder.InsertData(
                table: "RegisterRequests",
                columns: new[] { "id", "confirmation", "pending", "requestDate", "userId" },
                values: new object[,]
                {
                    { 1, false, true, new DateOnly(2024, 10, 2), 1 },
                    { 2, false, true, new DateOnly(2024, 10, 1), 2 },
                    { 3, true, false, new DateOnly(2024, 9, 30), 3 },
                    { 4, true, false, new DateOnly(2024, 9, 29), 4 },
                    { 5, false, true, new DateOnly(2024, 9, 28), 5 },
                    { 6, false, true, new DateOnly(2024, 9, 27), 6 },
                    { 7, true, false, new DateOnly(2024, 9, 26), 7 },
                    { 8, false, true, new DateOnly(2024, 9, 25), 8 },
                    { 9, true, false, new DateOnly(2024, 9, 24), 9 },
                    { 10, false, true, new DateOnly(2024, 9, 23), 10 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookAuthors_bookId",
                table: "BookAuthors",
                column: "bookId");

            migrationBuilder.CreateIndex(
                name: "IX_BookAuthors_userId",
                table: "BookAuthors",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_BookPublishRequests_bookId",
                table: "BookPublishRequests",
                column: "bookId");

            migrationBuilder.CreateIndex(
                name: "IX_BookPublishRequests_userId",
                table: "BookPublishRequests",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanRequests_bookId",
                table: "LoanRequests",
                column: "bookId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanRequests_userId",
                table: "LoanRequests",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_senderId",
                table: "Messages",
                column: "senderId");

            migrationBuilder.CreateIndex(
                name: "IX_Pages_bookId",
                table: "Pages",
                column: "bookId");

            migrationBuilder.CreateIndex(
                name: "IX_Points_userId",
                table: "Points",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_Punishments_userId",
                table: "Punishments",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_RegisterRequests_userId",
                table: "RegisterRequests",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_roleId",
                table: "Users",
                column: "roleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookAuthors");

            migrationBuilder.DropTable(
                name: "BookPublishRequests");

            migrationBuilder.DropTable(
                name: "LoanRequests");

            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "Pages");

            migrationBuilder.DropTable(
                name: "Points");

            migrationBuilder.DropTable(
                name: "Punishments");

            migrationBuilder.DropTable(
                name: "RegisterRequests");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
