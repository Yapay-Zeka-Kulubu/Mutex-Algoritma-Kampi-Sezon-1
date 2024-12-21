using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Crypto.Generators;

namespace libraryApp.backend.Entity
{
    public class LibraryDbContext : DbContext
    {
        public DbSet<Book> Books => Set<Book>();

        public DbSet<BookAuthor> BookAuthors => Set<BookAuthor>();

        public DbSet<BookPublishRequest> BookPublishRequests => Set<BookPublishRequest>();

        public DbSet<LoanRequest> LoanRequests => Set<LoanRequest>();

        public DbSet<Message> Messages => Set<Message>();

        public DbSet<Page> Pages => Set<Page>();

        public DbSet<Point> Points => Set<Point>();

        public DbSet<Punishment> Punishments => Set<Punishment>();

        public DbSet<RegisterRequest> RegisterRequests => Set<RegisterRequest>();

        public DbSet<Role> Roles => Set<Role>();

        public DbSet<User> Users => Set<User>();


        public LibraryDbContext(DbContextOptions<LibraryDbContext> options) : base(options)
        {

        }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Book>().HasData(
    new Book { id = 1, title = "The Psychology of Money", type = "psychology", number_of_pages = 250, status = false },
    new Book { id = 2, title = "The Silent Patient", type = "thriller", number_of_pages = 368, status = false },
    new Book { id = 3, title = "Educated", type = "memoir", number_of_pages = 334, status = false },
    new Book { id = 4, title = "Becoming", type = "memoir", number_of_pages = 448, status = false },
    new Book { id = 5, title = "The Alchemist", type = "fiction", number_of_pages = 208, status = false },
    new Book { id = 6, title = "Sapiens: A Brief History of Humankind", type = "history", number_of_pages = 464, status = false },
    new Book { id = 7, title = "The Power of Habit", type = "self-help", number_of_pages = 371, status = false },
    new Book { id = 8, title = "The Catcher in the Rye", type = "fiction", number_of_pages = 277, status = false },
    new Book { id = 9, title = "1984", type = "dystopian", number_of_pages = 328, status = false },
    new Book { id = 10, title = "To Kill a Mockingbird", type = "fiction", number_of_pages = 281, status = false }
);

            modelBuilder.Entity<BookAuthor>().HasData(
                new BookAuthor { bookId = 1, userId = 1, id = 1 },
                new BookAuthor { bookId = 2, userId = 2, id = 2 },
                new BookAuthor { bookId = 3, userId = 3, id = 3 },
                new BookAuthor { bookId = 4, userId = 4, id = 4 },
                new BookAuthor { bookId = 5, userId = 5, id = 5 },
                new BookAuthor { bookId = 6, userId = 6, id = 6 },
                new BookAuthor { bookId = 7, userId = 7, id = 7 },
                new BookAuthor { bookId = 8, userId = 8, id = 8 },
                new BookAuthor { bookId = 9, userId = 9, id = 9 },
                new BookAuthor { bookId = 10, userId = 10, id = 10 }
            );

            modelBuilder.Entity<BookPublishRequest>().HasData(
                new BookPublishRequest { id = 1, bookId = 1, confirmation = false, pending = true, userId = 1, requestDate = DateOnly.FromDateTime(DateTime.Now) },
                new BookPublishRequest { id = 2, bookId = 2, confirmation = false, pending = true, userId = 2, requestDate = DateOnly.FromDateTime(DateTime.Now) },
                new BookPublishRequest { id = 3, bookId = 3, confirmation = false, pending = true, userId = 3, requestDate = DateOnly.FromDateTime(DateTime.Now) },
                new BookPublishRequest { id = 4, bookId = 4, confirmation = false, pending = true, userId = 4, requestDate = DateOnly.FromDateTime(DateTime.Now) },
                new BookPublishRequest { id = 5, bookId = 5, confirmation = false, pending = true, userId = 5, requestDate = DateOnly.FromDateTime(DateTime.Now) },
                new BookPublishRequest { id = 6, bookId = 6, confirmation = false, pending = true, userId = 6, requestDate = DateOnly.FromDateTime(DateTime.Now) },
                new BookPublishRequest { id = 7, bookId = 7, confirmation = false, pending = true, userId = 7, requestDate = DateOnly.FromDateTime(DateTime.Now) },
                new BookPublishRequest { id = 8, bookId = 8, confirmation = false, pending = true, userId = 8, requestDate = DateOnly.FromDateTime(DateTime.Now) },
                new BookPublishRequest { id = 9, bookId = 9, confirmation = false, pending = true, userId = 9, requestDate = DateOnly.FromDateTime(DateTime.Now) },
                new BookPublishRequest { id = 10, bookId = 10, confirmation = false, pending = true, userId = 10, requestDate = DateOnly.FromDateTime(DateTime.Now) }
            );

