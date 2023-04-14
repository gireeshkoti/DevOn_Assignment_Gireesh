using BookManagement.Services.Models;
using BookManagement.Services.Models.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BookManagement.Services
{
    public class BookManagementService : IBookManagementService
    {
        private readonly BookManagementDbContext _dbContext;
        public BookManagementService(BookManagementDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IList<BookListModel> GetBookList()
        {
            var lstBooks = _dbContext.Books.ToList();
            return lstBooks.Select(
                x => new BookListModel()
                {
                    AuthorName = x.AuthorName,
                    BookId = x.BookId,
                    ISBN = x.ISBN,
                    PublisherName = x.PublisherName,
                    Title = x.Title
                }).ToList();
        }
        public Book AddNewBook(BookCreateModel newBook)
        {
            var book = new Book()
            {
                BookId = Guid.NewGuid(),
                AuthorName = newBook.AuthorName,
                Title = newBook.Title,
                ISBN = newBook.ISBN,
                PublisherName = newBook.PublisherName
            };

            _dbContext.Books.Add(book);
            _dbContext.SaveChanges();

            return book;
        }

        public Book UpdateBook(Guid id, BookUpdateModel bookToUpdate)
        {
            var book = _dbContext.Books.Find(id);
            if (book == null)
                return null;

            book.Title = bookToUpdate.Title;
            book.PublisherName = bookToUpdate.PublisherName;
            book.ISBN = bookToUpdate.ISBN;
            book.AuthorName = bookToUpdate.AuthorName;

            _dbContext.SaveChanges();

            return book;
        }

        public Book DeleteBook(Guid id)
        {
            var book = _dbContext.Books.Find(id);
            if (book == null) 
                return null;

            _dbContext.Books.Remove(book);
            _dbContext.SaveChanges();

            return book;
        }
    }
}
