using System;

namespace BookManagement.Services.Models
{
    public class BookListModel
    {
        public Guid BookId { get; set; }
        public string Title { get; set; }
        public string PublisherName { get; set; }
        public string ISBN { get; set; }
        public string AuthorName { get; set; }
    }
}
