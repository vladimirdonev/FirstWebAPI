using FirstWebAPI.Models;
using System.Collections.Generic;

namespace FirstWebAPI.Services
{
    public interface IBookServise
    {

        void CreateBook(Book book);

        ICollection<Book> AllBooks();

        Book GetBookById(string id);

        void EditBook(Book book);

        void DeleteBook(string id);
    }
}
