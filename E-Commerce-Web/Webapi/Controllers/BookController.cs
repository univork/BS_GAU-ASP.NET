using PMEntity;
using PMRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Webapi.Controllers
{
    public class BookController : ApiController
    {
        private BookRepository repo = new BookRepository();

        public List<Book> Get()
        {
            List<Book> books = repo.GetAll();
            return books;
        }
        public Book Get(int id)
        {

            return repo.Get(id);
        }
        
        public bool Post(Book book)
        {
            return repo.Insert(book);
        }

        public bool Put(Book book, bool warning)
        {
            return repo.Update(book, warning);
        }

        public int Delete(int id)
        {
            return repo.Delete(id);
        }
    }
}
