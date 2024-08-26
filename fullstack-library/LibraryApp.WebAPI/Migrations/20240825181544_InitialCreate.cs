using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace fullstack_library.Migrations
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
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: false),
                    IsPublished = table.Column<bool>(type: "boolean", nullable: false),
                    PublishDate = table.Column<DateTime>(type: "DATE", nullable: false),
                    IsBorrowed = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BookPublishRequests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BookId = table.Column<int>(type: "integer", nullable: false),
                    RequestDate = table.Column<DateTime>(type: "DATE", nullable: false),
                    IsPending = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookPublishRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookPublishRequests_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PageNumber = table.Column<int>(type: "integer", nullable: false),
                    BookId = table.Column<int>(type: "integer", nullable: false),
                    Content = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pages_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleId = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Surname = table.Column<string>(type: "text", nullable: false),
                    Username = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "DATE", nullable: false),
                    Gender = table.Column<char>(type: "character(1)", nullable: false),
                    IsPunished = table.Column<bool>(type: "boolean", nullable: false),
                    FineAmount = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookAuthors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BookId = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookAuthors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookAuthors_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookAuthors_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookBorrowActivities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BookId = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    BorrowDate = table.Column<DateTime>(type: "DATE", nullable: false),
                    ReturnDate = table.Column<DateTime>(type: "DATE", nullable: false),
                    IsApproved = table.Column<bool>(type: "boolean", nullable: false),
                    IsReturned = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookBorrowActivities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookBorrowActivities_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookBorrowActivities_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SenderId = table.Column<int>(type: "integer", nullable: false),
                    ReceiverId = table.Column<int>(type: "integer", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Details = table.Column<string>(type: "text", nullable: false),
                    IsReceiverRead = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Messages_Users_ReceiverId",
                        column: x => x.ReceiverId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Messages_Users_SenderId",
                        column: x => x.SenderId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "IsBorrowed", "IsPublished", "PublishDate", "Title" },
                values: new object[,]
                {
                    { 1, false, true, new DateTime(2023, 7, 22, 18, 15, 44, 315, DateTimeKind.Utc).AddTicks(6336), "To Kill a Mockingbird" },
                    { 2, false, true, new DateTime(2023, 9, 10, 18, 15, 44, 315, DateTimeKind.Utc).AddTicks(6347), "1984" },
                    { 3, false, true, new DateTime(2023, 10, 30, 18, 15, 44, 315, DateTimeKind.Utc).AddTicks(6350), "The Great Gatsby" },
                    { 4, false, true, new DateTime(2023, 12, 19, 18, 15, 44, 315, DateTimeKind.Utc).AddTicks(6353), "The Catcher in the Rye" },
                    { 5, false, true, new DateTime(2024, 2, 7, 18, 15, 44, 315, DateTimeKind.Utc).AddTicks(6356), "Moby-Dick" },
                    { 6, false, true, new DateTime(2024, 3, 28, 18, 15, 44, 315, DateTimeKind.Utc).AddTicks(6404), "Pride and Prejudice" },
                    { 7, false, true, new DateTime(2024, 5, 17, 18, 15, 44, 315, DateTimeKind.Utc).AddTicks(6407), "The Lord of the Rings" },
                    { 8, false, true, new DateTime(2024, 5, 27, 18, 15, 44, 315, DateTimeKind.Utc).AddTicks(6410), "Jane Eyre" },
                    { 9, false, true, new DateTime(2024, 6, 6, 18, 15, 44, 315, DateTimeKind.Utc).AddTicks(6412), "Brave New World" },
                    { 10, false, true, new DateTime(2024, 6, 16, 18, 15, 44, 315, DateTimeKind.Utc).AddTicks(6414), "The Hobbit" },
                    { 11, false, true, new DateTime(2024, 6, 26, 18, 15, 44, 315, DateTimeKind.Utc).AddTicks(6417), "Wuthering Heights" },
                    { 12, false, true, new DateTime(2024, 7, 6, 18, 15, 44, 315, DateTimeKind.Utc).AddTicks(6419), "Fahrenheit 451" },
                    { 13, false, true, new DateTime(2024, 7, 16, 18, 15, 44, 315, DateTimeKind.Utc).AddTicks(6421), "The Chronicles of Narnia" },
                    { 14, false, true, new DateTime(2024, 7, 26, 18, 15, 44, 315, DateTimeKind.Utc).AddTicks(6424), "Little Women" },
                    { 15, false, true, new DateTime(2024, 8, 5, 18, 15, 44, 315, DateTimeKind.Utc).AddTicks(6426), "The Picture of Dorian Gray" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "pendingUser" },
                    { 2, "member" },
                    { 3, "author" },
                    { 4, "staff" },
                    { 5, "manager" }
                });

            migrationBuilder.InsertData(
                table: "Pages",
                columns: new[] { "Id", "BookId", "Content", "PageNumber" },
                values: new object[,]
                {
                    { 1, 1, "In a land of fantasy, an unexpected hero emerged from the ordinary. The journey began with a single step into the unknown, leading to adventures beyond imagination.", 1 },
                    { 2, 1, "The hero faced trials that tested their courage and wisdom. Each challenge revealed hidden strengths and forged bonds that would be crucial in the trials ahead.", 2 },
                    { 3, 1, "As the hero ventured deeper into uncharted territories, they uncovered secrets long buried and faced adversaries that sought to thwart their quest.", 3 },
                    { 4, 1, "In the end, the hero's journey culminated in a revelation that changed their world forever, proving that even the smallest steps can lead to the grandest adventures.", 4 },
                    { 5, 2, "In the bustling city, a lone inventor labored in secrecy, crafting designs that promised to revolutionize the world. Their work went unnoticed until a pivotal encounter changed everything.", 1 },
                    { 6, 2, "The inventor's designs were met with skepticism, but perseverance led to breakthroughs that captured the attention of influential figures, setting the stage for a transformative era.", 2 },
                    { 7, 2, "Collaborations with renowned scientists led to the development of groundbreaking technologies, shifting the dynamics of the city and bringing the inventor’s dreams to fruition.", 3 },
                    { 8, 2, "The city, now a beacon of innovation, celebrated the inventor's contributions. Their legacy was cemented as a pioneer in a new age of technological advancement.", 4 },
                    { 9, 3, "Deep within a secluded forest, a hidden realm thrived in harmony. The forest's peace was disrupted by foreboding signs, hinting at challenges that lay ahead.", 1 },
                    { 10, 3, "A young guardian was chosen to protect the sanctuary. Their journey began with ancient rituals and encounters that revealed the weight of their new responsibilities.", 2 },
                    { 11, 3, "As the guardian traveled beyond the forest, they encountered allies and enemies, each revealing more about the prophecy and the role they were destined to play.", 3 },
                    { 12, 3, "The culmination of their quest brought forth a revelation that not only affected the sanctuary but also bridged the gap between the hidden realm and the outside world.", 4 },
                    { 13, 4, "In a small village, a young girl discovered an ancient artifact that set her on a path to uncover secrets long forgotten. Her adventure was just beginning.", 1 },
                    { 14, 4, "The artifact led her to distant lands and mysterious allies, each piece of the puzzle revealing more about the ancient prophecy and her role in it.", 2 },
                    { 15, 4, "Along the way, she faced trials that tested her resolve and discovered hidden strengths within herself. Each challenge brought her closer to the ultimate truth.", 3 },
                    { 16, 4, "The journey concluded with a revelation that changed her world, showing that the path of destiny is often forged through courage and perseverance.", 4 },
                    { 17, 5, "In a futuristic society, a rogue scientist defied the norms to pursue a groundbreaking experiment. The risks were high, but the potential rewards were even greater.", 1 },
                    { 18, 5, "The scientist's experiment faced numerous obstacles, from technical failures to opposition from authorities. Each challenge tested their determination and ingenuity.", 2 },
                    { 19, 5, "Despite the setbacks, the scientist made significant progress. Their work began to attract attention and eventually changed the course of their society's future.", 3 },
                    { 20, 5, "The experiment's success marked a new era of innovation and possibilities, proving that courage in the face of adversity can lead to transformative change.", 4 },
                    { 21, 6, "On a distant planet, a team of explorers embarked on a mission to uncover the secrets of an ancient civilization. Their journey was filled with wonder and danger.", 1 },
                    { 22, 6, "As they delved deeper into the ruins, they encountered relics and puzzles that hinted at the civilization's advanced knowledge and mysterious disappearance.", 2 },
                    { 23, 6, "The explorers faced perilous challenges, including natural hazards and unexpected encounters. Each discovery brought them closer to understanding the planet's enigmatic past.", 3 },
                    { 24, 6, "The mission's conclusion revealed profound truths about the civilization and the planet, marking a significant achievement in the history of exploration.", 4 },
                    { 25, 7, "In a dystopian world, a young rebel fought against a corrupt regime. Their struggle was a beacon of hope for a society yearning for change.", 1 },
                    { 26, 7, "The rebel's journey was fraught with danger and sacrifice. Allies were few, and enemies were many, but their resolve remained unshaken.", 2 },
                    { 27, 7, "Amidst the turmoil, the rebel uncovered secrets that could alter the balance of power. Their actions inspired a movement that spread across the land.", 3 },
                    { 28, 7, "The rebel's legacy was one of courage and resilience. Their fight against tyranny became a symbol of hope for future generations.", 4 },
                    { 29, 8, "In an enchanted realm, a mystical artifact held the key to unlocking ancient powers. A group of heroes embarked on a quest to find it.", 1 },
                    { 30, 8, "The quest took them through magical landscapes and mythical creatures. Each step brought them closer to the artifact and the powers it held.", 2 },
                    { 31, 8, "Challenges and riddles tested their skills and unity. They discovered that the true power of the artifact lay in their courage and friendship.", 3 },
                    { 32, 8, "The artifact's discovery brought about a transformation in the realm, uniting the land and restoring balance to its magical energies.", 4 },
                    { 33, 9, "In the depths of the ocean, a marine biologist uncovered secrets of a lost underwater city. Their discovery was both awe-inspiring and perilous.", 1 },
                    { 34, 9, "The biologist's exploration revealed advanced technologies and forgotten histories. Each finding contributed to a deeper understanding of the city's rise and fall.", 2 },
                    { 35, 9, "Encountering dangers both natural and artificial, the biologist pressed on, driven by the quest for knowledge and the preservation of the city's legacy.", 3 },
                    { 36, 9, "The expedition's findings reshaped the understanding of oceanic civilizations, leading to new discoveries and a greater appreciation of the planet's mysteries.", 4 },
                    { 37, 10, "In a bustling metropolis, a detective sought to solve a series of enigmatic crimes. Their investigation uncovered a web of intrigue and deception.", 1 },
                    { 38, 10, "The detective's pursuit of clues led them through hidden corners of the city, each revelation bringing them closer to unraveling the truth behind the crimes.", 2 },
                    { 39, 10, "Faced with false leads and dangerous encounters, the detective remained resolute, piecing together the puzzle with skill and determination.", 3 },
                    { 40, 10, "The resolution of the case not only brought justice but also shed light on the darker aspects of the city, prompting a wave of change and reform.", 4 },
                    { 41, 11, "In a fantasy kingdom, a young prince set out on a quest to reclaim his throne. The journey was fraught with danger and tests of character.", 1 },
                    { 42, 11, "The prince faced trials that tested his leadership and resolve. Each challenge brought him closer to understanding the responsibilities of ruling.", 2 },
                    { 43, 11, "Allies and adversaries alike shaped his journey, revealing truths about the kingdom's past and the future he hoped to build.", 3 },
                    { 44, 11, "The prince's return marked the beginning of a new era for the kingdom, one shaped by the lessons learned and the strength gained on his quest.", 4 },
                    { 45, 12, "In a secretive research facility, a scientist uncovered a groundbreaking discovery that had the potential to revolutionize their field of study.", 1 },
                    { 46, 12, "The research led to exciting advancements but also drew the attention of powerful entities with conflicting interests.", 2 },
                    { 47, 12, "Navigating the complex landscape of scientific ethics and external pressures, the scientist worked tirelessly to ensure their discovery's positive impact.", 3 },
                    { 48, 12, "The discovery's successful implementation marked a significant milestone, demonstrating the potential for innovation to shape the future.", 4 },
                    { 49, 13, "In an ancient land, a scholar stumbled upon a forgotten manuscript that revealed the secrets of an ancient civilization.", 1 },
                    { 50, 13, "The manuscript's revelations led the scholar on a journey across the land, uncovering hidden truths and long-lost artifacts.", 2 },
                    { 51, 13, "Each discovery added to the scholar's understanding of the civilization's rise and fall, providing valuable insights into their culture and technology.", 3 },
                    { 52, 13, "The scholar's findings transformed historical knowledge and inspired further exploration into the ancient world's mysteries.", 4 },
                    { 53, 14, "In a bustling space station, an astronaut embarked on a mission to explore uncharted regions of space. The journey was filled with challenges and discoveries.", 1 },
                    { 54, 14, "The mission's crew encountered alien phenomena and navigated through hazardous environments, each obstacle revealing more about the cosmos.", 2 },
                    { 55, 14, "As the exploration continued, the astronaut uncovered signs of ancient extraterrestrial civilizations and their impact on the galaxy.", 3 },
                    { 56, 14, "The mission's success expanded humanity's understanding of space and paved the way for future exploration and interstellar travel.", 4 },
                    { 57, 15, "In a post-apocalyptic world, a group of survivors struggled to rebuild society amidst the ruins. Their efforts were fraught with challenges and dangers.", 1 },
                    { 58, 15, "The survivors faced conflicts with other factions and the harsh realities of their environment, testing their resilience and resourcefulness.", 2 },
                    { 59, 15, "Amidst the struggle, they forged alliances and developed strategies to secure their future, working towards a new beginning for their community.", 3 },
                    { 60, 15, "Their efforts culminated in a restored sense of hope and a foundation for rebuilding, marking the dawn of a new era from the ashes of the old.", 4 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "BirthDate", "FineAmount", "Gender", "IsPunished", "Name", "Password", "RoleId", "Surname", "Username" },
                values: new object[,]
                {
                    { 1, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0f, 'F', false, "Alice", "123", 1, "Smith", "alice" },
                    { 2, new DateTime(1985, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 0f, 'M', false, "Bob", "123", 2, "Johnson", "bobby" },
                    { 3, new DateTime(1992, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 0f, 'F', false, "Carol", "123", 3, "Williams", "carol" },
                    { 4, new DateTime(1980, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 0f, 'M', false, "Dave", "123", 4, "Brown", "dave1" },
                    { 5, new DateTime(1995, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 0f, 'F', false, "Eve", "123", 5, "Jones", "eve01" },
                    { 6, new DateTime(1987, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 0f, 'M', false, "Frank", "123", 1, "Miller", "frank" },
                    { 7, new DateTime(1993, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 0f, 'F', false, "Grace", "123", 2, "Wilson", "grace" },
                    { 8, new DateTime(1988, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 0f, 'M', false, "Henry", "123", 3, "Moore", "henry" },
                    { 9, new DateTime(1994, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 0f, 'F', false, "Ivy", "123", 4, "Taylor", "ivy99" },
                    { 10, new DateTime(1991, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 0f, 'M', false, "Jack", "123", 5, "Anderson", "jack1" },
                    { 11, new DateTime(1991, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 0f, 'M', false, "NameOfManager", "123", 5, "Anderson", "manager" },
                    { 12, new DateTime(1991, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 0f, 'M', false, "NameOfStaff", "123", 4, "Anderson", "staff" },
                    { 13, new DateTime(1991, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 0f, 'M', false, "NameOfAuthor", "123", 3, "Anderson", "author" },
                    { 14, new DateTime(1991, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 0f, 'M', false, "NameOfMember", "123", 2, "Anderson", "member" },
                    { 15, new DateTime(1991, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 0f, 'M', false, "NameOfPending", "123", 1, "Anderson", "pending" }
                });

            migrationBuilder.InsertData(
                table: "BookAuthors",
                columns: new[] { "Id", "BookId", "UserId" },
                values: new object[,]
                {
                    { 1, 1, 3 },
                    { 2, 2, 8 },
                    { 3, 3, 3 },
                    { 4, 4, 8 },
                    { 5, 5, 3 },
                    { 6, 6, 8 },
                    { 7, 7, 3 },
                    { 8, 8, 8 },
                    { 9, 9, 3 },
                    { 10, 10, 8 },
                    { 11, 11, 3 },
                    { 12, 12, 8 },
                    { 13, 13, 3 },
                    { 14, 14, 8 },
                    { 15, 15, 3 }
                });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "Details", "IsReceiverRead", "ReceiverId", "SenderId", "Title" },
                values: new object[,]
                {
                    { 1, "Selam, nasılsın? Bir konu hakkında soru soracaktım", false, 2, 1, "Title test 1" },
                    { 2, "Can we schedule a meeting for next week?", true, 3, 2, "Meeting Request" },
                    { 3, "The project is moving forward as planned. Let's discuss further.", false, 4, 3, "Project Update" },
                    { 4, "Don't forget to submit the report by end of day.", true, 5, 4, "Reminder" },
                    { 5, "Please provide feedback on the recent presentation.", false, 1, 5, "Feedback Request" },
                    { 6, "Just following up on the last message I sent.", true, 2, 1, "Follow-up" },
                    { 7, "Please respond as soon as possible regarding the urgent matter.", false, 3, 2, "Urgent" },
                    { 8, "Thank you for your assistance with the project.", true, 4, 3, "Thank You" },
                    { 9, "I have a question about the new policy changes.", false, 5, 4, "Question" },
                    { 10, "You are invited to the team-building event next week.", true, 1, 5, "Invitation" },
                    { 11, "Can we have a quick chat tomorrow about the project?", false, 3, 1, "Quick Chat" },
                    { 12, "I need the latest report by tomorrow.", true, 4, 2, "Report Needed" },
                    { 13, "Please provide an update on the status of the task.", false, 5, 3, "Update Required" },
                    { 14, "Reminder to review the attached document.", true, 1, 4, "Reminder" },
                    { 15, "I have a suggestion for improving the workflow.", false, 2, 5, "Suggestion" },
                    { 16, "I would like your feedback on the recent changes.", true, 4, 1, "Feedback" },
                    { 17, "Following up on the previous discussion about the project.", false, 3, 2, "Follow-up" },
                    { 18, "Here's a proposal for the upcoming project.", true, 5, 3, "Proposal" },
                    { 19, "I have a query regarding the latest changes.", false, 1, 4, "Query" },
                    { 20, "This is an urgent matter that requires your immediate attention.", true, 2, 5, "Urgent" },
                    { 21, "Here is the latest update on the project.", false, 3, 1, "Update" },
                    { 22, "You are invited to the upcoming workshop.", true, 4, 2, "Invitation" },
                    { 23, "Following up on our meeting from last week.", false, 5, 3, "Meeting Follow-up" },
                    { 24, "A new task has been assigned to you.", true, 1, 4, "Task Assigned" },
                    { 25, "Please review the attached document and provide feedback.", false, 2, 5, "Review Request" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookAuthors_BookId",
                table: "BookAuthors",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_BookAuthors_UserId",
                table: "BookAuthors",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_BookBorrowActivities_BookId",
                table: "BookBorrowActivities",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_BookBorrowActivities_UserId",
                table: "BookBorrowActivities",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_BookPublishRequests_BookId",
                table: "BookPublishRequests",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_ReceiverId",
                table: "Messages",
                column: "ReceiverId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_SenderId",
                table: "Messages",
                column: "SenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Pages_BookId",
                table: "Pages",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Username",
                table: "Users",
                column: "Username",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookAuthors");

            migrationBuilder.DropTable(
                name: "BookBorrowActivities");

            migrationBuilder.DropTable(
                name: "BookPublishRequests");

            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "Pages");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
