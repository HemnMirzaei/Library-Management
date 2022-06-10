using Library.Core.Interfaces;
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
    public class DashboardService : IDashboard
    {
        private readonly LibDbContext _context;

        public DashboardService(LibDbContext context)
        {
            _context = context;
        }

        public List<Reservation> BooksOnLoan(int id)
        {
            return _context.Reservations.Include(b => b.Book).Where(i => i.UserId == id).ToList();

        }

        public Reservation GetReservation(int id)
        {
            return _context.Reservations.Find(id);
        }

        public LibraryUser GetUser(int id)
        {
            return _context.LibraryUsers.Find(id);
        }

        public bool IsExistId(int id)
        {
            return _context.LibraryUsers.Any(u => u.Id == id);
        }

        public void RemoveReservation(int? id)
        {
            Reservation reservation = _context.Reservations.Find(id);
            _context.Reservations.Remove(reservation);
            _context.SaveChanges();
        }
    }
}
