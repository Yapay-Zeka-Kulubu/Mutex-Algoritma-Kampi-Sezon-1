using Microsoft.EntityFrameworkCore;

namespace LibraryApp.Data.Entity
{
    public class LibraryDbContext : DbContext
    {
        public DbSet<Book> Books => Set<Book>();
        public DbSet<BookAuthor> BookAuthors => Set<BookAuthor>();
        public DbSet<BookBorrowActivity> BookBorrowActivities => Set<BookBorrowActivity>();
        public DbSet<Page> Pages => Set<Page>();
        public DbSet<Role> Roles => Set<Role>();
        public DbSet<User> Users => Set<User>();
        public DbSet<Message> Messages => Set<Message>();
        public DbSet<BookPublishRequest> BookPublishRequests => Set<BookPublishRequest>();

        public LibraryDbContext(DbContextOptions<LibraryDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
            .HasIndex(u => u.Username)
            .IsUnique();

            modelBuilder.Entity<Book>().HasData(
                new Book { Id = 1, Title = "To Kill a Mockingbird", PublishDate = DateTime.UtcNow.AddDays(-400), IsBorrowed = false, IsPublished = true },
        new Book { Id = 2, Title = "1984", PublishDate = DateTime.UtcNow.AddDays(-350), IsBorrowed = false, IsPublished = true },
        new Book { Id = 3, Title = "The Great Gatsby", PublishDate = DateTime.UtcNow.AddDays(-300), IsBorrowed = false, IsPublished = true },
        new Book { Id = 4, Title = "The Catcher in the Rye", PublishDate = DateTime.UtcNow.AddDays(-250), IsBorrowed = false, IsPublished = true },
        new Book { Id = 5, Title = "Moby-Dick", PublishDate = DateTime.UtcNow.AddDays(-200), IsBorrowed = false, IsPublished = true },
        new Book { Id = 6, Title = "Pride and Prejudice", PublishDate = DateTime.UtcNow.AddDays(-150), IsBorrowed = false, IsPublished = true },
        new Book { Id = 7, Title = "The Lord of the Rings", PublishDate = DateTime.UtcNow.AddDays(-100), IsBorrowed = false, IsPublished = true },
        new Book { Id = 8, Title = "Jane Eyre", PublishDate = DateTime.UtcNow.AddDays(-90), IsBorrowed = false, IsPublished = true },
        new Book { Id = 9, Title = "Brave New World", PublishDate = DateTime.UtcNow.AddDays(-80), IsBorrowed = false, IsPublished = true },
        new Book { Id = 10, Title = "The Hobbit", PublishDate = DateTime.UtcNow.AddDays(-70), IsBorrowed = false, IsPublished = true },
        new Book { Id = 11, Title = "Wuthering Heights", PublishDate = DateTime.UtcNow.AddDays(-60), IsBorrowed = false, IsPublished = true },
        new Book { Id = 12, Title = "Fahrenheit 451", PublishDate = DateTime.UtcNow.AddDays(-50), IsBorrowed = false, IsPublished = true },
        new Book { Id = 13, Title = "The Chronicles of Narnia", PublishDate = DateTime.UtcNow.AddDays(-40), IsBorrowed = false, IsPublished = true },
        new Book { Id = 14, Title = "Little Women", PublishDate = DateTime.UtcNow.AddDays(-30), IsBorrowed = false, IsPublished = true },
        new Book { Id = 15, Title = "The Picture of Dorian Gray", PublishDate = DateTime.UtcNow.AddDays(-20), IsBorrowed = false, IsPublished = true }
            );

            modelBuilder.Entity<BookAuthor>().HasData(
                new BookAuthor { Id = 1, BookId = 1, UserId = 3 },
        new BookAuthor { Id = 2, BookId = 2, UserId = 8 },
        new BookAuthor { Id = 3, BookId = 3, UserId = 3 },
        new BookAuthor { Id = 4, BookId = 4, UserId = 8 },
        new BookAuthor { Id = 5, BookId = 5, UserId = 3 },
        new BookAuthor { Id = 6, BookId = 6, UserId = 8 },
        new BookAuthor { Id = 7, BookId = 7, UserId = 3 },
        new BookAuthor { Id = 8, BookId = 8, UserId = 8 },
        new BookAuthor { Id = 9, BookId = 9, UserId = 3 },
        new BookAuthor { Id = 10, BookId = 10, UserId = 8 },
        new BookAuthor { Id = 11, BookId = 11, UserId = 3 },
        new BookAuthor { Id = 12, BookId = 12, UserId = 8 },
        new BookAuthor { Id = 13, BookId = 13, UserId = 3 },
        new BookAuthor { Id = 14, BookId = 14, UserId = 8 },
        new BookAuthor { Id = 15, BookId = 15, UserId = 3 }
            );

            modelBuilder.Entity<BookBorrowActivity>().HasData(
            );

            modelBuilder.Entity<Page>().HasData(
                new Page { Id = 1, BookId = 1, Content = "In a land of fantasy, an unexpected hero emerged from the ordinary. The journey began with a single step into the unknown, leading to adventures beyond imagination.", PageNumber = 1 },
        new Page { Id = 2, BookId = 1, Content = "The hero faced trials that tested their courage and wisdom. Each challenge revealed hidden strengths and forged bonds that would be crucial in the trials ahead.", PageNumber = 2 },
        new Page { Id = 3, BookId = 1, Content = "As the hero ventured deeper into uncharted territories, they uncovered secrets long buried and faced adversaries that sought to thwart their quest.", PageNumber = 3 },
        new Page { Id = 4, BookId = 1, Content = "In the end, the hero's journey culminated in a revelation that changed their world forever, proving that even the smallest steps can lead to the grandest adventures.", PageNumber = 4 },

        new Page { Id = 5, BookId = 2, Content = "In the bustling city, a lone inventor labored in secrecy, crafting designs that promised to revolutionize the world. Their work went unnoticed until a pivotal encounter changed everything.", PageNumber = 1 },
        new Page { Id = 6, BookId = 2, Content = "The inventor's designs were met with skepticism, but perseverance led to breakthroughs that captured the attention of influential figures, setting the stage for a transformative era.", PageNumber = 2 },
        new Page { Id = 7, BookId = 2, Content = "Collaborations with renowned scientists led to the development of groundbreaking technologies, shifting the dynamics of the city and bringing the inventor’s dreams to fruition.", PageNumber = 3 },
        new Page { Id = 8, BookId = 2, Content = "The city, now a beacon of innovation, celebrated the inventor's contributions. Their legacy was cemented as a pioneer in a new age of technological advancement.", PageNumber = 4 },

        new Page { Id = 9, BookId = 3, Content = "Deep within a secluded forest, a hidden realm thrived in harmony. The forest's peace was disrupted by foreboding signs, hinting at challenges that lay ahead.", PageNumber = 1 },
        new Page { Id = 10, BookId = 3, Content = "A young guardian was chosen to protect the sanctuary. Their journey began with ancient rituals and encounters that revealed the weight of their new responsibilities.", PageNumber = 2 },
        new Page { Id = 11, BookId = 3, Content = "As the guardian traveled beyond the forest, they encountered allies and enemies, each revealing more about the prophecy and the role they were destined to play.", PageNumber = 3 },
        new Page { Id = 12, BookId = 3, Content = "The culmination of their quest brought forth a revelation that not only affected the sanctuary but also bridged the gap between the hidden realm and the outside world.", PageNumber = 4 },

        new Page { Id = 13, BookId = 4, Content = "In a small village, a young girl discovered an ancient artifact that set her on a path to uncover secrets long forgotten. Her adventure was just beginning.", PageNumber = 1 },
        new Page { Id = 14, BookId = 4, Content = "The artifact led her to distant lands and mysterious allies, each piece of the puzzle revealing more about the ancient prophecy and her role in it.", PageNumber = 2 },
        new Page { Id = 15, BookId = 4, Content = "Along the way, she faced trials that tested her resolve and discovered hidden strengths within herself. Each challenge brought her closer to the ultimate truth.", PageNumber = 3 },
        new Page { Id = 16, BookId = 4, Content = "The journey concluded with a revelation that changed her world, showing that the path of destiny is often forged through courage and perseverance.", PageNumber = 4 },

        new Page { Id = 17, BookId = 5, Content = "In a futuristic society, a rogue scientist defied the norms to pursue a groundbreaking experiment. The risks were high, but the potential rewards were even greater.", PageNumber = 1 },
        new Page { Id = 18, BookId = 5, Content = "The scientist's experiment faced numerous obstacles, from technical failures to opposition from authorities. Each challenge tested their determination and ingenuity.", PageNumber = 2 },
        new Page { Id = 19, BookId = 5, Content = "Despite the setbacks, the scientist made significant progress. Their work began to attract attention and eventually changed the course of their society's future.", PageNumber = 3 },
        new Page { Id = 20, BookId = 5, Content = "The experiment's success marked a new era of innovation and possibilities, proving that courage in the face of adversity can lead to transformative change.", PageNumber = 4 },

        new Page { Id = 21, BookId = 6, Content = "On a distant planet, a team of explorers embarked on a mission to uncover the secrets of an ancient civilization. Their journey was filled with wonder and danger.", PageNumber = 1 },
        new Page { Id = 22, BookId = 6, Content = "As they delved deeper into the ruins, they encountered relics and puzzles that hinted at the civilization's advanced knowledge and mysterious disappearance.", PageNumber = 2 },
        new Page { Id = 23, BookId = 6, Content = "The explorers faced perilous challenges, including natural hazards and unexpected encounters. Each discovery brought them closer to understanding the planet's enigmatic past.", PageNumber = 3 },
        new Page { Id = 24, BookId = 6, Content = "The mission's conclusion revealed profound truths about the civilization and the planet, marking a significant achievement in the history of exploration.", PageNumber = 4 },

        new Page { Id = 25, BookId = 7, Content = "In a dystopian world, a young rebel fought against a corrupt regime. Their struggle was a beacon of hope for a society yearning for change.", PageNumber = 1 },
        new Page { Id = 26, BookId = 7, Content = "The rebel's journey was fraught with danger and sacrifice. Allies were few, and enemies were many, but their resolve remained unshaken.", PageNumber = 2 },
        new Page { Id = 27, BookId = 7, Content = "Amidst the turmoil, the rebel uncovered secrets that could alter the balance of power. Their actions inspired a movement that spread across the land.", PageNumber = 3 },
        new Page { Id = 28, BookId = 7, Content = "The rebel's legacy was one of courage and resilience. Their fight against tyranny became a symbol of hope for future generations.", PageNumber = 4 },

        new Page { Id = 29, BookId = 8, Content = "In an enchanted realm, a mystical artifact held the key to unlocking ancient powers. A group of heroes embarked on a quest to find it.", PageNumber = 1 },
        new Page { Id = 30, BookId = 8, Content = "The quest took them through magical landscapes and mythical creatures. Each step brought them closer to the artifact and the powers it held.", PageNumber = 2 },
        new Page { Id = 31, BookId = 8, Content = "Challenges and riddles tested their skills and unity. They discovered that the true power of the artifact lay in their courage and friendship.", PageNumber = 3 },
        new Page { Id = 32, BookId = 8, Content = "The artifact's discovery brought about a transformation in the realm, uniting the land and restoring balance to its magical energies.", PageNumber = 4 },

        new Page { Id = 33, BookId = 9, Content = "In the depths of the ocean, a marine biologist uncovered secrets of a lost underwater city. Their discovery was both awe-inspiring and perilous.", PageNumber = 1 },
        new Page { Id = 34, BookId = 9, Content = "The biologist's exploration revealed advanced technologies and forgotten histories. Each finding contributed to a deeper understanding of the city's rise and fall.", PageNumber = 2 },
        new Page { Id = 35, BookId = 9, Content = "Encountering dangers both natural and artificial, the biologist pressed on, driven by the quest for knowledge and the preservation of the city's legacy.", PageNumber = 3 },
        new Page { Id = 36, BookId = 9, Content = "The expedition's findings reshaped the understanding of oceanic civilizations, leading to new discoveries and a greater appreciation of the planet's mysteries.", PageNumber = 4 },

        new Page { Id = 37, BookId = 10, Content = "In a bustling metropolis, a detective sought to solve a series of enigmatic crimes. Their investigation uncovered a web of intrigue and deception.", PageNumber = 1 },
        new Page { Id = 38, BookId = 10, Content = "The detective's pursuit of clues led them through hidden corners of the city, each revelation bringing them closer to unraveling the truth behind the crimes.", PageNumber = 2 },
        new Page { Id = 39, BookId = 10, Content = "Faced with false leads and dangerous encounters, the detective remained resolute, piecing together the puzzle with skill and determination.", PageNumber = 3 },
        new Page { Id = 40, BookId = 10, Content = "The resolution of the case not only brought justice but also shed light on the darker aspects of the city, prompting a wave of change and reform.", PageNumber = 4 },

        new Page { Id = 41, BookId = 11, Content = "In a fantasy kingdom, a young prince set out on a quest to reclaim his throne. The journey was fraught with danger and tests of character.", PageNumber = 1 },
        new Page { Id = 42, BookId = 11, Content = "The prince faced trials that tested his leadership and resolve. Each challenge brought him closer to understanding the responsibilities of ruling.", PageNumber = 2 },
        new Page { Id = 43, BookId = 11, Content = "Allies and adversaries alike shaped his journey, revealing truths about the kingdom's past and the future he hoped to build.", PageNumber = 3 },
        new Page { Id = 44, BookId = 11, Content = "The prince's return marked the beginning of a new era for the kingdom, one shaped by the lessons learned and the strength gained on his quest.", PageNumber = 4 },

        new Page { Id = 45, BookId = 12, Content = "In a secretive research facility, a scientist uncovered a groundbreaking discovery that had the potential to revolutionize their field of study.", PageNumber = 1 },
        new Page { Id = 46, BookId = 12, Content = "The research led to exciting advancements but also drew the attention of powerful entities with conflicting interests.", PageNumber = 2 },
        new Page { Id = 47, BookId = 12, Content = "Navigating the complex landscape of scientific ethics and external pressures, the scientist worked tirelessly to ensure their discovery's positive impact.", PageNumber = 3 },
        new Page { Id = 48, BookId = 12, Content = "The discovery's successful implementation marked a significant milestone, demonstrating the potential for innovation to shape the future.", PageNumber = 4 },

        new Page { Id = 49, BookId = 13, Content = "In an ancient land, a scholar stumbled upon a forgotten manuscript that revealed the secrets of an ancient civilization.", PageNumber = 1 },
        new Page { Id = 50, BookId = 13, Content = "The manuscript's revelations led the scholar on a journey across the land, uncovering hidden truths and long-lost artifacts.", PageNumber = 2 },
        new Page { Id = 51, BookId = 13, Content = "Each discovery added to the scholar's understanding of the civilization's rise and fall, providing valuable insights into their culture and technology.", PageNumber = 3 },
        new Page { Id = 52, BookId = 13, Content = "The scholar's findings transformed historical knowledge and inspired further exploration into the ancient world's mysteries.", PageNumber = 4 },

        new Page { Id = 53, BookId = 14, Content = "In a bustling space station, an astronaut embarked on a mission to explore uncharted regions of space. The journey was filled with challenges and discoveries.", PageNumber = 1 },
        new Page { Id = 54, BookId = 14, Content = "The mission's crew encountered alien phenomena and navigated through hazardous environments, each obstacle revealing more about the cosmos.", PageNumber = 2 },
        new Page { Id = 55, BookId = 14, Content = "As the exploration continued, the astronaut uncovered signs of ancient extraterrestrial civilizations and their impact on the galaxy.", PageNumber = 3 },
        new Page { Id = 56, BookId = 14, Content = "The mission's success expanded humanity's understanding of space and paved the way for future exploration and interstellar travel.", PageNumber = 4 },

        new Page { Id = 57, BookId = 15, Content = "In a post-apocalyptic world, a group of survivors struggled to rebuild society amidst the ruins. Their efforts were fraught with challenges and dangers.", PageNumber = 1 },
        new Page { Id = 58, BookId = 15, Content = "The survivors faced conflicts with other factions and the harsh realities of their environment, testing their resilience and resourcefulness.", PageNumber = 2 },
        new Page { Id = 59, BookId = 15, Content = "Amidst the struggle, they forged alliances and developed strategies to secure their future, working towards a new beginning for their community.", PageNumber = 3 },
        new Page { Id = 60, BookId = 15, Content = "Their efforts culminated in a restored sense of hope and a foundation for rebuilding, marking the dawn of a new era from the ashes of the old.", PageNumber = 4 }
            );

            modelBuilder.Entity<Role>().HasData(
                new Role { Id = 1, Name = "pendingUser" },
                new Role { Id = 2, Name = "member" },
                new Role { Id = 3, Name = "author" },
                new Role { Id = 4, Name = "staff" },
                new Role { Id = 5, Name = "manager" }
            );

            modelBuilder.Entity<User>().HasData(
                 new User { Id = 1, Name = "Alice", Surname = "Smith", Username = "alice", Password = "123", BirthDate = new DateTime(1990, 1, 1), Gender = 'F', IsPunished = false, FineAmount = 0, RoleId = 1 },
                new User { Id = 2, Name = "Bob", Surname = "Johnson", Username = "bobby", Password = "123", BirthDate = new DateTime(1985, 2, 2), Gender = 'M', IsPunished = false, FineAmount = 0, RoleId = 2 },
                new User { Id = 3, Name = "Carol", Surname = "Williams", Username = "carol", Password = "123", BirthDate = new DateTime(1992, 3, 3), Gender = 'F', IsPunished = false, FineAmount = 0, RoleId = 3 },
                new User { Id = 4, Name = "Dave", Surname = "Brown", Username = "dave1", Password = "123", BirthDate = new DateTime(1980, 4, 4), Gender = 'M', IsPunished = false, FineAmount = 0, RoleId = 4 },
                new User { Id = 5, Name = "Eve", Surname = "Jones", Username = "eve01", Password = "123", BirthDate = new DateTime(1995, 5, 5), Gender = 'F', IsPunished = false, FineAmount = 0, RoleId = 5 },
                new User { Id = 6, Name = "Frank", Surname = "Miller", Username = "frank", Password = "123", BirthDate = new DateTime(1987, 6, 6), Gender = 'M', IsPunished = false, FineAmount = 0, RoleId = 1 },
                new User { Id = 7, Name = "Grace", Surname = "Wilson", Username = "grace", Password = "123", BirthDate = new DateTime(1993, 7, 7), Gender = 'F', IsPunished = false, FineAmount = 0, RoleId = 2 },
                new User { Id = 8, Name = "Henry", Surname = "Moore", Username = "henry", Password = "123", BirthDate = new DateTime(1988, 8, 8), Gender = 'M', IsPunished = false, FineAmount = 0, RoleId = 3 },
                new User { Id = 9, Name = "Ivy", Surname = "Taylor", Username = "ivy99", Password = "123", BirthDate = new DateTime(1994, 9, 9), Gender = 'F', IsPunished = false, FineAmount = 0, RoleId = 4 },
                new User { Id = 10, Name = "Jack", Surname = "Anderson", Username = "jack1", Password = "123", BirthDate = new DateTime(1991, 10, 10), Gender = 'M', IsPunished = false, FineAmount = 0, RoleId = 5 },

                new User { Id = 11, Name = "NameOfManager", Surname = "Anderson", Username = "manager", Password = "123", BirthDate = new DateTime(1991, 10, 10), Gender = 'M', IsPunished = false, FineAmount = 0, RoleId = 5 },
                new User { Id = 12, Name = "NameOfStaff", Surname = "Anderson", Username = "staff", Password = "123", BirthDate = new DateTime(1991, 10, 10), Gender = 'M', IsPunished = false, FineAmount = 0, RoleId = 4 },
                new User { Id = 13, Name = "NameOfAuthor", Surname = "Anderson", Username = "author", Password = "123", BirthDate = new DateTime(1991, 10, 10), Gender = 'M', IsPunished = false, FineAmount = 0, RoleId = 3 },
                new User { Id = 14, Name = "NameOfMember", Surname = "Anderson", Username = "member", Password = "123", BirthDate = new DateTime(1991, 10, 10), Gender = 'M', IsPunished = false, FineAmount = 0, RoleId = 2 },
                new User { Id = 15, Name = "NameOfPending", Surname = "Anderson", Username = "pending", Password = "123", BirthDate = new DateTime(1991, 10, 10), Gender = 'M', IsPunished = false, FineAmount = 0, RoleId = 1 }
            );

            modelBuilder.Entity<Message>().HasData(
                  new Message { Id = 1, SenderId = 1, ReceiverId = 2, Title = "Title test 1", Details = "Selam, nasılsın? Bir konu hakkında soru soracaktım", IsReceiverRead = false },
        new Message { Id = 2, SenderId = 2, ReceiverId = 3, Title = "Meeting Request", Details = "Can we schedule a meeting for next week?", IsReceiverRead = true },
        new Message { Id = 3, SenderId = 3, ReceiverId = 4, Title = "Project Update", Details = "The project is moving forward as planned. Let's discuss further.", IsReceiverRead = false },
        new Message { Id = 4, SenderId = 4, ReceiverId = 5, Title = "Reminder", Details = "Don't forget to submit the report by end of day.", IsReceiverRead = true },
        new Message { Id = 5, SenderId = 5, ReceiverId = 1, Title = "Feedback Request", Details = "Please provide feedback on the recent presentation.", IsReceiverRead = false },
        new Message { Id = 6, SenderId = 1, ReceiverId = 2, Title = "Follow-up", Details = "Just following up on the last message I sent.", IsReceiverRead = true },
        new Message { Id = 7, SenderId = 2, ReceiverId = 3, Title = "Urgent", Details = "Please respond as soon as possible regarding the urgent matter.", IsReceiverRead = false },
        new Message { Id = 8, SenderId = 3, ReceiverId = 4, Title = "Thank You", Details = "Thank you for your assistance with the project.", IsReceiverRead = true },
        new Message { Id = 9, SenderId = 4, ReceiverId = 5, Title = "Question", Details = "I have a question about the new policy changes.", IsReceiverRead = false },
        new Message { Id = 10, SenderId = 5, ReceiverId = 1, Title = "Invitation", Details = "You are invited to the team-building event next week.", IsReceiverRead = true },
        new Message { Id = 11, SenderId = 1, ReceiverId = 3, Title = "Quick Chat", Details = "Can we have a quick chat tomorrow about the project?", IsReceiverRead = false },
        new Message { Id = 12, SenderId = 2, ReceiverId = 4, Title = "Report Needed", Details = "I need the latest report by tomorrow.", IsReceiverRead = true },
        new Message { Id = 13, SenderId = 3, ReceiverId = 5, Title = "Update Required", Details = "Please provide an update on the status of the task.", IsReceiverRead = false },
        new Message { Id = 14, SenderId = 4, ReceiverId = 1, Title = "Reminder", Details = "Reminder to review the attached document.", IsReceiverRead = true },
        new Message { Id = 15, SenderId = 5, ReceiverId = 2, Title = "Suggestion", Details = "I have a suggestion for improving the workflow.", IsReceiverRead = false },
        new Message { Id = 16, SenderId = 1, ReceiverId = 4, Title = "Feedback", Details = "I would like your feedback on the recent changes.", IsReceiverRead = true },
        new Message { Id = 17, SenderId = 2, ReceiverId = 3, Title = "Follow-up", Details = "Following up on the previous discussion about the project.", IsReceiverRead = false },
        new Message { Id = 18, SenderId = 3, ReceiverId = 5, Title = "Proposal", Details = "Here's a proposal for the upcoming project.", IsReceiverRead = true },
        new Message { Id = 19, SenderId = 4, ReceiverId = 1, Title = "Query", Details = "I have a query regarding the latest changes.", IsReceiverRead = false },
        new Message { Id = 20, SenderId = 5, ReceiverId = 2, Title = "Urgent", Details = "This is an urgent matter that requires your immediate attention.", IsReceiverRead = true },
        new Message { Id = 21, SenderId = 1, ReceiverId = 3, Title = "Update", Details = "Here is the latest update on the project.", IsReceiverRead = false },
        new Message { Id = 22, SenderId = 2, ReceiverId = 4, Title = "Invitation", Details = "You are invited to the upcoming workshop.", IsReceiverRead = true },
        new Message { Id = 23, SenderId = 3, ReceiverId = 5, Title = "Meeting Follow-up", Details = "Following up on our meeting from last week.", IsReceiverRead = false },
        new Message { Id = 24, SenderId = 4, ReceiverId = 1, Title = "Task Assigned", Details = "A new task has been assigned to you.", IsReceiverRead = true },
        new Message { Id = 25, SenderId = 5, ReceiverId = 2, Title = "Review Request", Details = "Please review the attached document and provide feedback.", IsReceiverRead = false }
            );
        }
    }
}