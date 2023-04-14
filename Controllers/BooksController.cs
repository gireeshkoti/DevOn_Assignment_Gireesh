using System;
using System.Collections.Generic;
using BookManagement.CustomAttributes;
using BookManagement.Services;
using BookManagement.Services.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookManagement.Controllers
{
    [ApiKey]
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookManagementService _bookService;
        public BooksController(IBookManagementService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public IEnumerable<BookListModel> GetBooksList()
        {
            return _bookService.GetBookList();
        }

        [HttpPost]
        public IActionResult AddNewBook(BookCreateModel input)
        {
            try
            {
                var newBook = _bookService.AddNewBook(input);
                return Ok(newBook);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut("{id:guid}")]
        public IActionResult UpdateBook(Guid id, BookUpdateModel bookToUpdate)
        {
            try
            {
                if (id == Guid.Empty)
                    return BadRequest();

                var updatedBook = _bookService.UpdateBook(id, bookToUpdate);
                if (updatedBook == null)
                    return NotFound("Book not found.");
                else
                    return Ok(updatedBook);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete("{id:guid}")]
        public IActionResult DeleteBook(Guid id)
        {
            try
            {
                if (id == Guid.Empty)
                    return BadRequest();

                var deletedBook = _bookService.DeleteBook(id);
                if (deletedBook == null)
                    return NotFound("Book not found.");
                else
                    return Ok(deletedBook);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
