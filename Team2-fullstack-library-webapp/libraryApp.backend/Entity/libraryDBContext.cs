using Microsoft.EntityFrameworkCore;
namespace libraryApp.backend.Entity;
public class libraryDBContext : DbContext
{
    public DbSet<ceza> cezalar => Set<ceza>();
    public DbSet<hesapAcmaTalebi> hesapAcmaTalepleri => Set<hesapAcmaTalebi>();
    public DbSet<kitap> kitaplar => Set<kitap>();
    public DbSet<kitapOdunc> kitapOduncler => Set<kitapOdunc>();
    public DbSet<kitapYayinTalebi> kitapYayinTalepleri => Set<kitapYayinTalebi>();
    public DbSet<kitapYazari> kitapYazarlari => Set<kitapYazari>();
    public DbSet<mesaj> mesajlar => Set<mesaj>();
    public DbSet<puan> puanlar => Set<puan>();
    public DbSet<rol> roller => Set<rol>();
    public DbSet<sayfa> sayfalar => Set<sayfa>();
    public DbSet<user> users => Set<user>();

    public libraryDBContext(DbContextOptions<libraryDBContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<ceza>().HasData(
     new ceza { Id = 1, UserId = 2, CezaGunu = DateTime.UtcNow.AddDays(-30), CezaBitisGunu = DateTime.UtcNow.AddDays(-20), CezaAktifMi = false },
     new ceza { Id = 2, UserId = 3, CezaGunu = DateTime.UtcNow.AddDays(-60), CezaBitisGunu = DateTime.UtcNow.AddDays(-50), CezaAktifMi = false },
     new ceza { Id = 3, UserId = 4, CezaGunu = DateTime.UtcNow.AddDays(-10), CezaBitisGunu = DateTime.UtcNow.AddDays(-5), CezaAktifMi = true },
     new ceza { Id = 4, UserId = 5, CezaGunu = DateTime.UtcNow.AddDays(-25), CezaBitisGunu = DateTime.UtcNow.AddDays(-15), CezaAktifMi = false },
     new ceza { Id = 5, UserId = 6, CezaGunu = DateTime.UtcNow.AddDays(-40), CezaBitisGunu = DateTime.UtcNow.AddDays(-30), CezaAktifMi = true },
     new ceza { Id = 6, UserId = 7, CezaGunu = DateTime.UtcNow.AddDays(-70), CezaBitisGunu = DateTime.UtcNow.AddDays(-60), CezaAktifMi = false },
     new ceza { Id = 7, UserId = 8, CezaGunu = DateTime.UtcNow.AddDays(-5), CezaBitisGunu = DateTime.UtcNow.AddDays(5), CezaAktifMi = true },
     new ceza { Id = 8, UserId = 9, CezaGunu = DateTime.UtcNow.AddDays(-100), CezaBitisGunu = DateTime.UtcNow.AddDays(-90), CezaAktifMi = false },
     new ceza { Id = 9, UserId = 10, CezaGunu = DateTime.UtcNow.AddDays(-20), CezaBitisGunu = DateTime.UtcNow.AddDays(-10), CezaAktifMi = true },
     new ceza { Id = 10, UserId = 11, CezaGunu = DateTime.UtcNow.AddDays(-35), CezaBitisGunu = DateTime.UtcNow.AddDays(-25), CezaAktifMi = false }
 );

        modelBuilder.Entity<hesapAcmaTalebi>().HasData(
            new hesapAcmaTalebi { Id = 1, UserId = 1, TalepTarihi = DateTime.UtcNow.AddDays(-5), OnaylandiMi = true, BeklemedeMi = false },
            new hesapAcmaTalebi { Id = 2, UserId = 2, TalepTarihi = DateTime.UtcNow.AddDays(-5), OnaylandiMi = true, BeklemedeMi = false },
            new hesapAcmaTalebi { Id = 3, UserId = 3, TalepTarihi = DateTime.UtcNow.AddDays(-5), OnaylandiMi = true, BeklemedeMi = false },
            new hesapAcmaTalebi { Id = 4, UserId = 4, TalepTarihi = DateTime.UtcNow.AddDays(-5), OnaylandiMi = true, BeklemedeMi = false },
            new hesapAcmaTalebi { Id = 5, UserId = 5, TalepTarihi = DateTime.UtcNow.AddDays(-10), OnaylandiMi = true, BeklemedeMi = false },
            new hesapAcmaTalebi { Id = 6, UserId = 6, TalepTarihi = DateTime.UtcNow.AddDays(-15), OnaylandiMi = true, BeklemedeMi = false },
            new hesapAcmaTalebi { Id = 7, UserId = 7, TalepTarihi = DateTime.UtcNow.AddDays(-20), OnaylandiMi = true, BeklemedeMi = false },
            new hesapAcmaTalebi { Id = 8, UserId = 8, TalepTarihi = DateTime.UtcNow.AddDays(-25), OnaylandiMi = true, BeklemedeMi = false },
            new hesapAcmaTalebi { Id = 9, UserId = 9, TalepTarihi = DateTime.UtcNow.AddDays(-30), OnaylandiMi = true, BeklemedeMi = false },
            new hesapAcmaTalebi { Id = 10, UserId = 10, TalepTarihi = DateTime.UtcNow.AddDays(-35), OnaylandiMi = true, BeklemedeMi = false },
            new hesapAcmaTalebi { Id = 11, UserId = 11, TalepTarihi = DateTime.UtcNow.AddDays(-40), OnaylandiMi = true, BeklemedeMi = false },
            new hesapAcmaTalebi { Id = 12, UserId = 12, TalepTarihi = DateTime.UtcNow.AddDays(-45), OnaylandiMi = true, BeklemedeMi = false },
            new hesapAcmaTalebi { Id = 13, UserId = 13, TalepTarihi = DateTime.UtcNow.AddDays(-50), OnaylandiMi = true, BeklemedeMi = false },
            new hesapAcmaTalebi { Id = 14, UserId = 14, TalepTarihi = DateTime.UtcNow.AddDays(-50), OnaylandiMi = true, BeklemedeMi = false }
        );

        modelBuilder.Entity<kitap>().HasData(
            new kitap { Id = 1, Isim = "The Art of Coding", KitapYayinlandiMi = true, YayinlanmaTarihi = DateTime.UtcNow.AddDays(-365) },
            new kitap { Id = 2, Isim = "Learning C#", KitapYayinlandiMi = true, YayinlanmaTarihi = DateTime.UtcNow.AddDays(-400) },
            new kitap { Id = 3, Isim = "Mastering ASP.NET", KitapYayinlandiMi = true, YayinlanmaTarihi = DateTime.UtcNow.AddDays(-500) },
            new kitap { Id = 4, Isim = "Entity Framework Core", KitapYayinlandiMi = true, YayinlanmaTarihi = DateTime.UtcNow.AddDays(-200) },
            new kitap { Id = 5, Isim = "React for Beginners", KitapYayinlandiMi = true, YayinlanmaTarihi = DateTime.UtcNow.AddDays(-300) },
            new kitap { Id = 6, Isim = "Advanced SQL", KitapYayinlandiMi = true, YayinlanmaTarihi = DateTime.UtcNow.AddDays(-150) },
            new kitap { Id = 7, Isim = "JavaScript in Depth", KitapYayinlandiMi = true, YayinlanmaTarihi = DateTime.UtcNow.AddDays(-600) },
            new kitap { Id = 8, Isim = "Mastering Python", KitapYayinlandiMi = true, YayinlanmaTarihi = DateTime.UtcNow.AddDays(-100) },
            new kitap { Id = 9, Isim = "CSS: The Definitive Guide", KitapYayinlandiMi = true, YayinlanmaTarihi = DateTime.UtcNow.AddDays(-250) },
            new kitap { Id = 10, Isim = "HTML5 & CSS3", KitapYayinlandiMi = true, YayinlanmaTarihi = DateTime.UtcNow.AddDays(-320) }
        );

        modelBuilder.Entity<kitapOdunc>().HasData(
            new kitapOdunc { Id = 1, KitapId = 1, UserId = 2, TalepTarihi = DateTime.UtcNow.AddDays(-7), DonusTarihi = DateTime.UtcNow.AddDays(7), OnaylandiMi = true, BeklemedeMi = false, DondurulduMu = false },
            new kitapOdunc { Id = 2, KitapId = 2, UserId = 3, TalepTarihi = DateTime.UtcNow.AddDays(-8), DonusTarihi = DateTime.UtcNow.AddDays(6), OnaylandiMi = true, BeklemedeMi = false, DondurulduMu = false },
            new kitapOdunc { Id = 3, KitapId = 3, UserId = 4, TalepTarihi = DateTime.UtcNow.AddDays(-9), DonusTarihi = DateTime.UtcNow.AddDays(5), OnaylandiMi = true, BeklemedeMi = false, DondurulduMu = false },
            new kitapOdunc { Id = 4, KitapId = 4, UserId = 5, TalepTarihi = DateTime.UtcNow.AddDays(-10), DonusTarihi = DateTime.UtcNow.AddDays(4), OnaylandiMi = true, BeklemedeMi = false, DondurulduMu = false },
            new kitapOdunc { Id = 5, KitapId = 5, UserId = 6, TalepTarihi = DateTime.UtcNow.AddDays(-11), DonusTarihi = DateTime.UtcNow.AddDays(3), OnaylandiMi = true, BeklemedeMi = false, DondurulduMu = false },
            new kitapOdunc { Id = 6, KitapId = 6, UserId = 7, TalepTarihi = DateTime.UtcNow.AddDays(-12), DonusTarihi = DateTime.UtcNow.AddDays(2), OnaylandiMi = true, BeklemedeMi = false, DondurulduMu = false },
            new kitapOdunc { Id = 7, KitapId = 7, UserId = 8, TalepTarihi = DateTime.UtcNow.AddDays(-13), DonusTarihi = DateTime.UtcNow.AddDays(1), OnaylandiMi = true, BeklemedeMi = false, DondurulduMu = false },
            new kitapOdunc { Id = 8, KitapId = 8, UserId = 9, TalepTarihi = DateTime.UtcNow.AddDays(-14), DonusTarihi = DateTime.UtcNow.AddDays(-1), OnaylandiMi = true, BeklemedeMi = false, DondurulduMu = false },
            new kitapOdunc { Id = 9, KitapId = 9, UserId = 10, TalepTarihi = DateTime.UtcNow.AddDays(-15), DonusTarihi = DateTime.UtcNow.AddDays(-2), OnaylandiMi = true, BeklemedeMi = false, DondurulduMu = false },
            new kitapOdunc { Id = 10, KitapId = 10, UserId = 11, TalepTarihi = DateTime.UtcNow.AddDays(-16), DonusTarihi = DateTime.UtcNow.AddDays(-3), OnaylandiMi = true, BeklemedeMi = false, DondurulduMu = false }
        );

        modelBuilder.Entity<kitapYayinTalebi>().HasData(
            new kitapYayinTalebi { Id = 1, KitapId = 1, YazarId = 1, TalepTarihi = DateTime.UtcNow.AddDays(-3), OnaylandiMi = true, BeklemedeMi = false },
            new kitapYayinTalebi { Id = 2, KitapId = 2, YazarId = 2, TalepTarihi = DateTime.UtcNow.AddDays(-8), OnaylandiMi = true, BeklemedeMi = false },
            new kitapYayinTalebi { Id = 3, KitapId = 3, YazarId = 3, TalepTarihi = DateTime.UtcNow.AddDays(-10), OnaylandiMi = true, BeklemedeMi = false },
            new kitapYayinTalebi { Id = 4, KitapId = 4, YazarId = 4, TalepTarihi = DateTime.UtcNow.AddDays(-12), OnaylandiMi = true, BeklemedeMi = false },
            new kitapYayinTalebi { Id = 5, KitapId = 5, YazarId = 5, TalepTarihi = DateTime.UtcNow.AddDays(-15), OnaylandiMi = false, BeklemedeMi = true },
            new kitapYayinTalebi { Id = 6, KitapId = 6, YazarId = 6, TalepTarihi = DateTime.UtcNow.AddDays(-18), OnaylandiMi = true, BeklemedeMi = false },
            new kitapYayinTalebi { Id = 7, KitapId = 7, YazarId = 7, TalepTarihi = DateTime.UtcNow.AddDays(-20), OnaylandiMi = true, BeklemedeMi = false },
            new kitapYayinTalebi { Id = 8, KitapId = 8, YazarId = 8, TalepTarihi = DateTime.UtcNow.AddDays(-22), OnaylandiMi = false, BeklemedeMi = true },
            new kitapYayinTalebi { Id = 9, KitapId = 9, YazarId = 9, TalepTarihi = DateTime.UtcNow.AddDays(-25), OnaylandiMi = true, BeklemedeMi = false },
            new kitapYayinTalebi { Id = 10, KitapId = 10, YazarId = 10, TalepTarihi = DateTime.UtcNow.AddDays(-28), OnaylandiMi = false, BeklemedeMi = true }
        );

        modelBuilder.Entity<kitapYazari>().HasData(
            new kitapYazari { Id = 1, KitapId = 1, UserId = 1 },
            new kitapYazari { Id = 2, KitapId = 2, UserId = 2 },
            new kitapYazari { Id = 3, KitapId = 3, UserId = 3 },
            new kitapYazari { Id = 4, KitapId = 4, UserId = 4 },
            new kitapYazari { Id = 5, KitapId = 5, UserId = 5 },
            new kitapYazari { Id = 6, KitapId = 6, UserId = 6 },
            new kitapYazari { Id = 7, KitapId = 7, UserId = 7 },
            new kitapYazari { Id = 8, KitapId = 8, UserId = 8 },
            new kitapYazari { Id = 9, KitapId = 9, UserId = 9 },
            new kitapYazari { Id = 10, KitapId = 10, UserId = 10 }
        );

        modelBuilder.Entity<mesaj>().HasData(
            new mesaj { Id = 1, AlanId = 1, GonderenId = 2, Icerik = "Merhaba!", Konu = "Tanışma" },
            new mesaj { Id = 2, AlanId = 3, GonderenId = 4, Icerik = "Kitap öneriniz var mı?", Konu = "Öneri" },
            new mesaj { Id = 3, AlanId = 5, GonderenId = 6, Icerik = "Teşekkür ederim!", Konu = "Teşekkür" },
            new mesaj { Id = 4, AlanId = 7, GonderenId = 8, Icerik = "Görüşürüz.", Konu = "Veda" },
            new mesaj { Id = 5, AlanId = 9, GonderenId = 10, Icerik = "Nasıl yardımcı olabilirim?", Konu = "Yardım" },
            new mesaj { Id = 6, AlanId = 2, GonderenId = 3, Icerik = "Sorun nedir?", Konu = "Sorun" },
            new mesaj { Id = 7, AlanId = 4, GonderenId = 5, Icerik = "Günaydın!", Konu = "Selamlaşma" },
            new mesaj { Id = 8, AlanId = 6, GonderenId = 7, Icerik = "Neler yapıyorsun?", Konu = "Sohbet" },
            new mesaj { Id = 9, AlanId = 8, GonderenId = 9, Icerik = "Kitap aldım.", Konu = "Bilgilendirme" },
            new mesaj { Id = 10, AlanId = 10, GonderenId = 11, Icerik = "Yeni kitabım yayımlandı.", Konu = "Kitap Yayını" }
        );

        modelBuilder.Entity<puan>().HasData(
            new puan { Id = 1, KazanilanPuan = 1000, PuanGunu = DateTime.UtcNow.AddDays(-1), UserId = 1 },
            new puan { Id = 2, KazanilanPuan = 500, PuanGunu = DateTime.UtcNow.AddDays(-5), UserId = 2 },
            new puan { Id = 3, KazanilanPuan = 2000, PuanGunu = DateTime.UtcNow.AddDays(-10), UserId = 3 },
            new puan { Id = 4, KazanilanPuan = 1500, PuanGunu = DateTime.UtcNow.AddDays(-15), UserId = 4 },
            new puan { Id = 5, KazanilanPuan = 800, PuanGunu = DateTime.UtcNow.AddDays(-20), UserId = 5 },
            new puan { Id = 6, KazanilanPuan = 1200, PuanGunu = DateTime.UtcNow.AddDays(-25), UserId = 6 },
            new puan { Id = 7, KazanilanPuan = 700, PuanGunu = DateTime.UtcNow.AddDays(-30), UserId = 7 },
            new puan { Id = 8, KazanilanPuan = 900, PuanGunu = DateTime.UtcNow.AddDays(-35), UserId = 8 },
            new puan { Id = 9, KazanilanPuan = 1600, PuanGunu = DateTime.UtcNow.AddDays(-40), UserId = 9 },
            new puan { Id = 10, KazanilanPuan = 1100, PuanGunu = DateTime.UtcNow.AddDays(-45), UserId = 10 }
        );

        modelBuilder.Entity<sayfa>().HasData(
     // Pages for KitapId = 1
     new sayfa { Id = 1, Icerik = "Introduction to Coding Coding is the process of using a programming language to get a computer to behave how you want. In this chapter, we will cover the basics of what coding is and how it works.", SayfaNo = 1, KitapId = 1 },
     new sayfa { Id = 2, Icerik = "Coding Basics: Understanding syntax, variables, loops, and functions is essential in every programming language. We'll explore how these basic building blocks work in various coding languages.", SayfaNo = 2, KitapId = 1 },
     new sayfa { Id = 3, Icerik = "Advanced Coding Techniques: Once you grasp the basics, you can start using more advanced techniques like recursion, data structures, and algorithms to optimize your code.", SayfaNo = 3, KitapId = 1 },
     new sayfa { Id = 4, Icerik = "Debugging Tips: Debugging is a critical skill for every developer. This chapter focuses on tools and techniques for identifying and resolving issues in your code.", SayfaNo = 4, KitapId = 1 },
     new sayfa { Id = 5, Icerik = "Best Practices: Writing clean, efficient, and maintainable code is the hallmark of a skilled developer. We’ll explore best practices that will help you become a better programmer.", SayfaNo = 5, KitapId = 1 },

     // Pages for KitapId = 2
     new sayfa { Id = 6, Icerik = "Introduction to C#: C# is a modern, object-oriented programming language developed by Microsoft. In this chapter, we’ll cover the basics of the C# language and its history.", SayfaNo = 1, KitapId = 2 },
     new sayfa { Id = 7, Icerik = "Data Types: In C#, there are many different types of data such as int, string, and bool. This chapter explains the various data types available in C# and how to use them.", SayfaNo = 2, KitapId = 2 },
     new sayfa { Id = 8, Icerik = "Control Structures: Control structures help manage the flow of execution in your program. We will dive into if-else statements, loops, and switch cases in this chapter.", SayfaNo = 3, KitapId = 2 },
     new sayfa { Id = 9, Icerik = "Object-Oriented Programming: One of C#’s key strengths is its object-oriented nature. This chapter will teach you the principles of OOP such as inheritance, polymorphism, and encapsulation.", SayfaNo = 4, KitapId = 2 },
     new sayfa { Id = 10, Icerik = "Error Handling: Proper error handling is important to ensure the stability of your application. Learn how to use try-catch blocks and handle exceptions effectively.", SayfaNo = 5, KitapId = 2 },

     // Pages for KitapId = 3
     new sayfa { Id = 11, Icerik = "Web Development: This chapter introduces the key concepts of web development, including HTML, CSS, and JavaScript, which are the foundation of building websites.", SayfaNo = 1, KitapId = 3 },
     new sayfa { Id = 12, Icerik = "Front-End Frameworks: Explore the world of front-end development by learning about popular frameworks like React and Angular, and how they simplify web development.", SayfaNo = 2, KitapId = 3 },
     new sayfa { Id = 13, Icerik = "Back-End Development: Learn about server-side programming, database management, and APIs to build the back-end of a web application.", SayfaNo = 3, KitapId = 3 },
     new sayfa { Id = 14, Icerik = "Database Integration: This chapter focuses on how to integrate databases like SQL Server or MongoDB into your web applications.", SayfaNo = 4, KitapId = 3 },
     new sayfa { Id = 15, Icerik = "Deployment and Hosting: After building a web application, the final step is to deploy it. Learn about cloud services and how to host your application for the public.", SayfaNo = 5, KitapId = 3 },

     // Pages for KitapId = 4
     new sayfa { Id = 16, Icerik = "Python Basics: Python is a versatile language popular for both beginners and experts. In this chapter, we will introduce Python syntax and basic concepts.", SayfaNo = 1, KitapId = 4 },
     new sayfa { Id = 17, Icerik = "Data Structures in Python: Learn about lists, dictionaries, sets, and tuples, and how to use them effectively in your Python programs.", SayfaNo = 2, KitapId = 4 },
     new sayfa { Id = 18, Icerik = "File Handling in Python: Discover how to read from and write to files in Python, which is essential for many data processing tasks.", SayfaNo = 3, KitapId = 4 },
     new sayfa { Id = 19, Icerik = "Python Libraries: Python has a vast ecosystem of libraries such as NumPy, Pandas, and Matplotlib. Learn how to leverage these libraries in your projects.", SayfaNo = 4, KitapId = 4 },
     new sayfa { Id = 20, Icerik = "Web Scraping with Python: This chapter explores how to extract data from websites using popular libraries such as BeautifulSoup and Scrapy.", SayfaNo = 5, KitapId = 4 },

     // Pages for KitapId = 5
     new sayfa { Id = 21, Icerik = "Introduction to Algorithms: Algorithms are a set of rules to be followed in problem-solving operations. This chapter introduces basic algorithms and their use cases.", SayfaNo = 1, KitapId = 5 },
     new sayfa { Id = 22, Icerik = "Sorting Algorithms: Learn about various sorting algorithms such as Bubble Sort, Quick Sort, and Merge Sort, and their time complexities.", SayfaNo = 2, KitapId = 5 },
     new sayfa { Id = 23, Icerik = "Search Algorithms: Understand how to implement search algorithms like Binary Search and Linear Search for finding elements in data.", SayfaNo = 3, KitapId = 5 },
     new sayfa { Id = 24, Icerik = "Graph Algorithms: Explore algorithms related to graph data structures, such as Dijkstra’s algorithm and Depth-First Search.", SayfaNo = 4, KitapId = 5 },
     new sayfa { Id = 25, Icerik = "Dynamic Programming: Dynamic programming is an optimization technique used to solve complex problems by breaking them down into simpler subproblems.", SayfaNo = 5, KitapId = 5 },

      // Pages for KitapId = 6
    new sayfa { Id = 26, Icerik = "Introduction to Artificial Intelligence: AI is transforming the world. This chapter introduces the basics of AI and how machines learn from data.", SayfaNo = 1, KitapId = 6 },
    new sayfa { Id = 27, Icerik = "Machine Learning Fundamentals: Discover how machine learning models are created, trained, and used to predict outcomes.", SayfaNo = 2, KitapId = 6 },
    new sayfa { Id = 28, Icerik = "Neural Networks: Neural networks are the backbone of deep learning. Learn about how they function and why they're so powerful.", SayfaNo = 3, KitapId = 6 },
    new sayfa { Id = 29, Icerik = "Natural Language Processing: Explore how AI is used to process and understand human language, including applications like chatbots and translation services.", SayfaNo = 4, KitapId = 6 },
    new sayfa { Id = 30, Icerik = "AI Ethics: AI has profound societal implications. This chapter discusses the ethical considerations involved in creating and using AI technologies.", SayfaNo = 5, KitapId = 6 },

    // Pages for KitapId = 7
    new sayfa { Id = 31, Icerik = "Introduction to Cloud Computing: Cloud computing has revolutionized IT. This chapter introduces the key concepts of cloud platforms and services.", SayfaNo = 1, KitapId = 7 },
    new sayfa { Id = 32, Icerik = "AWS Fundamentals: Amazon Web Services (AWS) is one of the most popular cloud platforms. Learn about the core AWS services and their applications.", SayfaNo = 2, KitapId = 7 },
    new sayfa { Id = 33, Icerik = "Azure Overview: Microsoft Azure is another leading cloud platform. Discover its features and how it differs from AWS.", SayfaNo = 3, KitapId = 7 },
    new sayfa { Id = 34, Icerik = "Deploying Applications to the Cloud: This chapter covers the steps involved in deploying web applications to the cloud, ensuring scalability and reliability.", SayfaNo = 4, KitapId = 7 },
    new sayfa { Id = 35, Icerik = "Security in the Cloud: Cloud security is crucial. Learn about the key strategies for securing cloud-based applications and data.", SayfaNo = 5, KitapId = 7 },

    // Pages for KitapId = 8
    new sayfa { Id = 36, Icerik = "Data Science Overview: Data science is the process of deriving insights from data. This chapter introduces key data science concepts and techniques.", SayfaNo = 1, KitapId = 8 },
    new sayfa { Id = 37, Icerik = "Data Cleaning and Preparation: Learn the importance of cleaning and preparing data before analysis, and the tools used for this purpose.", SayfaNo = 2, KitapId = 8 },
    new sayfa { Id = 38, Icerik = "Exploratory Data Analysis: EDA helps uncover patterns and trends in data. This chapter covers the methods used for analyzing and visualizing data.", SayfaNo = 3, KitapId = 8 },
    new sayfa { Id = 39, Icerik = "Statistical Modeling: Understand how statistical models are created and used to make predictions based on data.", SayfaNo = 4, KitapId = 8 },
    new sayfa { Id = 40, Icerik = "Data Visualization: Effective data visualization helps communicate findings clearly. Learn about different techniques for visualizing data.", SayfaNo = 5, KitapId = 8 },

    // Pages for KitapId = 9
    new sayfa { Id = 41, Icerik = "Cybersecurity Basics: Cybersecurity is critical in today’s digital world. This chapter provides an introduction to the field of cybersecurity.", SayfaNo = 1, KitapId = 9 },
    new sayfa { Id = 42, Icerik = "Types of Cyber Attacks: Learn about common types of cyber attacks such as phishing, malware, and ransomware.", SayfaNo = 2, KitapId = 9 },
    new sayfa { Id = 43, Icerik = "Security Protocols: Security protocols like SSL/TLS and HTTPS are vital for protecting online communication. This chapter explains how these protocols work.", SayfaNo = 3, KitapId = 9 },
    new sayfa { Id = 44, Icerik = "Network Security: Explore how firewalls, intrusion detection systems, and VPNs are used to secure networks from cyber threats.", SayfaNo = 4, KitapId = 9 },
    new sayfa { Id = 45, Icerik = "Best Practices for Cybersecurity: Learn about the best practices that individuals and organizations can follow to ensure their systems remain secure.", SayfaNo = 5, KitapId = 9 },

    // Pages for KitapId = 10
    new sayfa { Id = 46, Icerik = "Introduction to Blockchain: Blockchain technology is transforming industries. This chapter explains how blockchain works and its key features.", SayfaNo = 1, KitapId = 10 },
    new sayfa { Id = 47, Icerik = "Cryptocurrency: Learn about the rise of cryptocurrencies like Bitcoin and Ethereum, and how they leverage blockchain technology.", SayfaNo = 2, KitapId = 10 },
    new sayfa { Id = 48, Icerik = "Smart Contracts: Discover how smart contracts are enabling new applications on blockchain platforms like Ethereum.", SayfaNo = 3, KitapId = 10 },
    new sayfa { Id = 49, Icerik = "Blockchain Use Cases: Explore real-world use cases of blockchain in industries such as finance, healthcare, and supply chain.", SayfaNo = 4, KitapId = 10 },
    new sayfa { Id = 50, Icerik = "Future of Blockchain: What does the future hold for blockchain? This chapter discusses emerging trends and challenges.", SayfaNo = 5, KitapId = 10 }
 );

        modelBuilder.Entity<user>().HasData(
            new user { Id = 1, Isim = "Ahmet", SoyIsim = "Yılmaz", Email = "ahmet.yilmaz@example.com", Password = BCrypt.Net.BCrypt.HashPassword("123"), RolId = 1 },
            new user { Id = 2, Isim = "Mehmet", SoyIsim = "Kaya", Email = "mehmet.kaya@example.com", Password = BCrypt.Net.BCrypt.HashPassword("123"), RolId = 2 },
            new user { Id = 3, Isim = "Ayşe", SoyIsim = "Demir", Email = "ayse.demir@example.com", Password = BCrypt.Net.BCrypt.HashPassword("123"), RolId = 3 },
            new user { Id = 4, Isim = "Fatma", SoyIsim = "Çelik", Email = "fatma.celik@example.com", Password = BCrypt.Net.BCrypt.HashPassword("123"), RolId = 4 },
            new user { Id = 5, Isim = "Ali", SoyIsim = "Öztürk", Email = "ali.ozturk@example.com", Password = BCrypt.Net.BCrypt.HashPassword("123"), RolId = 1 },
            new user { Id = 6, Isim = "Zeynep", SoyIsim = "Aksoy", Email = "zeynep.aksoy@example.com", Password = BCrypt.Net.BCrypt.HashPassword("123"), RolId = 2 },
            new user { Id = 7, Isim = "Emre", SoyIsim = "Güner", Email = "emre.guner@example.com", Password = BCrypt.Net.BCrypt.HashPassword("123"), RolId = 3 },
            new user { Id = 8, Isim = "Elif", SoyIsim = "Yılmaz", Email = "elif.yilmaz@example.com", Password = BCrypt.Net.BCrypt.HashPassword("123"), RolId = 4 },
            new user { Id = 9, Isim = "Cem", SoyIsim = "Koç", Email = "cem.koc@example.com", Password = BCrypt.Net.BCrypt.HashPassword("123"), RolId = 1 },
            new user { Id = 10, Isim = "Merve", SoyIsim = "Tan", Email = "merve.tan@example.com", Password = BCrypt.Net.BCrypt.HashPassword("123"), RolId = 2 },

            new user { Id = 11, Isim = "Türker", SoyIsim = "Kıvılcım", Email = "yonetici@example.com", Password = BCrypt.Net.BCrypt.HashPassword("123"), RolId = 4 },
            new user { Id = 12, Isim = "Melek", SoyIsim = "Altun", Email = "gorevli@example.com", Password = BCrypt.Net.BCrypt.HashPassword("123"), RolId = 3 },
            new user { Id = 13, Isim = "Ebrar", SoyIsim = "Saygılı", Email = "yazar@example.com", Password = BCrypt.Net.BCrypt.HashPassword("123"), RolId = 2 },
            new user { Id = 14, Isim = "Zehra", SoyIsim = "Akdemir", Email = "uye@example.com", Password = BCrypt.Net.BCrypt.HashPassword("123"), RolId = 1 }
        );

        modelBuilder.Entity<rol>().HasData(
            new rol { Id = 1, RolIsmi = "uye" },
            new rol { Id = 2, RolIsmi = "yazar" },
            new rol { Id = 3, RolIsmi = "gorevli" },
            new rol { Id = 4, RolIsmi = "yonetici" }
        );

    }
}