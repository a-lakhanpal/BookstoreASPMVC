using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using Bookstore.Library;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Bookstore.Models
{
    [DbConfigurationType(typeof(MySql.Data.Entity.MySqlEFConfiguration))]
    public class BookstoreContext: DbContext
    {
        public BookstoreContext()
            : base(Db.ConString)
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<BookstoreContext>());
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Book>Books{get; set;}
        public DbSet<Publisher> Publishers { get; set; }
    }
    [Table("books")]
    public class Book
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BookId { get; set; }

        [Required(ErrorMessage = "Please enter the name of the book.")]
        [MaxLength(50, ErrorMessage = "Name too long. Max 50 characters")]
        public string BookName { get; set; }

        [Required]
        public DateTime DatePublished { get; set; }

        [Required(ErrorMessage = "Please choose publisher for the book.")]
        public int PublisherId { get; set; }
        public Publisher publisher { get; set; }
    }

    [Table("publishers")]
    public class Publisher
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PublisherId { get; set; }

        [MaxLength(50, ErrorMessage = "Name too long. Max 50 characters")]
        [Required(ErrorMessage = "Please enter the name of the publisher.")]
        public string PublisherName { get; set; }

        [Required]
        [MaxLength(25, ErrorMessage = "Email too long! Max 25 characters")]
        [EmailAddress(ErrorMessage = "Enter a valid e-mail address")]
        public string PublisherEmail { get; set; }

        [Required]
        [MaxLength(20, ErrorMessage = "Phonenumber too long! Max 20 characters")]
        public string PublisherPhoneNumber { get; set; }
    }
}