            modelBuilder.Entity<LoanRequest>().HasData(
                new LoanRequest { id = 1, bookId = 1, confirmation = false, isReturned = false, requestDate = DateOnly.FromDateTime(DateTime.Now), returnDate = DateOnly.FromDateTime(DateTime.Now.AddDays(7)), pending = true, userId = 1 },
                new LoanRequest { id = 2, bookId = 2, confirmation = false, isReturned = false, requestDate = DateOnly.FromDateTime(DateTime.Now), returnDate = DateOnly.FromDateTime(DateTime.Now.AddDays(14)), pending = true, userId = 2 },
                new LoanRequest { id = 3, bookId = 3, confirmation = false, isReturned = false, requestDate = DateOnly.FromDateTime(DateTime.Now), returnDate = DateOnly.FromDateTime(DateTime.Now.AddDays(21)), pending = true, userId = 3 },
                new LoanRequest { id = 4, bookId = 4, confirmation = false, isReturned = false, requestDate = DateOnly.FromDateTime(DateTime.Now), returnDate = DateOnly.FromDateTime(DateTime.Now.AddDays(28)), pending = true, userId = 4 },
                new LoanRequest { id = 5, bookId = 5, confirmation = false, isReturned = false, requestDate = DateOnly.FromDateTime(DateTime.Now), returnDate = DateOnly.FromDateTime(DateTime.Now.AddDays(30)), pending = true, userId = 5 },
                new LoanRequest { id = 6, bookId = 6, confirmation = false, isReturned = false, requestDate = DateOnly.FromDateTime(DateTime.Now), returnDate = DateOnly.FromDateTime(DateTime.Now.AddDays(14)), pending = true, userId = 6 },
                new LoanRequest { id = 7, bookId = 7, confirmation = false, isReturned = false, requestDate = DateOnly.FromDateTime(DateTime.Now), returnDate = DateOnly.FromDateTime(DateTime.Now.AddDays(21)), pending = true, userId = 7 },
                new LoanRequest { id = 8, bookId = 8, confirmation = false, isReturned = false, requestDate = DateOnly.FromDateTime(DateTime.Now), returnDate = DateOnly.FromDateTime(DateTime.Now.AddDays(28)), pending = true, userId = 8 },
                new LoanRequest { id = 9, bookId = 9, confirmation = false, isReturned = false, requestDate = DateOnly.FromDateTime(DateTime.Now), returnDate = DateOnly.FromDateTime(DateTime.Now.AddDays(30)), pending = true, userId = 9 },
                new LoanRequest { id = 10, bookId = 10, confirmation = false, isReturned = false, requestDate = DateOnly.FromDateTime(DateTime.Now), returnDate = DateOnly.FromDateTime(DateTime.Now.AddDays(14)), pending = true, userId = 10 }
            );

            modelBuilder.Entity<Message>().HasData(
                new Message { id = 1, content = "Hello! Looking forward to reading this book.", isRead = false, recieverId = 2, senderId = 1, sendingDate = DateOnly.FromDateTime(DateTime.Now), title = "Greetings" },
                new Message { id = 2, content = "Did you finish the last chapter?", isRead = false, recieverId = 1, senderId = 2, sendingDate = DateOnly.FromDateTime(DateTime.Now), title = "Question" },
                new Message { id = 3, content = "I found a great article related to our reading.", isRead = false, recieverId = 3, senderId = 1, sendingDate = DateOnly.FromDateTime(DateTime.Now), title = "Resource Sharing" },
                new Message { id = 4, content = "Let's discuss this book in our next meeting.", isRead = false, recieverId = 4, senderId = 1, sendingDate = DateOnly.FromDateTime(DateTime.Now), title = "Discussion" },
                new Message { id = 5, content = "What do you think about the protagonist's choices?", isRead = false, recieverId = 5, senderId = 1, sendingDate = DateOnly.FromDateTime(DateTime.Now), title = "Character Analysis" },
                new Message { id = 6, content = "I can't wait to start the next book!", isRead = false, recieverId = 6, senderId = 1, sendingDate = DateOnly.FromDateTime(DateTime.Now), title = "Excitement" },
                new Message { id = 7, content = "Have you read the latest chapter?", isRead = false, recieverId = 7, senderId = 1, sendingDate = DateOnly.FromDateTime(DateTime.Now), title = "Update" },
                new Message { id = 8, content = "This book changed my perspective on many things.", isRead = false, recieverId = 8, senderId = 1, sendingDate = DateOnly.FromDateTime(DateTime.Now), title = "Thoughts" },
                new Message { id = 9, content = "I'm glad we chose this book for our group.", isRead = false, recieverId = 9, senderId = 1, sendingDate = DateOnly.FromDateTime(DateTime.Now), title = "Group Decision" },
                new Message { id = 10, content = "What are your favorite quotes from the book?", isRead = false, recieverId = 10, senderId = 1, sendingDate = DateOnly.FromDateTime(DateTime.Now), title = "Quotes" }
            );

