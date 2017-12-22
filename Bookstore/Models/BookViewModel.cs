using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bookstore.Models
{
    public class BookViewModel

    {
        public int BookId { get; set; }
        public string BookName { get; set; }
        public DateTime DatePublished { get; set; }
        public string PublisherName { get; set; }
    }
}