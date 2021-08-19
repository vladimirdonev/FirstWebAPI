using FirstWebAPI.Data;
using FirstWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FirstWebAPI.Services
{
    public class BookServise : IBookServise
    {
        private ApplicationDbContext db { get; set; }

        public BookServise(ApplicationDbContext db)
        {
            this.db = db;
        }

        public ICollection<Book> AllBooks()
        {
            return this.db.Books.ToList();
        }

        public void CreateBook(Book book)
        {
            this.db.Books.Add(book);
            this.db.SaveChanges();
        }

        public void DeleteBook(string id)
        {
            var book = this.db.Books.FirstOrDefault(x => x.Id == id);
            this.db.Remove(book);
            this.db.SaveChanges();
        }

        public void EditBook(Book book)
        {
            var bookToUpdate = this.db.Books.FirstOrDefault(x => x.Id == book.Id);
            bookToUpdate.Name = book.Name;
            this.db.Entry(bookToUpdate).State = Microsoft.EntityFrameworkCore.EntityState.Detached;
            this.db.Update(bookToUpdate);
            this.db.SaveChanges();
        }

        public Book GetBookById(string id)
        {
            return this.db.Books.FirstOrDefault(x => x.Id == id);
        }
    }
}
