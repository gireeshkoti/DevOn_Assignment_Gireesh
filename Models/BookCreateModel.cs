using System.ComponentModel.DataAnnotations;

namespace BookManagement.Services.Models
{
    public class BookCreateModel
    {
        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Publisher Name is required")]
        public string PublisherName { get; set; }

        [Required(ErrorMessage = "ISBN is required")]
        public string ISBN { get; set; }

        [Required(ErrorMessage = "Author Name is required")]
        public string AuthorName { get; set; }
    }

    public class BookUpdateModel
    {
        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Publisher Name is required")]
        public string PublisherName { get; set; }

        [Required(ErrorMessage = "ISBN is required")]
        public string ISBN { get; set; }

        [Required(ErrorMessage = "Author Name is required")]
        public string AuthorName { get; set; }
    }
}