            modelBuilder.Entity<Page>().HasData(
                new Page { id = 1, bookId = 1, content = "Understanding how money works is essential in today's economy. This chapter explores the psychology behind financial decisions.", pageNumber = 1 },
                new Page { id = 2, bookId = 1, content = "The concept of saving and investing is examined, highlighting the impact of time and compound interest.", pageNumber = 2 },
                new Page { id = 3, bookId = 1, content = "We delve into common financial myths and the reality behind them, debunking misconceptions that can hinder financial growth.", pageNumber = 3 },
                new Page { id = 4, bookId = 1, content = "Emotional aspects of money management are discussed, emphasizing the need for awareness and discipline.", pageNumber = 4 },
                new Page { id = 5, bookId = 1, content = "The final chapter provides actionable steps to improve financial literacy and well-being.", pageNumber = 5 },

                new Page { id = 6, bookId = 2, content = "The Silent Patient begins with a shocking incident, setting the stage for a psychological thriller filled with twists and turns.", pageNumber = 1 },
                new Page { id = 7, bookId = 2, content = "We explore the protagonist's motivations and the dark secrets that unfold throughout the narrative.", pageNumber = 2 },
                new Page { id = 8, bookId = 2, content = "Themes of love, betrayal, and forgiveness are intricately woven into the story, making it a gripping read.", pageNumber = 3 },
                new Page { id = 9, bookId = 2, content = "The unreliable narrator challenges readers to question the truth behind the events.", pageNumber = 4 },
                new Page { id = 10, bookId = 2, content = "The climax leaves readers breathless, leading to a shocking revelation that ties all elements together.", pageNumber = 5 },

                new Page { id = 11, bookId = 3, content = "Educated recounts the author's journey from a strict upbringing in Idaho to pursuing higher education against all odds.", pageNumber = 1 },
                new Page { id = 12, bookId = 3, content = "The struggle for knowledge and identity forms the core of this compelling memoir.", pageNumber = 2 },
                new Page { id = 13, bookId = 3, content = "Key events in the author's life are portrayed with raw honesty and vulnerability.", pageNumber = 3 },
                new Page { id = 14, bookId = 3, content = "The challenges faced by the author serve as a powerful reminder of the importance of education.", pageNumber = 4 },
                new Page { id = 15, bookId = 3, content = "The memoir concludes with a reflection on personal growth and the value of resilience.", pageNumber = 5 },

                new Page { id = 16, bookId = 4, content = "Becoming tells the inspiring story of Michelle Obama, chronicling her life from childhood to the White House.", pageNumber = 1 },
                new Page { id = 17, bookId = 4, content = "The author shares personal anecdotes that resonate with themes of identity and self-discovery.", pageNumber = 2 },
                new Page { id = 18, bookId = 4, content = "The journey through her career and marriage showcases the challenges faced in the public eye.", pageNumber = 3 },
                new Page { id = 19, bookId = 4, content = "Advocacy for education and health issues becomes a focal point in her story.", pageNumber = 4 },
                new Page { id = 20, bookId = 4, content = "The memoir ends with a powerful message of hope and empowerment for future generations.", pageNumber = 5 },

                new Page { id = 21, bookId = 5, content = "The Alchemist is a magical tale about following one’s dreams and listening to one’s heart.", pageNumber = 1 },
                new Page { id = 22, bookId = 5, content = "The journey of Santiago, a young shepherd, serves as a metaphor for the quest for personal legend.", pageNumber = 2 },
                new Page { id = 23, bookId = 5, content = "The book emphasizes the significance of dreams and the courage to pursue them.", pageNumber = 3 },
                new Page { id = 24, bookId = 5, content = "Wisdom and the interconnectedness of the universe play key roles in the narrative.", pageNumber = 4 },
                new Page { id = 25, bookId = 5, content = "The conclusion inspires readers to realize their own dreams and take action.", pageNumber = 5 },

                new Page { id = 26, bookId = 6, content = "Sapiens provides a thought-provoking overview of human history and evolution.", pageNumber = 1 },
                new Page { id = 27, bookId = 6, content = "The author examines how Homo sapiens came to dominate the Earth and the implications of this power.", pageNumber = 2 },
                new Page { id = 28, bookId = 6, content = "Major events, such as the Agricultural Revolution, are analyzed in detail.", pageNumber = 3 },
                new Page { id = 29, bookId = 6, content = "The narrative challenges readers to think critically about humanity's future.", pageNumber = 4 },
                new Page { id = 30, bookId = 6, content = "The concluding chapter reflects on our place in the world and our responsibilities as a species.", pageNumber = 5 },

                new Page { id = 31, bookId = 7, content = "The Power of Habit explores the science behind why habits exist and how they can be changed.", pageNumber = 1 },
                new Page { id = 32, bookId = 7, content = "The author breaks down the habit loop: cue, routine, and reward.", pageNumber = 2 },
                new Page { id = 33, bookId = 7, content = "Real-life examples illustrate the power of habits in personal and professional life.", pageNumber = 3 },
                new Page { id = 34, bookId = 7, content = "Strategies for creating positive habits and breaking negative ones are presented.", pageNumber = 4 },
                new Page { id = 35, bookId = 7, content = "The final chapter emphasizes the importance of belief in changing habits.", pageNumber = 5 },

                new Page { id = 36, bookId = 8, content = "The Catcher in the Rye narrates the story of Holden Caulfield, a disenchanted teenager.", pageNumber = 1 },
                new Page { id = 37, bookId = 8, content = "Themes of alienation and rebellion permeate the narrative, reflecting teenage angst.", pageNumber = 2 },
                new Page { id = 38, bookId = 8, content = "Holden's perspective provides a critique of adult hypocrisy and societal expectations.", pageNumber = 3 },
                new Page { id = 39, bookId = 8, content = "Key moments highlight the struggle for identity and connection.", pageNumber = 4 },
                new Page { id = 40, bookId = 8, content = "The ending leaves readers contemplating the complexities of growing up.", pageNumber = 5 },

                new Page { id = 41, bookId = 9, content = "1984 depicts a dystopian future under totalitarian rule, exploring themes of surveillance and oppression.", pageNumber = 1 },
                new Page { id = 42, bookId = 9, content = "The protagonist, Winston Smith, grapples with the loss of individuality in a conformist society.", pageNumber = 2 },
                new Page { id = 43, bookId = 9, content = "The narrative challenges readers to reflect on the nature of freedom and truth.", pageNumber = 3 },
                new Page { id = 44, bookId = 9, content = "The struggle against oppressive regimes is a central theme that resonates in contemporary society.", pageNumber = 4 },
                new Page { id = 45, bookId = 9, content = "The conclusion leaves a lasting impact, urging readers to remain vigilant in preserving their freedoms.", pageNumber = 5 },

                new Page { id = 46, bookId = 10, content = "To Kill a Mockingbird presents a poignant exploration of racism and injustice in the American South.", pageNumber = 1 },
                new Page { id = 47, bookId = 10, content = "The story unfolds through the eyes of young Scout Finch, offering a unique perspective on moral growth.", pageNumber = 2 },
                new Page { id = 48, bookId = 10, content = "Key characters highlight the complexities of human behavior and social norms.", pageNumber = 3 },
                new Page { id = 49, bookId = 10, content = "The narrative emphasizes empathy and understanding as vital to combating prejudice.", pageNumber = 4 },
                new Page { id = 50, bookId = 10, content = "The conclusion underscores the importance of standing up for what is right, even in the face of adversity.", pageNumber = 5 }
            );

