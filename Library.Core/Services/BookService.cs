using Library.Core.Classes;
using Library.Core.ViewModels;
using Library.Data.Context;
using Library.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.Services
{
    public class BookService : IBook
    {
        private readonly LibDbContext _context;
        public BookService(LibDbContext context)
        {
            _context = context;
        }

        public void AddNewBook(Book book)
        {
            _context.Books.Add(book);
            _context.SaveChanges();
        }

        public List<Topic> GetAllTopics()
        {
            return _context.Topics.OrderBy(t => t.Name).ToList();
        }

        public List<Book> GetAllBooks()
        {
            return _context.Books.OrderBy(b => b.Name).ToList();
        }

        public Book GetBookById (int? id)
        {
            return _context.Books.Include(t => t.Topic).FirstOrDefault(i => i.Id == id);
        }

        public void EditBook(int id,BookViewModel book)
        {
            Book bookToEdit = _context.Books.Find(id);
            bookToEdit.Name = book.Name;
            bookToEdit.Author = book.Author;
            bookToEdit.TopicId = book.TopicId;
            bookToEdit.Language = book.Language;
            bookToEdit.Pages = book.Pages;
            bookToEdit.Existing = book.Existing;
            bookToEdit.PublishYear = book.PublishYear;
            _context.SaveChanges();
        }

        public void DeleteBook(int? id)
        {
            var book = _context.Books.Find(id);
            _context.Books.Remove(book);
            _context.SaveChanges();
        }
    }
}
