using Library.Core.Interfaces;
using Library.Data.Context;
using Library.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.Services
{
    public class ReservationService : IReservation
    {
        private readonly LibDbContext _context;
        public ReservationService(LibDbContext context)
        {
            _context = context;
        }

        public void AddNewReservation(Reservation reservation)
        {
            int Bookid = reservation.BookId;
            Book book = _context.Books.Find(Bookid);
            book.Existing -= 1;
            _context.SaveChanges();

            _context.Reservations.Add(reservation);
            _context.SaveChanges();
        }

        public List<Book> GetAllBooks()
        {
            return _context.Books.ToList();
        }

        public List<LibraryUser> GetAllUsers()
        {
            return _context.LibraryUsers.ToList();
        }
    }
}
