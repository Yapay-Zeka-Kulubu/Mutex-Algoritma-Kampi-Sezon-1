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
                name: "cezalar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    CezaGunu = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CezaBitisGunu = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CezaAktifMi = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cezalar", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "hesapAcmaTalepleri",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    TalepTarihi = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    OnaylandiMi = table.Column<bool>(type: "boolean", nullable: false),
                    BeklemedeMi = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hesapAcmaTalepleri", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "kitaplar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Isim = table.Column<string>(type: "text", nullable: false),
                    KitapYayinlandiMi = table.Column<bool>(type: "boolean", nullable: false),
                    YayinlanmaTarihi = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_kitaplar", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "puanlar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    PuanGunu = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    KazanilanPuan = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_puanlar", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "roller",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RolIsmi = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_roller", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "sayfalar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    KitapId = table.Column<int>(type: "integer", nullable: false),
                    SayfaNo = table.Column<int>(type: "integer", nullable: false),
                    Icerik = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sayfalar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_sayfalar_kitaplar_KitapId",
                        column: x => x.KitapId,
                        principalTable: "kitaplar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Isim = table.Column<string>(type: "text", nullable: false),
                    SoyIsim = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    RolId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_users_roller_RolId",
                        column: x => x.RolId,
                        principalTable: "roller",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "kitapOduncler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    KitapId = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    TalepTarihi = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DonusTarihi = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    OnaylandiMi = table.Column<bool>(type: "boolean", nullable: false),
                    BeklemedeMi = table.Column<bool>(type: "boolean", nullable: false),
                    DondurulduMu = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_kitapOduncler", x => x.Id);
                    table.ForeignKey(
                        name: "FK_kitapOduncler_kitaplar_KitapId",
                        column: x => x.KitapId,
                        principalTable: "kitaplar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_kitapOduncler_users_UserId",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "kitapYayinTalepleri",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    KitapId = table.Column<int>(type: "integer", nullable: false),
                    YazarId = table.Column<int>(type: "integer", nullable: false),
                    TalepTarihi = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    OnaylandiMi = table.Column<bool>(type: "boolean", nullable: false),
                    BeklemedeMi = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_kitapYayinTalepleri", x => x.Id);
                    table.ForeignKey(
                        name: "FK_kitapYayinTalepleri_kitaplar_KitapId",
                        column: x => x.KitapId,
                        principalTable: "kitaplar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_kitapYayinTalepleri_users_YazarId",
                        column: x => x.YazarId,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "kitapYazarlari",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    KitapId = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_kitapYazarlari", x => x.Id);
                    table.ForeignKey(
                        name: "FK_kitapYazarlari_kitaplar_KitapId",
                        column: x => x.KitapId,
                        principalTable: "kitaplar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_kitapYazarlari_users_UserId",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "mesajlar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    GonderenId = table.Column<int>(type: "integer", nullable: false),
                    AlanId = table.Column<int>(type: "integer", nullable: false),
                    Konu = table.Column<string>(type: "text", nullable: false),
                    Icerik = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mesajlar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_mesajlar_users_GonderenId",
                        column: x => x.GonderenId,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "cezalar",
                columns: new[] { "Id", "CezaAktifMi", "CezaBitisGunu", "CezaGunu", "UserId" },
                values: new object[,]
                {
                    { 1, false, new DateTime(2024, 9, 12, 11, 17, 51, 392, DateTimeKind.Utc).AddTicks(9521), new DateTime(2024, 9, 2, 11, 17, 51, 392, DateTimeKind.Utc).AddTicks(9515), 2 },
                    { 2, false, new DateTime(2024, 8, 13, 11, 17, 51, 392, DateTimeKind.Utc).AddTicks(9523), new DateTime(2024, 8, 3, 11, 17, 51, 392, DateTimeKind.Utc).AddTicks(9522), 3 },
                    { 3, true, new DateTime(2024, 9, 27, 11, 17, 51, 392, DateTimeKind.Utc).AddTicks(9525), new DateTime(2024, 9, 22, 11, 17, 51, 392, DateTimeKind.Utc).AddTicks(9524), 4 },
                    { 4, false, new DateTime(2024, 9, 17, 11, 17, 51, 392, DateTimeKind.Utc).AddTicks(9526), new DateTime(2024, 9, 7, 11, 17, 51, 392, DateTimeKind.Utc).AddTicks(9526), 5 },
                    { 5, true, new DateTime(2024, 9, 2, 11, 17, 51, 392, DateTimeKind.Utc).AddTicks(9528), new DateTime(2024, 8, 23, 11, 17, 51, 392, DateTimeKind.Utc).AddTicks(9527), 6 },
                    { 6, false, new DateTime(2024, 8, 3, 11, 17, 51, 392, DateTimeKind.Utc).AddTicks(9529), new DateTime(2024, 7, 24, 11, 17, 51, 392, DateTimeKind.Utc).AddTicks(9529), 7 },
                    { 7, true, new DateTime(2024, 10, 7, 11, 17, 51, 392, DateTimeKind.Utc).AddTicks(9531), new DateTime(2024, 9, 27, 11, 17, 51, 392, DateTimeKind.Utc).AddTicks(9530), 8 },
                    { 8, false, new DateTime(2024, 7, 4, 11, 17, 51, 392, DateTimeKind.Utc).AddTicks(9532), new DateTime(2024, 6, 24, 11, 17, 51, 392, DateTimeKind.Utc).AddTicks(9532), 9 },
                    { 9, true, new DateTime(2024, 9, 22, 11, 17, 51, 392, DateTimeKind.Utc).AddTicks(9534), new DateTime(2024, 9, 12, 11, 17, 51, 392, DateTimeKind.Utc).AddTicks(9533), 10 },
                    { 10, false, new DateTime(2024, 9, 7, 11, 17, 51, 392, DateTimeKind.Utc).AddTicks(9535), new DateTime(2024, 8, 28, 11, 17, 51, 392, DateTimeKind.Utc).AddTicks(9535), 11 }
                });

            migrationBuilder.InsertData(
                table: "hesapAcmaTalepleri",
                columns: new[] { "Id", "BeklemedeMi", "OnaylandiMi", "TalepTarihi", "UserId" },
                values: new object[,]
                {
                    { 1, false, true, new DateTime(2024, 9, 27, 11, 17, 51, 392, DateTimeKind.Utc).AddTicks(9661), 4 },
                    { 2, false, true, new DateTime(2024, 9, 22, 11, 17, 51, 392, DateTimeKind.Utc).AddTicks(9662), 5 },
                    { 3, true, false, new DateTime(2024, 9, 17, 11, 17, 51, 392, DateTimeKind.Utc).AddTicks(9664), 6 },
                    { 4, false, true, new DateTime(2024, 9, 12, 11, 17, 51, 392, DateTimeKind.Utc).AddTicks(9665), 7 },
                    { 5, true, false, new DateTime(2024, 9, 7, 11, 17, 51, 392, DateTimeKind.Utc).AddTicks(9666), 8 },
                    { 6, false, true, new DateTime(2024, 9, 2, 11, 17, 51, 392, DateTimeKind.Utc).AddTicks(9667), 9 },
                    { 7, true, false, new DateTime(2024, 8, 28, 11, 17, 51, 392, DateTimeKind.Utc).AddTicks(9675), 10 },
                    { 8, false, true, new DateTime(2024, 8, 23, 11, 17, 51, 392, DateTimeKind.Utc).AddTicks(9676), 11 },
                    { 9, true, false, new DateTime(2024, 8, 18, 11, 17, 51, 392, DateTimeKind.Utc).AddTicks(9677), 12 },
                    { 10, false, true, new DateTime(2024, 8, 13, 11, 17, 51, 392, DateTimeKind.Utc).AddTicks(9678), 13 }
                });

            migrationBuilder.InsertData(
                table: "kitaplar",
                columns: new[] { "Id", "Isim", "KitapYayinlandiMi", "YayinlanmaTarihi" },
                values: new object[,]
                {
                    { 1, "The Art of Coding", true, new DateTime(2023, 10, 3, 11, 17, 51, 392, DateTimeKind.Utc).AddTicks(9721) },
                    { 2, "Learning C#", true, new DateTime(2023, 8, 29, 11, 17, 51, 392, DateTimeKind.Utc).AddTicks(9722) },
                    { 3, "Mastering ASP.NET", true, new DateTime(2023, 5, 21, 11, 17, 51, 392, DateTimeKind.Utc).AddTicks(9723) },
                    { 4, "Entity Framework Core", true, new DateTime(2024, 3, 16, 11, 17, 51, 392, DateTimeKind.Utc).AddTicks(9724) },
                    { 5, "React for Beginners", true, new DateTime(2023, 12, 7, 11, 17, 51, 392, DateTimeKind.Utc).AddTicks(9725) },
                    { 6, "Advanced SQL", true, new DateTime(2024, 5, 5, 11, 17, 51, 392, DateTimeKind.Utc).AddTicks(9726) },
                    { 7, "JavaScript in Depth", true, new DateTime(2023, 2, 10, 11, 17, 51, 392, DateTimeKind.Utc).AddTicks(9727) },
                    { 8, "Mastering Python", true, new DateTime(2024, 6, 24, 11, 17, 51, 392, DateTimeKind.Utc).AddTicks(9728) },
                    { 9, "CSS: The Definitive Guide", true, new DateTime(2024, 1, 26, 11, 17, 51, 392, DateTimeKind.Utc).AddTicks(9729) },
                    { 10, "HTML5 & CSS3", true, new DateTime(2023, 11, 17, 11, 17, 51, 392, DateTimeKind.Utc).AddTicks(9730) }
                });

            migrationBuilder.InsertData(
                table: "puanlar",
                columns: new[] { "Id", "KazanilanPuan", "PuanGunu", "UserId" },
                values: new object[,]
                {
                    { 1, 1000, new DateTime(2024, 10, 1, 11, 17, 51, 392, DateTimeKind.Utc).AddTicks(9917), 1 },
                    { 2, 500, new DateTime(2024, 9, 27, 11, 17, 51, 392, DateTimeKind.Utc).AddTicks(9918), 2 },
                    { 3, 2000, new DateTime(2024, 9, 22, 11, 17, 51, 392, DateTimeKind.Utc).AddTicks(9920), 3 },
                    { 4, 1500, new DateTime(2024, 9, 17, 11, 17, 51, 392, DateTimeKind.Utc).AddTicks(9921), 4 },
                    { 5, 800, new DateTime(2024, 9, 12, 11, 17, 51, 392, DateTimeKind.Utc).AddTicks(9922), 5 },
                    { 6, 1200, new DateTime(2024, 9, 7, 11, 17, 51, 392, DateTimeKind.Utc).AddTicks(9923), 6 },
                    { 7, 700, new DateTime(2024, 9, 2, 11, 17, 51, 392, DateTimeKind.Utc).AddTicks(9924), 7 },
                    { 8, 900, new DateTime(2024, 8, 28, 11, 17, 51, 392, DateTimeKind.Utc).AddTicks(9925), 8 },
                    { 9, 1600, new DateTime(2024, 8, 23, 11, 17, 51, 392, DateTimeKind.Utc).AddTicks(9926), 9 },
                    { 10, 1100, new DateTime(2024, 8, 18, 11, 17, 51, 392, DateTimeKind.Utc).AddTicks(9927), 10 }
                });

            migrationBuilder.InsertData(
                table: "roller",
                columns: new[] { "Id", "RolIsmi" },
                values: new object[,]
                {
                    { 1, "uye" },
                    { 2, "yazar" },
                    { 3, "gorevli" },
                    { 4, "yonetici" }
                });

            migrationBuilder.InsertData(
                table: "sayfalar",
                columns: new[] { "Id", "Icerik", "KitapId", "SayfaNo" },
                values: new object[,]
                {
                    { 1, "Introduction to Coding: Coding is the process of using a programming language to get a computer to behave how you want. In this chapter, we will cover the basics of what coding is and how it works.", 1, 1 },
                    { 2, "Coding Basics: Understanding syntax, variables, loops, and functions is essential in every programming language. We'll explore how these basic building blocks work in various coding languages.", 1, 2 },
                    { 3, "Advanced Coding Techniques: Once you grasp the basics, you can start using more advanced techniques like recursion, data structures, and algorithms to optimize your code.", 1, 3 },
                    { 4, "Debugging Tips: Debugging is a critical skill for every developer. This chapter focuses on tools and techniques for identifying and resolving issues in your code.", 1, 4 },
                    { 5, "Best Practices: Writing clean, efficient, and maintainable code is the hallmark of a skilled developer. We’ll explore best practices that will help you become a better programmer.", 1, 5 },
                    { 6, "Introduction to C#: C# is a modern, object-oriented programming language developed by Microsoft. In this chapter, we’ll cover the basics of the C# language and its history.", 2, 1 },
                    { 7, "Data Types: In C#, there are many different types of data such as int, string, and bool. This chapter explains the various data types available in C# and how to use them.", 2, 2 },
                    { 8, "Control Structures: Control structures help manage the flow of execution in your program. We will dive into if-else statements, loops, and switch cases in this chapter.", 2, 3 },
                    { 9, "Object-Oriented Programming: One of C#’s key strengths is its object-oriented nature. This chapter will teach you the principles of OOP such as inheritance, polymorphism, and encapsulation.", 2, 4 },
                    { 10, "Error Handling: Proper error handling is important to ensure the stability of your application. Learn how to use try-catch blocks and handle exceptions effectively.", 2, 5 },
                    { 11, "Web Development: This chapter introduces the key concepts of web development, including HTML, CSS, and JavaScript, which are the foundation of building websites.", 3, 1 },
                    { 12, "Front-End Frameworks: Explore the world of front-end development by learning about popular frameworks like React and Angular, and how they simplify web development.", 3, 2 },
                    { 13, "Back-End Development: Learn about server-side programming, database management, and APIs to build the back-end of a web application.", 3, 3 },
                    { 14, "Database Integration: This chapter focuses on how to integrate databases like SQL Server or MongoDB into your web applications.", 3, 4 },
                    { 15, "Deployment and Hosting: After building a web application, the final step is to deploy it. Learn about cloud services and how to host your application for the public.", 3, 5 },
                    { 16, "Python Basics: Python is a versatile language popular for both beginners and experts. In this chapter, we will introduce Python syntax and basic concepts.", 4, 1 },
                    { 17, "Data Structures in Python: Learn about lists, dictionaries, sets, and tuples, and how to use them effectively in your Python programs.", 4, 2 },
                    { 18, "File Handling in Python: Discover how to read from and write to files in Python, which is essential for many data processing tasks.", 4, 3 },
                    { 19, "Python Libraries: Python has a vast ecosystem of libraries such as NumPy, Pandas, and Matplotlib. Learn how to leverage these libraries in your projects.", 4, 4 },
                    { 20, "Web Scraping with Python: This chapter explores how to extract data from websites using popular libraries such as BeautifulSoup and Scrapy.", 4, 5 },
                    { 21, "Introduction to Algorithms: Algorithms are a set of rules to be followed in problem-solving operations. This chapter introduces basic algorithms and their use cases.", 5, 1 },
                    { 22, "Sorting Algorithms: Learn about various sorting algorithms such as Bubble Sort, Quick Sort, and Merge Sort, and their time complexities.", 5, 2 },
                    { 23, "Search Algorithms: Understand how to implement search algorithms like Binary Search and Linear Search for finding elements in data.", 5, 3 },
                    { 24, "Graph Algorithms: Explore algorithms related to graph data structures, such as Dijkstra’s algorithm and Depth-First Search.", 5, 4 },
                    { 25, "Dynamic Programming: Dynamic programming is an optimization technique used to solve complex problems by breaking them down into simpler subproblems.", 5, 5 },
                    { 26, "Introduction to Artificial Intelligence: AI is transforming the world. This chapter introduces the basics of AI and how machines learn from data.", 6, 1 },
                    { 27, "Machine Learning Fundamentals: Discover how machine learning models are created, trained, and used to predict outcomes.", 6, 2 },
                    { 28, "Neural Networks: Neural networks are the backbone of deep learning. Learn about how they function and why they're so powerful.", 6, 3 },
                    { 29, "Natural Language Processing: Explore how AI is used to process and understand human language, including applications like chatbots and translation services.", 6, 4 },
                    { 30, "AI Ethics: AI has profound societal implications. This chapter discusses the ethical considerations involved in creating and using AI technologies.", 6, 5 },
                    { 31, "Introduction to Cloud Computing: Cloud computing has revolutionized IT. This chapter introduces the key concepts of cloud platforms and services.", 7, 1 },
                    { 32, "AWS Fundamentals: Amazon Web Services (AWS) is one of the most popular cloud platforms. Learn about the core AWS services and their applications.", 7, 2 },
                    { 33, "Azure Overview: Microsoft Azure is another leading cloud platform. Discover its features and how it differs from AWS.", 7, 3 },
                    { 34, "Deploying Applications to the Cloud: This chapter covers the steps involved in deploying web applications to the cloud, ensuring scalability and reliability.", 7, 4 },
                    { 35, "Security in the Cloud: Cloud security is crucial. Learn about the key strategies for securing cloud-based applications and data.", 7, 5 },
                    { 36, "Data Science Overview: Data science is the process of deriving insights from data. This chapter introduces key data science concepts and techniques.", 8, 1 },
                    { 37, "Data Cleaning and Preparation: Learn the importance of cleaning and preparing data before analysis, and the tools used for this purpose.", 8, 2 },
                    { 38, "Exploratory Data Analysis: EDA helps uncover patterns and trends in data. This chapter covers the methods used for analyzing and visualizing data.", 8, 3 },
                    { 39, "Statistical Modeling: Understand how statistical models are created and used to make predictions based on data.", 8, 4 },
                    { 40, "Data Visualization: Effective data visualization helps communicate findings clearly. Learn about different techniques for visualizing data.", 8, 5 },
                    { 41, "Cybersecurity Basics: Cybersecurity is critical in today’s digital world. This chapter provides an introduction to the field of cybersecurity.", 9, 1 },
                    { 42, "Types of Cyber Attacks: Learn about common types of cyber attacks such as phishing, malware, and ransomware.", 9, 2 },
                    { 43, "Security Protocols: Security protocols like SSL/TLS and HTTPS are vital for protecting online communication. This chapter explains how these protocols work.", 9, 3 },
                    { 44, "Network Security: Explore how firewalls, intrusion detection systems, and VPNs are used to secure networks from cyber threats.", 9, 4 },
                    { 45, "Best Practices for Cybersecurity: Learn about the best practices that individuals and organizations can follow to ensure their systems remain secure.", 9, 5 },
                    { 46, "Introduction to Blockchain: Blockchain technology is transforming industries. This chapter explains how blockchain works and its key features.", 10, 1 },
                    { 47, "Cryptocurrency: Learn about the rise of cryptocurrencies like Bitcoin and Ethereum, and how they leverage blockchain technology.", 10, 2 },
                    { 48, "Smart Contracts: Discover how smart contracts are enabling new applications on blockchain platforms like Ethereum.", 10, 3 },
                    { 49, "Blockchain Use Cases: Explore real-world use cases of blockchain in industries such as finance, healthcare, and supply chain.", 10, 4 },
                    { 50, "Future of Blockchain: What does the future hold for blockchain? This chapter discusses emerging trends and challenges.", 10, 5 }
                });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "Id", "Email", "Isim", "Password", "RolId", "SoyIsim" },
                values: new object[,]
                {
                    { 1, "ahmet.yilmaz@example.com", "Ahmet", "$2a$11$U2Pl6W.DuVQ9RiUoA.KTGuiWAHZpSFA/HpQFUpVi4dGwfnhMY.lnq", 1, "Yılmaz" },
                    { 2, "mehmet.kaya@example.com", "Mehmet", "$2a$11$CYeDfDJOeLv5xUcD6LOmUef10VAGieYf8iUJayt9N72hCR6zeedke", 2, "Kaya" },
                    { 3, "ayse.demir@example.com", "Ayşe", "$2a$11$hmVhgJtFjzx97oO4FrVdDu06LygBGu7n7LWs9XeQIBfHbqZBMxNGW", 3, "Demir" },
                    { 4, "fatma.celik@example.com", "Fatma", "$2a$11$s/b74SPh6RVHD.vtozs/PeXtI2vCcoCGhmAyoUnhQMQtuBzdWOiQW", 4, "Çelik" },
                    { 5, "ali.ozturk@example.com", "Ali", "$2a$11$wJJoMYAq.2i8LnS8dBzzS.0MuExPmjs7re8XEseVWZthwE4kr15gK", 1, "Öztürk" },
                    { 6, "zeynep.aksoy@example.com", "Zeynep", "$2a$11$3aps3qrqCCv8/gu9Zw0CiON2PJ5LsdeU3RTr7FJFrKsUa3unx/sAq", 2, "Aksoy" },
                    { 7, "emre.guner@example.com", "Emre", "$2a$11$IJf1l9yOO5vBwDBkuEqR6.5tKU7.hL5jrFkLEWcEK/ZT4F54RL5hC", 3, "Güner" },
                    { 8, "elif.yilmaz@example.com", "Elif", "$2a$11$LB2Ux/aPyOQ86A3sTBob9OGTzrbSn41B4Se9hdl/eeBEmPAq4ELKK", 4, "Yılmaz" },
                    { 9, "cem.koc@example.com", "Cem", "$2a$11$Tz5AKBWqUuWTIJCPVc/cbuudN1DvnkfknbDYecrhy.vGgh9hJe.Qm", 1, "Koç" },
                    { 10, "merve.tan@example.com", "Merve", "$2a$11$SMDAsqBLEF5wT0jyqRbGYukbR9363NPkyB.lZWD3BR2lCFxUWyGnS", 2, "Tan" },
                    { 11, "yonetici@example.com", "Türker", "$2a$11$/2Vs5n77zw3P/e5SML/Mo.eTGdQs5Gi6zLqCNTAD6PbEH6KoOTOh2", 4, "Kıvılcım" },
                    { 12, "gorevli@example.com", "Melek", "$2a$11$oPKVHnehv9qCCjFpws/MfefF56scQLjBzrWtC16l38A0wlHy81fV.", 3, "Altun" },
                    { 13, "yazar@example.com", "Ebrar", "$2a$11$HylT7QzlgnevenX.p0eBpe2YLzoONE6VnE7PvaGvYAJqdZ5uysBKi", 2, "Saygılı" },
                    { 14, "uye@example.com", "Zehra", "$2a$11$1F2RV6hIBwijyO1TI3YDXe5yNOADmPK4.JoWkiwO/Of2TlJuucI9S", 1, "Akdemir" }
                });

            migrationBuilder.InsertData(
                table: "kitapOduncler",
                columns: new[] { "Id", "BeklemedeMi", "DondurulduMu", "DonusTarihi", "KitapId", "OnaylandiMi", "TalepTarihi", "UserId" },
                values: new object[,]
                {
                    { 1, false, false, new DateTime(2024, 10, 9, 11, 17, 51, 392, DateTimeKind.Utc).AddTicks(9753), 1, true, new DateTime(2024, 9, 25, 11, 17, 51, 392, DateTimeKind.Utc).AddTicks(9752), 2 },
                    { 2, false, false, new DateTime(2024, 10, 8, 11, 17, 51, 392, DateTimeKind.Utc).AddTicks(9755), 2, true, new DateTime(2024, 9, 24, 11, 17, 51, 392, DateTimeKind.Utc).AddTicks(9754), 3 },
                    { 3, false, false, new DateTime(2024, 10, 7, 11, 17, 51, 392, DateTimeKind.Utc).AddTicks(9757), 3, true, new DateTime(2024, 9, 23, 11, 17, 51, 392, DateTimeKind.Utc).AddTicks(9756), 4 },
                    { 4, false, false, new DateTime(2024, 10, 6, 11, 17, 51, 392, DateTimeKind.Utc).AddTicks(9759), 4, true, new DateTime(2024, 9, 22, 11, 17, 51, 392, DateTimeKind.Utc).AddTicks(9758), 5 },
                    { 5, false, false, new DateTime(2024, 10, 5, 11, 17, 51, 392, DateTimeKind.Utc).AddTicks(9760), 5, true, new DateTime(2024, 9, 21, 11, 17, 51, 392, DateTimeKind.Utc).AddTicks(9760), 6 },
                    { 6, false, false, new DateTime(2024, 10, 4, 11, 17, 51, 392, DateTimeKind.Utc).AddTicks(9762), 6, true, new DateTime(2024, 9, 20, 11, 17, 51, 392, DateTimeKind.Utc).AddTicks(9762), 7 },
                    { 7, false, false, new DateTime(2024, 10, 3, 11, 17, 51, 392, DateTimeKind.Utc).AddTicks(9764), 7, true, new DateTime(2024, 9, 19, 11, 17, 51, 392, DateTimeKind.Utc).AddTicks(9764), 8 },
                    { 8, false, false, new DateTime(2024, 10, 1, 11, 17, 51, 392, DateTimeKind.Utc).AddTicks(9766), 8, true, new DateTime(2024, 9, 18, 11, 17, 51, 392, DateTimeKind.Utc).AddTicks(9765), 9 },
                    { 9, false, false, new DateTime(2024, 9, 30, 11, 17, 51, 392, DateTimeKind.Utc).AddTicks(9767), 9, true, new DateTime(2024, 9, 17, 11, 17, 51, 392, DateTimeKind.Utc).AddTicks(9767), 10 },
                    { 10, false, false, new DateTime(2024, 9, 29, 11, 17, 51, 392, DateTimeKind.Utc).AddTicks(9769), 10, true, new DateTime(2024, 9, 16, 11, 17, 51, 392, DateTimeKind.Utc).AddTicks(9769), 11 }
                });

            migrationBuilder.InsertData(
                table: "kitapYayinTalepleri",
                columns: new[] { "Id", "BeklemedeMi", "KitapId", "OnaylandiMi", "TalepTarihi", "YazarId" },
                values: new object[,]
                {
                    { 1, false, 1, true, new DateTime(2024, 9, 29, 11, 17, 51, 392, DateTimeKind.Utc).AddTicks(9796), 1 },
                    { 2, false, 2, true, new DateTime(2024, 9, 24, 11, 17, 51, 392, DateTimeKind.Utc).AddTicks(9798), 2 },
                    { 3, false, 3, true, new DateTime(2024, 9, 22, 11, 17, 51, 392, DateTimeKind.Utc).AddTicks(9799), 3 },
                    { 4, false, 4, true, new DateTime(2024, 9, 20, 11, 17, 51, 392, DateTimeKind.Utc).AddTicks(9801), 4 },
                    { 5, true, 5, false, new DateTime(2024, 9, 17, 11, 17, 51, 392, DateTimeKind.Utc).AddTicks(9802), 5 },
                    { 6, false, 6, true, new DateTime(2024, 9, 14, 11, 17, 51, 392, DateTimeKind.Utc).AddTicks(9803), 6 },
                    { 7, false, 7, true, new DateTime(2024, 9, 12, 11, 17, 51, 392, DateTimeKind.Utc).AddTicks(9804), 7 },
                    { 8, true, 8, false, new DateTime(2024, 9, 10, 11, 17, 51, 392, DateTimeKind.Utc).AddTicks(9805), 8 },
                    { 9, false, 9, true, new DateTime(2024, 9, 7, 11, 17, 51, 392, DateTimeKind.Utc).AddTicks(9806), 9 },
                    { 10, true, 10, false, new DateTime(2024, 9, 4, 11, 17, 51, 392, DateTimeKind.Utc).AddTicks(9807), 10 }
                });

            migrationBuilder.InsertData(
                table: "kitapYazarlari",
                columns: new[] { "Id", "KitapId", "UserId" },
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
                table: "mesajlar",
                columns: new[] { "Id", "AlanId", "GonderenId", "Icerik", "Konu" },
                values: new object[,]
                {
                    { 1, 1, 2, "Merhaba!", "Tanışma" },
                    { 2, 3, 4, "Kitap öneriniz var mı?", "Öneri" },
                    { 3, 5, 6, "Teşekkür ederim!", "Teşekkür" },
                    { 4, 7, 8, "Görüşürüz.", "Veda" },
                    { 5, 9, 10, "Nasıl yardımcı olabilirim?", "Yardım" },
                    { 6, 2, 3, "Sorun nedir?", "Sorun" },
                    { 7, 4, 5, "Günaydın!", "Selamlaşma" },
                    { 8, 6, 7, "Neler yapıyorsun?", "Sohbet" },
                    { 9, 8, 9, "Kitap aldım.", "Bilgilendirme" },
                    { 10, 10, 11, "Yeni kitabım yayımlandı.", "Kitap Yayını" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_kitapOduncler_KitapId",
                table: "kitapOduncler",
                column: "KitapId");

            migrationBuilder.CreateIndex(
                name: "IX_kitapOduncler_UserId",
                table: "kitapOduncler",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_kitapYayinTalepleri_KitapId",
                table: "kitapYayinTalepleri",
                column: "KitapId");

            migrationBuilder.CreateIndex(
                name: "IX_kitapYayinTalepleri_YazarId",
                table: "kitapYayinTalepleri",
                column: "YazarId");

            migrationBuilder.CreateIndex(
                name: "IX_kitapYazarlari_KitapId",
                table: "kitapYazarlari",
                column: "KitapId");

            migrationBuilder.CreateIndex(
                name: "IX_kitapYazarlari_UserId",
                table: "kitapYazarlari",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_mesajlar_GonderenId",
                table: "mesajlar",
                column: "GonderenId");

            migrationBuilder.CreateIndex(
                name: "IX_sayfalar_KitapId",
                table: "sayfalar",
                column: "KitapId");

            migrationBuilder.CreateIndex(
                name: "IX_users_RolId",
                table: "users",
                column: "RolId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cezalar");

            migrationBuilder.DropTable(
                name: "hesapAcmaTalepleri");

            migrationBuilder.DropTable(
                name: "kitapOduncler");

            migrationBuilder.DropTable(
                name: "kitapYayinTalepleri");

            migrationBuilder.DropTable(
                name: "kitapYazarlari");

            migrationBuilder.DropTable(
                name: "mesajlar");

            migrationBuilder.DropTable(
                name: "puanlar");

            migrationBuilder.DropTable(
                name: "sayfalar");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "kitaplar");

            migrationBuilder.DropTable(
                name: "roller");
        }
    }
}