            modelBuilder.Entity<Point>().HasData(
                new Point { id = 1, earnDate = DateOnly.FromDateTime(DateTime.Now), userId = 1, point = 10 },
                new Point { id = 2, earnDate = DateOnly.FromDateTime(DateTime.Now.AddDays(-1)), userId = 1, point = 20 },
                new Point { id = 3, earnDate = DateOnly.FromDateTime(DateTime.Now.AddDays(-2)), userId = 2, point = 15 },
                new Point { id = 4, earnDate = DateOnly.FromDateTime(DateTime.Now.AddDays(-3)), userId = 2, point = 25 },
                new Point { id = 5, earnDate = DateOnly.FromDateTime(DateTime.Now.AddDays(-4)), userId = 3, point = 30 },
                new Point { id = 6, earnDate = DateOnly.FromDateTime(DateTime.Now.AddDays(-5)), userId = 4, point = 40 },
                new Point { id = 7, earnDate = DateOnly.FromDateTime(DateTime.Now.AddDays(-6)), userId = 5, point = 50 },
                new Point { id = 8, earnDate = DateOnly.FromDateTime(DateTime.Now.AddDays(-7)), userId = 6, point = 60 },
                new Point { id = 9, earnDate = DateOnly.FromDateTime(DateTime.Now.AddDays(-8)), userId = 7, point = 70 },
                new Point { id = 10, earnDate = DateOnly.FromDateTime(DateTime.Now.AddDays(-9)), userId = 8, point = 80 }
            );

