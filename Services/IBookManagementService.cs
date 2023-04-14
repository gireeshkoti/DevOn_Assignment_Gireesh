using System;
using System.Collections.Generic;
using BookManagement.Services.Models;
using BookManagement.Services.Models.DataModels;

namespace BookManagement.Services
{
    public interface IBookManagementService
    {
        IList<BookListModel> GetBookList();
        Book AddNewBook(BookCreateModel newBook);
        Book UpdateBook(Guid id, BookUpdateModel bookToUpdate);
        Book DeleteBook(Guid id);
    }
}
