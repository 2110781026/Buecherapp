using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Buecherapp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Buecherapp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : ControllerBase
    {
        private readonly ILogger<BookController> logger;
        private readonly DataContext context;

        public BookController(ILogger<BookController> logger, DataContext context)
        {
            this.logger = logger;
            this.context = context;
        }

        [HttpGet]
        public IEnumerable<Book> ListBooks()
        {
            return this.context.Books;
        }

        [HttpGet("{id}")]
        public Book GetBook(int id)
        {
            return this.context.Find<Book>(id);
        }

        [HttpGet("test")]
        public string Test()
        {
            return "asdf";
        }

        [HttpPost]
        public int CreateBook(Book book)
        {
            this.context.Add(book);
            this.context.SaveChanges();



            return book.Id;
        }

        [HttpDelete("{id}")]
        public bool DeleteBook(int id)
        {
            Book book = this.context.Find<Book>(id);
            if (book == null)
                return false;
            this.context.Remove(book);
            this.context.SaveChanges();
            return true;
        }

        
        [HttpPut("{id}")]
        public bool UpdateBook(int id, Book book){

             // look for the book in the DB and complain if not found
            Book dbBook = this.context.Find<Book>(id);  
            if (dbBook == null)
                return false;

            dbBook.Title = book.Title;
            dbBook.Author = book.Author;
            dbBook.Genre = book.Genre;
            dbBook.Rating = book.Rating;
            dbBook.IsRead = book.IsRead;
            dbBook.Owned = book.Owned;
            dbBook.CurrentlyLentTo = book.CurrentlyLentTo;
            
            this.context.SaveChanges();
            return true;
        }

    }


}
    
    