            modelBuilder.Entity<Punishment>().HasData(
                new Punishment { id = 1, fineAmount = 5, isActive = true, punishmentDate = DateOnly.FromDateTime(DateTime.Now), userId = 1 },
                new Punishment { id = 2, fineAmount = 10, isActive = true, punishmentDate = DateOnly.FromDateTime(DateTime.Now.AddDays(-1)), userId = 2 },
                new Punishment { id = 3, fineAmount = 15, isActive = false, punishmentDate = DateOnly.FromDateTime(DateTime.Now.AddDays(-2)), userId = 3 },
                new Punishment { id = 4, fineAmount = 20, isActive = true, punishmentDate = DateOnly.FromDateTime(DateTime.Now.AddDays(-3)), userId = 4 },
                new Punishment { id = 5, fineAmount = 25, isActive = false, punishmentDate = DateOnly.FromDateTime(DateTime.Now.AddDays(-4)), userId = 5 },
                new Punishment { id = 6, fineAmount = 30, isActive = true, punishmentDate = DateOnly.FromDateTime(DateTime.Now.AddDays(-5)), userId = 6 },
                new Punishment { id = 7, fineAmount = 35, isActive = true, punishmentDate = DateOnly.FromDateTime(DateTime.Now.AddDays(-6)), userId = 7 },
                new Punishment { id = 8, fineAmount = 40, isActive = false, punishmentDate = DateOnly.FromDateTime(DateTime.Now.AddDays(-7)), userId = 8 },
                new Punishment { id = 9, fineAmount = 45, isActive = true, punishmentDate = DateOnly.FromDateTime(DateTime.Now.AddDays(-8)), userId = 9 },
                new Punishment { id = 10, fineAmount = 50, isActive = false, punishmentDate = DateOnly.FromDateTime(DateTime.Now.AddDays(-9)), userId = 10 }
            );

