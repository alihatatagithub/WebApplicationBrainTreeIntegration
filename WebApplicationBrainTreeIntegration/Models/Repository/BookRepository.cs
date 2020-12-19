using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationBrainTreeIntegration.Data;

namespace WebApplicationBrainTreeIntegration.Models.Repository
{

    public interface IBookRepository
    {

        IEnumerable<Book> GetBooks();
        Task<Book> GetBook(int? Bookid);

        void AddBook(Book Book);
        void UpdateBook(Book Book);
        void DeleteBook(int Bookid);

    }
    public class BookRepository :IBookRepository
    {

        private ApplicationDbContext _appDbContext;

        public BookRepository(ApplicationDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public void AddBook(Book Book)
        {
            var result = _appDbContext.Books.Add(Book);
            _appDbContext.SaveChanges();


        }


        public void DeleteBook(int Bookid)
        {
            var result = _appDbContext.Books.FirstOrDefault(e => e.Id == Bookid);

            _appDbContext.Books.Remove(result);
            _appDbContext.SaveChanges();



        }

        public async Task<Book> GetBook(int? Bookid)
        {
            return await _appDbContext.Books.FirstOrDefaultAsync(e => e.Id == Bookid);
        }

        public IEnumerable<Book> GetBooks()
        {
            return _appDbContext.Books.ToList();
        }

        public void UpdateBook(Book newBook)
        {
            var result = _appDbContext.Books.FirstOrDefault(e => e.Id == newBook.Id);

            result.Name = newBook.Name;
            result.AutherName = newBook.AutherName;
            result.Price = newBook.Price;
            _appDbContext.SaveChanges();




        }


    }
}
