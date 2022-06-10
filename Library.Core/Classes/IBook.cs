using Library.Core.ViewModels;
using Library.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.Classes
{
    public interface IBook
    {
        List<Topic> GetAllTopics();

        void AddNewBook(Book book);

        List<Book> GetAllBooks();

        Book GetBookById(int? id);

        void EditBook(int id, BookViewModel book);   

        void DeleteBook(int? id);
    }
}