            modelBuilder.Entity<RegisterRequest>().HasData(
                new RegisterRequest { id = 1, confirmation = true, pending = false, requestDate = DateOnly.FromDateTime(DateTime.Now), userId = 1 },
                new RegisterRequest { id = 2, confirmation = true, pending = false, requestDate = DateOnly.FromDateTime(DateTime.Now.AddDays(-1)), userId = 2 },
                new RegisterRequest { id = 3, confirmation = true, pending = false, requestDate = DateOnly.FromDateTime(DateTime.Now.AddDays(-2)), userId = 3 },
                new RegisterRequest { id = 4, confirmation = true, pending = false, requestDate = DateOnly.FromDateTime(DateTime.Now.AddDays(-3)), userId = 4 },
                new RegisterRequest { id = 5, confirmation = true, pending = false, requestDate = DateOnly.FromDateTime(DateTime.Now.AddDays(-4)), userId = 5 },
                new RegisterRequest { id = 6, confirmation = true, pending = false, requestDate = DateOnly.FromDateTime(DateTime.Now.AddDays(-5)), userId = 6 },
                new RegisterRequest { id = 7, confirmation = true, pending = false, requestDate = DateOnly.FromDateTime(DateTime.Now.AddDays(-6)), userId = 7 },
                new RegisterRequest { id = 8, confirmation = true, pending = false, requestDate = DateOnly.FromDateTime(DateTime.Now.AddDays(-7)), userId = 8 },
                new RegisterRequest { id = 9, confirmation = true, pending = false, requestDate = DateOnly.FromDateTime(DateTime.Now.AddDays(-8)), userId = 9 },
                new RegisterRequest { id = 10, confirmation = true, pending = false, requestDate = DateOnly.FromDateTime(DateTime.Now.AddDays(-9)), userId = 10 },

                new RegisterRequest { id = 11, confirmation = true, pending = false, requestDate = DateOnly.FromDateTime(DateTime.Now.AddDays(-9)), userId = 11 },
                new RegisterRequest { id = 12, confirmation = true, pending = false, requestDate = DateOnly.FromDateTime(DateTime.Now.AddDays(-9)), userId = 12 },
                new RegisterRequest { id = 13, confirmation = true, pending = false, requestDate = DateOnly.FromDateTime(DateTime.Now.AddDays(-9)), userId = 13 },
                new RegisterRequest { id = 14, confirmation = true, pending = false, requestDate = DateOnly.FromDateTime(DateTime.Now.AddDays(-9)), userId = 14 },
                new RegisterRequest { id = 15, confirmation = true, pending = false, requestDate = DateOnly.FromDateTime(DateTime.Now.AddDays(-9)), userId = 15 }
            );

            modelBuilder.Entity<User>().HasData(
                new User { id = 1, email = "test1@example.com", name = "Alice", surname = "Smith", username = "alice_smith", password = "pass123", roleId = 1, userStatus = true },
                new User { id = 2, email = "test2@example.com", name = "Bob", surname = "Brown", username = "bob_brown", password = "pass234", roleId = 1, userStatus = true },
                new User { id = 3, email = "test3@example.com", name = "Charlie", surname = "Davis", username = "charlie_davis", password = "pass345", roleId = 1, userStatus = true },
                new User { id = 4, email = "test4@example.com", name = "Diana", surname = "Evans", username = "diana_evans", password = "pass456", roleId = 1, userStatus = true },
                new User { id = 5, email = "test5@example.com", name = "Evan", surname = "Foster", username = "evan_foster", password = "pass567", roleId = 1, userStatus = true },
                new User { id = 6, email = "test6@example.com", name = "Fiona", surname = "Gates", username = "fiona_gates", password = "pass678", roleId = 1, userStatus = true },
                new User { id = 7, email = "test7@example.com", name = "George", surname = "Harris", username = "george_harris", password = "pass789", roleId = 1, userStatus = true },
                new User { id = 8, email = "test8@example.com", name = "Hannah", surname = "Irwin", username = "hannah_irwin", password = "pass890", roleId = 1, userStatus = true },
                new User { id = 9, email = "test9@example.com", name = "Isaac", surname = "Jones", username = "isaac_jones", password = "pass901", roleId = 1, userStatus = true },
                new User { id = 10, email = "test10@example.com", name = "Jack", surname = "King", username = "jack_king", password = "pass012", roleId = 1, userStatus = true },

                new User { id = 11, email = "test11@example.com", name = "Feyza", surname = "Beyaztaş", username = "member", password = "123", roleId = 1, userStatus = true },
                new User { id = 12, email = "test12@example.com", name = "Türker", surname = "Kıvılcım", username = "manager", password = "123", roleId = 2, userStatus = true },
                new User { id = 13, email = "test13@example.com", name = "Fatih", surname = "Çağdaş", username = "staff", password = "123", roleId = 3, userStatus = true },
                new User { id = 14, email = "test14@example.com", name = "Zehra", surname = "Ülker", username = "author", password = "123", roleId = 4, userStatus = true },
                new User { id = 15, email = "test14@example.com", name = "Özge", surname = "Nur", username = "author2", password = "123", roleId = 4, userStatus = true }
            );

            modelBuilder.Entity<Role>().HasData(

               new Role { id = 1, name = "member" },
                new Role { id = 2, name = "manager" },
                new Role { id = 3, name = "staff" },
                new Role { id = 4, name = "author" }
                );
        }
    }
}
