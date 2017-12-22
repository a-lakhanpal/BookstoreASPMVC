namespace Bookstore.Migrations
{
    using Models;
    using System;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<Bookstore.Models.BookstoreContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            SetSqlGenerator("MySql.Data.MySqlClient", new MySql.Data.Entity.MySqlMigrationSqlGenerator());
        }

        protected override void Seed(BookstoreContext context)
        {
            context.Books.AddOrUpdate(x => x.BookId,
                new Book() { BookId = 1, BookName = "JAVA 101", DatePublished = DateTime.Parse("2010-08-10 09:30:03"), PublisherId = 3 },
                new Book() { BookId = 2, BookName = "ORACLE 101", DatePublished = DateTime.Parse("2010-08-10 09:30:03"), PublisherId = 1 },
                new Book() { BookId = 3, BookName = "MYSQL 101", DatePublished = DateTime.Parse("2010-08-10 09:30:03"), PublisherId = 1 },
                new Book() { BookId = 4, BookName = "MSSQL 101", DatePublished = DateTime.Parse("2010-08-10 09:30:03"), PublisherId = 1 },
                new Book() { BookId = 5, BookName = "NOSQL 101", DatePublished = DateTime.Parse("2010-08-10 09:30:03"), PublisherId = 3 },
                new Book() { BookId = 6, BookName = "DATA SCIENCE 101", DatePublished = DateTime.Parse("2010-08-10 09:30:03"), PublisherId = 2 },
                new Book() { BookId = 7, BookName = "PYTHON 101", DatePublished = DateTime.Parse("2010-08-10 09:30:03"), PublisherId = 2 },
                new Book() { BookId = 8, BookName = "MACHINE LEARNING 101", DatePublished = DateTime.Parse("2010-08-10 09:30:03"), PublisherId = 2 },
                new Book() { BookId = 9, BookName = "COMMUNICATION SKILLS 101", DatePublished = DateTime.Parse("2010-08-10 09:30:03"), PublisherId = 2 },
                new Book() { BookId = 10, BookName = "CALCULUS 101", DatePublished = DateTime.Parse("2010-08-10 09:30:03"), PublisherId = 3 }
                );
            context.Publishers.AddOrUpdate(x => x.PublisherId,
                    new Publisher() { PublisherId = 1, PublisherName = "JOHN DOE", PublisherEmail = "johndoe@gmail.com",PublisherPhoneNumber="+254700000000" },
                     new Publisher() { PublisherId = 2, PublisherName = "JANE DOE", PublisherEmail = "janedoe@gmail.com", PublisherPhoneNumber = "+254700000001" },
                      new Publisher() { PublisherId = 3, PublisherName = "WALLAH BIN WALLAH", PublisherEmail = "wallah@gmail.com", PublisherPhoneNumber = "+254700000002" }
                );
            context.SaveChanges();
        }
    }
}
