// View Models are used to offer data to a client 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using AutoMapper;
using Buecherapp.Models;
using Buecherapp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Net.Http.Json;

namespace Buecherapp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : ControllerBase
    {
        private readonly ILogger<BookController> logger;
        private readonly DataContext context;
        private readonly IMapper mapper;
        private readonly HttpClient client;

        public BookController(ILogger<BookController> logger, DataContext context, IMapper mapper)
        {
            this.logger = logger;
            this.context = context;
            this.mapper = mapper;
            //this.client = new HttpClient { BaseAddress = new Uri("https://www.googleapis.com/books/v1") };
            this.client = new HttpClient();
        }

        [HttpGet]
        public async Task<IEnumerable<BookListViewModel>> ListBooksAsync()
        {
            var result = this.mapper.ProjectTo<BookListViewModel>(this.context.Books).ToList();
            foreach (var book in result)
            {
                book.Description = await GetGoogleDescriptionAsync(book.ISBN);
            }
            return result;
        }

        private async Task<string> GetGoogleDescriptionAsync(string isbn)
        {

            // TODO: replace Try Catch with proper Status Code handling
            try
            {
                var info = await this.client.GetFromJsonAsync<GoogleBookItems>($"https://www.googleapis.com/books/v1/volumes?q={isbn}");

                // check if we got results
                var item = info.Items.FirstOrDefault();

                return item?.VolumeInfo?.Description;
            }
            catch (HttpRequestException)
            {
                return null;
            }
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
        public bool UpdateBook(int id, BookEditViewModel book)
        {

            // look for the book in the DB and complain if not found
            Book dbBook = this.context.Find<Book>(id);
            if (dbBook == null)
                return false;

            this.mapper.Map(book, dbBook);

            this.context.SaveChanges();
            return true;
        }
    }
}



